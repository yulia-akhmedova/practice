using CharacterCreatorMenu.Enums;
using CharacterCreatorMenu.Extensions;

namespace CharacterCreatorMenu.Models
{
    public class Characteristic
    {
        public string Name { get; private set; }
        public int Value { get; private set; }

        public Characteristic(CharacteristicType name)
        {
            Name = name.GetDescription();
        }

        public int ChangeValue(OperationType type, int points)
        {
            var oldValue = Value;
            var operations = new Operations();
            var operation = operations.GetOperation(type);

            Value = operation.Calculate(Value, points);

            return Value - oldValue;
        }
    }
}
