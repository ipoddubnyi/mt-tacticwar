using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MT.TacticWar.Core.Landscape;

namespace MT.TacticWar.Core.Objects
{
    //Подразделение
    public class Division : IObject
    {
        public DivisionType mType; //тип подразделения

        public Coordinates mCoords; //координаты на зоне БД

        public Coordinates mFlag;   //координаты места назначения
        public Coordinates mDayTag; //координаты цели юнита в этот день

        public int mId;             //номер подразделения
        public string mName;        //имя
        public int mIgrokId;        //ид игрока

        public int mPowerAntiInf;   //общая мощь против пехоты и артиллерии
        public int mPowerAntiBron;  //общая мощь против бронетехники и кораблей
        public int mPowerAntiAir;   //общая мощь против воздуха

        public int mArmourFromInf;  //общая защита от пехоты
        public int mArmourFromBron; //общая защита от любой техники

        public int mSuplies;        //число патронов и снарядов

        public int mRadius;         //радиус действия (для артиллерии)
        public int mObzor;          //радиус обзора

        public UnitLevel mLevel;      //уровень повышения

        public int mSteps;          //число шагов (равно числу шагов самого медленного юнита)
        public bool mStepLand;      //ходит ли по земле
        public bool mStepAqua;      //ходит ли по воде

        public List<StructUnits> mUnits;    //список юнитов

        public bool mSelected;              //выделен ли объект
        string mImage;                      //путь к изображению

        //********************************************************************************
        
        #region Настройки класса

        [System.ComponentModel.Description("Номер владельца подразделения")] 
        public string Игрок
        {
            get { return ("Игрок " + mIgrokId.ToString()); }
        }

        [System.ComponentModel.Description("Тип подразделения")] 
        public string Тип
        {
            get
            {
                string res = "";

                switch (mType)
                {
                    case DivisionType.Infantry:
                        res = "Пехота";
                        break;
                    case DivisionType.Vehicle:
                        res = "Бронетехника";
                        break;
                    case DivisionType.Artillery:
                        res = "Артиллерия";
                        break;
                    case DivisionType.Aviation:
                        res = "Авиация";
                        break;
                    case DivisionType.Ship:
                        res = "Флот";
                        break;
                }

                return res;
            }
        }

        [System.ComponentModel.Description("Название подразделения")] 
        public string Название
        {
            get { return mName; }
        }

        [System.ComponentModel.Description("Координаты подразделения на карте")] 
        public string Координаты
        {
            get { return ("(" + mCoords.y + ", " + mCoords.x + ")"); }
        }

        [System.ComponentModel.Description("Боевая мощь противопехотного оружия")] 
        public string Мощь_против_пехоты
        {
            get { return mPowerAntiInf.ToString(); }
        }
        [System.ComponentModel.Description("Боевая мощь противотанкового оружия")] 
        public string Мощь_против_бронетехники
        {
            get { return mPowerAntiBron.ToString(); }
        }
        [System.ComponentModel.Description("Боевая мощь противовоздушного оружия")] 
        public string Мощь_против_авиации
        {
            get { return mPowerAntiAir.ToString(); }
        }

        [System.ComponentModel.Description("Защита от противопехотного оружия")] 
        public string Защита_от_пехоты
        {
            get { return mArmourFromInf.ToString(); }
        }
        [System.ComponentModel.Description("Защита от противотанкового оружия")] 
        public string Защита_от_техники
        {
            get { return mArmourFromBron.ToString(); }
        }

        [System.ComponentModel.Description("На каком радиусе подразделение может выполнять функции")] 
        public string Радиус
        {
            get { return mRadius.ToString(); }
        }

        [System.ComponentModel.Description("Дальность видимости подразделения")] 
        public string Обзор
        {
            get { return mObzor.ToString(); }
        }

        [System.ComponentModel.Description("Ранг поздразделения")] 
        public string Ранг
        {
            get
            {
                string res = "";

                switch (mLevel)
                {
                    case UnitLevel.Recruit:
                        res = "Новобранец";
                        break;
                    case UnitLevel.Warrior:
                        res = "Воин";
                        break;
                    case UnitLevel.Veteran:
                        res = "Ветеран";
                        break;
                    case UnitLevel.Hero:
                        res = "Герой";
                        break;
                    default:
                        res = "Кто-то";
                        break;
                }

                return res;
            }
        }

        [System.ComponentModel.Description("Количество патронов. Без патронов подразделение не может вести боевые действия")] 
        public string Патроны
        {
            get { return mSuplies.ToString(); }
        }

        [System.ComponentModel.Description("Число шагов подразделения")] 
        public string Шаги
        {
            get { return mSteps.ToString(); }
        }

        #endregion

        //********************************************************************************

        //Конструктор
        public Division(int igrok, int id, int type, string name, int i, int j, List<StructUnits> units)
        {
            //тип подразделения
            switch (type)
            {
                case 0:
                    mType = DivisionType.Infantry;
                    break;
                case 2:
                    mType = DivisionType.Artillery;
                    break;
                case 3:
                    mType = DivisionType.Aviation;
                    break;
                case 4:
                    mType = DivisionType.Ship;
                    break;
                case 1:
                default:
                    mType = DivisionType.Vehicle;
                    break;
            }

            mCoords.x = i; //координаты на зоне БД
            mCoords.y = j;

            mFlag.x = -1;   //координаты места назначения
            mFlag.y = -1;
            mDayTag.x = -1; //координаты цели юнита в этот день
            mDayTag.y = -1;

            mId = id;             //номер подразделения
            mName = name;        //имя
            mIgrokId = igrok;        //ид игрока

            //список юнитов
            mUnits = units; //new List<StructUnits>();

            //пересчитать показатели
            recountParams();

            mSelected = false;         //выделен ли объект
            mImage = "Tank.png";          //путь к изображению
        }

        //********************************************************************************

        /// <summary>Рисование подразделения
        /// </summary>
        /// <param name="grf">объект, на котором рисуется</param>
        /// <param name="left">отступ слева</param>
        /// <param name="top">отступ сверху</param>
        /// <returns></returns>
        void IObject.drawMe(Graphics grf, int left, int top)
        {

        }

        //Нарисовать подразделение
        public void drawElement(Graphics grf, int left, int top, int fieldSize)
        {
            mImage = "img\\elements\\";

            //выбрать изображение по типу подразделения
            switch (mType)
            {
                case DivisionType.Infantry:
                    mImage += "Human";
                    break;
                case DivisionType.Ship:
                    mImage += "Ship";
                    break;
                case DivisionType.Aviation:
                    mImage += "Plane";
                    break;
                case DivisionType.Artillery:
                    mImage += "Artiller";
                    break;
                case DivisionType.Vehicle:
                default:
                    mImage += "Tank";
                    break;
            }

            string endOfImg = ".png";

            //если выделен
            if (mSelected)
                endOfImg = "_selected.png";

            mImage += (mIgrokId + 1).ToString() + endOfImg;

            Image newImage = Image.FromFile(mImage);
            grf.DrawImage(newImage, left, top, fieldSize, fieldSize); //j * fieldSize, i * fieldSize);

            newImage.Dispose();
            //grf.Dispose();
        }

        //Выделить подразделение
        public void selectMe()
        {
            mSelected = true;
        }

        //Снять выделение с подразделения
        public void deselectMe()
        {
            mSelected = false;
        }

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
                mSteps -= oneDayPut.ElementAt(k).mProhodCost;

                //если юниту хватает шагов, чтобы пройти по данной ячейке
                //if (mSteps < 0)
                //    k = put.Count; //иначе - завершаем цикл
            }

            mCoords.x = mDayTag.x;
            mCoords.y = mDayTag.y;

            mDayTag.x = -1;
            mDayTag.y = -1;
        }

        //Просчитать часть пути, которую юнит пройдёт за один день
        public void countOneDayOfElement(ref List<Cell> put)
        {
            int curSteps = mSteps; //шаги в текущем ходе
            int tmp = 0;

            //бежим по точкам пути
            for (int k = 0; k < put.Count; k++)
            {
                //если юниту хватает шагов, чтобы пройти по данной ячейке
                if (curSteps >= 0)
                {
                    tmp = k; //запоминаем ячейку по списку
                    curSteps -= put.ElementAt(k).mProhodCost;
                }
                else
                    k = put.Count; //иначе - завершаем цикл
            }

            //запоминаем координаты цели на этот день
            mDayTag = put.ElementAt(tmp).mCoords;

            //бежим по оставшимся точкам пути
            put.RemoveRange(tmp + 1, put.Count - tmp - 1); //удаляем элементы
        }

        //Поставить флаг для подразделения
        public void setFlag(int i, int j)
        {
            mFlag.x = i;
            mFlag.y = j;
        }

        //Убрать флаг для подразделения
        public void removeFlag()
        {
            mFlag.x = -1;
            mFlag.y = -1;

            mDayTag.x = -1;
            mDayTag.y = -1;
        }

        //Пересчитать показатели подразделения
        public void recountParams()
        {
            //???? если есть повторяющиеся юниты - объединить их
            for (int k = 0; k < mUnits.Count; k++)
            {
                for (int l = 0; l < mUnits.Count; l++)
                {
                    if(k == l) continue;

                    if (mUnits[k].unit.mName == mUnits[l].unit.mName)
                    {
                        //!!!!!!!!!!!!
                        StructUnits temp = mUnits[k];
                        temp.count += mUnits[l].count;

                        //если юниты ранены - учесть это
                        if (mUnits[l].unit.mHealth != Health.Ready)
                            mUnits[k].unit.mHealth = mUnits[l].unit.mHealth;

                        //удаляем и начинаем цик заново
                        mUnits.RemoveAt(l);
                        k = 0;
                        l = 0;
                    }
                }
            }

            //пересчитываем остальные параметры

            //
            int allUnits = 0;       //все юниты в сумме

            mPowerAntiInf = 0;      //средняя мощь против пехоты и артиллерии
            mPowerAntiAir = 0;      //средняя мощь против воздуха
            mPowerAntiBron = 0;     //средняя мощь против бронетехники и кораблей

            mArmourFromInf = 0;     //средняя защита от пехоты
            mArmourFromBron = 0;    //средняя защита от любой техники

            mSuplies = 0;           //число патронов и снарядов
            mRadius = int.MaxValue; //радиус действия (для артиллерии)
            mObzor = 0;             //радиус обзора

            int level = 0;          //средний уровень

            mSteps = int.MaxValue;  //число шагов (равно числу шагов самого медленного юнита)
            mStepLand = true;       //ходит ли по земле
            mStepAqua = true;       //ходит ли по воде

            for (int k = 0; k < mUnits.Count; k++)
            {
                allUnits += mUnits[k].count;

                //считаем средние следующих величин
                mPowerAntiInf += mUnits[k].unit.mPowerAntiInf * mUnits[k].count;
                mPowerAntiAir += mUnits[k].unit.mPowerAntiAir * mUnits[k].count;
                mPowerAntiBron += mUnits[k].unit.mPowerAntiBron * mUnits[k].count;

                mArmourFromInf += mUnits[k].unit.mArmourFromInf * mUnits[k].count;
                mArmourFromBron += mUnits[k].unit.mArmourFromBron * mUnits[k].count;

                switch (mUnits[k].unit.mLevel)
                {
                    case UnitLevel.Recruit:
                        level += 1 * mUnits[k].count;
                        break;
                    case UnitLevel.Warrior:
                        level += 2 * mUnits[k].count;
                        break;
                    case UnitLevel.Veteran:
                        level += 3 * mUnits[k].count;
                        break;
                    case UnitLevel.Hero:
                        level += 4 * mUnits[k].count;
                        break;
                 }

                //сумма патронов
                mSuplies += mUnits[k].unit.mSuplies;

                //выбираем минимальный радиус
                if (mUnits[k].unit.mRadius < mRadius)
                    mRadius = mUnits[k].unit.mRadius;

                //выбираем максимальный обзор
                if (mUnits[k].unit.mObzor > mObzor)
                    mObzor = mUnits[k].unit.mObzor;

                //выбираем минимальное число шагов
                if (mUnits[k].unit.mSteps < mSteps)
                    mSteps = mUnits[k].unit.mSteps;

                //если хоть 1 юнит не ходит по земле - никто не ходит
                if (!mUnits[k].unit.mStepLand)
                    mStepLand = false;

                //если хоть 1 юнит не плавает - никто не плавает
                if (!mUnits[k].unit.mStepAqua)
                    mStepAqua = false;
            }

            mPowerAntiInf /= allUnits;
            mPowerAntiAir /= allUnits;
            mPowerAntiBron /= allUnits;

            mArmourFromInf /= allUnits;
            mArmourFromBron /= allUnits;

            level /= allUnits;

            switch (level)
            {
                case 1:
                    mLevel = UnitLevel.Recruit;
                    break;
                case 3:
                    mLevel = UnitLevel.Veteran;
                    break;
                case 4:
                    mLevel = UnitLevel.Hero;
                    break;
                case 2:
                default:
                    mLevel = UnitLevel.Warrior;
                    break;
            }
        }

        //Чинить войска
        //Если нет сломанной техники и раненых - false
        public bool repairUnits()
        {
            bool res = false;

            for (int k = 0; k < mUnits.Count; k++)
            {
                //если есть раненые
                if (mUnits[k].unit.mHealth == Health.Wounded)
                {
                    res = true;
                    mUnits[k].unit.unitRepair();
                }
            }

            return res;
        }
    }
}
