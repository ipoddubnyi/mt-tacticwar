using System.Collections.Generic;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Sources.Algorithm
{
    // Структура параметров при поиске кратчайшего пути
    internal struct BellmanParam
    {
        public Coordinates From;    // откуда идём
        public Coordinates To;      // куда идём
        public List<Cell> BestWay;  // путь - массив координат
        public int Cost;            // цена всего пути
    }
}
