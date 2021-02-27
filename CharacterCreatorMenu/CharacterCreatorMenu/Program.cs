using CharacterCreatorMenu.Enums;
using CharacterCreatorMenu.Extensions;
using CharacterCreatorMenu.Helpers;
using CharacterCreatorMenu.Models;

namespace CharacterCreatorMenu
{
    class Program
    {
        static void Main()
        {
            Player player = new Player();
            CharacteristicType characteristic;
            OperationType operatorSign;

            InputHelper.PrintIntro(player.Points);

            while (player.Points > 0)
            {
                InputHelper.PrintPlayerData(player);

                characteristic = InputHelper.GetEnumTypeInput<CharacteristicType>(Messages.CHARACTERISTIC_REQUEST);
                operatorSign = InputHelper.GetEnumTypeInput<OperationType>(Messages.OPERAND_REQUEST);

                var operandPoints = InputHelper.GetIntInput(Messages.GetPointsRequest(operatorSign));

                player.CalculateCharacteristicValue(characteristic, operatorSign, operandPoints);
            }

            player.SetAge(InputHelper.GetIntInput(Messages.AGE_REQUEST));

            InputHelper.PrintPlayerData(player);
        }
    }
}
