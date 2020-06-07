using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalManager.Controls;
using MedicalManager.Entities;

namespace MedicalManager
{
    public partial class FormWorkflow : Form
    {
        public FormWorkflow(Employee employee)
        {
            InitializeComponent();
            switch(employee.Power)
            {
                case 1: RunAsRegistrator(); break;
                case 2: RunAsLaborant(); break;
                case 3: RunAsDoctor(); break;
                case 4: RunAsAdministrator(); break;
                default: break;
            }

            labelEmployee.Text = $"{employee.Role} {employee.Lname} {employee.Fname} {employee.Patronymic}";
        }

        private void RunAsRegistrator()
        {
            ControlRegistrator controlRegistrator = new ControlRegistrator();
            controlRegistrator.Dock = DockStyle.Fill;
            Text = "СППР для мед. учреждений (Регистратор)";
            tableLayoutPanel1.Controls.Add(controlRegistrator);
        }

        private void RunAsLaborant()
        {
            ControlLaborant controlLaborant = new ControlLaborant();
            controlLaborant.Dock = DockStyle.Fill;
            Text = "СППР для мед. учреждений (Лаборант)";
            tableLayoutPanel1.Controls.Add(controlLaborant);
        }

        private void RunAsDoctor()
        {
            ControlDoctor controlDoctor = new ControlDoctor();
            controlDoctor.Dock = DockStyle.Fill;
            Text = "СППР для мед. учреждений (Доктор)";
            tableLayoutPanel1.Controls.Add(controlDoctor);
        }

        private void RunAsAdministrator()
        {
            ControlAdministrator controlAdministrator = new ControlAdministrator();
            controlAdministrator.Dock = DockStyle.Fill;
            Text = "СППР для мед. учреждений (Администратор)";
            tableLayoutPanel1.Controls.Add(controlAdministrator);
        }

        private void FormWorkflow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = DialogResult == DialogResult.Cancel && MessageBox.Show("Вы уверены, что хотите завершить работу с программой?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.No;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
