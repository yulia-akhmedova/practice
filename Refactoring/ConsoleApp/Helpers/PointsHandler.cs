namespace ConsoleApp.Helpers
{
    public static class PointsHandler
    {
        //I would suggest to get reed of this static class and methods
        //instead you can use Visitor pattern
        //create separate classes for operation (add, subtract)
        //Characteristic will have a method which will accept type of Operation (operation will be either interface or abstract class)
        //that class will does actuall job by adding or subtracting
        //peration types - store in Enums
        public static int ConvertOperandToFactor(string operand)
        {
            return operand == "+" ? 1 : -1;
        }

        public static int GetValidPointsNumber(int points)
        {
            //const int
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
