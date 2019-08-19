using System.Collections.Generic;

namespace MT.TacticWar.Core.Scripts
{
    public interface IStatement
    {
        ISituation Execute(Mission mission);
        List<ScriptArgument> GetArguments();
    }
}
