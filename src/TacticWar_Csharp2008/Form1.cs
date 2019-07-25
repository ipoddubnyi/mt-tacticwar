using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TacticWar
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }        

        private TW_Game.CSimulator SIMUL; //симулятор

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
            SIMUL = new TW_Game.CSimulator("miss\\" + missionName + "\\",
                                igrk0Name, igrk1Name, igrk0AI, igrk1AI);

            //если не было ошибки
            if (SIMUL.mError == "")
            {
                //размеры поля боя и окна
                int oldHei = gameMap.Height; //старые координаты для центровки окна
                int oldWid = gameMap.Width;

                gameMap.Height = SIMUL.mGameMap.mHeight * SIMUL.mGameMap.mFieldWidth + 2;
                gameMap.Width = SIMUL.mGameMap.mWidth * SIMUL.mGameMap.mFieldWidth + 2;

                this.Height = gameMap.Height + 80;
                this.Width = gameMap.Width + propertyGrid1.Width + 50;

                if(oldHei != gameMap.Height)
                    this.Top -= Math.Abs(oldHei - gameMap.Height + 80) / 2;

                if (oldWid != gameMap.Width)
                    this.Left -= Math.Abs(oldWid - gameMap.Width + 50) / 2;

                //рисование карты
                SIMUL.drawAll(gameMap.CreateGraphics());

                //показ брифинга
                MessageBox.Show(SIMUL.mMission.mBriefing, "Брифинг");
            }
            else
            {
                MessageBox.Show(SIMUL.mError, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ESignals signal;

                signal = SIMUL.zonaClick(e.X, e.Y);

                //если собрана информация о юните
                switch (signal)
                {
                    case ESignals.s03_READY_UNIT_INFO:
                        unitInfo();
                        break;
                    case ESignals.s04_ATTACK:
                        attakaElemxElem();
                        break;
                }
            }
        }

        //Заполнить информацию о юнитах
        private void unitInfo()
        {
            if (SIMUL.mUnitInfo.elemId != -1)
                propertyGrid1.SelectedObject = SIMUL.mMasIgroki[SIMUL.mUnitInfo.playerId].mElements[SIMUL.mUnitInfo.elemId];
            else
                propertyGrid1.SelectedObject = SIMUL.mMasIgroki[SIMUL.mUnitInfo.playerId].mBuildings[SIMUL.mUnitInfo.buildId];

            listInfoUnits.Items.Clear();

            //если есть юниты
            if (SIMUL.mUnitInfo.units != null)
            {
                for (int k = 0; k < SIMUL.mUnitInfo.units.Count; k++)
                {
                    listInfoUnits.Items.Add(SIMUL.mUnitInfo.units[k].unit.mName +
                                    " (" + SIMUL.mUnitInfo.units[k].count + ")");
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
            List<TW_Units.CElement> e1 = new List<TacticWar.TW_Units.CElement>();
            List<TW_Units.CElement> e2 = new List<TacticWar.TW_Units.CElement>();

            //----------

            FrmAttack frmAt = new FrmAttack();

            frmAt.elemAtak_name = SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked].mName;
            frmAt.elemDef_name = SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements[SIMUL.mAttackInfo.elemDefended].mName;
            frmAt.elemAtak_units = new List<string>();
            frmAt.elemDef_units = new List<string>();
            frmAt.poddAtak_units = new List<string>();
            frmAt.poddDef_units = new List<string>();

            string item;

            for (int k = 0; k < SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked].mUnits.Count; k++)
            {
                item = SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked].mUnits[k].unit.mName + " (" +
                        + SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked].mUnits[k].count + ")";
                frmAt.elemAtak_units.Add(item);
            }

            for (int k = 0; k < SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements[SIMUL.mAttackInfo.elemDefended].mUnits.Count; k++)
            {
                item = SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements[SIMUL.mAttackInfo.elemDefended].mUnits[k].unit.mName + " (" +
                        + SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements[SIMUL.mAttackInfo.elemDefended].mUnits[k].count + ")";
                frmAt.elemDef_units.Add(item);
            }

            frmAt.win = -1;

            DialogResult dr = frmAt.ShowDialog();

            //----------

            if (dr == DialogResult.OK)
            {
                int win = SIMUL.attackSimulator(SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked],
                                            SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements[SIMUL.mAttackInfo.elemDefended],
                                            e1, e2);

                //MessageBox.Show(a.ToString());

                //после пересчёта параметров нужно снова установить шаги = 0
                SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked].mSteps = 0;
                SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements[SIMUL.mAttackInfo.elemDefended].mSteps = 0;

                //если победил атакующий
                if (win == 1)
                {
                    //удаляем защищавшегося
                    SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements.RemoveAt(SIMUL.mAttackInfo.elemDefended);

                    frmAt.elemAtak_units.Clear();
                    frmAt.elemDef_units.Clear();

                    for (int k = 0; k < SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked].mUnits.Count; k++)
                    {
                        item = SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked].mUnits[k].unit.mName + " (" +
                                +SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked].mUnits[k].count + ")";
                        frmAt.elemAtak_units.Add(item);
                    }

                    //собрать информацию об этом юните
                    SIMUL.setUnitInfo(SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked]);
                    unitInfo();
                }
                else if (win == 2) //если победил защищавшийся
                {
                    //удаляем атакующего
                    SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements.RemoveAt(SIMUL.mAttackInfo.elemAttacked);

                    frmAt.elemAtak_units.Clear();
                    frmAt.elemDef_units.Clear();

                    for (int k = 0; k < SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements[SIMUL.mAttackInfo.elemDefended].mUnits.Count; k++)
                    {
                        item = SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements[SIMUL.mAttackInfo.elemDefended].mUnits[k].unit.mName + " (" +
                                +SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements[SIMUL.mAttackInfo.elemDefended].mUnits[k].count + ")";
                        frmAt.elemDef_units.Add(item);
                    }

                    //выделить победившее подразделение
                    SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].selectElement(SIMUL.mAttackInfo.elemDefended);

                    //собрать информацию об этом юните
                    SIMUL.setUnitInfo(SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mElements[SIMUL.mAttackInfo.elemDefended]);
                    unitInfo();

                    //устанавливаем выделение на защищавшегося
                    SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mSelectedElementId = -1;
                    SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokDefended].mSelectedElementId = SIMUL.mAttackInfo.elemDefended;
                }
                else //ничья
                {
                    //убираем флаг у атакующего
                    SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked].mFlag.x = -1;
                    SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked].mFlag.y = -1;

                    //собрать информацию об этом юните
                    SIMUL.setUnitInfo(SIMUL.mMasIgroki[SIMUL.mAttackInfo.igrokAttacked].mElements[SIMUL.mAttackInfo.elemAttacked]);
                    unitInfo();
                }

                frmAt.win = win;
                frmAt.ShowDialog();
            }

            //----------

            frmAt.Dispose();

            //перерисовываем поле боя
            SIMUL.drawAll(gameMap.CreateGraphics());
        }

        private void gameMap_Paint(object sender, PaintEventArgs e)
        {
            if(SIMUL != null)
                SIMUL.drawAll(gameMap.CreateGraphics());
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
