using System.Windows.Forms;
using MT.TacticWar.Gameplay;

namespace MT.TacticWar.UI
{
    public class GameInteration : IInteraction
    {
        public void ShowMessage(string text)
        {
            MessageBox.Show(text, "Сообщение");
        }
        public void ShowMessage(string text, string caption)
        {
            MessageBox.Show(text, caption);
        }
    }
}
