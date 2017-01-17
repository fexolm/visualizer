using System;
using System.Collections.Generic;
using System.Text;
using Visualizer.Parser.ResultTypes;

namespace Visualizer.Parser.Interfaces
{
    interface IMoveParser:IParser<FigureResult>
    {
        TickInfo GetTick();
    }
}
