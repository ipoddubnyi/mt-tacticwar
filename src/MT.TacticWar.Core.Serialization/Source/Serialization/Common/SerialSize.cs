using System.Xml.Serialization;

namespace MT.TacticWar.Core.Serialization
{
    public class SerialSize
    {
        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        public SerialSize()
        {
        }

        public SerialSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
