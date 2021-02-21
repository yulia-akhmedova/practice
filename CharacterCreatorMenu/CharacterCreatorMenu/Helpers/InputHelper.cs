using CharacterCreatorMenu.Models;
using EnumDescription;
using System;
using System.Linq;

namespace CharacterCreatorMenu.Helpers
{
    public static class InputHelper
    {
        public static void PrintIntro(int points)
        {
            Console.WriteLine(string.Format(Messages.INTRO_MESSAGE, points));
            Console.ReadKey();
        }

        public static string GetStringInput<T>(string message)
            where T : struct, IConvertible
        {
            var isValid = false;
            var values = (T[])Enum.GetValues(typeof(T));
            var value = string.Empty;

            while (isValid == false)
            {
                Console.Write(message);
                value = Console.ReadLine().ToLower();

                isValid = values.Any(x => EnumHelper.GetDescription(x).ToLower() == value);
            }
            return value;
        }

        public static int GetIntInput(string message)
        {
            var isInputParsed = false;
            var intInput = 0;
            var stringInput = string.Empty;

            while (isInputParsed == false)
            {
                Console.Write(message);
                stringInput = Console.ReadLine().ToLower();

                isInputParsed = int.TryParse(stringInput, out intInput);
            }

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
