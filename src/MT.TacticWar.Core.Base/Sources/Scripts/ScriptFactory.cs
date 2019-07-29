using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public static class ScriptFactory
    {
        public static ICondition CreateCondition(string type, string[] arguments)
        {
            switch (type)
            {
                case "unitcount":
                    return new UnitCountCondition(arguments);
            }

            throw new Exception("Неизвестный тип условия.");
        }

        public static IStatement CreateStatement(string type, string[] arguments)
        {
            switch (type)
            {
                case "gameover":
                    return new GameOverStatement(arguments);
                case "message":
                    return new MessageStatement(arguments);
            }

            throw new Exception("Неизвестный тип выражения.");
        }
    }
}
