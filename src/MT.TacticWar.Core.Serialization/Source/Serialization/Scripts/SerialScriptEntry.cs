using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Serialization
{
    /// <summary>Класс для сериализации ICondition и IStatement.</summary>
    public class SerialScriptEntry
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("argument")]
        public SerialScriptArgument[] Arguments;

        public SerialScriptEntry()
        {
        }

        public SerialScriptEntry(ICondition condition)
        {
            Type = Script.GetScriptCode(condition);
            Arguments = SerialScriptArgument.CreateFrom(
                ScriptArgument.GetArguments(condition)
            ).ToArray();
        }

        public SerialScriptEntry(IStatement statement)
        {
            Type = Script.GetScriptCode(statement);
            Arguments = SerialScriptArgument.CreateFrom(
                ScriptArgument.GetArguments(statement)
            ).ToArray();
        }

        public string[] GetArguments()
        {
            var args = new List<string>();
            foreach (var arg in Arguments)
                args.Add(arg.Value);
            return args.ToArray();
        }
    }
}
