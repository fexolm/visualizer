using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Visualizer.Parser.ResultTypes
{
    class FigureResult
    {
        public readonly IDictionary<string, double[]> Parameters;

        public readonly string Name;

        public FigureResult(string name, IDictionary<string, double[]> parameters)
        {
            Parameters = parameters;
            Name = name;
        }
    }
}
