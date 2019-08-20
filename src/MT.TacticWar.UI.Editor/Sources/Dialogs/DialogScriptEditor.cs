using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MT.TacticWar.Core.Base.Scripts;
using MT.TacticWar.Core.Scripts;

namespace MT.TacticWar.UI.Editor.Dialogs
{
    public partial class DialogScriptEditor : Form
    {
        public Script Script { get; private set; }

        private ScriptArgument[] conditionParameters;
        private ScriptArgument[] statementParameters;

        public DialogScriptEditor(Script script = null)
        {
            InitializeComponent();

            conditionParameters = new ScriptArgument[0];
            statementParameters = new ScriptArgument[0];

            comboConditionType.DataSource = null;
            comboConditionType.Items.Clear();
            comboConditionType.DataSource = ScriptFactory.Conditions;

            comboStatementType.DataSource = null;
            comboStatementType.Items.Clear();
            comboStatementType.DataSource = ScriptFactory.Statements;

            if (null != script)
            {
                txtDescription.Text = script.Description;

                var code = ScriptFactory.GetScriptConditionCode(script.Condition);
                foreach (var cond in ScriptFactory.Conditions)
                {
                    if (cond.Code.Equals(code))
                    {
                        comboConditionType.SelectedItem = cond;
                        break;
                    }
                }

                code = ScriptFactory.GetScriptStatementCode(script.Statement);
                foreach (var st in ScriptFactory.Statements)
                {
                    if (st.Code.Equals(code))
                    {
                        comboStatementType.SelectedItem = st;
                        break;
                    }
                }

                conditionParameters = ScriptArgument.GetArguments(script.Condition);
                statementParameters = ScriptArgument.GetArguments(script.Statement);
            }

            ListConditionParamsRefresh();
            ListStatementParamsRefresh();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ListConditionParamsRefresh()
        {
            listConditionParams.DataSource = null;
            listConditionParams.Items.Clear();
            listConditionParams.DataSource = conditionParameters;
        }

        private void ListStatementParamsRefresh()
        {
            listStatementParams.DataSource = null;
            listStatementParams.Items.Clear();
            listStatementParams.DataSource = statementParameters;
        }

        private void ComboConditionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != comboConditionType.SelectedItem)
            {
                var condition = (ScriptConditionVariant)comboConditionType.SelectedItem;
                conditionParameters = ScriptArgument.GetArguments(condition.Type);
                ListConditionParamsRefresh();
            }
        }

        private void ComboStatementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != comboStatementType.SelectedItem)
            {
                var statement = (ScriptStatementVariant)comboStatementType.SelectedItem;
                statementParameters = ScriptArgument.GetArguments(statement.Type);
                ListStatementParamsRefresh();
            }
        }

        private void ListConditionParams_DoubleClick(object sender, EventArgs e)
        {
            if (listConditionParams.SelectedIndex >= 0)
            {
                var param = conditionParameters[listConditionParams.SelectedIndex];
                using (var dialog = new DialogScriptParamInput(param.Name, param.Value))
                {
                    if (DialogResult.OK == dialog.ShowDialog())
                    {
                        param.Value = dialog.Value;
                        conditionParameters[listConditionParams.SelectedIndex] = param;
                        ListConditionParamsRefresh();
                    }
                }
            }
        }

        private void ListStatementParams_DoubleClick(object sender, EventArgs e)
        {
            if (listStatementParams.SelectedIndex >= 0)
            {
                var param = statementParameters[listStatementParams.SelectedIndex];
                using (var dialog = new DialogScriptParamInput(param.Name, param.Value))
                {
                    if (DialogResult.OK == dialog.ShowDialog())
                    {
                        param.Value = dialog.Value;
                        statementParameters[listStatementParams.SelectedIndex] = param;
                        ListStatementParamsRefresh();
                    }
                }
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateEntries())
                DialogResult = DialogResult.None;

            var condition = (ScriptConditionVariant)comboConditionType.SelectedItem;
            var statement = (ScriptStatementVariant)comboStatementType.SelectedItem;

            Script = new Script(
                    txtDescription.Text,
                    condition.Create(GetParametersValues(conditionParameters)),
                    statement.Create(GetParametersValues(statementParameters))
                );
        }

        private bool ValidateEntries()
        {
            if (0 == txtDescription.Text.Length)
            {
                ShowError("Описание скрипта не может быть пустым.");
                return false;
            }

            if (null == comboConditionType.SelectedItem)
            {
                ShowError("Условие не задано.");
                return false;
            }

            if (null == comboStatementType.SelectedItem)
            {
                ShowError("Действие не задано.");
                return false;
            }

            return true;
        }

        private string[] GetParametersValues(ScriptArgument[] parameters)
        {
            var result = new List<string>();

            foreach (var param in parameters)
                result.Add(param.Value);
            
            return result.ToArray();
        }
    }
}
