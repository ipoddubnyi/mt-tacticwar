using MT.TacticWar.Core.Landscape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.TacticWar.Core.Sources.Algorithm
{
    // Структура параметров при поиске кратчайшего пути
    public struct BellmanParam
    {
        public Coordinates From;    // откуда идём
        public Coordinates To;      // куда идём
        public List<Cell> BestWay;  // путь - массив координат
        public int Cost;            // цена всего пути
    }
}
