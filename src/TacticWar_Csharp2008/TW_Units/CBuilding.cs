using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TacticWar.TW_Units
{
    //Строение
    class CBuilding : CObject
    {
        public EBuildingTypes mType;    //тип строения

        public SCoordinates mCoords;     //координаты на зоне БД

        public int mId;                 //номер
        public string mName;            //имя
        public int mIgrokId;            //ид игрока
        public int mHealth;             //здоровье

        public int mRadius;             //радиус действия
        public int mObzor;              //радиус обзора

        public bool mIsOhran;           //есть ли охранение в здании
        public TW_Units.CElement mOhraneniye;   //подразделение на охранении

        public bool mSelected;                  //выделен ли объект
        string mImage;                          //путь к изображению

        //********************************************************************************

        #region Настройки класса

        [System.ComponentModel.Description("Номер владельца строения")] 
        public string Игрок
        {
            get { return ("Игрок " + mIgrokId.ToString()); }
        }

        [System.ComponentModel.Description("Тип строения")] 
        public string Тип
        {
            get
            {
                string res = "";

                switch (mType)
                {
                    case EBuildingTypes.Factory:
                        res = "Завод";
                        break;
                    case EBuildingTypes.Kazarma:
                        res = "Казарма";
                        break;
                    case EBuildingTypes.Storehouse:
                        res = "Склад";
                        break;
                    case EBuildingTypes.Radar:
                        res = "Радар";
                        break;
                    case EBuildingTypes.Airfield:
                        res = "Аэропорт";
                        break;
                    case EBuildingTypes.Port:
                        res = "Порт";
                        break;
                }

                return res;
            }
        }

        [System.ComponentModel.Description("Название строения")] 
        public string Название
        {
            get { return mName; }
        }

        [System.ComponentModel.Description("Координаты строения на карте")] 
        public string Координаты
        {
            get { return ("(" + mCoords.y + ", " + mCoords.x + ")"); }
        }

        /*[System.ComponentModel.Description("")] 
        public string Здоровье
        {
            get { return mHealth.ToString(); }
        }*/

        [System.ComponentModel.Description("На каком радиусе здание может выполнять функции")] 
        public string Радиус
        {
            get { return mRadius.ToString(); }
        }

        [System.ComponentModel.Description("Дальность видимости здания")] 
        public string Обзор
        {
            get { return mObzor.ToString(); }
        }

        #endregion

        //********************************************************************************

        //Конструктор
        public CBuilding()
        {

        }

        //Конструктор
        public CBuilding(int igrok, int id, int type, string name, int i, int j, int health, int radius, int obzor, bool isOhr, TW_Units.CElement elemOhr)
        {
            //тип строения
            switch (type)
            {
                case 1:
                    mType = EBuildingTypes.Kazarma;
                    break;
                case 2:
                    mType = EBuildingTypes.Storehouse;
                    break;
                case 3:
                    mType = EBuildingTypes.Radar;
                    break;
                case 4:
                    mType = EBuildingTypes.Airfield;
                    break;
                case 5:
                    mType = EBuildingTypes.Port;
                    break;
                case 0:
                default:
                    mType = EBuildingTypes.Factory;
                    break;
            }

            mCoords.x = i; //координаты на зоне БД
            mCoords.y = j;

            mId = id; //номер здания
            mName = name; //имя
            mIgrokId = igrok; //ид игрока
            mHealth = health; //здоровье

            mRadius = radius; //радиус действия
            mObzor = obzor; //радиус обзора

            mIsOhran = isOhr; //есть ли охранение в здании
            mOhraneniye = elemOhr; //подразделение на охранении

            mSelected = false; //выделен ли объект
            mImage = "Zavod1.png"; //путь к изображению
        }

        //********************************************************************************

        /// <summary>Рисование строения
        /// </summary>
        /// <param name="grf">объект, на котором рисуется</param>
        /// <param name="left">отступ слева</param>
        /// <param name="top">отступ сверху</param>
        /// <returns></returns>
        void CObject.drawMe(Graphics grf, int left, int top)
        {

        }

        //Копировать здание
        public CBuilding copyBuilding()
        {
            CBuilding newBuilding = new CBuilding();

            newBuilding.mType = mType; //тип строения

            newBuilding.mCoords.x = mCoords.x; //координаты на зоне БД
            newBuilding.mCoords.y = mCoords.y;

            newBuilding.mId = mId; ; //номер
            newBuilding.mName = mName; //имя
            newBuilding.mIgrokId = mIgrokId; //ид игрока
            newBuilding.mHealth = mHealth; //здоровье

            newBuilding.mRadius = mRadius; //радиус действия
            newBuilding.mObzor = mObzor; //радиус обзора

            newBuilding.mIsOhran = mIsOhran; //есть ли охранение в здании
            newBuilding.mOhraneniye = mOhraneniye; //подразделение на охранении

            newBuilding.mSelected = mSelected; //выделен ли объект
            newBuilding.mImage = mImage; //путь к изображению

            return newBuilding;
        }

        //Выделить здание
        public void selectMe()
        {
            mSelected = true;
        }

        //Снять выделение со здания
        public void deselectMe()
        {
            mSelected = false;
        }

        //Нарисовать здание
        public void drawBuilding(Graphics grf, int left, int top, int fieldSize)
        {
            mImage = "img\\buildings\\";

            //выбрать изображение по типу подразделения
            switch (mType)
            {
                case EBuildingTypes.Kazarma:
                    mImage += "Kazarma";
                    break;
                case EBuildingTypes.Storehouse:
                    mImage += "Sklad";
                    break;
                case EBuildingTypes.Radar:
                    mImage += "Radar";
                    break;
                case EBuildingTypes.Airfield:
                    mImage += "Aeroport";
                    break;
                case EBuildingTypes.Port:
                    mImage += "Port";
                    break;
                case EBuildingTypes.Factory:
                default:
                    mImage += "Zavod";
                    break;
            }

            string endOfImg = ".png";

            //если выделен
            if (mSelected)
                endOfImg = "_selected.png";

            mImage += (mIgrokId + 1).ToString() + endOfImg;

            Image newImage = Image.FromFile(mImage);
            grf.DrawImage(newImage, left, top, fieldSize, fieldSize); //j * fieldSize, i * fieldSize);

            //---

            //если есть охранение - пометить
            if (mIsOhran)
            {
                mImage = "img\\features\\Defend.png";

                newImage = Image.FromFile(mImage);
                grf.DrawImage(newImage, left, top, fieldSize, fieldSize); //j * fieldSize, i * fieldSize);
            }

            newImage.Dispose();
            //grf.Dispose();
        }

        //Добавить охранение в здание
        //Возвращает false при ошибке
        public bool addOhraneniye(CElement ohran)
        {
            //если уже есть охранение - ошибка
            if (mIsOhran) return false;

            mIsOhran = true;
            mOhraneniye = ohran;

            return true;
        }
    }
}
