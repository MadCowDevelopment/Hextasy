using Hextasy.CardWars.Cards.Specials;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class CpuPlayer : Player
    {
        public CpuPlayer(string name, Owner owner, KingCard kingCard, Deck deck)
            : base(name, owner, kingCard, deck)
        {
        }
    }
}
