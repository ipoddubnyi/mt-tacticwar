using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialMissionInfo
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("briefing")]
        public string Briefing { get; set; }

        [XmlElement("version")]
        public string Version { get; set; }

        public SerialMissionInfo()
        {
        }

        public SerialMissionInfo(Mission mission, string version)
        {
            Name = mission.Name;
            Briefing = PrepareBriefing(mission.Briefing);
            Version = version;
        }

        public string GetTrimmedBriefing()
        {
            return TextTrim(Briefing);
        }

        private static string PrepareBriefing(string briefing)
        {
            var lines = briefing.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                sb.Append(Environment.NewLine);
                sb.Append("        ");
                sb.Append(line);
            }
            sb.Append(Environment.NewLine);
            sb.Append("    ");
            return sb.ToString();
        }

        private static string TextTrim(string text)
        {
            var buffer = new StringBuilder();
            using (TextReader sr = new StringReader(text))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    buffer.AppendLine(line.Trim());
                }
            }
            return buffer.ToString().Trim();
        }
    }
}
