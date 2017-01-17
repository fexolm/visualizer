using System.IO;
using System;
using System.Collections.Generic;
using Visualizer.Parser.Interfaces;
using Visualizer.Parser.ResultTypes;


namespace Visualizer.Parser.Implementation
{
    class MoveParser : InitParser, IMoveParser
    {

        private List<string> Content;
        private int Stringnumber;

        public MoveParser()
        {
            Finished = false;
            Content = new List<string>();
            ToList();
            Stringnumber = 0;
        }

        private void ToList()
        {
            using (var strwam = new StreamReader(@"Logs.txt"))
            { 
                while (!(strwam.Peek() == -1))
                {
                    Content.Add(strwam.ReadLine());
                }
            }
        }

        public override FigureResult ParseLine()
        {
            var words = Content[Stringnumber].Split(' ', '\n');

            IDictionary<string, double[]> parameters = new Dictionary<string, double[]>();
            for (int j = 1; j < words.Length; j++)
            {
                var parse = Parse(words[j]);
                parameters.Add(parse.Command, parse.Parameters);
            }
            return new FigureResult(words[0], parameters);
        }

        public TickInfo GetTick()
        {
            List<FigureResult> resultlist = new List<FigureResult>();
            Finished = !(Stringnumber < Content.Count - 1);
            if (!Finished)
            {
                int tick = int.Parse(Content[Stringnumber].Split(' ', '\n')[0]);//номер тика всегда будет первым при входе в метод
                Stringnumber++;
                int result = 0;
                while ((Stringnumber <= Content.Count - 1) && !Int32.TryParse(Content[Stringnumber].Split(' ', '\n')[0], out result)) //проверяем, является ли строка числом
                {
                    resultlist.Add(ParseLine());
                    Stringnumber++;
                }
                Finished = !(Stringnumber < Content.Count - 1);
                return new TickInfo(tick, resultlist);
            }
            else
            {
                throw new Exception(" Файл закончился");
            }


        }
    }

}