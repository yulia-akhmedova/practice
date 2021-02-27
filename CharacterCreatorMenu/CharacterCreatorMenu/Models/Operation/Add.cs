namespace CharacterCreatorMenu.Models.Operation
{
    public class Add : BaseOperation
    {
        public override int Calculate(int oldValue, int points)
        {
            var newValue = oldValue + points;

            return GetValidPointsNumber(newValue);
        }
    }
}
