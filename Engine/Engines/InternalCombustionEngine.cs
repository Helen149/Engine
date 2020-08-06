using System;
using System.Collections.Generic;
using System.Text;

namespace EngineOverheating
{
    class InternalCombustionEngine: IEngine
    {
        private int momentOfInertia;
        private TorqueVersusSpeed dependenceMV;
        private readonly double CoefficientHeatTorgue = 0.01;
        private readonly double CoefficientHeatSpeed = 0.0001;
        private readonly double CoefficientCooling = 0.1;

        private double torque;
        private double speed;
        public int SuperheatTemperature { get; }
        public double Temperature { get; private set; }

        public InternalCombustionEngine(int momentOfInertia, TorqueVersusSpeed dependenceMV, int superheatTemperature, double temperature)
        {
            this.momentOfInertia = momentOfInertia;
            this.dependenceMV = dependenceMV;
            SuperheatTemperature = superheatTemperature;
            torque = this.dependenceMV.GetTorque(speed);
            Temperature = temperature;
        }

        public void Start(int deltaTime, double temp)
        {
            var speedHeat = torque * CoefficientHeatTorgue + speed * speed * CoefficientHeatSpeed;
            var speedColling = CoefficientCooling * (temp - Temperature);
            Temperature += deltaTime * (speedHeat + speedColling);

            var acceleration = torque / momentOfInertia;
            speed += acceleration * deltaTime;
            torque = dependenceMV.GetTorque(speed);
        }
    }
}
