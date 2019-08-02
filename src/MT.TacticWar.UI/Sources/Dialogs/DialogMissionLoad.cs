using System;
using System.IO;
using System.Windows.Forms;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Serialization;
using MT.TacticWar.UI.Graphics;

namespace MT.TacticWar.UI.Dialogs
{
    public partial class DialogMissionLoad : Form
    {
        public Mission SelectedMission { get; private set; }

        public DialogMissionLoad()
        {
            InitializeComponent();
            ResetInfo();
        }

        private void ResetInfo()
        {
            SelectedMission = null;

            txtMisName.Text = "";
            txtBriefing.Text = "";
            txtMisMode.Text = "";
            txtMapName.Text = "";
            txtMapSize.Text = "";

            btnLoad.Enabled = false;
        }

        private void DialogMissionLoad_Load(object sender, EventArgs e)
        {
            listMissions.Items.Clear();

            var dir = new DirectoryInfo("missions\\");
            if (dir.Exists)
            {
                var directories = dir.GetDirectories();
                foreach (var dirInfo in directories)
                {
                    var missionInfo = new FileInfo($"missions\\{dirInfo.Name}\\.info");
                    if (missionInfo.Exists)
                        listMissions.Items.Add(dirInfo.Name);
                }

                if (listMissions.Items.Count > 0)
                    listMissions.SelectedIndex = 0;
            }
        }

        private void ListMissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var misName = listMissions.Items[listMissions.SelectedIndex];

                string misFolderPath = $"missions\\{misName}";
                SelectedMission = MissionLoader.LoadGame(misFolderPath);

                txtMisName.Text = SelectedMission.Name;
                txtBriefing.Text = SelectedMission.Briefing;
                txtMisMode.Text = "-";

                btnLoad.Enabled = true;

                // TODO: при первой загрузке дважды вызывается Paint()
                DrawMapSketch();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Миссия повреждена. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetInfo();
            }
        }

        private void DrawMapSketch()
        {
            var grf = pnlMapEskiz.CreateGraphics();
            int cellsize = pnlMapEskiz.Height / SelectedMission.Map.Height;
            var graphics = new GameGraphics(grf, cellsize);

            graphics.DrawMap(SelectedMission.Map);

            txtMapName.Text = SelectedMission.Map.Name;
            txtMapSize.Text = $"{SelectedMission.Map.Width} x {SelectedMission.Map.Height}";
        }

        private void PnlMapSketch_Paint(object sender, PaintEventArgs e)
        {
            if (SelectedMission != null)
                DrawMapSketch();
        }
    }
}
