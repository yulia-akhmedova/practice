namespace ConsoleApp.Helpers
{
    public static class Messages
    {
        public const string INTRO_MESSAGE = "Добро пожаловать в меню выбора создания персонажа!\n" +
            "У вас есть {0} очков, которые вы можете распределить по умениям\n" +
            "Нажмите любую клавишу чтобы продолжить...";
        public const string CHARACTERISTIC_REQUEST = "\nКакую характеристику вы хотите изменить: ";
        public const string OPERAND_REQUEST = "Что вы хотите сделать [+\\-]: ";
        public const string POINTS_REQUEST = "Количество поинтов которые следует {0}: ";
        public const string AGE_REQUEST = "Вы распределили все очки. Введите возраст персонажа: ";

        public static string GetPointsRequest(string operand)
        {
            var operandValue = operand == "+" ? "прибавить" : "отнять";
            return string.Format(POINTS_REQUEST, operandValue);
        }
    }
}
