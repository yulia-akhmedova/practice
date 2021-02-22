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
            //can be used as name.GetDescription since it is extension
            Name = EnumHelper.GetDescription(name);
        }

        public int ChangeValue(OperationType type, int points)
        {
            var methodParameters = new object[] { Value, points };
            var oldValue = Value;

            //not clear why do you have this InvokeMethod. why not to pass not type but Operation object?
            //then there will not be any black magic with types, params etc
            //al available operatios can be stored in dictionary for example or array as done for list of characteristics
            Value = (int)ClassHelper.InvokeMethod<Operation>(type, methodParameters);

            return Value - oldValue;
        }
    }
}
