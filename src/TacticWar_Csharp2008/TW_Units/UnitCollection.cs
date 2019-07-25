﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacticWar.TW_Units
{
    #region Пехота

    /* Партизаны
     * 
     * Отделение непрофессиональной пехоты
     * Состоит из нескольких людей, вооружённых автоматами и пулеметами
     * 
     * Плюсы:
     * + низкая стоимость
     * + дальность хода
     * + высокая эффективность против пехоты
     * 
     * Минусы:
     * - низкая эффективность против техники и авиации
     * - малое число патронов
     */
    class CuiPartizans : CUnit
    {
        //Конструктор
        public CuiPartizans(int id)
        {
            //номер юнита в подразделении
            mId = id;

            //тип подразделения
            mType = EElementTypes.Infantry;
            //имя
            mName = "Партизаны";
            //цена юнита
            mCost.value = 400;

            //здоровье
            mHealth = EHealth.eh0_READY;

            //общая мощь против пехоты и артиллерии
            mPowerAntiInf = 20;
            //общая мощь против бронетехники и кораблей
            mPowerAntiBron = 2;
            //общая мощь против воздуха
            mPowerAntiAir = 2;

            //общая защита от пехоты
            mArmourFromInf = 20;
            //общая защита от любой техники
            mArmourFromBron = 30;
            //число патронов и снарядов
            mSuplies = 1500;

            //радиус действия (для артиллерии)
            mRadius = 0;
            //радиус обзора
            mObzor = 1;
            //уровень повышения
            mLevel = ELevels.Recruit;

            //число шагов
            mSteps = 10;
            //ходит ли по земле
            mStepLand = true;
            //ходит ли по воде
            mStepAqua = false;
        }
    }

    /* Солдаты
     * 
     * Отделение мотопехоты
     * Состоит из нескольких людей, вооружённых автоматами, пулеметами, гранатомётами
     * Присутствует БТР или БМП
     * 
     * Плюсы:
     * + дальность хода
     * + высокая эффективность против пехоты
     * + большое число патронов
     * + защищённость от техники
     * 
     * Минусы:
     * - высокая цена
     * - низкая эффективность против авиации
     */
    class CuiSoldiers : CUnit
    {
        //Конструктор
        public CuiSoldiers(int id)
        {
            //номер юнита в подразделении
            mId = id;

            //тип подразделения
            mType = EElementTypes.Infantry;
            //имя
            mName = "Солдаты";
            //цена юнита
            mCost.value = 700;

            //здоровье
            mHealth = EHealth.eh0_READY;

            //общая мощь против пехоты и артиллерии
            mPowerAntiInf = 25;
            //общая мощь против бронетехники и кораблей
            mPowerAntiBron = 10;
            //общая мощь против воздуха
            mPowerAntiAir = 5;

            //общая защита от пехоты
            mArmourFromInf = 30;
            //общая защита от любой техники
            mArmourFromBron = 30;
            //число патронов и снарядов
            mSuplies = 5000;

            //радиус действия (для артиллерии)
            mRadius = 0;
            //радиус обзора
            mObzor = 1;
            //уровень повышения
            mLevel = ELevels.Recruit;

            //число шагов
            mSteps = 8;
            //ходит ли по земле
            mStepLand = true;
            //ходит ли по воде
            mStepAqua = false;
        }
    }

    /* Разведывательно-диверсионная группа
     * 
     * Отделение специально подготовленной пехоты
     * Состоит из нескольких хорошо подготовленных людей
     * 
     * Плюсы:
     * + высокая эффективность против пехоты и бронетехники
     * + высокая защита
     * + дальность хода
     * + высокая дальность обзора
     * + высокий изначальный уровень повышения
     * + хождение по земле и воде
     * 
     * Минусы:
     * - высока стоимость
     * - низкая эффективность против авиации
     */
    class CuiDiversionGroup : CUnit
    {
        //Конструктор
        public CuiDiversionGroup(int id)
        {
            //номер юнита в подразделении
            mId = id;

            //тип подразделения
            mType = EElementTypes.Infantry;
            //имя
            mName = "Диверсанты";
            //цена юнита
            mCost.value = 3000;

            //здоровье
            mHealth = EHealth.eh0_READY;

            //общая мощь против пехоты и артиллерии
            mPowerAntiInf = 35;
            //общая мощь против бронетехники и кораблей
            mPowerAntiBron = 20;
            //общая мощь против воздуха
            mPowerAntiAir = 2;

            //общая защита от пехоты
            mArmourFromInf = 80;
            //общая защита от любой техники
            mArmourFromBron = 30;
            //число патронов и снарядов
            mSuplies = 3000;

            //радиус действия (для артиллерии)
            mRadius = 0;
            //радиус обзора
            mObzor = 2;
            //уровень повышения
            mLevel = ELevels.Warrior;

            //число шагов
            mSteps = 10;
            //ходит ли по земле
            mStepLand = true;
            //ходит ли по воде
            mStepAqua = true;
        }
    }

    /* Лейтенант запаса Поддубный И.Е.
     * 
     * Герой
     * 
     * Плюсы:
     * + эффективность против всего
     * + защита от всего
     * + высокий начальный уровень повышения
     * + хождение по земле и воде
     * 
     * Минусы:
     * - очень высокая стоимость
     * - невысокая дальность хода
     * - малое число патронов
     */
    class CuiPoddubnyy : CUnit
    {
        //Конструктор
        public CuiPoddubnyy(int id)
        {
            //номер юнита в подразделении
            mId = id;

            //тип подразделения
            mType = EElementTypes.Infantry;
            //имя
            mName = "Лейтенант";
            //цена юнита
            mCost.value = 50000;

            //здоровье
            mHealth = EHealth.eh0_READY;

            //общая мощь против пехоты и артиллерии
            mPowerAntiInf = 80;
            //общая мощь против бронетехники и кораблей
            mPowerAntiBron = 80;
            //общая мощь против воздуха
            mPowerAntiAir = 80;

            //общая защита от пехоты
            mArmourFromInf = 80;
            //общая защита от любой техники
            mArmourFromBron = 80;
            //число патронов и снарядов
            mSuplies = 1500;

            //радиус действия (для артиллерии)
            mRadius = 0;
            //радиус обзора
            mObzor = 1;
            //уровень повышения
            mLevel = ELevels.Hero;

            //число шагов
            mSteps = 5;
            //ходит ли по земле
            mStepLand = true;
            //ходит ли по воде
            mStepAqua = true;
        }
    }

    #endregion

    #region Бронетехника

    /* Тяжёлая мотопехота
     * 
     * Отделение тяжело вооружённой пехоты на БТР и БМП
     * 
     * Плюсы:
     * + низкая стоимость
     * + дальность хода
     * + высокая эффективность против пехоты
     * + большое число патронов
     * 
     * Минусы:
     * - низкая эффективность против техники
     */
    class CuvMotopehota : CUnit
    {
        //Конструктор
        public CuvMotopehota(int id)
        {
            //номер юнита в подразделении
            mId = id;

            //тип подразделения
            mType = EElementTypes.Vehicle;
            //имя
            mName = "Мотопехота";
            //цена юнита
            mCost.value = 800;

            //здоровье
            mHealth = EHealth.eh0_READY;

            //общая мощь против пехоты и артиллерии
            mPowerAntiInf = 20;
            //общая мощь против бронетехники и кораблей
            mPowerAntiBron = 15;
            //общая мощь против воздуха
            mPowerAntiAir = 5;

            //общая защита от пехоты
            mArmourFromInf = 30;
            //общая защита от любой техники
            mArmourFromBron = 30;
            //число патронов и снарядов
            mSuplies = 5000;

            //радиус действия (для артиллерии)
            mRadius = 0;
            //радиус обзора
            mObzor = 1;
            //уровень повышения
            mLevel = ELevels.Recruit;

            //число шагов
            mSteps = 8;
            //ходит ли по земле
            mStepLand = true;
            //ходит ли по воде
            mStepAqua = false;
        }
    }

    /* Средний танк
     * 
     * Основная боевая единица
     * 
     * Плюсы:
     * + высокая эффективность против техники
     * + высокая защита от пехоты
     * 
     * Минусы:
     * - низкая эффективность против авиации и пехоты
     * - малое число патронов
     */
    class CuvTankMiddle : CUnit
    {
        //Конструктор
        public CuvTankMiddle(int id)
        {
            //номер юнита в подразделении
            mId = id;

            //тип подразделения
            mType = EElementTypes.Vehicle;
            //имя
            mName = "Средний танк";
            //цена юнита
            mCost.value = 1500;

            //здоровье
            mHealth = EHealth.eh0_READY;

            //общая мощь против пехоты и артиллерии
            mPowerAntiInf = 20;
            //общая мощь против бронетехники и кораблей
            mPowerAntiBron = 50;
            //общая мощь против воздуха
            mPowerAntiAir = 5;

            //общая защита от пехоты
            mArmourFromInf = 80;
            //общая защита от любой техники
            mArmourFromBron = 50;
            //число патронов и снарядов
            mSuplies = 1500;

            //радиус действия (для артиллерии)
            mRadius = 0;
            //радиус обзора
            mObzor = 1;
            //уровень повышения
            mLevel = ELevels.Recruit;

            //число шагов
            mSteps = 5;
            //ходит ли по земле
            mStepLand = true;
            //ходит ли по воде
            mStepAqua = false;
        }
    }

    /* Тяжёлый танк
     * 
     * Тяжело вооружённая боевая единица
     * Предназначена для штурма хорошо вооружённых укреплений
     * 
     * Плюсы:
     * + высокая эффективность против техники
     * + высокая защита от пехоты и техники
     * 
     * Минусы:
     * - низкая дальность хода
     * - высокая стоимость
     * - низкая эффективность против авиации и пехоты
     * - малое число патронов
     */
    class CuvTankHeavy : CUnit
    {
        //Конструктор
        public CuvTankHeavy(int id)
        {
            //номер юнита в подразделении
            mId = id;

            //тип подразделения
            mType = EElementTypes.Vehicle;
            //имя
            mName = "Тяжёлый танк";
            //цена юнита
            mCost.value = 3000;

            //здоровье
            mHealth = EHealth.eh0_READY;

            //общая мощь против пехоты и артиллерии
            mPowerAntiInf = 15;
            //общая мощь против бронетехники и кораблей
            mPowerAntiBron = 80;
            //общая мощь против воздуха
            mPowerAntiAir = 10;

            //общая защита от пехоты
            mArmourFromInf = 80;
            //общая защита от любой техники
            mArmourFromBron = 80;
            //число патронов и снарядов
            mSuplies = 1000;

            //радиус действия (для артиллерии)
            mRadius = 0;
            //радиус обзора
            mObzor = 1;
            //уровень повышения
            mLevel = ELevels.Recruit;

            //число шагов
            mSteps = 4;
            //ходит ли по земле
            mStepLand = true;
            //ходит ли по воде
            mStepAqua = false;
        }
    }

    /* Зенитно-ракетный комплекс
     * 
     * Боевая единица ПВО войск
     * 
     * Плюсы:
     * + высокая эффективность против авиации
     * + дальность обзора
     * + ??????? дальность действия
     * 
     * Минусы:
     * - высокая стоимость
     * - низкая эффективность против пехоты и техники
     * - низкая защита
     * - малое число патронов
     */
    class CuvZRK : CUnit
    {
        //Конструктор
        public CuvZRK(int id)
        {
            //номер юнита в подразделении
            mId = id;

            //тип подразделения
            mType = EElementTypes.Vehicle;
            //имя
            mName = "ЗРК";
            //цена юнита
            mCost.value = 2500;

            //здоровье
            mHealth = EHealth.eh0_READY;

            //общая мощь против пехоты и артиллерии
            mPowerAntiInf = 5;
            //общая мощь против бронетехники и кораблей
            mPowerAntiBron = 10;
            //общая мощь против воздуха
            mPowerAntiAir = 80;

            //общая защита от пехоты
            mArmourFromInf = 30;
            //общая защита от любой техники
            mArmourFromBron = 15;
            //число патронов и снарядов
            mSuplies = 1000;

            //радиус действия (для артиллерии)
            mRadius = 0;
            //радиус обзора
            mObzor = 1;
            //уровень повышения
            mLevel = ELevels.Recruit;

            //число шагов
            mSteps = 5;
            //ходит ли по земле
            mStepLand = true;
            //ходит ли по воде
            mStepAqua = false;
        }
    }

    #endregion

    #region Артиллерия

    #endregion

    #region Авиация

    #endregion

    #region Корабли

    #endregion
}
