using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Visualizer.Parser.ResultTypes;
using Visualizer.Repo;

namespace Visualizer.Drawing
{
    class Drawer:IDrawer
    {
        public Graphics graphics { set; private get; }
        private List<TickInfo> tickInfo;
        private int lastNumber;
        public void Initialize(List<TickInfo> tickInfo)
        {
            Finished = false;
            lastNumber = 0;
            this.tickInfo = tickInfo;
        }

        public void DrawTick(int number)
        {
            try
            {
                Clean(lastNumber);
                var movements = tickInfo[number].Movement;
                foreach (var movement in movements)
                {
                    var figure = BindingRepository.Instance.GetFigure(movement.Name);
                    figure.graphics = graphics;
                    figure.Init(movement);
                    figure.Draw();
                }
            }
            catch
            {
                Finished = true;
            }
        }
        private void Clean(int number)
        {
            if(number >=0)
            {
                var movements = tickInfo[number].Movement;
                foreach (var movement in movements)
                {
                    var figure = BindingRepository.Instance.GetFigure(movement.Name);
                    figure.graphics = graphics;
                    figure.Clear();
                }
            }
        }
        public bool Finished
        {
            get;
            private set;
        }

        public void DrawMap(Parser.ResultTypes.MapResult map)
        {
        }
    }
}
