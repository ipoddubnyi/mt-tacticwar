using System.Linq;

namespace MT.TacticWar.Core
{
    // Структура с условиями победы/поражения
    public struct MissionManage
    {
        int playerWinner;   //ид игрока-победителя (0 - никто, 3 - союзник, 4 - нейтрал)

        #region KILL THEM ALL

        // Конец ли игры (перегруженная функция)
        private MissionStatus IsEndKillThemAll(Player player1, Player player2)
        {
            byte tmp = 0;

            //если у игрока 1 не осталось подразделений
            if (player1.Divisions.Count < 1)
                tmp = 2;

            //если у игрока 2 не осталось подразделений
            if (player1.Divisions.Count < 1)
                tmp += 1;

            //проверка побед
            switch (tmp)
            {
                case 1: //победил 1
                    playerWinner = 1;
                    return MissionStatus.MissionComplete;
                case 2: //победил 2
                    playerWinner = 2;
                    return MissionStatus.MissionFailed;
                case 3: //ничья
                    playerWinner = 0;
                    return MissionStatus.MissionDraw;
            }

            //иначе, пока не конец
            playerWinner = 0;
            return MissionStatus.InProgress;
        }

        #endregion

        #region KILL THE OBJECT

        int objectKillig;  //ид юнита, которого нужно уничтожить

        // Конец ли игры (перегруженная функция)
        private MissionStatus IsEndKillTheObject(Player player1, Player player2)
        {
            //если у игрока 1 не осталось подразделений
            if (player1.Divisions.Count < 1)
            {
                playerWinner = 2;
                return MissionStatus.MissionFailed;
            }

            bool objectAlive = false;

            //если у игрока 2 не осталось подразделений
            for (int i = 0; i < player1.Divisions.Count; i++)
            {
                //если объект ещё есть в списке живых
                if (player1.Divisions.ElementAt(i).Id == objectKillig)
                    objectAlive = true;
            }

            //если объекта нет в списке живых
            if (!objectAlive)
            {
                playerWinner = 1;
                return MissionStatus.MissionComplete;
            }

            //иначе, пока не конец
            playerWinner = 0;
            return MissionStatus.InProgress;
        }

        #endregion

        // Проверить игру на окончание
        public MissionStatus CheckGameOver(MissionMode gameMode, Player player1, Player player2)
        {
            //выбираем режим игры
            switch (gameMode)
            {
                case MissionMode.KillThemAll:
                    return IsEndKillThemAll(player1, player2);
                case MissionMode.DestroyTheTarget:
                    return IsEndKillTheObject(player1, player2);
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
