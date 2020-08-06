using System;

namespace EngineOverheating
{
    class Program
    {
        static void Main(string[] args)
        {
            var ambientTemperature = GetUserTemperature();
            var dependenceMV = new TorqueVersusSpeed(new double[] { 20, 75, 100, 105, 75, 0 }, new double[] { 0, 75, 150, 200, 250, 300 });
            var engine = new InternalCombustionEngine(10, dependenceMV, 110, ambientTemperature);
            var stand = new OverheatingTestStand(engine, ambientTemperature);
            SetResultTime(stand);
        }

        public static double GetUserTemperature()
        {
            Console.WriteLine("Для проведения теста введите температуру окружающей среды в °С:");
            var userInput = Console.ReadLine();
            double result;

            while(!Double.TryParse(userInput,out result))
            {
                Console.WriteLine("Получены некорректные данные. Введите температуру окружающей среды в °С:");
                userInput = Console.ReadLine();
            }

            return result;
        }

        public static void SetResultTime(OverheatingTestStand stand)
        {
            var time = stand.Run();
            if(time>= stand.maxTestTime)
                Console.WriteLine("За время проведения теста температура перегрева не была достигнута.");
            else
                Console.WriteLine($"Температура перегрева будет достигнута в течение {time} с");
        }
    }
}
