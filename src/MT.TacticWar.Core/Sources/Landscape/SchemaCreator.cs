using System;

namespace MT.TacticWar.Core.Landscape
{
    public class SchemaCreator
    {
        public Type Type;

        public SchemaCreator(Type type)
        {
            Type = type;
        }

        public Schema Create()
        {
            return (Schema)Activator.CreateInstance(Type);
        }

        public string GetCode()
        {
            return Schema.GetSchemaCode(Type);
        }

        public override string ToString()
        {
            return Schema.GetSchemaName(Type);
        }
    }
}
