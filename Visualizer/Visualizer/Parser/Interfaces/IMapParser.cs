using System;
using System.Collections.Generic;
using System.Text;
using Visualizer.Parser.ResultTypes;

namespace Visualizer.Parser.Interfaces
{
    interface IMapParser:IParser<MapResult>
    {
        MapResult GetMap();
    }
}
