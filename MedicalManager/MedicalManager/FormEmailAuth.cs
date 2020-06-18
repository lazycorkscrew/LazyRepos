using MedicalManager.Entities;
using MedicalManager.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalManager
{
    public partial class FormEmailAuth : Form
    {
        public FormEmailAuth()
        {
            InitializeComponent();
            EmailSettings emailSettings = LogicProvider.Logic.GetEmailSettings();
            textBoxHost.Text = emailSettings.Host;
            numericUpDownPort.Value = emailSettings.Port;
            textBoxEmail.Text = emailSettings.Address;
            textBoxPassword.Text = emailSettings.Password;
            checkBoxEnableSSL.Checked = emailSettings.EnableSSL;

        }

        private void buttonSaveEmailSettings_Click(object sender, EventArgs e)
        {
            bool settingsSaved = LogicProvider.Logic.SetEmailSettings
                (new EmailSettings
                {
                    Host = textBoxHost.Text,
                    Port = numericUpDownPort.Value,
                    Address = textBoxEmail.Text,
                    Password = textBoxPassword.Text,
                    EnableSSL = checkBoxEnableSSL.Checked

                });

            string message = (settingsSaved ? "Настройки электронной почты успешно сохранены." : "Не удалось сохранить настройки электронной почты. Обратитесь к администратору.");
            MessageBox.Show(message, "Уведомление");
            if(settingsSaved)
            {
                Close();
            }
        }
    }
}
