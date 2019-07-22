using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;
using MT.TacticWar.Core.Players;
using MT.TacticWar.Core.Types.Mission;

namespace MT.TacticWar.UI
{
    class MissionLoader
    {
        public static Map LoadMap(string filePath)
        {
            Map map = null;
            using (var sr = new StreamReader(filePath))
            {
                //читать имя карты
                var name = sr.ReadLine();

                //читать размеры карты
                var height = int.Parse(sr.ReadLine());
                var width = int.Parse(sr.ReadLine());
                var field = new Cell[height, width];

                //загрузить схему земли
                var schema = (LandscapeSchema)int.Parse(sr.ReadLine());

                //загрузить карту
                string line;

                /*for (int y = 0; y < height; y++)
                {
                    line = sr.ReadLine();

                    //бежим по ячейкам в строке
                    for (int x = 0; x < width; x++)
                    {
                        field[y, x] = new Cell(
                            y,
                            x,
                            (CellType)int.Parse(line.Substring(x, 1))
                        );
                    }
                }*/
                for (int y = 0; y < height; y++)
                {
                    line = sr.ReadLine();

                    for (int x = 0; x < width; x++)
                    {
                        field[x, y] = new Cell(
                            x,
                            y,
                            (CellType)int.Parse(line.Substring(x, 1))
                        );
                    }
                }

                //читаем промежуточную строку
                line = sr.ReadLine();

                //читаем массив проходимых и нет ячеек
                /*for (int y = 0; y < height; y++)
                {
                    line = sr.ReadLine();

                    //бежим по ячейкам в строке
                    for (int x = 0; x < width; x++)
                    {
                        //определяем проходимость ячейки (проходима, если 0)
                        if (int.Parse(line.Substring(x, 1)) == 0)
                        {
                            field[y, x].Passable = true;
                            //Field[k, l].PassCost = Cell.GetPassCost(Field[k, l].Type);
                        }
                        else
                        {
                            field[y, x].Passable = false;
                            field[y, x].PassCost = int.MaxValue;
                        }
                    }
                }*/
                for (int y = 0; y < height; y++)
                {
                    line = sr.ReadLine();

                    for (int x = 0; x < width; x++)
                    {
                        //определяем проходимость ячейки (проходима, если 0)
                        if (int.Parse(line.Substring(x, 1)) == 0)
                        {
                            field[x, y].Passable = true;
                            //Field[k, l].PassCost = Cell.GetPassCost(Field[k, l].Type);
                        }
                        else
                        {
                            field[x, y].Passable = false;
                            field[x, y].PassCost = int.MaxValue;
                        }
                    }
                }

                map = new Map(width, height);
                map.Name = name;
                map.Field = field;
            }

            return map;
        }

        public static Mission LoadMission(string filePath)
        {
            Mission mission = null;
            using (var sr = new StreamReader(filePath))
            {
                //читаем имя миссии
                string name = sr.ReadLine();

                //читать путь к карте
                string mapPath = sr.ReadLine();

                //читать путь к юнитам
                //mPathUnit = sr.ReadLine();
                int playerCount = int.Parse(sr.ReadLine());

                //читать брифинг
                string line;
                string briefing = "";

                while ((line = sr.ReadLine()) != "[конец]")
                {
                    briefing += line + "\r\n";
                }

                //читать режим игры
                var mode = (MissionMode)int.Parse(sr.ReadLine());

                //!!!!!!!!!!!! читать параметры игры !!!!!!!!!!!!!!

                mission = new Mission();
                mission.mName = name;
                mission.mBriefing = briefing;
                mission.mCountIgroki = playerCount;
                mission.mPathMap = mapPath;
            }

            return mission;
        }

        public static Player LoadPlayerState(string filePath)
        {
            Player player = null;
            using (var sr = new StreamReader(filePath))
            {
                //проверяем ид игрока
                int id = int.Parse(sr.ReadLine());

                //читаем имя игрока
                //Name = sr.ReadLine();

                //читаем уровень игрока
                var rank = (PlayerRank)int.Parse(sr.ReadLine());

                //читаем деньги
                Money money;
                money.value = int.Parse(sr.ReadLine());

                //читаем число подразделений
                int countElem = int.Parse(sr.ReadLine());

                //читаем число зданий
                int countBuild = int.Parse(sr.ReadLine());

                //читаем подразделения
                var divisions = new List<Division>();

                for (int k = 0; k < countElem; k++)
                {
                    //[подразделение]
                    sr.ReadLine();

                    string nameElem = sr.ReadLine();

                    int type = int.Parse(sr.ReadLine());

                    int elemX = int.Parse(sr.ReadLine());
                    int elemY = int.Parse(sr.ReadLine());

                    //число разных юнитов
                    int countUnit = int.Parse(sr.ReadLine());

                    //список юнитов
                    var unitList = new List<StructUnits>();

                    //читаем юнитов
                    //Divisions[k].mUnits = new List<StructUnits>();

                    for (int kk = 0; kk < countUnit; kk++)
                    {
                        //[юнит]
                        sr.ReadLine();

                        //читать имя юнита (зависит от типа юнита)
                        int unitName = int.Parse(sr.ReadLine());

                        //число таких юнитов
                        int count = int.Parse(sr.ReadLine());

                        Unit unit;

                        //создать юнита в зависимости от типа юнита

                        if (type == 0) //пехота
                        {
                            switch (unitName)
                            {
                                case 1:
                                    unit = new CuiSoldiers(kk);
                                    break;
                                case 2:
                                    unit = new CuiDiversionGroup(kk);
                                    break;
                                case 3:
                                    unit = new CuiPoddubnyy(kk);
                                    break;
                                case 0:
                                default:
                                    unit = new CuiPartizans(kk);
                                    break;
                            }
                        }
                        else //if (type == 1) //!!!!!!!!!! бронетехника
                        {
                            switch (unitName)
                            {
                                case 1:
                                    unit = new CuvTankMiddle(kk);
                                    break;
                                case 2:
                                    unit = new CuvTankHeavy(kk);
                                    break;
                                case 3:
                                    unit = new CuvZRK(kk);
                                    break;
                                case 0:
                                default:
                                    unit = new CuvMotopehota(kk);
                                    break;
                            }
                        }

                        //создать структуру
                        StructUnits tmpStructUnit;
                        tmpStructUnit.unit = unit;
                        tmpStructUnit.count = count;

                        unitList.Add(tmpStructUnit);
                    }

                    Division tmpElem;

                    //создаём подразделение
                    tmpElem = new Division(id, k, type, nameElem, elemX, elemY, unitList);

                    //добавить здание
                    divisions.Add(tmpElem);
                }

                //читаем здания
                var buildings = new List<Building>();

                for (int k = 0; k < countBuild; k++)
                {
                    //[здание]
                    sr.ReadLine();

                    string nameBld = sr.ReadLine();

                    int type = int.Parse(sr.ReadLine());

                    int bldX = int.Parse(sr.ReadLine());
                    int bldY = int.Parse(sr.ReadLine());

                    int hlth = int.Parse(sr.ReadLine());

                    int rdus = int.Parse(sr.ReadLine());
                    int obzr = int.Parse(sr.ReadLine());

                    int ohrid = int.Parse(sr.ReadLine());

                    Building tmpBld;

                    //создать юнита в зависимости от охранения
                    if (ohrid == -1)
                        tmpBld = new Building(id, k, type, nameBld, bldX, bldY, hlth, rdus, obzr, false, null);
                    else
                        tmpBld = new Building(id, k, type, nameBld, bldX, bldY, hlth, rdus, obzr, true, divisions[ohrid]);

                    //добавить здание
                    buildings.Add(tmpBld);
                }

                //[ворота]
                sr.ReadLine();

                //читаем ворота
                var gates = new Coordinates(
                    int.Parse(sr.ReadLine()),
                    int.Parse(sr.ReadLine())
                );

                player = new Player(id);
                player.Id = id;
                player.Rank = rank;
                player.Money = money;
                player.Divisions = divisions;
                player.Buildings = buildings;
                player.Gates = gates;
            }

            return player;
        }
    }
}
