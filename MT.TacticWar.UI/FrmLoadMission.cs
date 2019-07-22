using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MT.TacticWar.UI
{
    public partial class FrmLoadMission : Form
    {
        public FrmLoadMission()
        {
            InitializeComponent();
        }

        private int[,] mapMas; //массив эскиза
        public string SelectedMissName; //название выбранной миссии

        //Загрузка миссии
        private void FrmLoadMission_Load(object sender, EventArgs e)
        {
            mapMas = null;

            listMissions.Items.Clear();

            DirectoryInfo dir = new DirectoryInfo("miss\\");

            //если папка существует
            if (dir.Exists)
            {
                DirectoryInfo[] sourceDirectories = dir.GetDirectories();

                //Перебор миссий
                for (int j = 0; j < sourceDirectories.Length; ++j)
                {
                    FileInfo missionInfo = new FileInfo("miss\\" + sourceDirectories[j].Name +
                                    "\\mission.mis");

                    if (missionInfo.Exists)
                        listMissions.Items.Add(sourceDirectories[j].Name);
                }

                if (listMissions.Items.Count > 0)
                    listMissions.SelectedIndex = 0;
            }
        }

        //Выбор миссии
        private void listMissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                string misFileName = "miss\\" +
                    listMissions.Items[listMissions.SelectedIndex] + "\\mission.mis";

                using (StreamReader sr = new StreamReader(misFileName))
                {
                    //читаем имя миссии
                    txtMisName.Text = sr.ReadLine();

                    //читать путь к карте
                    string pathMap = sr.ReadLine();
                    pathMap = "miss\\" +
                        listMissions.Items[listMissions.SelectedIndex] + "\\" + pathMap;

                    //читать путь к юнитам
                    //mPathUnit = sr.ReadLine();
                    sr.ReadLine();

                    //читать брифинг
                    string line;
                    txtBriefing.Text = "";

                    while ((line = sr.ReadLine()) != "[конец]")
                    {
                        txtBriefing.Text += line + "\r\n";
                    }

                    //читать режим игры
                    switch (int.Parse(sr.ReadLine()))
                    {
                        case 0:
                        default:
                            txtMisMode.Text = "Убить их всех";
                            break;
                    }

                    //читать карту
                    if (loadMap(pathMap))
                    {
                        drawEskiz();
                        SelectedMissName = listMissions.SelectedItem.ToString();
                        btnLoad.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Карта повреждена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnLoad.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Миссия повреждена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Загрузить эскиз карты
        private bool loadMap(string pathMap)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(pathMap))
                {
                    //читать имя карты
                    txtMapName.Text = sr.ReadLine();

                    //читать размеры карты
                    int hei = int.Parse(sr.ReadLine());
                    int wid = int.Parse(sr.ReadLine());
                    mapMas = new int[hei, wid];
                    txtMapSize.Text = "(" + wid + ", " + hei + ")";

                    //читать схему земли
                    sr.ReadLine();

                    //загрузить карту
                    string line;

                    for (int k = 0; k < hei; k++)
                    {
                        line = sr.ReadLine();

                        //бежим по ячейкам в строке
                        for (int l = 0; l < wid; l++)
                        {
                            mapMas[k, l] = int.Parse(line.Substring(l, 1));
                        }
                    }

                    //дальше не читаем
                }
            }
            catch (Exception)
            {
                //Ошибка загрузки карты
                return false;
            }

            return true;
        }

        //Нарисовать эскиз карты
        private void drawEskiz()
        {
            Graphics grf = pnlMapEskiz.CreateGraphics();
            SolidBrush brsh = new SolidBrush(Color.Black);

            float fieldHei = (float)pnlMapEskiz.Height / (float)mapMas.GetLength(0);
            float fieldWid = (float)pnlMapEskiz.Width / (float)mapMas.GetLength(1);

            for (int i = 0; i < mapMas.GetLength(0); i++)
            {
                for (int j = 0; j < mapMas.GetLength(1); j++)
                {
                    switch (mapMas[i, j])
                    {
                        case 0: //трава
                            brsh.Color = Color.Green;
                            break;
                        case 1: //снег
                            brsh.Color = Color.WhiteSmoke;
                            break;
                        case 2: //песок
                            brsh.Color = Color.Yellow;
                            break;
                        case 3: //вода
                            brsh.Color = Color.Blue;
                            break;
                        case 4: //камни
                            brsh.Color = Color.Gray;
                            break;
                        case 5: //лес
                            brsh.Color = Color.DarkGreen;
                            break;
                        case 6: //дорога
                            brsh.Color = Color.LightGray;
                            break;
                        case 7: //строения
                            brsh.Color = Color.DarkGray;
                            break;
                        case 8: //лёд
                            brsh.Color = Color.LightBlue;
                            break;
                        default: //иначе
                            brsh.Color = Color.White;
                            break;
                    }

                    grf.FillRectangle(brsh, j * fieldWid, i * fieldHei, fieldWid, fieldHei);
                }
            }

            brsh.Dispose();
            //??? grf.Dispose();
        }

        //Перерисовать карту
        private void pnlMapEskiz_Paint(object sender, PaintEventArgs e)
        {
            if(mapMas != null)
                drawEskiz();
        }
    }
}
