using MT.TacticWar.Core.Landscape;
using System;

namespace MT.TacticWar.Core.Base.Landscape
{
    public struct SchemaVariant
    {
        public string Name;
        public string Code;
        public Type Type;

        public Schema Create()
        {
            return (Schema)Activator.CreateInstance(Type);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
