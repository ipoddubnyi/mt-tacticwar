using System.Collections.Generic;

namespace MT.TacticWar.Core.Scripts
{
    public interface ICondition
    {
        bool Check(Mission mission);
        List<ScriptArgument> GetArguments();
    }
}
