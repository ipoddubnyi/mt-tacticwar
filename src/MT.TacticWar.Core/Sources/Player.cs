using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MT.TacticWar.Core.Players;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Core
{
    public class Player
    {
        ForceSide Type;             //кто игрок (игрок 1, 2, союзник, нейтрал)
        PlayerIntelligence AI;           //искусственный интелект

        public string Name;                   //имя
        public int Id;                        //номер игрока
        //System.Drawing.Color mColor;  //цвет юнитов игрока
        public bool IsPlaying;                   //играет ли данный игрок (возможно, уже проиграл)
        public PlayerRank Rank;                    //уровень игрока. В зависимости от него игрок может формировать новые подразделения

        public int Money;                   //ресурсы, за которые игрок может ремонтировать войска и покупать новое вооружение

        public List<Division> Divisions;   //список подразделение
        public List<Building> Buildings;  //список структур

        public List<Gate> Gates;     //ворота для выхода подкреплений

        public Player(int id)
        {
            if(id == 0)
                Type = ForceSide.Ours;     //кто игрок (игрок 1, 2, союзник, нейтрал)
            else if(id == 1)
                Type = ForceSide.Enemy;

            AI = PlayerIntelligence.Human;   //искусственный интелект

            Name = "Игрок";                   //имя
            Id = id;                        //номер игрока
            //System.Drawing.Color mColor;  //цвет юнитов игрока
            IsPlaying = true;                   //играет ли данный игрок (возможно, уже проиграл)
            Rank = PlayerRank.Soldier;                    //уровень игрока. В зависимости от него игрок может формировать новые подразделения

            Money = Money + 10000;                   //ресурсы, за которые игрок может ремонтировать войска и покупать новое вооружение

            Divisions = new List<Division>();      //список подразделение
            Buildings = new List<Building>();     //список структур

            Gates = new List<Gate>();
        }

        /// <summary>Конструктор
        /// </summary>
        /// <param name="id">ид игрока</param>
        /// <param name="name">имя игрока</param>
        /// <param name="AI">управление ИИ</param>
        /// <param name="filePath">путь к файлу с объектами игрока</param>
        /// <returns></returns>
        public Player(int id, string name, bool AI)
        {
            //номер игрока
            Id = id;

            //тип игрока
            switch (Id)
            {
                case 0:
                    Type = ForceSide.Ours;
                    break;
                case 1:
                    Type = ForceSide.Enemy;
                    break;
                case 2:
                    Type = ForceSide.Allies;
                    break;
                case 3:
                    Type = ForceSide.Neutral;
                    break;
                default:
                    Type = ForceSide.Unknown;
                    break;
            }

            //имя
            Name = name;

            //искусственный интеллект
            if (AI)
                this.AI = PlayerIntelligence.AI;
            else
                this.AI = PlayerIntelligence.Human;

            IsPlaying = true; //играет ли данный игрок (возможно, уже проиграл)
        }

        public Division GetDivisionAt(int x, int y)
        {
            return Divisions.GetAt(new Coordinates(x, y));
        }

        public Building GetBuildingAt(int x, int y)
        {
            return Buildings.GetAt(new Coordinates(x, y));
        }

        public void ResetDivisionsParams()
        {
            foreach (var division in Divisions)
            {
                division.ResetParams();
            }
        }
    }
}
