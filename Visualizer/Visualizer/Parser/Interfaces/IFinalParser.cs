using System;
using System.Collections.Generic;
using System.Text;
using Visualizer.Parser.ResultTypes;

namespace Visualizer.Parser.Interfaces
{
    interface IFinalParser
    {
        List<TickInfo> Ticks { get; }

        MapResult Map { get; }

        List<TickInfo> GetTicks();
    }
}
