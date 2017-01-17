using System;
using System.Collections.Generic;
using System.Text;
using Visualizer.Drawing;

namespace Visualizer.Repo
{
    class FigureRepository
    {
        private IDictionary<string, Type> repo;

        #region Singleton
        private static FigureRepository instance;
        public static FigureRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new FigureRepository();
                return instance;
            }
        }
        private FigureRepository()
        {
            repo = new Dictionary<string, Type>();
        }
        #endregion

        public void Add(string name, Type type)
        {
            if (!repo.ContainsKey(name))
                repo.Add(name, type);
            else
                throw new Exception("Данны тип уже существует в репозитории");
        }

        public Type Get(string name)
        {
            Type type;
            if (repo.TryGetValue(name, out type))
                return type;
            else
                throw new Exception("Такого типа нет в репозитории");
        }
    }
}
