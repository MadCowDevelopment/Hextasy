namespace Hextasy.CardWars.AI
{
    public interface IUtilityFunction
    {
        double Calculate(CardWarsGameLogic gameLogic);
    }
}