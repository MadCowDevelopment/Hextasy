﻿using System.ComponentModel.Composition;
using System.Threading;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.AI
{
    [InheritedExport(typeof(CpuPlayer))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public abstract class CpuPlayer : Player
    {
        #region Fields

        public static int DurationBetweenActions = 500;

        #endregion Fields

        #region Public Properties

        public abstract string CpuName
        {
            get;
        }

        public bool Simulated
        {
            get;
            set;
        }

        #endregion Public Properties

        #region Public Methods

        public void TakeTurn(CardWarsGameLogic cardWarsGameLogic)
        {
            OnTakeTurn(cardWarsGameLogic);
            Wait();
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract void OnTakeTurn(CardWarsGameLogic cardWarsGameLogic);

        protected void Wait()
        {
            Thread.Sleep(DurationBetweenActions);
        }

        #endregion Protected Methods
    }
}