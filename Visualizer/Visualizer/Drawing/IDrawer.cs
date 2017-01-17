using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Visualizer.Parser.ResultTypes;

namespace Visualizer.Drawing
{
    interface IDrawer
    {
        Graphics graphics { set; }
        void Initialize(List<TickInfo> tickInfo);
        void DrawTick(int number);
        bool Finished { get; }
        void DrawMap(MapResult map);
    }
}
