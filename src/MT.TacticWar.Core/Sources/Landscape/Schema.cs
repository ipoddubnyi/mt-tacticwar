using System;

namespace MT.TacticWar.Core.Landscape
{
    public abstract class Schema
    {
        //

        public static string GetSchemaName(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(SchemaAttribute), false);
            var schema = attributes[0] as SchemaAttribute;
            return schema?.Name;
        }

        public static string GetSchemaCode(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(SchemaAttribute), false);
            var schema = attributes[0] as SchemaAttribute;
            return schema?.Code;
        }

        public static string GetSchemaCode(Schema schema)
        {
            return GetSchemaCode(schema.GetType());
        }
    }
}
