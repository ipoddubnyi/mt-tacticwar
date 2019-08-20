using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public static class ScriptFactory
    {
        public static readonly List<ScriptConditionVariant> Conditions = new List<ScriptConditionVariant>()
        {
            new ScriptConditionVariant { Code = "unitcount",    Type = typeof(UnitCountCondition) }
        };

        public static readonly List<ScriptStatementVariant> Statements = new List<ScriptStatementVariant>()
        {
            new ScriptStatementVariant { Code = "gameover",     Type = typeof(GameOverStatement) },
            new ScriptStatementVariant { Code = "message",      Type = typeof(MessageStatement) }
        };

        public static string GetScriptConditionCode(ICondition condition)
        {
            foreach (var c in Conditions)
            {
                if (c.Type.Equals(condition.GetType()))
                    return c.Code;
            }

            throw new Exception("Неизвестный тип условия.");
        }

        public static string GetScriptStatementCode(IStatement statement)
        {
            foreach (var s in Statements)
            {
                if (s.Type.Equals(statement.GetType()))
                    return s.Code;
            }

            throw new Exception("Неизвестный тип действия.");
        }

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
