namespace Hextasy.CardWars.Logic
{
    public static class IdCreator
    {
        private static long _currentId = 0;

        public static long Next()
        {
            return _currentId++;
        }
    }
}
