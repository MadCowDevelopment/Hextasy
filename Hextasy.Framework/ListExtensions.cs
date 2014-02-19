using System.Collections.Generic;
using System.Linq;

namespace Hextasy.Framework
{
    public static class ListExtensions
    {
        #region Public Static Methods

        public static void AddNotNull<T>(this IList<T> enumerable, T objToAdd)
            where T : class
        {
            if (objToAdd != null)
            {
                enumerable.Add(objToAdd);
            }
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            var result = new List<T>(enumerable);
            if (result.Count <= 1) return result;

            for (var i = 0; i < result.Count; i++)
            {
                var card = result[i];
                result.RemoveAt(i);
                result.Insert(RNG.Next(0, result.Count - 1), card);
            }

            return result;
        }

        public static T RandomOrDefault<T>(this IEnumerable<T> enumerable)
        {
            var temp = enumerable.ToList();
            if (temp.Count == 0) return default(T);
            return temp[RNG.Next(0, temp.Count - 1)];
        }

        public static IEnumerable<O> TakeAndRemove<T, O>(this IList<T> list, int amount) where O : T
        {
            var takenCards = list.OfType<O>().Take(amount).ToList();
            takenCards.ForEach(card => list.Remove(card));
            return takenCards;
        }

        public static IEnumerable<O> TakeAndRemove<T, O>(this IList<T> list) where O : T
        {
            var takenCards = list.OfType<O>().ToList();
            takenCards.ForEach(card => list.Remove(card));
            return takenCards;
        }

        #endregion Public Static Methods
    }
}