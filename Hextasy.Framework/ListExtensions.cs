using System.Collections.Generic;

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

        #endregion Public Static Methods
    }
}