using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Visualizer.Drawing.Figures
{
    abstract class Figure : IFigure
    {
        public Graphics graphics { protected get; set; }
        public abstract void Draw();

        public abstract void Clear();

        public abstract void Init(Parser.ResultTypes.FigureResult info);
    }
}
