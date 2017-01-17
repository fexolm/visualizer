using System;
using System.Collections.Generic;
using System.Text;
using Visualizer.Repo;

namespace Visualizer.Parser.ResultTypes
{
    public enum ActionType
    {
        Bind,
        Unbind
    }
    public class ActionResult
    {
        public readonly ActionType Type;

        public readonly object[] Parameters; //параметры смотри в обработчиках действий(класс MethodRepository)

        public ActionResult(ActionType type, string name, object[] parameters)
        {
            Type = type;
            Parameters = parameters; 
        }

        public void Invoke()
        {
            MethodRepository.Instance.Invoke(Type, Parameters);
        }
    }
}
