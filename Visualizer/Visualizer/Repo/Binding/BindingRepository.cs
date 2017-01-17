using System;
using System.Collections.Generic;
using System.Text;
using Visualizer.Drawing;

namespace Visualizer.Repo
{
    class BindingRepository
    {
        private IDictionary<string, IFigure> repo;

        #region Singleton
        private static BindingRepository instance;
        public static BindingRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new BindingRepository();
                return instance;
            }
        }
        private BindingRepository()
        {
            repo = new Dictionary<string, IFigure>();
        }
        #endregion

        public IFigure GetFigure(string name)
        {
            IFigure figure;
            if (repo.TryGetValue(name, out figure))
                return figure;
            else
                throw new Exception("Фигуры с таким названием нет в репозитории");
        }

        public void BindFigure(string name, string type)
        {
            Type figureType = FigureRepository.Instance.Get(type);
            if (!repo.ContainsKey(name))
                repo.Add(name, (IFigure)Activator.CreateInstance(figureType));
            else
                throw new Exception("Фигура с таким именем уже зарегистрирована в репозитории");
        }
    }
}

