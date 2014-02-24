using System;

namespace Hextasy.Framework
{
    public static class RNG
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);

        public static int Next(int min, int max)
        {
            return Random.Next(min, max + 1);
        }

        public static bool Chance(int percent)
        {
            return Next(1, 100) <= percent;
        }
    }
}
