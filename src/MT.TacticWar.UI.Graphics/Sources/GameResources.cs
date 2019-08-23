using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Base.Objects;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI.Graphics
{
    static class GameResources
    {
        public static Image GetCrossImage()
        {
            var src = @"images\features\cross.png";
            return Image.FromFile(src);
        }

        public static Image GetFlagImage(MoveType moveType)
        {
            string src = GetFlagImagePath(moveType);
            return Image.FromFile(src);
        }

        private static string GetFlagImagePath(MoveType moveType)
        {
            var path = @"images\flags\";
            switch (moveType)
            {
                case MoveType.Join:
                    return $"{path}join.png";
                case MoveType.Attack:
                    return $"{path}attack.png";
                case MoveType.Defend:
                    return $"{path}defend.png";
                case MoveType.Capture:
                    return $"{path}capture.png";
                case MoveType.Go:
                    return $"{path}flag.png";
            }

            throw new Exception("Неизвестный тип флага.");
        }

        public static Image GetDivisionImage(Division division)
        {
            var src = GetDivisionImagePath(division);
            return Image.FromFile(src);
        }

        public static Image GetBuildingImage(Building building)
        {
            var src = GetBuildingImagePath(building);
            return Image.FromFile(src);
        }

        public static Image GetBuildingDefendImage()
        {
            var src = @"images\features\defend.png";
            return Image.FromFile(src);
        }

        private static string GetDivisionImagePath(Division division)
        {
            var path = @"images\divisions\";
            if (division is Infantry)
                return $"{path}human.png";
            else if (division is Vehicle)
                return $"{path}tank.png";
            else if (division is Ship)
                return $"{path}ship.png";
            else if (division is Navy)
                return $"{path}navy.png";
            else if (division is Artillery)
                return $"{path}artillery.png";
            else if (division is Aviation)
                return $"{path}plane.png";
            else if (division is Engineers)
                return $"{path}engineers.png";
            else if (division is Train)
                return $"{path}train.png";

            throw new Exception("Неизвестный тип подразделения.");
        }

        private static string GetBuildingImagePath(Building building)
        {
            var path = @"images\buildings\";
            if (building is Barracks)
                return $"{path}barracks.png";
            else if (building is Storehouse)
                return $"{path}storehouse.png";
            else if (building is Factory)
                return $"{path}factory.png";
            else if (building is Radar)
                return $"{path}radar.png";
            else if (building is Airfield)
                return $"{path}airfield.png";
            else if (building is Port)
                return $"{path}port.png";
            else if (building is Shipyard)
                return $"{path}shipyard.png";

            else if (building is CityHouse)
                return $"{path}cityhouse.png";
            else if (building is VillageHut)
                return $"{path}villagehut.png";
            else if (building is Church)
                return $"{path}church.png";

            throw new Exception("Неизвестный тип строения.");
        }

        public static ImageAttributes GetObjectColorReplacement(string color, bool selected)
        {
            var colorMap = new List<ColorMap>();
            colorMap.Add(new ColorMap
            {
                OldColor = Color.Silver,
                NewColor = ConvertPlayerColor(color)
            });
            if (selected)
            {
                colorMap.Add(new ColorMap
                {
                    OldColor = Color.Black,
                    NewColor = Color.DarkOrange
                });
            }
            var attr = new ImageAttributes();
            attr.SetRemapTable(colorMap.ToArray());
            return attr;
        }

        private static Color ConvertPlayerColor(string color)
        {
            if (color.Equals("green", StringComparison.InvariantCultureIgnoreCase))
                return Color.MediumSeaGreen;

            if (color.Equals("red", StringComparison.InvariantCultureIgnoreCase))
                return Color.OrangeRed;

            if (color.Equals("yellow", StringComparison.InvariantCultureIgnoreCase))
                return Color.Gold;

            if (color.Equals("blue", StringComparison.InvariantCultureIgnoreCase))
                return Color.SlateBlue;

            if (color.Equals("white", StringComparison.InvariantCultureIgnoreCase))
                return Color.Snow;

            return ColorTranslator.FromHtml(color);
        }
    }
}
