using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalManager.PL;
using MedicalManager.Entities;

namespace MedicalManager.Controls
{
    public partial class ControlLaborant : UserControl
    {
        int selectedIndex = 0;

        public ControlLaborant()
        {
            InitializeComponent();
            comboBoxAnalysisTypes.DataSource = LogicProvider.Logic.GetAnalysisTypes();
        }

        private void comboBoxAnalysisTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxAnalyses.DataSource = LogicProvider.Logic.GetAnalysesByTypeId((comboBoxAnalysisTypes.SelectedItem as AnalysisType).Id);
        }

        private void timerUpdateInfo_Tick(object sender, EventArgs e)
        {
            selectedIndex = (listBoxAnalyses.SelectedIndex >= 0 ? listBoxAnalyses.SelectedIndex : 0);
            listBoxAnalyses.DataSource = LogicProvider.Logic.GetAnalysesByTypeId((comboBoxAnalysisTypes.SelectedItem as AnalysisType).Id);
            if (selectedIndex < listBoxAnalyses.Items.Count)
            {
                listBoxAnalyses.SetSelected(selectedIndex, true);
            }
        }

        private void listBoxAnalyses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labelRequestNumber.Text = $"Заявка № {(listBoxAnalyses.SelectedItem as Analysis).Id}";
            }
            catch(Exception ex)
            {
                labelRequestNumber.Text = "...";
            }
        }

        private void buttonFillAnalysis_Click(object sender, EventArgs e)
        {
            bool analysisFilled = listBoxAnalyses.SelectedItem != null && LogicProvider.Logic.SetConclusionByAnalysisId((listBoxAnalyses.SelectedItem as Analysis).Id, textBoxConclusion.Text);
            string message = (analysisFilled? "Результат анализа успешно добавлен.":"Не удалось добавить результат анализа. Обратитесь к администратору.");
            MessageBox.Show(message, "Уведомление");
            if (analysisFilled)
            {
                textBoxConclusion.Text = string.Empty;
            }

            listBoxAnalyses.DataSource = LogicProvider.Logic.GetAnalysesByTypeId((comboBoxAnalysisTypes.SelectedItem as AnalysisType).Id);
        }
    }
}
