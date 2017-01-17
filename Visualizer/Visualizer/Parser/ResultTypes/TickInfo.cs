using System;
using System.Collections.Generic;
using System.Text;

namespace Visualizer.Parser.ResultTypes
{
    class TickInfo
    {
        public readonly int Tick;

        public readonly List<FigureResult> Movement;

        public TickInfo(int tick, List<FigureResult> movement)
        {
            Tick = tick;
            Movement = movement;
        }
    }
}
