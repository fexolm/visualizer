using System;
using System.Collections.Generic;
using System.Text;

namespace Visualizer.Parser.ResultTypes
{
    class MapResult
    {
        public readonly int TermSize;

        public readonly int[][] Map;

        public MapResult(int termSize, int[][] map)
        {
            TermSize = termSize;
            Map = map;
        }
    }
}
