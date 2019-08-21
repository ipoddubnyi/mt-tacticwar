using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Plugins
{
    public abstract class Plugin
    {
        public abstract Schema CreateSchema(string code);

        public abstract CellCreator[] GetSchemaCellTypes(Schema schema);

        public abstract Cell CreateCell(Schema schema, char code, int x, int y);

        public abstract Division CreateDivision(string code, Player player, int id, string name, int x, int y);

        public abstract Building CreateBuilding(string code, Player player, int id, string name, int x, int y, int health, Division security);

        public abstract Unit CreateUnit(Division division, string code, int id);

        public abstract ICondition CreateCondition(string code, string[] arguments);

        public abstract IStatement CreateStatement(string code, string[] arguments);
    }
}
