using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineOverheating
{
    class TorqueVersusSpeed
    {
        private Dictionary<double, double> DependenceMV;

        public TorqueVersusSpeed(double[] torques, double[] speeds)
        {
            if (torques.Length != speeds.Length)
                throw new ArgumentException("Количество элементов зависимости для крутящего момента и скорости не совпадают.");

            DependenceMV = new Dictionary<double, double>();
            for (int i = 0; i < torques.Length; i++)
                DependenceMV.Add(speeds[i], torques[i]);
        }

        public double GetTorque(double speed)
        {
            if (DependenceMV.ContainsKey(speed))
                return DependenceMV[speed];

            var point1 = DependenceMV.Last(u => u.Key <= speed);
            var point2 = DependenceMV.First(u => u.Key >= speed);
 
            return point1.Value + (point2.Value - point1.Value) / (point2.Key - point1.Key) * (speed - point1.Key);
        }
    }
}
