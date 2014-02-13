﻿using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards
{
    [Export(typeof(Card))]
    public class FallenAngelCard : Card
    {
        public override string ImageSource
        {
            get { return @"Cards\Images\FallenAngel.png"; }
        }

        public override string Name
        {
            get { return "Fallen Angel"; }
        }

        public override string Description
        {
            get { return "The fallen angel will bring you down. And it will bring down your mother."; }
        }

        public override int BaseAttack
        {
            get { return 4; }
        }

        public override int BaseHealth
        {
            get { return 6; }
        }

        public override int Cost
        {
            get { return 10; }
        }
    }
}