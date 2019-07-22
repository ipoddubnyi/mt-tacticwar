using System.Linq;

namespace MT.TacticWar.Core.Types
{
    // Структура с условиями победы/поражения
    public struct MissionManage
    {
        int idOfWinIgrok;   //ид игрока-победителя (0 - никто, 3 - союзник, 4 - нейтрал)

        #region 0 KILL THEM ALL

        //Конец ли игры (перегруженная функция)
        private MissionStatus isEnd(Player igrk1, Player igrk2)
        {
            byte tmp = 0;

            //если у игрока 1 не осталось подразделений
            if (igrk1.Divisions.Count < 1)
                tmp = 2;

            //если у игрока 2 не осталось подразделений
            if (igrk1.Divisions.Count < 1)
                tmp += 1;

            //проверка побед
            switch (tmp)
            {
                case 1: //победил 1
                    idOfWinIgrok = 1;
                    return MissionStatus.MissionComplete;
                case 2: //победил 2
                    idOfWinIgrok = 2;
                    return MissionStatus.MissionFailed;
                case 3: //ничья
                    idOfWinIgrok = 0;
                    return MissionStatus.MissionDraw;
            }

            //иначе, пока не конец
            idOfWinIgrok = 0;
            return MissionStatus.InProgress;
        }

        #endregion

        #region KILL THE OBJECT

        int idOfKillingObject;  //ид юнита, которого нужно уничтожить

        //Конец ли игры (перегруженная функция)
        private MissionStatus isEnd_gm1(Player igrk1, Player igrk2)
        {
            //если у игрока 1 не осталось подразделений
            if (igrk1.Divisions.Count < 1)
            {
                idOfWinIgrok = 2;
                return MissionStatus.MissionFailed;
            }

            bool objectAlive = false;

            //если у игрока 2 не осталось подразделений
            for (int i = 0; i < igrk1.Divisions.Count; i++)
            {
                //если объект ещё есть в списке живых
                if (igrk1.Divisions.ElementAt(i).Id == idOfKillingObject)
                    objectAlive = true;
            }

            //если объекта нет в списке живых
            if (!objectAlive)
            {
                idOfWinIgrok = 1;
                return MissionStatus.MissionComplete;
            }

            //иначе, пока не конец
            idOfWinIgrok = 0;
            return MissionStatus.InProgress;
        }

        #endregion

        //Проверить игру на окончание
        public MissionStatus checkGameOver(MissionMode gameMode, Player igrk1, Player igrk2)
        {
            //выбираем режим игры
            switch (gameMode)
            {
                case MissionMode.KillThemAll:
                    return isEnd(igrk1, igrk2);
                case MissionMode.DestroyTheTarget:
                    return isEnd_gm1(igrk1, igrk2);
                case MissionMode.CaptureTheBuilding:
                    break;
                case MissionMode.DefendTheTarget:
                    break;
                case MissionMode.CaptureTheFlag:
                    break;
                case MissionMode.CaptureZones:
                    break;
                default:
                    break;
            }

            return MissionStatus.InProgress;
        }
    }
}
