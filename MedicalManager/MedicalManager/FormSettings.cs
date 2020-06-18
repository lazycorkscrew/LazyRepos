using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalManager.PL;

namespace MedicalManager
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            textBoxConnectionString.Text = LogicProvider.Logic.GetDBConnectionString();
        }

        private void buttonSaveConnectionString_Click(object sender, EventArgs e)
        {
            bool connectionStringChanged = LogicProvider.Logic.SetDBConnectionString(textBoxConnectionString.Text);
            string message = (connectionStringChanged ? "Строка подключения успешно изменена." : "Не удалось изменить строку подключения.");
            MessageBox.Show(message, "Уведомление");

            if(connectionStringChanged)
            {
                Close();
            }
        }
    }
}
