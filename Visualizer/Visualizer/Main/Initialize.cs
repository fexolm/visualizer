using System;
using System.Collections.Generic;
using System.Text;
using Visualizer.Parser.Interfaces;
using Visualizer.Parser.ResultTypes;
using Visualizer.Repo;
using Visualizer.Repo.Interseptors;
using Visualizer.Parser.Implementation;
using Visualizer.Drawing;
using Visualizer.Drawing.Figures;

namespace Visualizer
{
    static partial class Program
    {
        static void Initialize()
        {
            #region Figure
            FigureRepository.Instance.Add("rectangle", typeof(Rectangle));
            #endregion

            #region Method
            MethodRepository.Instance.Add(ActionType.Bind, typeof(BindingRepository).GetMethod("BindFigure"));
            #endregion

            #region Instance
            Repository.Instance.Add<IBindingParser, BindingParser, EmptyInterceptor>();
            Repository.Instance.Add<IInitParser, InitParser, EmptyInterceptor>();
            Repository.Instance.Add<IMapParser, MapParser, EmptyInterceptor>();
            Repository.Instance.Add<IMoveParser, MoveParser, EmptyInterceptor>();
            Repository.Instance.Add<IFinalParser, FinalParser, EmptyInterceptor>();
            Repository.Instance.Add<IDrawer, Drawer, EmptyInterceptor>();
            #endregion
        }
    }
}
