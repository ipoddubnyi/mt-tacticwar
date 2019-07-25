using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TacticWar.TW_Mission
{
    //Миссия
    class CMission
    {
        public string mName;        //имя миссии

        public string mPathMap;     //путь к файлу карты
        //public string mPathUnit;  //путь к файлу юнитов
        public int mCountIgroki;    //число игроков

        public string mBriefing;    //миссия
        public EGameMode mGameMode; //режим игры
        public SMode mManage;        //структура управления миссией

        public string mError;       //ошибка

        //********************************************************************************

        /// <summary>Конструктор
        /// </summary>
        /// <param name="filePath">путь к файлу миссии</param>
        /// <returns></returns>
        public CMission(string filePath)
        {
            mError = "";

            if (!loadMission(filePath))
                return; 
        }

        //********************************************************************************

        /// <summary>Загрузка миссии
        /// </summary>
        /// <param name="misFileName">путь к файлу миссии</param>
        /// <returns>Возвращает (false), если возникла ошибка</returns>
        private bool loadMission(string misFileName)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(misFileName))
                {
                    //читаем имя миссии
                    mName = sr.ReadLine();

                    //читать путь к карте
                    mPathMap = sr.ReadLine();

                    //читать путь к юнитам
                    //mPathUnit = sr.ReadLine();
                    mCountIgroki = int.Parse(sr.ReadLine());

                    //читать брифинг
                    string line;
                    mBriefing = "";

                    while ((line = sr.ReadLine()) != "[конец]")
                    {
                        mBriefing += line + "\r\n";
                    }

                    //читать режим игры
                    switch (int.Parse(sr.ReadLine()))
                    {
                        case 0:
                        default:
                            mGameMode = EGameMode.gm0_KILL_THEM_ALL;
                            break;
                    }

                    //!!!!!!!!!!!! читать параметры игры !!!!!!!!!!!!!!
                }
            }
            catch (Exception e)
            {
                mError = "Ошибка загрузки миссии";
                return false;
            }

            return true;
        }
    }
}
