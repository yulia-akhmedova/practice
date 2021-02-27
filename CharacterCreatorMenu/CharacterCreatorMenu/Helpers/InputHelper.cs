using CharacterCreatorMenu.Extensions;
using CharacterCreatorMenu.Models;
using System;
using System.Linq;

namespace CharacterCreatorMenu.Helpers
{
    public static class InputHelper
    {
        public static void PrintIntro(int points)
        {
            Console.WriteLine(Messages.INTRO_MESSAGE, points);
            Console.ReadKey();
        }

        public static T GetEnumTypeInput<T>(string message)
            where T : struct
        {
            var isValid = false;
            var input = string.Empty;
            var values = EnumExtensions.GetEnumArray<T>();
            T value;

            do
            {
                Console.Write(message);
                input = Console.ReadLine().ToLower();

                isValid = values.Any(x => EnumExtensions.GetDescription(x).ToLower() == input);
            }
            while (isValid == false);

            EnumExtensions.GetEnumFromDescription(input, out value);
            return value;
        }

        public static int GetIntInput(string message)
        {
            var isInputParsed = false;
            var intInput = 0;
            var stringInput = string.Empty;

            do
            {
                Console.Write(message);
                stringInput = Console.ReadLine().ToLower();

                isInputParsed = int.TryParse(stringInput, out intInput);
            }
            while (isInputParsed == false);

            return intInput;
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
            const int maxValue = 10;
            var bar = string.Empty;

            return bar.PadLeft(value, filledSymbol).PadRight(maxValue, blankSymbol);
        }
    }
}
