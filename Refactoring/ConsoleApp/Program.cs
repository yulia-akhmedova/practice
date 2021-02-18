using ConsoleApp.Helpers;
using ConsoleApp.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var player = new Player();

            var characteristic = string.Empty;
            var operand = string.Empty;
            var operation = 0;

            ConsoleHandler.PrintIntro(player.Points);
            //just to test
            while (player.Points > 0)
            {
                ConsoleHandler.PrintPlayerData(player);

                characteristic = ConsoleHandler.GetUserInput(Messages.CHARACTERISTIC_REQUEST);
                operand = ConsoleHandler.GetUserInput(Messages.OPERAND_REQUEST);
                operation = ConsoleHandler.ParseUserInput(Messages.GetPointsRequest(operand));

                player.CalculateCharacteristicValue(characteristic, operation, operand);
            }
            
            player.SetAge(ConsoleHandler.ParseUserInput(Messages.AGE_REQUEST));
            player.ResetPoints();

            ConsoleHandler.PrintPlayerData(player);
        }
    }
}
