using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.TacticWar.Core.Serialization
{
    public class Browser
    {
        public IEnumerable<string> Browse(string folderPath)
        {
            var dir = new DirectoryInfo(folderPath);
            if (dir.Exists)
            {
                var sourceDirectories = dir.GetDirectories();

                foreach (var miss in sourceDirectories)
                for (int j = 0; j < sourceDirectories.Length; ++j)
                {
                    var missPath = Path.Combine(folderPath, miss.Name, "mission.mis");
                    var missionInfo = new FileInfo(missPath);

                    if (missionInfo.Exists)
                        yield return miss.Name;
                }
            }
        }

        public void Preload(string folderPath, string missName)
        {
            string missPath = Path.Combine(folderPath, missName, "mission.mis");
            using (var sr = new StreamReader(missPath))
            {
                //читаем имя миссии
                string missInternalName = sr.ReadLine();

                //читать путь к карте
                string pathMap = sr.ReadLine();
                pathMap = Path.Combine(folderPath, missName, pathMap);

                //читать путь к юнитам
                //mPathUnit = sr.ReadLine();
                sr.ReadLine();

                //читать брифинг
                string line;
                string briefing = "";

                while ((line = sr.ReadLine()) != "[конец]")
                {
                    briefing += line + Environment.NewLine;
                }

                string missMode = "";

                //читать режим игры
                switch (int.Parse(sr.ReadLine()))
                {
                    case 0:
                    default:
                        missMode = "Убить их всех";
                        break;
                }

                //читать карту
                /*if (loadMap(pathMap))
                {
                    drawEskiz();
                }*/
            }
        }
    }
}
