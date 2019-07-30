﻿using System.Collections.Generic;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Base.Objects
{
    public class Infantry : Division, IInfantry
    {
        public override string Type => "Пехота";

        public Infantry(Player player, int id, string name, int x, int y) :
            base(player, id, name, x, y)
        {
        }
    }
}
