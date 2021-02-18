using ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Models
{
    public class Player
    {
        //why 25 is hardcoded? may be pass value via constructor to follow DI?
        public int Points { get; private set; } = 25;
        public int Age { get; private set; }

        //interesting, but I would still prefer enums
        //I understand that names are in russian, but you can handle it by writing custom extensions
        //for instance you can use Description attribute for Enum values
        //there you will hold Russian names which you will use to compare user input
        //and you will need to create enum extension to get value from description
        //here is example https://blog.hildenco.com/2018/07/getting-enum-descriptions-using-c.html
        //enums can be easily converted to arrays: (T[])Enum.GetValues(typeof(T)) where T is enum type
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
            //may throw exception if characteristic name will not match
            var characteristic = Characteristics.First(x => x.Name.ToLower() == name);
            var points = pointsToChange * PointsHandler.ConvertOperandToFactor(operand);

            Points += characteristic.ChangeValue(points);

            //are you sure you need console reference in the class?
            Console.ReadKey();
        }
    }
}
