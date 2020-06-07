using MedicalManager.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalManager
{
    public partial class FormReport : Form
    {
        public FormReport(int HistoryId)
        {
            InitializeComponent();
            textBoxReport.Text = LogicProvider.Logic.GetReportText(HistoryId);
        }
    }
}
