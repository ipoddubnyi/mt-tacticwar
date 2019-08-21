using System;
using System.Collections.Generic;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    public static class ScriptFactory
    {
        public static readonly List<ScriptConditionCreator> Conditions = new List<ScriptConditionCreator>()
        {
            new ScriptConditionCreator(typeof(UnitCountCondition))
        };

        public static readonly List<ScriptStatementCreator> Statements = new List<ScriptStatementCreator>()
        {
            new ScriptStatementCreator(typeof(GameOverStatement)),
            new ScriptStatementCreator(typeof(MessageStatement))
        };

        public static ICondition CreateCondition(string code, string[] arguments)
        {
            foreach (var c in Conditions)
            {
                if (c.GetCode().Equals(code))
                    return c.Create(arguments);
            }

            throw new Exception("Неизвестный тип условия.");
        }

        public static IStatement CreateStatement(string code, string[] arguments)
        {
            foreach (var s in Statements)
            {
                if (s.GetCode().Equals(code))
                    return s.Create(arguments);
            }

            throw new Exception("Неизвестный тип выражения.");
        }
    }
}
