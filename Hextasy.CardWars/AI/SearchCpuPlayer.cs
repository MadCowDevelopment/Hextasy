using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hextasy.CardWars.Cards;

namespace Hextasy.CardWars.AI
{
    public class SearchCpuPlayer : CpuPlayer
    {
        public override string CpuName
        {
            get { return "Search"; }
        }

        protected override void OnTakeTurn(CardWarsGameLogic cardWarsGameLogic)
        {
            var copy = cardWarsGameLogic.DeepCopy();


        }
    }
}
