using System;
using System.Collections.Generic;
using System.Text;

namespace Visualizer.Repo.Interseptors
{
    class EmptyInterceptor : BaseInterceptor
    {
        public EmptyInterceptor(object instance) : base(instance) { }
        protected override object Intercept(System.Reflection.MethodBase method, object[] arguments)
        {
            return method.Invoke(Instanse, arguments);
        }
    }
}
