
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
    }
}
