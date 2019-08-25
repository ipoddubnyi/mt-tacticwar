using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MT.TacticWar.Core.Base.Landscape;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Serialization
{
    [XmlRoot("map")]
    public class SerialMap
    {
        [XmlElement("info", IsNullable = false)]
        public SerialMapInfo Info { get; set; }

        [XmlElement("landscape")]
        public string Landscape { get; set; }

        [XmlElement("impassability")]
        public string Impassability { get; set; }

        //[XmlArray("cells")]
        //[XmlArrayItem("cell")]
        //public SerialCell[] Cells { get; set; }

        public SerialMap()
        {
        }

        public SerialMap(Map map, string version)
        {
            Info = new SerialMapInfo(map, version);
            Landscape = PrepareLandscapeString(map.Field, map.Width, map.Height);
            Impassability = PrepareImpassabilityString(map.Field, map.Width, map.Height);
            //TODO: Cells = null;
        }

        public Map Create()
        {
            var name = Info.Name;
            var description = Info.Description;
            var width = Info.Size.Width;
            var height = Info.Size.Height;
            var schemacode = Info.Schema;
            var schema = LandscapeFactory.CreateSchema(schemacode);

            var landlines = TextSplitAndTrim(Landscape, width);
            if (landlines.Length != height)
                throw new FormatException("Неверный формат карты ландшафта.");

            var impasslines = TextSplitAndTrim(Impassability, width);
            if (impasslines.Length != height)
                throw new FormatException("Неверный формат карты проходимости.");

            var field = CreateField(width, height, schema, landlines);
            field = SpecifyPassability(field, width, height, impasslines);

            return new Map(name, description, width, height, schema, field);
        }

        private Cell[,] CreateField(int width, int height, Schema schema, string[] landlines)
        {
            var field = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var code = landlines[y].Substring(x, 1)[0];
                    field[x, y] = LandscapeFactory.CreateCell(schema, code, x, y);
                }
            }
            return field;
        }

        private Cell[,] SpecifyPassability(Cell[,] field, int width, int height, string[] impasslines)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // определяем проходимость ячейки (проходима, если 0)
                    if (0 == int.Parse(impasslines[y].Substring(x, 1)))
                    {
                        field[x, y].Passable = true;
                    }
                    else
                    {
                        field[x, y].Passable = false;
                        field[x, y].PassCost = int.MaxValue;
                    }
                }
            }
            return field;
        }

        private static string PrepareLandscapeString(Cell[,] cells, int width, int height)
        {
            var sb = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                sb.Append(Environment.NewLine);
                sb.Append("        ");
                for (int x = 0; x < width; x++)
                {
                    sb.Append(Cell.GetCellCode(cells[x, y]));
                }
            }
            sb.Append(Environment.NewLine);
            sb.Append("    ");
            return sb.ToString();
        }

        private static string PrepareImpassabilityString(Cell[,] cells, int width, int height)
        {
            var sb = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                sb.Append(Environment.NewLine);
                sb.Append("        ");
                for (int x = 0; x < width; x++)
                {
                    sb.Append(cells[x, y].Passable ? '0' : '1');
                }
            }
            sb.Append(Environment.NewLine);
            sb.Append("    ");
            return sb.ToString();
        }

        private static string[] TextSplitAndTrim(string test, int chunkSize)
        {
            test = new string(test.Where(c => !char.IsWhiteSpace(c)).ToArray());
            return Enumerable.Range(0, test.Length / chunkSize)
                .Select(i => test.Substring(i * chunkSize, chunkSize)).ToArray();
        }

        public static void Serialize(string filePath, SerialMap map)
        {
            using (var writer = XmlWriter.Create(filePath,
                new XmlWriterSettings { Indent = true, IndentChars = "    " }))
            {
                var serializer = new XmlSerializer(typeof(SerialMap));
                serializer.Serialize(writer, map);
            }
        }

        public static SerialMap Deserialize(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(SerialMap));
                return serializer.Deserialize(fs) as SerialMap;
            }
        }
    }
}
