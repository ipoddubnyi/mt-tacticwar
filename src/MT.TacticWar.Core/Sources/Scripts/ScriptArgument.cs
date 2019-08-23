using System;
using System.Collections.Generic;
using System.Reflection;

namespace MT.TacticWar.Core.Scripts
{
    public class ScriptArgument
    {
        private readonly ScriptArgumentAttribute attributes;

        public string Name => attributes.Name;
        public Type Type { get; private set; }
        public string Value { get; set; }

        public ScriptArgument(ScriptArgumentAttribute attributes, Type type, string value = "")
        {
            this.attributes = attributes;
            Type = type;
            Value = value;
        }

        public bool Check()
        {
            return CheckPossible(Value);
        }

        public bool CheckPossible(string value)
        {
            if (Type.Equals(typeof(string)))
                return attributes.CanBeEmpty ? true : !string.IsNullOrEmpty(value);

            if (Type.Equals(typeof(int)))
            {
                if (int.TryParse(value, out var vint))
                    return vint >= attributes.Min && vint <= attributes.Max;

                return false;
            }

            if (Type.Equals(typeof(Operation)))
                return Operation.TryConvertOperationType(value, out var vop);

            return true;
        }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }

        //

        public static ScriptArgument[] GetArgumentsArray(Type conditionType)
        {
            var arguments = new List<ScriptArgument>();

            var properties = conditionType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var type = property.PropertyType;
                var attrs = property.GetCustomAttributes(typeof(ScriptArgumentAttribute), false);
                foreach (ScriptArgumentAttribute attr in attrs)
                {
                    arguments.Add(new ScriptArgument(attr, type));
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
                var type = property.PropertyType;
                var value = property.GetValue(condition, null).ToString();
                var attrs = property.GetCustomAttributes(typeof(ScriptArgumentAttribute), false);
                foreach (ScriptArgumentAttribute attr in attrs)
                {
                    arguments.Add(new ScriptArgument(attr, type, value));
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
                var type = property.PropertyType;
                var value = property.GetValue(statement, null).ToString();
                var attrs = property.GetCustomAttributes(typeof(ScriptArgumentAttribute), false);
                foreach (ScriptArgumentAttribute attr in attrs)
                {
                    arguments.Add(new ScriptArgument(attr, type, value));
                }
            }

            return arguments.ToArray();
        }
    }
}
