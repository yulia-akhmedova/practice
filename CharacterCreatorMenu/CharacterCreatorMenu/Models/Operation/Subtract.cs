namespace CharacterCreatorMenu.Models.Operation
{
    public class Subtract : BaseOperation
    {
        public override int Calculate(int oldValue, int points)
        {
            var newValue = oldValue - points;

            return GetValidPointsNumber(newValue);
        }
    }
}
