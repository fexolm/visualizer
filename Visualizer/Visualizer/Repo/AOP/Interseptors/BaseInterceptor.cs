using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace Visualizer.Repo.Interseptors
{
    abstract class BaseInterceptor : RealProxy, IRemotingTypeInfo, IInterceptor
    {
        protected object Instanse;
        public BaseInterceptor(object instanse)
            : base(typeof(MarshalByRefObject))
        {
            Instanse = instanse;
        }

        protected abstract object Intercept(MethodBase method, object[] arguments);
        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage methodMessage = (IMethodCallMessage)msg;
            MethodBase method = methodMessage.MethodBase;
            object[] arguments = methodMessage.Args;
            object returnValue = Intercept(method, arguments);
            Debug.WriteLine(returnValue);
            return new ReturnMessage(returnValue, methodMessage.Args, methodMessage.ArgCount, methodMessage.LogicalCallContext, methodMessage);
        }
        #region IRemotingTypeInfo
        public bool CanCastTo(Type fromType, object o)
        {
            return true;
        }

        public string TypeName
        {
            get;
            set;
        }
        #endregion
    }
}
