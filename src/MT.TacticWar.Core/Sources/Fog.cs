using System;
using System.Collections.Generic;
using System.Text;

namespace MT.TacticWar.Core
{
    public class Fog
    {
        private int[,] fog;
        public int Width;
        public int Height;

        /// <summary>Есть ли туман в данной ячейке.</summary>
        public bool this[int x, int y] => 0 == fog[x, y];

        /// <summary>Есть ли туман в данной ячейке.</summary>
        public bool this[Coordinates pt] => 0 == fog[pt.X, pt.Y];

        public Fog(int width, int height, Player player)
        {
            Init(width, height);

            foreach (var division in player.Divisions)
            {
                SetVisible(division.Position, division.Parameters.RadiusView);
            }

            foreach (var building in player.Buildings)
            {
                SetVisible(building.Position, building.RadiusView);
            }
        }

        private void Init(int width, int height)
        {
            Width = width;
            Height = height;

            fog = new int[width, height];
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    fog[x, y] = 0;
        }

        private void SetVisible(Coordinates position, int radius)
        {
            int mixX = Math.Max(0, position.X - radius);
            int maxX = Math.Min(Width - 1, position.X + radius);

            int mixY = Math.Max(0, position.Y - radius);
            int maxY = Math.Min(Height - 1, position.Y + radius);

            for (int y = mixY; y <= maxY; ++y)
                for (int x = mixX; x <= maxX; ++x)
                    fog[x, y] += 1;
        }

        public Coordinates[] UpdateArea(Coordinates position, int radius, bool visible)
        {
            var area = new List<Coordinates>();

            int mixX = Math.Max(0, position.X - radius);
            int maxX = Math.Min(Width - 1, position.X + radius);

            int mixY = Math.Max(0, position.Y - radius);
            int maxY = Math.Min(Height - 1, position.Y + radius);

            for (int y = mixY; y <= maxY; ++y)
            {
                for (int x = mixX; x <= maxX; ++x)
                {
                    if (visible)
                    {
                        fog[x, y] += 1;
                    }
                    else
                    {
                        fog[x, y] -= 1;
                        if (fog[x, y] < 0) fog[x, y] = 0;
                    }
                    area.Add(new Coordinates(x, y));
                }
            }

            return area.ToArray();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    sb.Append(fog[x, y]);
                }

                sb.Append('\n');
            }

            System.Diagnostics.Debug.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
