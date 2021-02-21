using CharacterCreatorMenu.Enums;
using EnumDescription;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterCreatorMenu.Models
{
    public class Player
    {
        public int Points { get; private set; }
        public int Age { get; private set; }
        public IEnumerable<Characteristic> Characteristics { get; private set; }

        public Player()
        {
            Points = 25;
            Characteristics = new Characteristic[]
            {
                new Characteristic(CharacteristicType.Strength),
                new Characteristic(CharacteristicType.Agility),
                new Characteristic(CharacteristicType.Intelligence)
            };
        }

        public void SetAge(int age)
        {
            Age = age;
        }

        public int SetPoints(int pointsToApply)
        {
            if (Points < pointsToApply)
            {
                return Points;
            }
            return pointsToApply;
        }

        public void ResetPoints()
        {
            if (Points < 0)
            {
                Points = 0;
            }
        }

        public void CalculateCharacteristicValue(string name, int points, string operand)
        {
            var characteristic = Characteristics.FirstOrDefault(x => x.Name.ToLower() == name);

            if (characteristic != null)
            {
                var operationTypes = (OperationType[])Enum.GetValues(typeof(OperationType));
                var operationType = operationTypes.First(x => EnumHelper.GetDescription(x) == operand);
                var pointsToApply = SetPoints(points);

                Points -= characteristic.ChangeValue(operationType, pointsToApply);

                ResetPoints();
            }
        }
    }
}
