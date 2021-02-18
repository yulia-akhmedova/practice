using ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Models
{
    public class Player
    {
        public int Points { get; private set; } = 25;
        public int Age { get; private set; }
        public IEnumerable<Characteristic> Characteristics { get; private set; } = new Characteristic[]
        {
            new Characteristic("Сила"),
            new Characteristic("Ловкость"),
            new Characteristic("Интеллект")
        };

        public void SetAge(int age)
        {
            Age = age;
        }

        public void ResetPoints()
        {
            Points = PointsHandler.Validate(Points);
        }

        public void CalculateCharacteristicValue(string name, int pointsToChange, string operand)
        {
            var characteristic = Characteristics.First(x => x.Name.ToLower() == name);
            var points = pointsToChange * PointsHandler.ConvertOperandToFactor(operand);

            Points += characteristic.ChangeValue(points);

            Console.ReadKey();
        }
    }
}
