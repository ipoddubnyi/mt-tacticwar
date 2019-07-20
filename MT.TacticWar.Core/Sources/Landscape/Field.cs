using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core.Landscape
{
    //Зона боевых действий
    public class Field
    {
        public string mName;            //имя карты

        public Cell[,] mField;        //массив - поле боя
        public int mFieldWidth;         //размер поля

        public int mWidth;              //ширина поля боя
        public int mHeight;             //высота поля боя

        public LandscapeSchema mZemShema;     //схема земли

        public BellmanParam mPutParams; //параметры кратчайшего пути

        public string mError;           //ошибка

        //********************************************************************************

        /// <summary>Конструктор
        /// </summary>
        /// <param name="n">высота поля</param>
        /// <param name="m">ширина поля</param>
        /// <returns></returns>
        public Field(int n, int m)
        {
            mHeight = n;
            mWidth = m;

            mZemShema = LandscapeSchema.Summer;

            mField = new Cell[n, m];
            /* !!! */ mFieldWidth = 21;

            mError = "";

            for (int i = mField.GetLowerBound(0); i < mHeight; i++)
                for (int j = mField.GetLowerBound(1); j < mWidth; j++)
                    mField[i, j] = new Cell(i, j);
        }

        /// <summary>Конструктор
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        /// <returns></returns>
        public Field(string fileName)
        {
            //mZemShema = EZemShema.Leto;
            /* !!! */ mFieldWidth = 21;

            mError = "";

            if (!loadMap(fileName))
                return;                        

            mPutParams.kratPut = new List<Cell>();
        }

        //********************************************************************************

        /// <summary>Загрузка карты
        /// </summary>
        /// <param name="mapFileName">путь к файлу карты</param>
        /// <returns>Возвращает (false), если возникла ошибка</returns>
        private bool loadMap(string mapFileName)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(mapFileName))
                {
                    //читать имя карты
                    mName = sr.ReadLine();

                    //читать размеры карты
                    mHeight = int.Parse(sr.ReadLine());
                    mWidth = int.Parse(sr.ReadLine());
                    mField = new Cell[mHeight, mWidth];

                    //загрузить схему земли
                    switch (int.Parse(sr.ReadLine()))
                    {
                        case 1:
                            mZemShema = LandscapeSchema.Winter;
                            break;
                        case 2:
                            mZemShema = LandscapeSchema.City;
                            break;
                        case 0:
                        default:
                            mZemShema = LandscapeSchema.Summer;
                            break;
                    }

                    //загрузить карту
                    string line;

                    for (int k = 0; k < mHeight; k++)
                    {
                        line = sr.ReadLine();

                        //бежим по ячейкам в строке
                        for(int l = 0; l < mWidth; l++)
                        {
                            mField[k, l] = new Cell(k, l);

                            //определяем тип земли
                            mField[k, l].mZemType = (CellType)int.Parse(line.Substring(l, 1));
                        }
                    }

                    //читаем промежуточную строку
                    line = sr.ReadLine();

                    //читаем массив проходимых и нет ячеек
                    for (int k = 0; k < mHeight; k++)
                    {
                        line = sr.ReadLine();

                        //бежим по ячейкам в строке
                        for (int l = 0; l < mWidth; l++)
                        {
                            //определяем проходимость ячейки (проходима, если 0)
                            if (int.Parse(line.Substring(l, 1)) == 0)
                            {
                                mField[k, l].mProhodima = true;
                                mField[k, l].countProhodCost();
                            }
                            else
                            {
                                mField[k, l].mProhodima = false;
                                mField[k, l].mProhodCost = int.MaxValue;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                mError = "Ошибка загрузки карты";
                return false;
            }

            return true;
        }

        #region Поиск кратчайшего пути

        /// <summary>Инициализация переменных перед поиском кратчайшего пути
        /// </summary>
        /// <param name="elem">юнит, для которого ищем путь</param>
        /// <param name="fC">координаты флага (до куда вести поиск)</param>
        /// <returns></returns>
        private void BellmanInitPoiskPuti(Division elem, Coordinates fC)
        {
            //запомнить координаты начала и конца поиска
            mPutParams.unitCoords.x = elem.mCoords.x;
            mPutParams.unitCoords.y = elem.mCoords.y;
            mPutParams.flagCoords.x = fC.x;
            mPutParams.flagCoords.y = fC.y;

            //инициализируем остальные параметры
            mPutParams.elem = elem;
            mPutParams.cost = int.MaxValue;
            mPutParams.kratPut = new List<Cell>();
            mPutParams.kratPut.Clear();

            //бежим по всем клеткам
            for (int i = mField.GetLowerBound(0); i < mHeight; i++)
            {
                for (int j = mField.GetLowerBound(1); j < mWidth; j++)
                {
                    //обнуляем цену у флага
                    if(BellmanIsFlagHere(i, j))
                        mField[i, j].mCost = 0;
                    else
                        mField[i, j].mCost = int.MaxValue;

                    //очищаем все направления
                    mField[i, j].mNapravl.m1_levo = mField[i, j].mNapravl.m2_verh = false;
                    mField[i, j].mNapravl.m3_pravo = mField[i, j].mNapravl.m4_niz = false;

                    //обнуляем приоритетные направления
                    mField[i, j].mNapravl.prioritet = 0;
                }
            }
        }

        /// <summary>Обнуление направлений
        /// </summary>
        /// <returns></returns>
        private void BellmanNapravlNulling()
        {
            //бежим по всем клеткам
            for (int i = mField.GetLowerBound(0); i < mHeight; i++)
            {
                for (int j = mField.GetLowerBound(1); j < mWidth; j++)
                {
                    //очищаем все направления
                    mField[i, j].mNapravl.m1_levo = mField[i, j].mNapravl.m2_verh = false;
                    mField[i, j].mNapravl.m3_pravo = mField[i, j].mNapravl.m4_niz = false;
                }
            }
        }

        /// <summary>Можно ли ступать на клетку с координатами
        /// </summary>
        /// <param name="i">первая координата (строки)</param>
        /// <param name="j">вторая координата (стролбцы)</param>
        /// <returns></returns>
        private bool BellmanCanStep(int i, int j)
        {
            //если координаты за пределами поля
            if ((i < mField.GetLowerBound(0)) || (i > mField.GetUpperBound(0)))
                return false;

            if ((j < mField.GetLowerBound(1)) || (j > mField.GetUpperBound(1)))
                return false;

            //если ячейка НЕ проходима ИЛИ занята
            if ((!mField[i, j].mProhodima) || (mField[i, j].mZanyata))
            {
                //если координаты не совпадают с координатами юнита
                if ((mPutParams.unitCoords.x != i) || (mPutParams.unitCoords.y != j))
                    return false;
            }

            //если в ячейке вода, а юнит земной
            if ((mField[i, j].mZemType == CellType.Water) &&
                (!mPutParams.elem.mStepAqua))
                return false;

            //если в ячейке НЕ вода, а юнит водный
            if ((mField[i, j].mZemType != CellType.Water) &&
                (!mPutParams.elem.mStepLand))
                return false;

            return true;
        }

        /// <summary>Есть ли смысл идти в эту ячейку?
        /// </summary>
        /// <param name="i">первая координата (строки)</param>
        /// <param name="j">вторая координата (стролбцы)</param>
        /// <returns></returns>
        private bool BellmanIsSmyslToStep(int i, int j)
        {
            //если в эту ячейку попасть дороже, чем вообще в целом до флага,
            //  то эту ячейку можно и не рассматривать
            if (mField[i, j].mCost >
                mField[mPutParams.elem.mCoords.x, mPutParams.elem.mCoords.y].mCost)
                return false;

            //смысл есть
            return true;
        }

        /// <summary>Проверка, есть ли флаг в этой клетке
        /// </summary>
        /// <param name="i">первая координата (строки)</param>
        /// <param name="j">вторая координата (стролбцы)</param>
        /// <returns></returns>
        private bool BellmanIsFlagHere(int i, int j)
        {
            if ((mPutParams.flagCoords.x == i) && (mPutParams.flagCoords.y == j))
                return true;

            return false;
        }

        /// <summary>Рекурсивная функция, выполняющая шаги
        /// </summary>
        /// <param name="x">первая координата (строки)</param>
        /// <param name="y">вторая координата (стролбцы)</param>
        /// <returns></returns>
        private void BellmanLetsStep(int x, int y)
        {
            //-------------------- лево --------------------

            //если слева ещё НЕ были И там НЕТ флага, И туда можно идти
            if ((!mField[x, y].mNapravl.m1_levo) &&
                (!BellmanIsFlagHere(x, y - 1)) &&
                (BellmanCanStep(x, y - 1)))
            {
                //помечаем контакт с левой клеткой
                mField[x, y].mNapravl.m1_levo = true;
                mField[x, y - 1].mNapravl.m3_pravo = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (mField[x, y - 1].mCost >
                    (mField[x, y - 1].mProhodCost + mField[x, y].mCost))
                {
                    //заменяем цену
                    mField[x, y - 1].mCost =
                                mField[x, y - 1].mProhodCost + mField[x, y].mCost;

                    //если есть смысл шагать дальше
                    if (BellmanIsSmyslToStep(x, y - 1))
                    {
                        //меняем приоритетное направление левой ячейки на правое
                        mField[x, y - 1].mNapravl.prioritet = 3;

                        //переходим к рассмотрению клетки слева
                        BellmanLetsStep(x, y - 1);
                    }
                }
            }

            //-------------------- верх --------------------

            //если сверху ещё НЕ были И там НЕТ флага, И туда можно идти
            if ((!mField[x, y].mNapravl.m2_verh) &&
                (!BellmanIsFlagHere(x - 1, y)) &&
                (BellmanCanStep(x - 1, y)))
            {
                //помечаем контакт с верхней клеткой
                mField[x, y].mNapravl.m2_verh = true;
                mField[x - 1, y].mNapravl.m4_niz = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (mField[x - 1, y].mCost >
                    (mField[x - 1, y].mProhodCost + mField[x, y].mCost))
                {
                    //заменяем цену
                    mField[x - 1, y].mCost =
                                mField[x - 1, y].mProhodCost + mField[x, y].mCost;

                    //если есть смысл шагать дальше
                    if (BellmanIsSmyslToStep(x - 1, y))
                    {
                        //меняем приоритетное направление верхней ячейки на нижнее
                        mField[x - 1, y].mNapravl.prioritet = 4;

                        //переходим к рассмотрению клетки сверху
                        BellmanLetsStep(x - 1, y);
                    }
                }
            }

            //-------------------- право --------------------

            //если справа ещё НЕ были И там НЕТ флага, И туда можно идти
            if ((!mField[x, y].mNapravl.m3_pravo) &&
                (!BellmanIsFlagHere(x, y + 1)) &&
                (BellmanCanStep(x, y + 1)))
            {
                //помечаем контакт с правой клеткой
                mField[x, y].mNapravl.m3_pravo = true;
                mField[x, y + 1].mNapravl.m1_levo = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (mField[x, y + 1].mCost >
                    (mField[x, y + 1].mProhodCost + mField[x, y].mCost))
                {
                    //заменяем цену
                    mField[x, y + 1].mCost =
                                mField[x, y + 1].mProhodCost + mField[x, y].mCost;

                    //если есть смысл шагать дальше
                    if (BellmanIsSmyslToStep(x, y + 1))
                    {
                        //меняем приоритетное направление правой ячейки на левое
                        mField[x, y + 1].mNapravl.prioritet = 1;

                        //переходим к рассмотрению клетки справа
                        BellmanLetsStep(x, y + 1);
                    }
                }
            }

            //-------------------- низ --------------------

            //если снизу ещё НЕ были И там НЕТ флага, И туда можно идти
            if ((!mField[x, y].mNapravl.m4_niz) &&
                (!BellmanIsFlagHere(x + 1, y)) &&
                (BellmanCanStep(x + 1, y)))
            {
                //помечаем контакт с нижней клеткой
                mField[x, y].mNapravl.m4_niz = true;
                mField[x + 1, y].mNapravl.m2_verh = true;

                //определяем цену этого контакта
                //если цена в ячейке больше,
                //  чем проход по ней + проход по предыдущим ячейкам,
                //  то заменяем цену (на более выгодную - меньшую)
                //иначе вообще не трогаем это направление
                if (mField[x + 1, y].mCost >
                    (mField[x + 1, y].mProhodCost + mField[x, y].mCost))
                {
                    //заменяем цену
                    mField[x + 1, y].mCost =
                                mField[x + 1, y].mProhodCost + mField[x, y].mCost;

                    //если есть смысл шагать дальше
                    if (BellmanIsSmyslToStep(x + 1, y))
                    {
                        //меняем приоритетное направление нижней ячейки на верхнее
                        mField[x + 1, y].mNapravl.prioritet = 2;

                        //переходим к рассмотрению клетки снизу
                        BellmanLetsStep(x + 1, y);
                    }
                }
            }

            //---------------------------------------------

            BellmanNapravlNulling(); //обнуляем направления
        }

        /// <summary>Выбор пути, если он есть (сохранение координат в список)
        /// </summary>
        /// <returns>Возвращает, есть ли путь</returns>
        private bool BellmanVyborPuti()
        {
            Coordinates curCoords; //текущие координаты

            curCoords.x = mPutParams.unitCoords.x;
            curCoords.y = mPutParams.unitCoords.y;

            //если цена в ячейке юнита = (int.MaxValue), значит, путь не найден
            if (mField[curCoords.x, curCoords.y].mCost == int.MaxValue)
                return false;

            //запоминаем цену всего пути
            mPutParams.cost = mField[curCoords.x, curCoords.y].mCost;

            //счётчик для того, чтобы не было зацикливания
            int counter = 0;

            //сохраняем первую координату - положение юнита
            mPutParams.kratPut.Add(mField[curCoords.x, curCoords.y]);

            //пока не наткнёмся на флаг
            while (!BellmanIsFlagHere(curCoords.x, curCoords.y))
            {
                //перебираем приоритетные направления
                switch(mField[curCoords.x, curCoords.y].mNapravl.prioritet)
                {
                    case 1 : //левое
                        curCoords.y -= 1;
                        break;
                    case 2 : //верхнее
                        curCoords.x -= 1;
                        break;
                    case 3 : //правое
                        curCoords.y += 1;
                        break;
                    case 4 : //нижнее
                        curCoords.x += 1;
                        break;
                    default : //иначе - путь не найден
                        return false;
                        //break;
                }

                //сохраняем следующую координату
                mPutParams.kratPut.Add(mField[curCoords.x, curCoords.y]);

                //если счётчик итераций больше возможного числа ходов, то пути нет
                if (++counter > (mHeight * mWidth)) return false;
            }

            return true;
        }

        /// <summary>[ГЛАВНАЯ] Поиск кратчайшего пути методом Беллмана
        /// </summary>
        /// <param name="elem">подразделение, для которого ищем путь</param>
        /// <param name="fC">координаты флага (до куда ищем путь)</param>
        /// <returns>Возвращает, найден путь или нет</returns>
        public bool BellmanPoiskPuti(Division elem, Coordinates fC)
        {
            //инициализация
            BellmanInitPoiskPuti(elem, fC);

            //если ячейка не проходима
            if (!mField[fC.x, fC.y].mProhodima)
                return false;

            //если в ячейке вода, а юнит земной
            if ((mField[fC.x, fC.y].mZemType == CellType.Water) &&
                (!elem.mStepAqua))
                return false;

            //если в ячейке НЕ вода, а юнит водный
            if ((mField[fC.x, fC.y].mZemType != CellType.Water) &&
                (!elem.mStepLand))
                return false;

            //стартуем с флага
            BellmanLetsStep(fC.x, fC.y);

            //выбор пути, если он найден
            return BellmanVyborPuti();
        }

        #endregion

        #region Рисование

        /// <summary>Рисование карты
        /// </summary>
        /// <param name="grf">на чём будем рисовать карту</param>
        /// <returns></returns>
        public void drawMap(Graphics grf)
        {
            //бежим по всем ячейкам
            for (int i = 0; i < mHeight; i++)
            {
                for (int j = 0; j < mWidth; j++)
                {
                    //рисование одной ячейки
                    drawField(grf, i, j);
                }
            }

            //grf.Dispose();
        }

        /// <summary>Рисование одной ячейки
        /// </summary>
        /// <param name="grf">на чём будем рисовать</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        public void drawField(Graphics grf, int i, int j)
        {
            Brush myBrsh;

            switch (mField[i, j].mZemType)
            {
                case CellType.Grass:
                    myBrsh = new SolidBrush(Color.Green);
                    break;
                case CellType.Snow:
                    myBrsh = new SolidBrush(Color.WhiteSmoke);
                    break;
                case CellType.Sand:
                    myBrsh = new SolidBrush(Color.Yellow);
                    break;
                case CellType.Water:
                    myBrsh = new SolidBrush(Color.Blue);
                    break;
                case CellType.Stones:
                    myBrsh = new SolidBrush(Color.Gray);
                    break;
                case CellType.Forest:
                    myBrsh = new SolidBrush(Color.DarkGreen);
                    break;
                case CellType.Road:
                    myBrsh = new SolidBrush(Color.LightGray);
                    break;
                case CellType.Buildings:
                    myBrsh = new SolidBrush(Color.DarkGray);
                    break;
                case CellType.Ice:
                    myBrsh = new SolidBrush(Color.LightBlue);
                    break;
                default:
                    myBrsh = new SolidBrush(Color.White);
                    break;
            }

            //i - строки матрицы (ось OY), j - столбцы (ось OX)
            grf.FillRectangle(myBrsh, j * mFieldWidth, i * mFieldWidth,
                                        mFieldWidth, mFieldWidth);
            myBrsh.Dispose();

            //grf.Dispose();
        }

        /// <summary>Рисования креста (когда путь не найден)
        /// </summary>
        /// <param name="grf">на чём будем рисовать</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <returns></returns>
        public void drawKrest(Graphics grf, int i, int j)
        {
            string image = "img\\features\\Krest.png";
            Image newImage = Image.FromFile(image);
            grf.DrawImage(newImage, j * mFieldWidth, i * mFieldWidth, mFieldWidth, mFieldWidth);

            //grf.Dispose();
        }

        /// <summary>Рисования флага
        /// </summary>
        /// <param name="grf">на чём будем рисовать</param>
        /// <param name="i">координата по высоте</param>
        /// <param name="j">координата по ширине</param>
        /// <param name="atack">присоединение (Add)/атака (Atak)/захват (Capture)/ защита
        /// (Defend)/обычный флаг (F)</param>
        /// <param name="redBlue">цвет (Red/Blue)</param>
        /// <returns></returns>
        public void drawFlag(Graphics grf, int i, int j, string atack, string redBlue)
        {
            string image = "img\\flags\\";

            //если флаг красный, иначе - синий
            image += "Flag" + atack + redBlue + ".png";

            Image newImage = Image.FromFile(image);
            grf.DrawImage(newImage, j * mFieldWidth, i * mFieldWidth, mFieldWidth, mFieldWidth);

            newImage.Dispose();
            //grf.Dispose();
        }

        /// <summary>Рисование пути, в том числе однодневную часть (синим цветом)
        /// </summary>
        /// <param name="grf">на чём будем рисовать</param>
        /// <param name="allPut">весь путь (список координат)</param>
        /// <param name="oneDayPut">однодневный путь (часть всего пути)</param>
        /// <returns></returns>
        public void drawPut(Graphics grf, List<Cell> allPut, List<Cell> oneDayPut)
        {
            Pen myPen = new Pen(Color.Red);

            int x1, y1, x2, y2;

            //рисуем путь на один день
            for (int k = 0; k < (oneDayPut.Count-1); k++)
            {
                x1 = oneDayPut.ElementAt(k).mCoords.y * mFieldWidth + mFieldWidth / 2 + 1;
                y1 = oneDayPut.ElementAt(k).mCoords.x * mFieldWidth + mFieldWidth / 2 + 1;
                x2 = oneDayPut.ElementAt(k+1).mCoords.y * mFieldWidth + mFieldWidth / 2 + 1;
                y2 = oneDayPut.ElementAt(k+1).mCoords.x * mFieldWidth + mFieldWidth / 2 + 1;
                grf.DrawLine(myPen, x1, y1, x2, y2);
            }

            //если однодневный путь не меньше полного, рисуем красный флаг
            if (oneDayPut.Count < allPut.Count)
            {
                myPen.Dispose();
                myPen = new Pen(Color.Blue);

                //рисуем оставшийся путь
                for (int k = (oneDayPut.Count-1); k < (allPut.Count - 1); k++)
                {
                    x1 = allPut.ElementAt(k).mCoords.y * mFieldWidth + mFieldWidth / 2 + 1;
                    y1 = allPut.ElementAt(k).mCoords.x * mFieldWidth + mFieldWidth / 2 + 1;
                    x2 = allPut.ElementAt(k + 1).mCoords.y * mFieldWidth + mFieldWidth / 2 + 1;
                    y2 = allPut.ElementAt(k + 1).mCoords.x * mFieldWidth + mFieldWidth / 2 + 1;
                    grf.DrawLine(myPen, x1, y1, x2, y2);
                }

                //рисуем синий флаг
                //drawFlag(grf, allPut.Last().mCoords.x, allPut.Last().mCoords.y, false);
            }
            /*else
            {
                drawFlag(grf, allPut.Last().mCoords.x, allPut.Last().mCoords.y, true);
                myPen.Dispose();
                return;
            }*/

            myPen.Dispose();
        }

        #endregion

        /// <summary>Определить занятость ячеек
        /// </summary>
        /// <param name="igroki">массив игроков (для доступа к их объектам)</param>
        /// <returns></returns>
        public void fieldZanyatost(Player[] igroki)
        {
            int i, j;

            //Назвать все ячейки свободными
            for (i = 0; i < mHeight; i++)
                for (j = 0; j < mWidth; j++)
                    mField[i, j].mZanyata = false;

            for (int l = 0; l < igroki.GetLength(0); l++)
            {
                //бежим по подразделениям игрока l
                for (int k = 0; k < igroki[l].mElements.Count; k++)
                {
                    i = igroki[l].mElements[k].mCoords.x;
                    j = igroki[l].mElements[k].mCoords.y;
                    mField[i, j].mZanyata = true;
                }

                //бежим по зданиям игрока l
                for (int k = 0; k < igroki[l].mBuildings.Count; k++)
                {
                    i = igroki[l].mBuildings[k].mCoords.x;
                    j = igroki[l].mBuildings[k].mCoords.y;
                    mField[i, j].mZanyata = true;
                }
            }
        }
    }
}
