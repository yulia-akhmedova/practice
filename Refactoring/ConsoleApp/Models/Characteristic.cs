using ConsoleApp.Helpers;

namespace ConsoleApp.Models
{
    public class Characteristic
    {
        public string Name { get; private set; }
        public int Value { get; private set; }

        //if you avoid harcoded name - you will beed to pass Enum value here
        public Characteristic(string name)
        {
            Name = name;
        }

        public int ChangeValue(int points)
        {
            var initialValue = Value;
            var total = initialValue + points;
            var difference = 0;

            Value = PointsHandler.GetValidPointsNumber(total);
            difference = initialValue - Value;

            return difference;
        }
    }
}
