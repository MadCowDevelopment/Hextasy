using System.Collections.Generic;
using System.Linq;

namespace Hextasy.CardWars.AI
{
    internal class Node
    {
        #region Constructors

        public Node(CpuPlayerCommand playerAction)
        {
            PlayerAction = playerAction;
            Children = new List<Node>();
        }

        #endregion Constructors

        #region Public Properties

        public double BranchValue
        {
            get { return Children.Count > 0 ? Children.Max(p => p.BranchValue) : Value; }
        }

        public List<Node> Children
        {
            get; private set;
        }

        public CpuPlayerCommand PlayerAction
        {
            get; private set;
        }

        public double Value
        {
            get; set;
        }

        #endregion Public Properties
    }
}