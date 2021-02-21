using CharacterCreatorMenu.Enums;
using CharacterCreatorMenu.Helpers;
using EnumDescription;

namespace CharacterCreatorMenu.Models
{
    public class Characteristic
    {
        public string Name { get; private set; }
        public int Value { get; private set; }

        public Characteristic(CharacteristicType name)
        {
            Name = EnumHelper.GetDescription(name);
        }

        public int ChangeValue(OperationType type, int points)
        {
            var methodParameters = new object[] { Value, points };
            var oldValue = Value;

            Value = (int)ClassHelper.InvokeMethod<Operation>(type, methodParameters);

            return Value - oldValue;
        }
    }
}
