﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Hextasy.Framework;

namespace Hextasy.Trains
{
    [Export(typeof(TrainsGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TrainsGameLogic : GameLogic<TrainsSettings, TrainsTile, TrainsStatistics>
    {
        #region Fields

        private readonly Random _random = new Random((int)DateTime.Now.Ticks);

        private bool _isPlayer1Active;

        #endregion Fields

        #region Public Properties

        public TrainsTile TileToPlace
        {
            get; private set;
        }

        #endregion Public Properties

        #region Public Methods

        public void ReplaceTile(TrainsTile oldTile, TrainsTile newTile)
        {
            oldTile.CopyExits(newTile);
            oldTile.CanBePlaced = TileCanBePlaced(oldTile);
        }

        public void SetTile(TrainsTile tileToPlace)
        {
            if (!tileToPlace.CanBePlaced) return;
            tileToPlace.IsFixed = true;
            tileToPlace.CanBePlaced = false;
            _isPlayer1Active = !_isPlayer1Active;
            InitializeTileToPlace();
            CheckForWinCondition();
        }

        #endregion Public Methods

        #region Protected Methods

        protected override TrainsTile CreateTile(int column, int row)
        {
            return Settings.SelectedMap.CreateTile(column, row);
        }

        protected override void OnSettingsInitialized()
        {
            InitializePlayerStations();
            InitializeTileToPlace();
        }

        #endregion Protected Methods

        #region Private Methods

        private void CheckForWinCondition()
        {
            var player1Win = CheckWinCondition(Owner.Player1);
            var player2Win = CheckWinCondition(Owner.Player2);

            if(player1Win || player2Win) RaiseFinished(new GameFinishedEventArgs<TrainsStatistics>(new TrainsStatistics()));
        }

        private bool CheckWinCondition(Owner owner)
        {
            var visitedTiles = new List<TrainsTile>();
            var tilesToVisit = new List<TrainsTile>();
            tilesToVisit.Add(Tiles.OfType<StationTile>().First(p => p.Owner == owner));
            do
            {
                var currentlyVisiting = new List<TrainsTile>(tilesToVisit);
                tilesToVisit.Clear();
                foreach (var tileToVisit in currentlyVisiting)
                {
                    visitedTiles.Add(tileToVisit);
                    if (visitedTiles.Count(p => p.Owner == owner) == 4)
                    {
                        return true;
                    }

                    if (tileToVisit.HasTopExit)
                    {
                        var neighbour = HexMap.GetTopNeighbour(tileToVisit);
                        if(neighbour != null && neighbour.HasBottomExit && !visitedTiles.Contains(neighbour) && !tilesToVisit.Contains(neighbour) && !currentlyVisiting.Contains(neighbour))
                            tilesToVisit.Add(neighbour);
                    }

                    if (tileToVisit.HasTopRightExit)
                    {
                        var neighbour = HexMap.GetTopRightNeighbour(tileToVisit);
                        if (neighbour != null && neighbour.HasBottomLeftExit && !visitedTiles.Contains(neighbour) && !tilesToVisit.Contains(neighbour) && !currentlyVisiting.Contains(neighbour))
                            tilesToVisit.Add(neighbour);
                    }

                    if (tileToVisit.HasBottomRightExit)
                    {
                        var neighbour = HexMap.GetBottomRightNeighbour(tileToVisit);
                        if (neighbour != null && neighbour.HasTopLeftExit && !visitedTiles.Contains(neighbour) && !tilesToVisit.Contains(neighbour) && !currentlyVisiting.Contains(neighbour))
                            tilesToVisit.Add(neighbour);
                    }

                    if (tileToVisit.HasBottomExit)
                    {
                        var neighbour = HexMap.GetBottomNeighbour(tileToVisit);
                        if (neighbour != null && neighbour.HasTopExit && !visitedTiles.Contains(neighbour) && !tilesToVisit.Contains(neighbour) && !currentlyVisiting.Contains(neighbour))
                            tilesToVisit.Add(neighbour);
                    }

                    if (tileToVisit.HasBottomLeftExit)
                    {
                        var neighbour = HexMap.GetBottomLeftNeighbour(tileToVisit);
                        if (neighbour != null && neighbour.HasTopRightExit && !visitedTiles.Contains(neighbour) && !tilesToVisit.Contains(neighbour) && !currentlyVisiting.Contains(neighbour))
                            tilesToVisit.Add(neighbour);
                    }

                    if (tileToVisit.HasTopLeftExit)
                    {
                        var neighbour = HexMap.GetTopLeftNeighbour(tileToVisit);
                        if (neighbour != null && neighbour.HasBottomRightExit && !visitedTiles.Contains(neighbour) && !tilesToVisit.Contains(neighbour) && !currentlyVisiting.Contains(neighbour))
                            tilesToVisit.Add(neighbour);
                    }
                }
            } while (tilesToVisit.Count > 0);

            return false;
        }

        private void InitializePlayerStation(List<string> stations, Owner owner)
        {
            for (var i = 0; i < 4; i++)
            {
                var indexOfNextStation = _random.Next(0, stations.Count);
                var nextStation = stations[indexOfNextStation];
                Tiles.OfType<StationTile>().Single(p => p.Name == nextStation).Owner = owner;
                stations.Remove(nextStation);
            }
        }

        private void InitializePlayerStations()
        {
            var stations = new List<string>(Settings.SelectedMap.Stations);
            InitializePlayerStation(stations, Owner.Player1);
            InitializePlayerStation(stations, Owner.Player2);
        }

        private void InitializeTileToPlace()
        {
            var bools = Enumerable.Repeat(false, 6).ToList();
            do
            {
                for (var i = 0; i < bools.Count; i++)
                {
                    bools[i] = _random.Next(0, 2) == 0;
                }
            } while (bools.Count(p => p) <= 2);
            TileToPlace = new TrainsTile(Owner.None, bools[0], bools[1], bools[2], bools[3], bools[4], bools[5]);
        }

        private bool TileCanBePlaced(TrainsTile tileToPlace)
        {
            if (tileToPlace.IsFixed) return false;

            var neighbour = HexMap.GetTopNeighbour(tileToPlace);
            if (tileToPlace.HasTopExit)
            {
                if (neighbour == null || (neighbour.IsFixed && !neighbour.HasBottomExit)) return false;
            }
            else
            {
                if (neighbour != null && neighbour.IsFixed && neighbour.HasBottomExit) return false;
            }

            neighbour = HexMap.GetTopRightNeighbour(tileToPlace);
            if (tileToPlace.HasTopRightExit)
            {
                if (neighbour == null || (neighbour.IsFixed && !neighbour.HasBottomLeftExit)) return false;
            }
            else
            {
                if (neighbour != null && neighbour.IsFixed && neighbour.HasBottomLeftExit) return false;
            }

            neighbour = HexMap.GetBottomRightNeighbour(tileToPlace);
            if (tileToPlace.HasBottomRightExit)
            {
                if (neighbour == null || (neighbour.IsFixed && !neighbour.HasTopLeftExit)) return false;
            }
            else
            {
                if (neighbour != null && neighbour.IsFixed && neighbour.HasTopLeftExit) return false;
            }

            neighbour = HexMap.GetBottomNeighbour(tileToPlace);
            if (tileToPlace.HasBottomExit)
            {
                if (neighbour == null || (neighbour.IsFixed && !neighbour.HasTopExit)) return false;
            }
            else
            {
                if (neighbour != null && neighbour.IsFixed && neighbour.HasTopExit) return false;
            }

            neighbour = HexMap.GetBottomLeftNeighbour(tileToPlace);
            if (tileToPlace.HasBottomLeftExit)
            {
                if (neighbour == null || (neighbour.IsFixed && !neighbour.HasTopRightExit)) return false;
            }
            else
            {
                if (neighbour != null && neighbour.IsFixed && neighbour.HasTopRightExit) return false;
            }

            neighbour = HexMap.GetTopLeftNeighbour(tileToPlace);
            if (tileToPlace.HasTopLeftExit)
            {
                if (neighbour == null || (neighbour.IsFixed && !neighbour.HasBottomRightExit)) return false;
            }
            else
            {
                if (neighbour != null && neighbour.IsFixed && neighbour.HasBottomRightExit) return false;
            }

            return true;
        }

        #endregion Private Methods
    }
}