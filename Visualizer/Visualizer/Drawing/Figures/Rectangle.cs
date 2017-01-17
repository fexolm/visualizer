using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Visualizer.Parser.ResultTypes;
using System.Drawing;

namespace Visualizer.Drawing.Figures
{
    class Rectangle : Figure
    {
        private double[] Position;
        private double[] Size;
        private Color FigureColor;

        public override void Clear()
        {
            Draw(Color.White);
        }

        public override void Draw()
        {
            Draw(FigureColor);
        }

        private void Draw(Color color)
        {
            Pen pen = new Pen(color, 2);
            graphics.DrawRectangle(pen, Convert.ToInt32(Position[0]), Convert.ToInt32(Position[1]), Convert.ToInt32(Size[0]), Convert.ToInt32(Size[1]));
        }

        public override void Init(FigureResult info)
        {
            if (!info.Parameters.TryGetValue("pos", out Position))
                throw new Exception("Координаты фигуры не заданы");

            if (!info.Parameters.TryGetValue("size", out Size))
                throw new Exception("Размеры фигуры не заданы");

            double[] color;
            if (!info.Parameters.TryGetValue("color", out color))
                throw new Exception("Цвет фигуры не задан");
            FigureColor = Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2]));
        }
    }
}
