using System;
using System.Collections.Generic;
using System.Text;

namespace Visualizer.Parser.Interfaces
{
    interface IParser<ResultType>
    {
        ResultType ParseLine();

        bool Finished { get; }
    }
}
