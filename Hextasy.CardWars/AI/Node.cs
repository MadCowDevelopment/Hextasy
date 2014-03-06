using System.Collections.Generic;
using System.Linq;

namespace Hextasy.CardWars.AI
{
    internal class Node
    {
        public PlayerAction PlayerAction { get; private set; }

        public Node(PlayerAction playerAction)
        {
            PlayerAction = playerAction;
            Children = new List<Node>();
        }

        public double Value { get; set; }

        public List<Node> Children { get; private set; }

        public double BranchValue
        {
            get { return Children.Count > 0 ? Children.Max(p => p.BranchValue) : Value; }
        }
    }
}