using System;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Base.Landscape
{
    public struct SchemaVariant
    {
        public string Code;
        public Type Type;

        public Schema Create()
        {
            return (Schema)Activator.CreateInstance(Type);
        }

        public override string ToString()
        {
            return Schema.GetSchemaName(Type);
        }
    }
}
