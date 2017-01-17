using System;
using System.IO;
using Visualizer.Parser.Interfaces;
using Visualizer.Parser.ResultTypes;


namespace Visualizer.Parser.Implementation
{
    class BindingParser : IBindingParser
    {
        private StreamReader reader;
        public BindingParser()
        {
            reader = new StreamReader(@"Binding.txt");
        }
        public bool Finished
        {
            get
            {
                return (reader.Peek() == -1);
            }
        }
        private ActionType TypeDef(string[] array)
        {
            switch (array[0])
            {
                case "bind":
                    return ActionType.Bind;
                case "unbind":
                    return ActionType.Unbind;
                default:
                    throw new Exception("Данное действие не определено");
            }
        }

        public ActionResult ParseLine()
        {
            if (!Finished)
            {
                var words = reader.ReadLine().Split(' ');

                var type = TypeDef(words);

                var parameters = new object[words.Length - 2];

                for (int i = 2; i < words.Length; i++)
                {
                    parameters[i - 2] = words[i];
                }

                return new ActionResult(type, words[1], parameters);
            }
            else
                throw new Exception("Файл закончился");

        }
    }
}