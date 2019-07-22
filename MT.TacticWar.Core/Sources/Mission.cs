using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MT.TacticWar.Core.Types.Mission;

namespace MT.TacticWar.Core
{
    public class Mission
    {
        public string mName;        //имя миссии

        public string mPathMap;     //путь к файлу карты
        //public string mPathUnit;  //путь к файлу юнитов
        public int mCountIgroki;    //число игроков

        public string mBriefing;    //миссия
        public MissionMode mGameMode; //режим игры
        public MissionManage mManage;        //структура управления миссией

        public string mError;       //ошибка

        //********************************************************************************

        public Mission()
        {
            mError = "";
        }
    }
}
