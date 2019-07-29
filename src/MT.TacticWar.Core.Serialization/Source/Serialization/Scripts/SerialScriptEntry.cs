using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    [Serializable]
    public class SerialScriptEntry
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("argument")]
        public SerialScriptArgument[] Arguments;

        public string[] GetArguments()
        {
            var args = new List<string>();
            foreach (var arg in Arguments)
                args.Add(arg.Value);
            return args.ToArray();
        }
    }
}
