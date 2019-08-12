
namespace MT.TacticWar.UI.Editor.Painters
{
    interface IPainter
    {
        void Start(int x, int y);

        void Stop();

        /// <summary>Пока активен, рисует непрерывно.</summary>
        bool IsActive();

        /// <returns>Изменились ли координаты.</returns>
        bool TryMove(int x, int y);

        void Paint();
    }
}
