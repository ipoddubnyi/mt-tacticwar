
namespace MT.TacticWar.Core.Scripts
{
    public class Script
    {
        public string Description { get; private set; }
        public ICondition Condition { get; private set; }
        public IStatement Statement { get; private set; }

        public Script(string description, ICondition condition, IStatement statement)
        {
            Description = description;
            Condition = condition;
            Statement = statement;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
