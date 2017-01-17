using System;
using System.Collections.Generic;
using Visualizer.Repo.Interseptors;

namespace Visualizer.Repo
{


    class Repository
    {
        struct Connector
        {
            public Type Implementation;
            public Type Interceptor;
            public Connector(Type implementation, Type interceptor)
            {
                Implementation = implementation;
                Interceptor = interceptor;
            }
        }

        private Dictionary<Type, Connector> Repo;

        #region Singleton

        private static Repository _instance;
        private Repository()
        {
            Repo = new Dictionary<Type, Connector>();
        }

        public static Repository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Repository();
                }
                return _instance;
            }
        }
        #endregion
        public void Add<TInterface, TImplementation, TInterceptor>()
        {
            if (!Repo.ContainsKey(typeof(TInterface)))
                Repo.Add(typeof(TInterface), new Connector(typeof(TImplementation), typeof(TInterceptor)));
            else
                throw new Exception("Реализация этого интерфейса уже описана в контейнере");
        }

        public TInterface GetInstance<TInterface>()
        {
            Connector connector;
            if(Repo.TryGetValue(typeof(TInterface), out connector))
            {
                object instance = Activator.CreateInstance(connector.Implementation);
                return (TInterface)(((IInterceptor)Activator.CreateInstance(connector.Interceptor, instance)).GetTransparentProxy());
            }
            else
                throw new Exception("Не удалось найти реализацию этого интерфейса в контейнере");
        }
    }
}
