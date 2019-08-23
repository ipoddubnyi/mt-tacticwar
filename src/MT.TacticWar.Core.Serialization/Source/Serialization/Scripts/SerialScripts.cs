using System;
using System.Xml.Serialization;
using MT.TacticWar.Core.Base.Scripts;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
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

        public Script Create()
        {
            return new Script(
                    Description,
                    Repeatable,
                    ScriptFactory.CreateCondition(Condition.Type, Condition.GetArguments()),
                    ScriptFactory.CreateStatement(Statement.Type, Statement.GetArguments())
                );
        }
    }
}
