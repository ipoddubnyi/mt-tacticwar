
namespace MT.TacticWar.Core
{
    /// <summary>
    /// Режимы миссии.
    /// </summary>
    public enum MissionMode
    {
        /// <summary>
        /// Игроку 1 нужно уничтожить все юниты игрока 2.
        /// Игроку 2 нужно уничтожить все юниты игрока 1.
        /// </summary>
        KillThemAll,

        /// <summary>
        /// Игроку 1 нужно уничтожить один объект врага (именно уничтожить).
        /// Игроку 2 нужно защитить этот объект (уничтожить все юниты игрока 1).
        /// </summary>
        DestroyTheTarget,

        /// <summary>
        /// Игроку 1 нужно захватить строение игрока 2.
        /// Игроку 2 нужно защитить строение (уничтожить все юниты игрока 1).
        /// </summary>
        CaptureTheBuilding,

        /// <summary>
        /// Игроку 1 нужно защитить объект (уничтожить все юниты игрока 2).
        /// Игроку 2 нужно уничтожить этот объект.
        /// </summary>
        DefendTheTarget,

        /// <summary>
        /// Игроку 1 нужно захватить флаг игрока 2 и принести его на базу.
        /// Игроку 2 нужно захватить флаг игрока 1 и принести его на базу.
        /// </summary>
        CaptureTheFlag,

        /// <summary>
        /// Игрокам нужно захватить все зоны (дерижабли) на карте или уничтожить противника.
        /// </summary>
        CaptureZones
    };
}

public static string AsString(this MissionMode mode)
{
    switch (mode)
    {
        case MissionMode.KillThemAll:
            return "Убить их всех";
        case MissionMode.DestroyTheTarget:
            return "Уничтожение цели";
        case MissionMode.CaptureTheBuilding:
            return "Захат здания";
        case MissionMode.DefendTheTarget:
            return "Защита здания";
        case MissionMode.CaptureTheFlag:
            return "Захват флага";
        case MissionMode.CaptureZones:
            return "Захват зон";
    }

    throw new Exception("Неизвестный режим миссии.");
}
