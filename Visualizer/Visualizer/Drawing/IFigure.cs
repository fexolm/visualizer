using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Visualizer.Parser.ResultTypes;

namespace Visualizer.Drawing
{
    interface IFigure
    {
        Graphics graphics { set; }
        void Draw();//Рисует фигуру
        void Clear();//Стирает фигуру
        void Init(FigureResult info);
    }
}
