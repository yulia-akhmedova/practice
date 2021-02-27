namespace CharacterCreatorMenu.Models.Operation
{
    public abstract class BaseOperation
    {
        public abstract int Calculate(int oldValue, int points);

        public int GetValidPointsNumber(int points)
        {
            const int minPoints = 0;
            const int maxPoints = 10;

            return (points < minPoints) ? minPoints : (points > maxPoints) ? maxPoints : points;
        }
    }
}
