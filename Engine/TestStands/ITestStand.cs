using System;
using System.Collections.Generic;
using System.Text;

namespace EngineOverheating
{
    public interface ITestStand
    {
        IEngine Engine { get; }
        int Run();
    }
}
