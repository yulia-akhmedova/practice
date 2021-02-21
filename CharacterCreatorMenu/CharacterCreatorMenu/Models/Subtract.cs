using CharacterCreatorMenu.Attributes;

namespace CharacterCreatorMenu.Models
{
    public class Subtract : Operation
    {
        [MethodToInvoke]
        public override int Calculate(int oldValue, int points)
        {
            var newValue = oldValue - points;

            return GetValidPointsNumber(newValue);
        }
    }
}
