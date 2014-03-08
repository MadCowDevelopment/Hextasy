using System.Collections.Generic;
using System.Diagnostics;

namespace Hextasy.CardWars.AI
{
    internal static class AIDebugHelper
    {
        #region Public Static Methods

        public static void LogNumberOfTotalNodes(IEnumerable<Node> nodes)
        {
            var totalCount = 0;
            foreach (var node in nodes)
            {
                CountNodes(node, ref totalCount);
            }

            Debug.WriteLine("");
            Debug.WriteLine("Total nodes: {0}", totalCount);
            Debug.WriteLine("");
        }

        #endregion Public Static Methods

        #region Private Static Methods

        private static void CountNodes(Node node, ref int totalCount)
        {
            totalCount++;
            foreach (var child in node.Children)
            {
                CountNodes(child, ref totalCount);
            }
        }

        #endregion Private Static Methods
    }
}