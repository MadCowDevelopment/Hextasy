using System;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Summoned
{
    public class BabyDragonCard : DragonCard
    {
        #region Fields

        private readonly DragonFlight _dragonFlight;
        private readonly Gender _gender;

        #endregion Fields

        #region Constructors

        public BabyDragonCard(DragonFlight dragonFlight, Gender gender)
        {
            _dragonFlight = dragonFlight;
            _gender = gender;

            Traits.Add(new DragonGrowthTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override int Cost
        {
            get { return 0; }
        }

        public override string Description
        {
            get { return "Just wait until I grow up..."; }
        }

        public override DragonFlight DragonFlight
        {
            get { return _dragonFlight; }
        }

        public override Gender Gender
        {
            get { return _gender; }
        }

        public override string Name
        {
            get { return string.Format("{0} {1} Baby Dragon", Gender, DragonFlight); }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get
            {
                switch (DragonFlight)
                {
                    case DragonFlight.Red:
                        return "DragonBabyRed.png";
                    case DragonFlight.Black:
                        return "DragonBabyBlack.png";
                    case DragonFlight.Blue:
                        return "DragonBabyBlue.png";
                    case DragonFlight.Gold:
                        return "DragonBabyGold.png";
                    case DragonFlight.Green:
                        return "DragonBabyGreen.png";
                    default:
                        throw new InvalidOperationException("This dragonflight does not have a image resource.");
                }
            }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new BabyDragonCard(DragonFlight, Gender);
        }

        #endregion Protected Methods
    }
}