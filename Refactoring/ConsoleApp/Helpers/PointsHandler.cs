namespace ConsoleApp.Helpers
{
    public static class PointsHandler
    {
        public static int ConvertOperandToFactor(string operand)
        {
            return operand == "+" ? 1 : -1;
        }

        public static int GetValidPointsNumber(int points)
        {
            var minPoints = 0;
            var maxPoints = 10;

            return (points < minPoints) ? minPoints : (points > maxPoints) ? maxPoints : points;
        }

        public static int Validate(int points)
        {
            return points < 0 ? 0 : points;
        }
    }
}
