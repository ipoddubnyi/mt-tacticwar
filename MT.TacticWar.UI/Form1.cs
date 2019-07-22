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

                gameMap.Height = SIMUL.Map.Height * GameGraphics.CellSize + 2;
                gameMap.Width = SIMUL.Map.Width * GameGraphics.CellSize + 2;

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
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gameMap_MouseClick(object sender, MouseEventArgs e)
        {
            //если нажатие не левой кнопкой
            if (e.Button != MouseButtons.Left)
            {
                SIMUL.deselectAll();
                unitInfoClear();
            }
            else
            {
                Signals signal;

                signal = SIMUL.ZonaClick(e.X, e.Y);

                //если собрана информация о юните
                switch (signal)
                {
                    case Signals.s03_READY_UNIT_INFO:
                        unitInfo();
                        break;
                    case Signals.s04_ATTACK:
                        attakaElemxElem();
                        break;
                }
            }
        }

        //Заполнить информацию о юнитах
        private void unitInfo()
        {
            if (SIMUL.SelectedUnitInfo.elemId != -1)
                propertyGrid1.SelectedObject = SIMUL.Players[SIMUL.SelectedUnitInfo.playerId].Divisions[SIMUL.SelectedUnitInfo.elemId];
            else
                propertyGrid1.SelectedObject = SIMUL.Players[SIMUL.SelectedUnitInfo.playerId].Buildings[SIMUL.SelectedUnitInfo.buildId];

            listInfoUnits.Items.Clear();

            //если есть юниты
            if (SIMUL.SelectedUnitInfo.units != null)
            {
                for (int k = 0; k < SIMUL.SelectedUnitInfo.units.Count; k++)
                {
                    listInfoUnits.Items.Add(SIMUL.SelectedUnitInfo.units[k].unit.Name +
                                    " (" + SIMUL.SelectedUnitInfo.units[k].count + ")");
                }
            }
        }

        //Стереть информацию о юнитах
        private void unitInfoClear()
        {
            propertyGrid1.SelectedObject = null;

            listInfoUnits.Items.Clear();
        }

        //Атака
        private void attakaElemxElem()
        {
            //!!!!!! поддержка - временно отсутствует
            List<Division> e1 = new List<Division>();
            List<Division> e2 = new List<Division>();

            //----------

            FrmAttack frmAt = new FrmAttack();

            frmAt.elemAtak_name = SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked].Name;
            frmAt.elemDef_name = SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended].Name;
            frmAt.elemAtak_units = new List<string>();
            frmAt.elemDef_units = new List<string>();
            frmAt.poddAtak_units = new List<string>();
            frmAt.poddDef_units = new List<string>();

            string item;

            for (int k = 0; k < SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked].Units.Count; k++)
            {
                item = SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked].Units[k].unit.Name + " (" +
                        + SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked].Units[k].count + ")";
                frmAt.elemAtak_units.Add(item);
            }

            for (int k = 0; k < SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended].Units.Count; k++)
            {
                item = SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended].Units[k].unit.Name + " (" +
                        + SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended].Units[k].count + ")";
                frmAt.elemDef_units.Add(item);
            }

            frmAt.win = -1;

            DialogResult dr = frmAt.ShowDialog();

            //----------

            if (dr == DialogResult.OK)
            {
                int win = SIMUL.attackSimulator(SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked],
                                            SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended],
                                            e1, e2);

                //MessageBox.Show(a.ToString());

                //после пересчёта параметров нужно снова установить шаги = 0
                SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked].Steps = 0;
                SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended].Steps = 0;

                //если победил атакующий
                if (win == 1)
                {
                    //удаляем защищавшегося
                    SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions.RemoveAt(SIMUL.AttackInfo.elemDefended);

                    frmAt.elemAtak_units.Clear();
                    frmAt.elemDef_units.Clear();

                    for (int k = 0; k < SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked].Units.Count; k++)
                    {
                        item = SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked].Units[k].unit.Name + " (" +
                                +SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked].Units[k].count + ")";
                        frmAt.elemAtak_units.Add(item);
                    }

                    //собрать информацию об этом юните
                    SIMUL.setUnitInfo(SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked]);
                    unitInfo();
                }
                else if (win == 2) //если победил защищавшийся
                {
                    //удаляем атакующего
                    SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions.RemoveAt(SIMUL.AttackInfo.elemAttacked);

                    frmAt.elemAtak_units.Clear();
                    frmAt.elemDef_units.Clear();

                    for (int k = 0; k < SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended].Units.Count; k++)
                    {
                        item = SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended].Units[k].unit.Name + " (" +
                                +SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended].Units[k].count + ")";
                        frmAt.elemDef_units.Add(item);
                    }

                    //выделить победившее подразделение
                    SIMUL.SelectDivision(SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended]);

                    //собрать информацию об этом юните
                    SIMUL.setUnitInfo(SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended]);
                    unitInfo();

                    //устанавливаем выделение на защищавшегося
                    SIMUL.SelectedDivision = SIMUL.Players[SIMUL.AttackInfo.igrokDefended].Divisions[SIMUL.AttackInfo.elemDefended];
                }
                else //ничья
                {
                    //убираем флаг у атакующего
                    SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked].Target.X = -1;
                    SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked].Target.Y = -1;

                    //собрать информацию об этом юните
                    SIMUL.setUnitInfo(SIMUL.Players[SIMUL.AttackInfo.igrokAttacked].Divisions[SIMUL.AttackInfo.elemAttacked]);
                    unitInfo();
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
