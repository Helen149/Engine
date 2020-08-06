using System;
using System.Collections.Generic;
using System.Text;

namespace EngineOverheating
{
    class OverheatingTestStand : ITestStand
    {
        public IEngine Engine { get; }
        public readonly int maxTestTime = 86400;
        private double ambientTemperature;
        private int deltaTime = 1;

        public OverheatingTestStand(IEngine engine, double temperature)
        {
            Engine = engine;
            ambientTemperature = temperature;
        }

        public int Run()
        {
            var time = 0;
            for(; Engine.Temperature < Engine.SuperheatTemperature && time<maxTestTime; time+=deltaTime)
                Engine.Start(deltaTime, ambientTemperature);
            
            return time;
        }
    }
}
