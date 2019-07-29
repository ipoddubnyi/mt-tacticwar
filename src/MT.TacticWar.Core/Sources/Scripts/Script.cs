
namespace MT.TacticWar.Core.Scripts
{
    public class Script
    {
        public ICondition Condition { get; private set; }
        public IStatement Statement { get; private set; }

        public Script(ICondition condition, IStatement statement)
        {
            Condition = condition;
            Statement = statement;
        }
    }
}
