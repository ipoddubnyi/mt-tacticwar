using System;
using System.Windows.Forms;
using MT.TacticWar.Core.Base.Landscape;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogMapNew : Form
    {
        private const int WidthMin = 5;
        private const int WidthMax = 25;
        private const int HeightMin = 5;
        private const int HeightMax = 25;

        public int MapSizeWidth { get; private set; }
        public int MapSizeHeight { get; private set; }
        public string MapSchema { get; private set; }
        public string MapName { get; private set; }
        public string MapDescription { get; private set; }

        public DialogMapNew()
        {
            InitializeComponent();

            var schemas = LandscapeFactory.GetAvailableSchema();
            comboMapSchema.Items.Clear();
            comboMapSchema.DataSource = new BindingSource(schemas, null);
            comboMapSchema.DisplayMember = "Key";
            comboMapSchema.ValueMember = "Value";
        }

        private void DialogMapNew_Load(object sender, EventArgs e)
        {
            MapSizeWidth = 0;
            MapSizeHeight = 0;
            MapSchema = "";
            MapName = "";
            MapDescription = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                DialogResult = DialogResult.None;
        }

        private bool ValidateEntries()
        {
            if (!int.TryParse(txtSizeWidth.Text, out int width))
            {
                ShowError("Неверное значение ширины карты.");
                return false;
            }

            if (width < WidthMin || width > WidthMax)
            {
                ShowError($"Ширины карты должна быть от {WidthMin} до {WidthMax}.");
                return false;
            }

            if (!int.TryParse(txtSizeHeight.Text, out int height))
            {
                ShowError("Неверное значение высоты карты.");
                return false;
            }

            if (height < HeightMin || height > HeightMax)
            {
                ShowError($"Высоты карты должна быть от {HeightMin} до {HeightMax}.");
                return false;
            }

            if (0 == txtMapName.Text.Length)
            {
                ShowError("Название карты не может быть пустым.");
                return false;
            }

            MapSizeWidth = width;
            MapSizeHeight = height;
            MapSchema = comboMapSchema.SelectedValue.ToString();
            MapName = txtMapName.Text;
            MapDescription = txtMapDescription.Text;

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
