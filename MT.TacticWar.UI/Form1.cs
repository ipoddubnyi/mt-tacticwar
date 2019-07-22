using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MT.TacticWar.Core;
using MT.TacticWar.Core.Objects;

namespace MT.TacticWar.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }        

        private Simulator SIMUL; //симулятор

        //Дебажная кнопка
        private void button3_Click(object sender, EventArgs e)
        {
            loadMission("Дорога");
        }

        //Загрузка миссии
        private void loadMission(string missionName)
        {
            FrmUsersControl ucForm = new FrmUsersControl();

            if (ucForm.ShowDialog() == DialogResult.OK)
            {
                startSimulator(missionName, ucForm.igrk1Name, ucForm.igrk2Name,
                                ucForm.igrk1AI, ucForm.igrk2AI);
            }

            ucForm.Dispose();
        }

        private void startSimulator(string missionName, string igrk0Name, string igrk1Name,
                                    bool igrk0AI, bool igrk1AI)
        {
            try
            {
                SIMUL = new Simulator("miss\\" + missionName + "\\",
                                    igrk0Name, igrk1Name, igrk0AI, igrk1AI);

                //размеры поля боя и окна
                int oldHei = gameMap.Height; //старые координаты для центровки окна
                int oldWid = gameMap.Width;

                gameMap.Height = SIMUL.Game.Map.Height * GameGraphics.CellSize + 2;
                gameMap.Width = SIMUL.Game.Map.Width * GameGraphics.CellSize + 2;

                this.Height = gameMap.Height + 80;
                this.Width = gameMap.Width + propertyGrid1.Width + 50;

                if (oldHei != gameMap.Height)
                    this.Top -= Math.Abs(oldHei - gameMap.Height + 80) / 2;

                if (oldWid != gameMap.Width)
                    this.Left -= Math.Abs(oldWid - gameMap.Width + 50) / 2;

                //рисование карты
                SIMUL.InitGraphics(gameMap.CreateGraphics());
                SIMUL.drawAll();

                // TODO: показ брифинга
                //MessageBox.Show(SIMUL.Mission.mBriefing, "Брифинг");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gameMap_MouseClick(object sender, MouseEventArgs e)
        {
            //если нажатие не левой кнопкой
            if (e.Button != MouseButtons.Left)
            {
                SIMUL.deselectAll();
                ClearObjectInfo();
            }
            else
            {
                Signals signal;

                signal = SIMUL.ZonaClick(e.X, e.Y);

                //если собрана информация о юните
                switch (signal)
                {
                    case Signals.s03_READY_UNIT_INFO:
                        ShowObjectInfo();
                        break;
                    case Signals.s04_ATTACK:
                        BattleDivisionVsDivision();
                        break;
                }
            }
        }

        // Заполнить информацию о юнитах
        private void ShowObjectInfo()
        {
            ClearObjectInfo();

            if (null != SIMUL.SelectedDivision)
            {
                propertyGrid1.SelectedObject = new DivisionInfo(SIMUL.SelectedDivision);

                foreach (var unitInfo in SIMUL.SelectedDivision.Units)
                {
                    listInfoUnits.Items.Add($"{unitInfo.unit.Name} ({unitInfo.count})");
                }
            }
            else if (null != SIMUL.SelectedBuilding)
            {
                propertyGrid1.SelectedObject = new BuildingInfo(SIMUL.SelectedBuilding);
            }
        }

        // Стереть информацию о юнитах
        private void ClearObjectInfo()
        {
            propertyGrid1.SelectedObject = null;
            listInfoUnits.Items.Clear();
        }

        //Атака
        private void BattleDivisionVsDivision()
        {
            //!!!!!! поддержка - временно отсутствует
            List<Division> e1 = new List<Division>();
            List<Division> e2 = new List<Division>();

            //----------

            FrmAttack frmAt = new FrmAttack();

            frmAt.elemAtak_name = SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked].Name;
            frmAt.elemDef_name = SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions[SIMUL.AttackInfo.DivisionDefended].Name;
            frmAt.elemAtak_units = new List<string>();
            frmAt.elemDef_units = new List<string>();
            frmAt.poddAtak_units = new List<string>();
            frmAt.poddDef_units = new List<string>();

            string item;

            foreach (var unitInfo in SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked].Units)
            {
                item = $"{unitInfo.unit.Name} ({unitInfo.count})";
                frmAt.elemAtak_units.Add(item);
            }

            foreach (var unitInfo in SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions[SIMUL.AttackInfo.DivisionDefended].Units)
            {
                item = $"{unitInfo.unit.Name} ({unitInfo.count})";
                frmAt.elemDef_units.Add(item);
            }

            frmAt.win = -1;

            DialogResult dr = frmAt.ShowDialog();

            //----------

            if (dr == DialogResult.OK)
            {
                int win = SIMUL.attackSimulator(SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked],
                                            SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions[SIMUL.AttackInfo.DivisionDefended],
                                            e1, e2);

                //MessageBox.Show(a.ToString());

                //после пересчёта параметров нужно снова установить шаги = 0
                SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked].Steps = 0;
                SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions[SIMUL.AttackInfo.DivisionDefended].Steps = 0;

                //если победил атакующий
                if (win == 1)
                {
                    //удаляем защищавшегося
                    SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions.RemoveAt(SIMUL.AttackInfo.DivisionDefended);

                    frmAt.elemAtak_units.Clear();
                    frmAt.elemDef_units.Clear();

                    for (int k = 0; k < SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked].Units.Count; k++)
                    {
                        item = SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked].Units[k].unit.Name + " (" +
                                +SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked].Units[k].count + ")";
                        frmAt.elemAtak_units.Add(item);
                    }

                    //собрать информацию об этом юните
                    SIMUL.setUnitInfo(SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked]);
                    ShowObjectInfo();
                }
                else if (win == 2) //если победил защищавшийся
                {
                    //удаляем атакующего
                    SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions.RemoveAt(SIMUL.AttackInfo.DivisionAttacked);

                    frmAt.elemAtak_units.Clear();
                    frmAt.elemDef_units.Clear();

                    for (int k = 0; k < SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions[SIMUL.AttackInfo.DivisionDefended].Units.Count; k++)
                    {
                        item = SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions[SIMUL.AttackInfo.DivisionDefended].Units[k].unit.Name + " (" +
                                +SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions[SIMUL.AttackInfo.DivisionDefended].Units[k].count + ")";
                        frmAt.elemDef_units.Add(item);
                    }

                    //выделить победившее подразделение
                    SIMUL.SelectDivision(SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions[SIMUL.AttackInfo.DivisionDefended]);

                    //собрать информацию об этом юните
                    SIMUL.setUnitInfo(SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions[SIMUL.AttackInfo.DivisionDefended]);
                    ShowObjectInfo();

                    //устанавливаем выделение на защищавшегося
                    SIMUL.SelectedDivision = SIMUL.Game.Players[SIMUL.AttackInfo.PlayerDefended].Divisions[SIMUL.AttackInfo.DivisionDefended];
                }
                else //ничья
                {
                    //убираем флаг у атакующего
                    SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked].Target.X = -1;
                    SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked].Target.Y = -1;

                    //собрать информацию об этом юните
                    SIMUL.setUnitInfo(SIMUL.Game.Players[SIMUL.AttackInfo.PlayerAttacked].Divisions[SIMUL.AttackInfo.DivisionAttacked]);
                    ShowObjectInfo();
                }

                frmAt.win = win;
                frmAt.ShowDialog();
            }

            //----------

            frmAt.Dispose();

            //перерисовываем поле боя
            SIMUL.drawAll();
        }

        private void gameMap_Paint(object sender, PaintEventArgs e)
        {
            if(SIMUL != null)
                SIMUL.drawAll();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //button3_Click(null, null);
        }

        //Меню - Миссия - Загрузить
        private void menuMisLoad_Click(object sender, EventArgs e)
        {
            FrmLoadMission newForm = new FrmLoadMission();

            DialogResult res = newForm.ShowDialog();

            //если миссия выбрана - загрузить
            if (res == DialogResult.OK)
            {
                string missName = newForm.SelectedMissName;
                loadMission(missName);
            }

            newForm.Dispose();
        }
    }
}
