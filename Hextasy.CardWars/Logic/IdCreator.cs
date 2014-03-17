namespace Hextasy.CardWars.Logic
{
    public static class IdCreator
    {
        #region Fields

        private static long _currentId = 0;

        #endregion Fields

        #region Public Static Methods

        public static long Next()
        {
            return _currentId++;
        }

        #endregion Public Static Methods
    }
}