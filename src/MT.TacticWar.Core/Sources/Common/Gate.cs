using System.Diagnostics;

namespace MT.TacticWar.Core
{
    [DebuggerDisplay("{Id}: ({X}, {Y})")]
    public class Gate : Coordinates
    {
        public int Id { get; set; }

        public Gate(int id, int x, int y) :
            base(x, y)
        {
            Id = id;
        }

        public bool Equals(Gate gate)
        {
            return Equals(gate.X, gate.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is Gate ? Equals(obj as Gate) : false;
        }

        public override int GetHashCode()
        {
            var hashCode = 1426304211;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
