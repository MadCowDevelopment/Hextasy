using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars.Logic
{
    public abstract class PlayerAction
    {
        #region Constructors

        public PlayerAction(Owner owner)
        {
            Owner = owner;
        }

        #endregion Constructors

        #region Public Properties

        public Owner Owner
        {
            get; private set;
        }

        #endregion Public Properties
    }

    public class MulliganAction : PlayerAction
    {
        #region Constructors

        public MulliganAction(Owner owner)
            : base(owner)
        {
        }

        #endregion Constructors
    }

    public class AttackAction : PlayerAction
    {
        #region Constructors

        public AttackAction(Owner owner, MonsterCard attacker, MonsterCard defender)
            : base(owner)
        {
            Attacker = attacker;
            Defender = defender;
        }

        #endregion Constructors

        #region Public Properties

        public MonsterCard Attacker
        {
            get; private set;
        }

        public MonsterCard Defender
        {
            get; private set;
        }

        #endregion Public Properties
    }

    public class PlayMonsterCardAction : PlayerAction
    {
        #region Constructors

        public PlayMonsterCardAction(Owner owner, MonsterCard playedCard)
            : base(owner)
        {
            PlayedCard = playedCard;
        }

        #endregion Constructors

        #region Public Properties

        public MonsterCard PlayedCard
        {
            get; private set;
        }

        #endregion Public Properties
    }

    public class PlaySpellCardAction : PlayerAction
    {
        #region Constructors

        public PlaySpellCardAction(Owner owner, SpellCard playedCard)
            : base(owner)
        {
            PlayedCard = playedCard;
        }

        #endregion Constructors

        #region Public Properties

        public SpellCard PlayedCard
        {
            get; set;
        }

        #endregion Public Properties
    }
}