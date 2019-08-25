using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using MT.TacticWar.Core.Base.Scripts;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialScript
    {
        [XmlAttribute("desc")]
        public string Description { get; set; }

        [XmlAttribute("repeat")]
        public bool Repeatable { get; set; }

        [XmlElement("condition")]
        public SerialScriptEntry Condition { get; set; }

        [XmlElement("statement")]
        public SerialScriptEntry Statement { get; set; }

        public SerialScript()
        {
            Repeatable = false;
        }

        public SerialScript(Script script)
        {
            Description = script.Description;
            Condition = new SerialScriptEntry(script.Condition);
            Statement = new SerialScriptEntry(script.Statement);
        }

        public Script Create()
        {
            return new Script(
                Description,
                Repeatable,
                ScriptFactory.CreateCondition(Condition.Type, Condition.GetArguments()),
                ScriptFactory.CreateStatement(Statement.Type, Statement.GetArguments())
            );
        }

        public static IEnumerable<Script> Create(IEnumerable<SerialScript> sscripts)
        {
            foreach (var sscript in sscripts)
                yield return sscript.Create();
        }

        public static IEnumerable<SerialScript> CreateFrom(IEnumerable<Script> scripts)
        {
            foreach (var script in scripts)
                yield return new SerialScript(script);
        }
    }
}
