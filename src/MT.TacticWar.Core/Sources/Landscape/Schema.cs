using System;

namespace MT.TacticWar.Core.Landscape
{
    public abstract class Schema
    {
        public virtual string Name => "Схема";

        public Schema()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        //

        public static string GetSchemaName(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(SchemaAttribute), false);
            var schema = attributes[0] as SchemaAttribute;
            return schema?.Name;
        }
    }
}
