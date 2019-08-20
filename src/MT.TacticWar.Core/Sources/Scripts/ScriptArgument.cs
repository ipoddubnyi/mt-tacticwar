using System;
using System.Collections.Generic;
using System.Reflection;

namespace MT.TacticWar.Core.Scripts
{
    public struct ScriptArgument
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public ScriptArgument(string name, string value = "")
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }

        //

        public static ScriptArgument[] GetArguments(Type conditionType)
        {
            var arguments = new List<ScriptArgument>();

            var properties = conditionType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attrs = property.GetCustomAttributes(typeof(ScriptArgumentAttribute), false);
                foreach (ScriptArgumentAttribute col in attrs)
                {
                    arguments.Add(new ScriptArgument(col.Name));
                }
            }

            return arguments.ToArray();
        }

        public static ScriptArgument[] GetArguments(ICondition condition)
        {
            var arguments = new List<ScriptArgument>();

            var properties = condition.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attrs = property.GetCustomAttributes(typeof(ScriptArgumentAttribute), false);
                foreach (ScriptArgumentAttribute col in attrs)
                {
                    var value = property.GetValue(condition, null).ToString();
                    arguments.Add(new ScriptArgument(col.Name, value));
                }
            }

            return arguments.ToArray();
        }

        // TODO: отрефакторить повторяющийся код
        public static ScriptArgument[] GetArguments(IStatement statement)
        {
            var arguments = new List<ScriptArgument>();

            var properties = statement.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var attrs = property.GetCustomAttributes(typeof(ScriptArgumentAttribute), false);
                foreach (ScriptArgumentAttribute col in attrs)
                {
                    var value = property.GetValue(statement, null).ToString();
                    arguments.Add(new ScriptArgument(col.Name, value));
                }
            }

            return arguments.ToArray();
        }
    }
}
