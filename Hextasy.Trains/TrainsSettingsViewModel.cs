﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Hextasy.Framework;

namespace Hextasy.Trains
{
    [Export(typeof(TrainsSettingsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TrainsSettingsViewModel : SettingsViewModel<TrainsSettings>
    {
        #region Constructors

        [ImportingConstructor]
        public TrainsSettingsViewModel([ImportMany]IEnumerable<IMap> maps)
        {
            Maps = maps;
            SelectedMap = Maps.FirstOrDefault();

            Player1 = "Player 1";
            Player2 = "Player 2";
        }

        #endregion Constructors

        #region Public Properties

        public IEnumerable<IMap> Maps
        {
            get; set;
        }

        public string Player1
        {
            get;
            set;
        }

        public string Player2
        {
            get;
            set;
        }

        public IMap SelectedMap
        {
            get; set;
        }

        public override TrainsSettings Settings
        {
            get { return new TrainsSettings(Player1, Player2, SelectedMap); }
        }

        #endregion Public Properties
    }
}