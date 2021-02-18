using ConsoleApp.Models;
using System;

namespace ConsoleApp.Helpers
{
    //input handler? input helper?
    public static class ConsoleHandler
    {
        public static void PrintIntro(int points)
        {
            Console.WriteLine(string.Format(Messages.INTRO_MESSAGE, points));
            Console.ReadKey();
        }

        //well, input must be validated
        //the only way to validate in the console app is to use endless loop
        //i.e. ask to input value untill input is valid
        //ask to input characteristics name until user inputs one which is in defined Enum
        public static string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine().ToLower();
        }

        public static void PrintPlayerData(Player player)
        {
            Console.Clear();

            Console.WriteLine($"Поинты - {player.Points}");

            Console.WriteLine($"Возраст - {player.Age}\n");

            foreach (var characteristic in player.Characteristics)
            {
                Console.WriteLine($"{characteristic.Name} - [{DrawBar(characteristic.Value)}]");
            }

            Console.ReadKey();
        }

        static string DrawBar(int value, char filledSymbol = '#', char blankSymbol = ' ')
        {
            var bar = string.Empty;
            //const int maxValue
            var maxValue = 10;

            return bar.PadLeft(value, filledSymbol).PadRight(maxValue, blankSymbol);
        }

        //parse GetIntInput would sound better
        public static int ParseUserInput(string message)
        {
            var isInputParsed = false;
            var parsedInput = 0;

            while (isInputParsed == false)
            {
                var userInput = GetUserInput(message);
                isInputParsed = int.TryParse(userInput, out parsedInput);
            }

            return parsedInput;
        }
    }
}
