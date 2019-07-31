using System.Collections.Generic;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Landscape;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.Gameplay
{
    public interface IGraphics
    {
        void DrawMap(Map map);

        void DrawArea(Mission mission, Coordinates area, Fog fog);

        void DrawArea(Mission mission, Coordinates[] area, Fog fog);

        void DrawCell(Cell cell);

        void DrawCellOne(Cell cell, Fog fog);

        void DrawCross(Coordinates pt);

        void DrawFlag(Coordinates pt, MoveType moveType, bool isOneday);

        void DrawWay(List<Cell> wayall, int onedayIndex);

        void DrawPlayersObjects(Player[] players, Player currentPlayer, Division selectedDivision, Building selectedBuilding, Fog fog);

        void DrawDivision(Division division, bool selected);

        void DrawBuilding(Building building, bool selected);

        void DrawFog(Fog fog);
    }
}
