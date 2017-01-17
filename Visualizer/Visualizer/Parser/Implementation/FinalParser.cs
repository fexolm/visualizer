using System.Collections.Generic;
using Visualizer.Parser.Interfaces;
using Visualizer.Parser.ResultTypes;
using Visualizer.Repo;

namespace Visualizer.Parser.Implementation
{
    class FinalParser:IFinalParser
    {
        public List<TickInfo> Ticks
        {
            get;
            private set;
        }

        public List<TickInfo> GetTicks()
        {
            return Ticks;
        }

        public MapResult Map
        {
            get;
            private set;
        }

        private readonly IBindingParser _bindingParser;
        private readonly IInitParser _initParser;
        private readonly IMoveParser _moveParser;
        private readonly IMapParser _mapParser;

        public FinalParser()
        {
            Ticks = new List<TickInfo>();
            _bindingParser = Repository.Instance.GetInstance<IBindingParser>();
            _initParser = Repository.Instance.GetInstance<IInitParser>();
            _moveParser = Repository.Instance.GetInstance<IMoveParser>();
            _mapParser = Repository.Instance.GetInstance<IMapParser>();
            Init();
            
        }

        private void Init()
        {
            while(!_bindingParser.Finished)
            {
                var action = _bindingParser.ParseLine();
                action.Invoke();
            }
            while(!_initParser.Finished)
            {
                var info = _initParser.ParseLine();
                BindingRepository.Instance.GetFigure(info.Name).Init(info);
            }
            bool l = !_moveParser.Finished;
            while(!_moveParser.Finished)
            {
                Ticks.Add(_moveParser.GetTick());
            }
            Map = _mapParser.GetMap();
        }

    }
}
