using System.Collections.Generic;
using System.Linq;
using Hextasy.Framework;

namespace Hextasy.MiningBot
{
    public class MiningBotTile : HexagonTile
    {
        private readonly List<int> _imageSequence = new List<int> { 4, 6, 6, 2, 1, 5, 3 };
        private readonly List<int> _offSets = new List<int> { 0, 4, 2, 6, 4, 2, 6, 3, 2, 5, 3, 2, 5, 0, 6, 2 };

        private readonly string _backgroundImage;

        public MiningBotTile(int column, int row, SoilType soilType)
        {
            Overlays = new List<string>();

            SoilType = soilType;
            _backgroundImage = GetBackgroundImageForSoilType(SoilType);

            if (SoilType != SoilType.None)
            {
                var index = _imageSequence[(row + _offSets[column%16])%7];
                if (index > 1) _backgroundImage += index;
            }

            _backgroundImage += ".png";
        }

        public SoilType SoilType { get; private set; }

        public string BackgroundImage
        {
            get { return _backgroundImage; }
        }

        public IEnumerable<string> Overlays { get; private set; }

        public void UpdateOverlay(NeighbourInfo neighbourInfo)
        {
            var overlays = new List<string>();
            overlays.AddRange(FindOverlays(SoilType.Sand, neighbourInfo));
            overlays.AddRange(FindOverlays(SoilType.Stone, neighbourInfo));
            Overlays = overlays;
        }

        private IEnumerable<string> FindOverlays(SoilType soilType, NeighbourInfo neighbourInfo)
        {
            var overlays = new List<string>();
            if (soilType == SoilType || SoilType == SoilType.None || soilType < SoilType)
            {
                return overlays;
            }

            var baseImagePath = GetBackgroundImageForSoilType(soilType);
            if (neighbourInfo.TopNeighbour != null && neighbourInfo.TopNeighbour.SoilType == soilType)
            {
                if (neighbourInfo.TopRightNeighbour != null && neighbourInfo.TopRightNeighbour.SoilType == soilType)
                {
                    overlays.Add(baseImagePath + "-n-ne.png");
                }
                else
                {
                    overlays.Add(baseImagePath + "-n.png");
                }
            }

            if (neighbourInfo.TopRightNeighbour != null && neighbourInfo.TopRightNeighbour.SoilType == soilType)
            {
                if (neighbourInfo.BottomRightNeighbour != null && neighbourInfo.BottomRightNeighbour.SoilType == soilType)
                {
                    overlays.Add(baseImagePath + "-ne-se.png");
                }
                else
                {
                    overlays.Add(baseImagePath + "-ne.png");
                }
            }

            if (neighbourInfo.BottomRightNeighbour != null && neighbourInfo.BottomRightNeighbour.SoilType == soilType)
            {
                if (neighbourInfo.BottomNeighbour != null && neighbourInfo.BottomNeighbour.SoilType == soilType)
                {
                    overlays.Add(baseImagePath + "-se-s.png");
                }
                else
                {
                    overlays.Add(baseImagePath + "-se.png");
                }
            }

            if (neighbourInfo.BottomNeighbour != null && neighbourInfo.BottomNeighbour.SoilType == soilType)
            {
                if (neighbourInfo.BottomLeftNeighbour != null && neighbourInfo.BottomLeftNeighbour.SoilType == soilType)
                {
                    overlays.Add(baseImagePath + "-s-sw.png");
                }
                else
                {
                    overlays.Add(baseImagePath + "-s.png");
                }
            }

            if (neighbourInfo.BottomLeftNeighbour != null && neighbourInfo.BottomLeftNeighbour.SoilType == soilType)
            {
                if (neighbourInfo.TopLeftNeighbour != null && neighbourInfo.TopLeftNeighbour.SoilType == soilType)
                {
                    overlays.Add(baseImagePath + "-sw-nw.png");
                }
                else
                {
                    overlays.Add(baseImagePath + "-sw.png");
                }
            }

            if (neighbourInfo.TopLeftNeighbour != null && neighbourInfo.TopLeftNeighbour.SoilType == soilType)
            {
                if (neighbourInfo.TopNeighbour != null && neighbourInfo.TopNeighbour.SoilType == soilType)
                {
                    overlays.Add(baseImagePath + "-nw-n.png");
                }
                else
                {
                    overlays.Add(baseImagePath + "-nw.png");
                }
            }

            return overlays.Distinct();
        }

        private string GetBackgroundImageForSoilType(SoilType soilType)
        {
            const string basePath = @"pack://application:,,,/Hextasy.MiningBot;component/Images/";
            switch (soilType)
            {
                case SoilType.None:
                    return basePath + "empty";
                case SoilType.Dirt:
                    return basePath + "earthy-floor";
                case SoilType.Sand:
                    return basePath + "beach";
                case SoilType.Stone:
                    return basePath + "floor";
                default:
                    return basePath + "empty";
            }
        }
    }

    public enum SoilType
    {
        None,
        Dirt,
        Sand,
        Stone
    }
}