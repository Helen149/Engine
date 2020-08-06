using System;
using System.Collections.Generic;
using System.Text;

namespace EngineOverheating
{
    public interface IEngine
    {
        int SuperheatTemperature { get; }
        double Temperature { get; }
        void Start(int deltaTime, double ambientTemperature);
    }
}
