using CharacterCreatorMenu.Enums;
using CharacterCreatorMenu.Helpers;
using CharacterCreatorMenu.Models;

namespace CharacterCreatorMenu
{
    class Program
    {
        static void Main()
        {
            var player = new Player();
            var characteristic = string.Empty;
            var operand = string.Empty;
            var operation = 0; //this is not quite operation, but points to add or subtract

            InputHelper.PrintIntro(player.Points);

            while (player.Points > 0)
            {
                InputHelper.PrintPlayerData(player);

                characteristic = InputHelper.GetStringInput<CharacteristicType>(Messages.CHARACTERISTIC_REQUEST);
                operand = InputHelper.GetStringInput<OperationType>(Messages.OPERAND_REQUEST);
                operation = InputHelper.GetIntInput(Messages.GetPointsRequest(operand));

                player.CalculateCharacteristicValue(characteristic, operation, operand);
            }

            player.SetAge(InputHelper.GetIntInput(Messages.AGE_REQUEST));

            InputHelper.PrintPlayerData(player);
        }
    }
}
