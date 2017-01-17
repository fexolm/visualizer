using System;
using System.IO;
using System.Collections.Generic;
using Visualizer.Parser.Interfaces;
using Visualizer.Parser.ResultTypes;


namespace Visualizer.Parser.Implementation
{
    class InitParser : IInitParser
    {
        public struct ParseResult
        {
            public readonly double[] Parameters;

            public readonly string Command;

            public ParseResult(double[] parameters, string command)
            {
                Parameters = parameters;
                Command = command;
            }
        }

        public InitParser()
        {
            showed = 0;
            Finished = false;
        }
        public bool Finished
        {
            get;
            protected set;
        }

        private double[] GetDoubleValues(string[] parameters)
        {
            double[] result = new double[parameters.Length];
            for (int i = 0, n = parameters.Length; i < n; i++)
                result[i] = double.Parse(parameters[i]);
            return result;
        }
        public ParseResult Parse(string str)
        {
            string[] splitted = str.Split(':');
            splitted[1] = splitted[1].Trim(')', '(');
            var coords = splitted[1].Split(';');
            return new ParseResult(GetDoubleValues(coords), splitted[0]);
        }
        private IList<FigureResult> figures;
        private IList<FigureResult> GetFigures()
        {
            if (figures == null)
            {
                figures = new List<FigureResult>();
                using (var strwam = new StreamReader(@"Init.txt"))
                {
                    while (!(strwam.Peek() == -1))
                    {
                        var words = strwam.ReadLine().Split(' '); // pos:(3;4) size:(5;6)
                        //words[0] - объект действия
                        IDictionary<string, double[]> parameters = new Dictionary<string, double[]>();
                        for (int i = 1; i < words.Length; i++)
                        {

                            var parse = Parse(words[i]);
                            parameters.Add(parse.Command, parse.Parameters);
                        }
                        Finished = strwam.Peek() == -1;
                        figures.Add(new FigureResult(words[0], parameters));
                    }
                }
            }
            return figures;
        }
        private int showed;
        public virtual FigureResult ParseLine()
        {
            Finished = showed == GetFigures().Count;
            if (!Finished)
            {
                Finished = showed == GetFigures().Count - 1;
                return GetFigures()[showed++];
            }
            else
                throw new StackOverflowException();
        }
    }
}