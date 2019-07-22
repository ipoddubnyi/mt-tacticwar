using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Objects
{
    public class Division : IObject
    {
        public DivisionType Type; //тип подразделения

        public Coordinates Coordinates; //координаты на зоне БД

        public Coordinates Target;   //координаты места назначения
        public Coordinates DayTarget; //координаты цели юнита в этот день

        public int Id;             //номер подразделения
        public string Name;        //имя
        public int PlayerId;        //ид игрока

        public int PowerAntiInf;   //общая мощь против пехоты и артиллерии
        public int PowerAntiBron;  //общая мощь против бронетехники и кораблей
        public int PowerAntiAir;   //общая мощь против воздуха

        public int ArmourFromInf;  //общая защита от пехоты
        public int ArmourFromBron; //общая защита от любой техники

        public int Suplies;        //число патронов и снарядов

        public int RadiusAttack;         //радиус действия (для артиллерии)
        public int RadiusView;          //радиус обзора

        public UnitLevel Level;      //уровень повышения

        public int Steps;          //число шагов (равно числу шагов самого медленного юнита)
        public bool CanStepLand;      //ходит ли по земле
        public bool CanStepAqua;      //ходит ли по воде

        public List<StructUnits> Units;    //список юнитов

        //********************************************************************************
        
        #region Настройки класса

        [DisplayName("Игрок")]
        [Description("Номер владельца подразделения")]
        public string Игрок
        {
            get { return ("Игрок " + PlayerId.ToString()); }
        }

        [DisplayName("Тип")]
        [Description("Тип подразделения")] 
        public string Тип => Type.AsString();

        [DisplayName("Название")]
        [Description("Название подразделения")] 
        public string Название => Name;

        [DisplayName("Координаты")]
        [Description("Координаты подразделения на карте")]
        public string Координаты => Coordinates.ToString();

        [DisplayName("Мощь против пехоты")]
        [Description("Боевая мощь противопехотного оружия")] 
        public string Мощь_против_пехоты => PowerAntiInf.ToString();

        [DisplayName("Мощь против бронетехники")]
        [Description("Боевая мощь противотанкового оружия")] 
        public string Мощь_против_бронетехники => PowerAntiBron.ToString();

        [DisplayName("Мощь против авиации")]
        [Description("Боевая мощь противовоздушного оружия")] 
        public string Мощь_против_авиации => PowerAntiAir.ToString();

        [DisplayName("Защита от пехоты")]
        [Description("Защита от противопехотного оружия")] 
        public string Защита_от_пехоты => ArmourFromInf.ToString();

        [DisplayName("Защита от техники")]
        [Description("Защита от противотанкового оружия")] 
        public string Защита_от_техники => ArmourFromBron.ToString();

        [DisplayName("Радиус атаки")]
        [Description("На каком радиусе подразделение может выполнять функции")] 
        public string Радиус => RadiusAttack.ToString();

        [DisplayName("Радиус обзора")]
        [Description("Дальность видимости подразделения")] 
        public string Обзор => RadiusView.ToString();

        [DisplayName("Ранг")]
        [Description("Ранг поздразделения")]
        public string Ранг => Level.AsString();

        [DisplayName("Количество патронов")]
        [Description("Количество патронов. Без патронов подразделение не может вести боевые действия")] 
        public string Патроны => Suplies.ToString();

        [DisplayName("Количество шагов")]
        [Description("Число шагов подразделения")] 
        public string Шаги => Steps.ToString();

        #endregion

        //********************************************************************************

        public Division(int igrok, int id, int type, string name, int i, int j, List<StructUnits> units)
        {
            //тип подразделения
            Type = (DivisionType)type;

            //координаты на зоне БД
            Coordinates = new Coordinates(i, j);

            //координаты места назначения
            Target = new Coordinates(-1, -1);

            //координаты цели юнита в этот день
            DayTarget = new Coordinates(-1, -1);

            Id = id;             //номер подразделения
            Name = name;        //имя
            PlayerId = igrok;        //ид игрока

            //список юнитов
            Units = units; //new List<StructUnits>();

            //пересчитать показатели
            recountParams();
        }

        //********************************************************************************

        //Продвинуть подразделение к цели на этот день
        //!!!!!!!!!! Возврат: true - достигли цели
        public void pushElement(List<Cell> put)
        {
            //просчитать путь для юнита на один день (для рисования на карте)
            Cell[] tmpArr = new Cell[put.Count];
            put.CopyTo(tmpArr);
            List<Cell> oneDayPut = tmpArr.ToList();
            countOneDayOfElement(ref oneDayPut);

            //бежим по точкам пути
            for (int k = 0; k < (oneDayPut.Count - 1); k++)
            {
                Steps -= oneDayPut.ElementAt(k).PassCost;

                //если юниту хватает шагов, чтобы пройти по данной ячейке
                //if (Steps < 0)
                //    k = put.Count; //иначе - завершаем цикл
            }

            Coordinates.X = DayTarget.X;
            Coordinates.Y = DayTarget.Y;

            DayTarget.X = -1;
            DayTarget.Y = -1;
        }

        //Просчитать часть пути, которую юнит пройдёт за один день
        public void countOneDayOfElement(ref List<Cell> put)
        {
            int curSteps = Steps; //шаги в текущем ходе
            int tmp = 0;

            //бежим по точкам пути
            for (int k = 0; k < put.Count; k++)
            {
                //если юниту хватает шагов, чтобы пройти по данной ячейке
                if (curSteps >= 0)
                {
                    tmp = k; //запоминаем ячейку по списку
                    curSteps -= put.ElementAt(k).PassCost;
                }
                else
                    k = put.Count; //иначе - завершаем цикл
            }

            //запоминаем координаты цели на этот день
            DayTarget = put.ElementAt(tmp).Coordinates.Clone();

            //бежим по оставшимся точкам пути
            put.RemoveRange(tmp + 1, put.Count - tmp - 1); //удаляем элементы
        }

        //Поставить флаг для подразделения
        public void setFlag(int i, int j)
        {
            Target.X = i;
            Target.Y = j;
        }

        //Убрать флаг для подразделения
        public void removeFlag()
        {
            Target.X = -1;
            Target.Y = -1;

            DayTarget.X = -1;
            DayTarget.Y = -1;
        }

        //Пересчитать показатели подразделения
        public void recountParams()
        {
            //???? если есть повторяющиеся юниты - объединить их
            for (int k = 0; k < Units.Count; k++)
            {
                for (int l = 0; l < Units.Count; l++)
                {
                    if(k == l) continue;

                    if (Units[k].unit.Name == Units[l].unit.Name)
                    {
                        //!!!!!!!!!!!!
                        StructUnits temp = Units[k];
                        temp.count += Units[l].count;

                        //если юниты ранены - учесть это
                        if (Units[l].unit.Health != Health.Ready)
                            Units[k].unit.Health = Units[l].unit.Health;

                        //удаляем и начинаем цик заново
                        Units.RemoveAt(l);
                        k = 0;
                        l = 0;
                    }
                }
            }

            //пересчитываем остальные параметры

            //
            int allUnits = 0;       //все юниты в сумме

            PowerAntiInf = 0;      //средняя мощь против пехоты и артиллерии
            PowerAntiAir = 0;      //средняя мощь против воздуха
            PowerAntiBron = 0;     //средняя мощь против бронетехники и кораблей

            ArmourFromInf = 0;     //средняя защита от пехоты
            ArmourFromBron = 0;    //средняя защита от любой техники

            Suplies = 0;           //число патронов и снарядов
            RadiusAttack = int.MaxValue; //радиус действия (для артиллерии)
            RadiusView = 0;             //радиус обзора

            int level = 0;          //средний уровень

            Steps = int.MaxValue;  //число шагов (равно числу шагов самого медленного юнита)
            CanStepLand = true;       //ходит ли по земле
            CanStepAqua = true;       //ходит ли по воде

            for (int k = 0; k < Units.Count; k++)
            {
                allUnits += Units[k].count;

                //считаем средние следующих величин
                PowerAntiInf += Units[k].unit.PowerAntiInf * Units[k].count;
                PowerAntiAir += Units[k].unit.PowerAntiAir * Units[k].count;
                PowerAntiBron += Units[k].unit.PowerAntiBron * Units[k].count;

                ArmourFromInf += Units[k].unit.ArmourFromInf * Units[k].count;
                ArmourFromBron += Units[k].unit.ArmourFromBron * Units[k].count;

                switch (Units[k].unit.Level)
                {
                    case UnitLevel.Recruit:
                        level += 1 * Units[k].count;
                        break;
                    case UnitLevel.Warrior:
                        level += 2 * Units[k].count;
                        break;
                    case UnitLevel.Veteran:
                        level += 3 * Units[k].count;
                        break;
                    case UnitLevel.Hero:
                        level += 4 * Units[k].count;
                        break;
                 }

                //сумма патронов
                Suplies += Units[k].unit.Suplies;

                //выбираем минимальный радиус
                if (Units[k].unit.RadiusAttack < RadiusAttack)
                    RadiusAttack = Units[k].unit.RadiusAttack;

                //выбираем максимальный обзор
                if (Units[k].unit.RadiusView > RadiusView)
                    RadiusView = Units[k].unit.RadiusView;

                //выбираем минимальное число шагов
                if (Units[k].unit.Steps < Steps)
                    Steps = Units[k].unit.Steps;

                //если хоть 1 юнит не ходит по земле - никто не ходит
                if (!Units[k].unit.StepLand)
                    CanStepLand = false;

                //если хоть 1 юнит не плавает - никто не плавает
                if (!Units[k].unit.StepAqua)
                    CanStepAqua = false;
            }

            PowerAntiInf /= allUnits;
            PowerAntiAir /= allUnits;
            PowerAntiBron /= allUnits;

            ArmourFromInf /= allUnits;
            ArmourFromBron /= allUnits;

            level /= allUnits;

            switch (level)
            {
                case 1:
                    Level = UnitLevel.Recruit;
                    break;
                case 3:
                    Level = UnitLevel.Veteran;
                    break;
                case 4:
                    Level = UnitLevel.Hero;
                    break;
                case 2:
                default:
                    Level = UnitLevel.Warrior;
                    break;
            }
        }

        //Чинить войска
        //Если нет сломанной техники и раненых - false
        public bool repairUnits()
        {
            bool res = false;

            for (int k = 0; k < Units.Count; k++)
            {
                //если есть раненые
                if (Units[k].unit.Health == Health.Wounded)
                {
                    res = true;
                    Units[k].unit.Repair();
                }
            }

            return res;
        }

        public bool CanStep(CellType cell)
        {
            // если в ячейке вода, а юнит земной
            if (CellType.Water == cell && !CanStepAqua)
                return false;

            // если в ячейке НЕ вода, а юнит водный
            if (CellType.Water != cell && !CanStepLand)
                return false;

            return true;
        }
    }
}
