using System;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.Core.Base.Scripts
{
    [Script("Переместить подразделение", Code = "movedivision")]
    public class MoveDivisionStatement : IStatement
    {
        [ScriptArgument("Игрок")]
        private int PlayerId { get; set; }

        [ScriptArgument("Подразделение")]
        private int DivisionId { get; set; }

        [ScriptArgument("Координата X")]
        private int X { get; set; }

        [ScriptArgument("Координата Y")]
        private int Y { get; set; }

        public MoveDivisionStatement(params string[] args)
        {
            if (4 != args.Length)
                throw new FormatException("Неверный формат выражения.");

            PlayerId = int.Parse(args[0]);
            DivisionId = int.Parse(args[1]);
            X = int.Parse(args[2]);
            Y = int.Parse(args[3]);
        }

        public ISituation Execute(Mission mission)
        {
            var division = mission.Players.GetById(PlayerId).Divisions.GetById(DivisionId);
            if (null != division)
                division.Position = new Coordinates(X, Y);

            return null;
        }
    }
}
