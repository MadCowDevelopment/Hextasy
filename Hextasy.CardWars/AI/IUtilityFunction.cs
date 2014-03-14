using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.AI
{
    public interface IUtilityFunction
    {
        #region Methods

        double Calculate(CardWarsGameLogic gameLogic);

        #endregion Methods
    }
}