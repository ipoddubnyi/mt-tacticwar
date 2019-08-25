using System.Collections.Generic;
using System.Xml.Serialization;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialScriptArgument
    {
        [XmlAttribute("comment")]
        public string Comment { get; set; }

        [XmlText]
        public string Value { get; set; }

        public SerialScriptArgument()
        {
        }

        public SerialScriptArgument(ScriptArgument argument)
        {
            Comment = argument.Name;
            Value = argument.Value;
        }

        public static IEnumerable<SerialScriptArgument> CreateFrom(IEnumerable<ScriptArgument> arguments)
        {
            foreach (var argument in arguments)
                yield return new SerialScriptArgument(argument);
        }
    }
}
