using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Visualizer.Parser.ResultTypes;

namespace Visualizer.Repo
{
    class MethodRepository
    {
        private IDictionary<ActionType, MethodInfo> repo;

        #region Singletone

        private static MethodRepository instance;

        public static MethodRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new MethodRepository();
                return instance;
            }
        }

        private MethodRepository()
        {
            repo = new Dictionary<ActionType, MethodInfo>();
        }
        #endregion

        public void Add(ActionType type, MethodInfo method)
        {
            if (!repo.ContainsKey(type))
                repo.Add(type, method);
            else
                throw new Exception("Метод с таким типом уже зарегистрирован в репозитории");
        }

        public void Invoke(ActionType type, object[] parameters)
        {
            MethodInfo method;
            if (repo.TryGetValue(type, out method))
                method.Invoke(BindingRepository.Instance, parameters);
            else
                throw new Exception("Этого типа нет в репозитории");
        }

    }
}
