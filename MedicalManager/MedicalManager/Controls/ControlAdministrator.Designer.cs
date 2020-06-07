namespace MedicalManager.Controls
{
    partial class ControlAdministrator
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonReject = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.listBoxRequests = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxNewDepartment = new System.Windows.Forms.ComboBox();
            this.buttonCreateEmployee = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxNewRole = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNewPatronymic = new System.Windows.Forms.TextBox();
            this.textBoxNewFname = new System.Windows.Forms.TextBox();
            this.textBoxNewLname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.textBoxOldLname = new System.Windows.Forms.TextBox();
            this.textBoxOldFname = new System.Windows.Forms.TextBox();
            this.textBoxOldPatronymic = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxOldRole = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.listBoxEmployees = new System.Windows.Forms.ListBox();
            this.timerUpdateInfo = new System.Windows.Forms.Timer(this.components);
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewLogin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxOldDepartment = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1030, 511);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1022, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Добавить сотрудника";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1016, 479);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonReject);
            this.panel1.Controls.Add(this.buttonAccept);
            this.panel1.Controls.Add(this.listBoxRequests);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 473);
            this.panel1.TabIndex = 0;
            // 
            // buttonReject
            // 
            this.buttonReject.Location = new System.Drawing.Point(102, 252);
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.Size = new System.Drawing.Size(75, 23);
            this.buttonReject.TabIndex = 3;
            this.buttonReject.Text = "Запретить";
            this.buttonReject.UseVisualStyleBackColor = true;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(7, 252);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(89, 23);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Разрешить";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // listBoxRequests
            // 
            this.listBoxRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRequests.DisplayMember = "Info";
            this.listBoxRequests.FormattingEnabled = true;
            this.listBoxRequests.Location = new System.Drawing.Point(7, 20);
            this.listBoxRequests.Name = "listBoxRequests";
            this.listBoxRequests.Size = new System.Drawing.Size(492, 225);
            this.listBoxRequests.TabIndex = 1;
            this.listBoxRequests.ValueMember = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заявки новых сотрудников";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBoxNewDepartment);
            this.panel2.Controls.Add(this.buttonCreateEmployee);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.comboBoxNewRole);
            this.panel2.Controls.Add(this.textBoxNewPassword);
            this.panel2.Controls.Add(this.textBoxNewLogin);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxNewPatronymic);
            this.panel2.Controls.Add(this.textBoxNewFname);
            this.panel2.Controls.Add(this.textBoxNewLname);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(511, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 473);
            this.panel2.TabIndex = 1;
            // 
            // comboBoxNewDepartment
            // 
            this.comboBoxNewDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxNewDepartment.DisplayMember = "Name";
            this.comboBoxNewDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNewDepartment.FormattingEnabled = true;
            this.comboBoxNewDepartment.Location = new System.Drawing.Point(95, 197);
            this.comboBoxNewDepartment.Name = "comboBoxNewDepartment";
            this.comboBoxNewDepartment.Size = new System.Drawing.Size(392, 21);
            this.comboBoxNewDepartment.TabIndex = 18;
            this.comboBoxNewDepartment.ValueMember = "Id";
            // 
            // buttonCreateEmployee
            // 
            this.buttonCreateEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateEmployee.Location = new System.Drawing.Point(95, 224);
            this.buttonCreateEmployee.Name = "buttonCreateEmployee";
            this.buttonCreateEmployee.Size = new System.Drawing.Size(392, 23);
            this.buttonCreateEmployee.TabIndex = 17;
            this.buttonCreateEmployee.Text = "Создать";
            this.buttonCreateEmployee.UseVisualStyleBackColor = true;
            this.buttonCreateEmployee.Click += new System.EventHandler(this.buttonCreateEmployee_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Отделение";
            // 
            // comboBoxNewRole
            // 
            this.comboBoxNewRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxNewRole.DisplayMember = "Name";
            this.comboBoxNewRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNewRole.FormattingEnabled = true;
            this.comboBoxNewRole.Location = new System.Drawing.Point(95, 40);
            this.comboBoxNewRole.Name = "comboBoxNewRole";
            this.comboBoxNewRole.Size = new System.Drawing.Size(392, 21);
            this.comboBoxNewRole.TabIndex = 11;
            this.comboBoxNewRole.ValueMember = "Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Отчество";
            // 
            // textBoxNewPatronymic
            // 
            this.textBoxNewPatronymic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewPatronymic.Location = new System.Drawing.Point(95, 119);
            this.textBoxNewPatronymic.Name = "textBoxNewPatronymic";
            this.textBoxNewPatronymic.Size = new System.Drawing.Size(392, 20);
            this.textBoxNewPatronymic.TabIndex = 6;
            // 
            // textBoxNewFname
            // 
            this.textBoxNewFname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewFname.Location = new System.Drawing.Point(95, 93);
            this.textBoxNewFname.Name = "textBoxNewFname";
            this.textBoxNewFname.Size = new System.Drawing.Size(392, 20);
            this.textBoxNewFname.TabIndex = 5;
            // 
            // textBoxNewLname
            // 
            this.textBoxNewLname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewLname.Location = new System.Drawing.Point(95, 67);
            this.textBoxNewLname.Name = "textBoxNewLname";
            this.textBoxNewLname.Size = new System.Drawing.Size(392, 20);
            this.textBoxNewLname.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Имя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Тип аккаунта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Создать сотрудника";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.listBoxEmployees);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1022, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Изменить/удалить сотрудника";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.comboBoxOldDepartment);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.buttonEdit);
            this.groupBox1.Controls.Add(this.textBoxOldLname);
            this.groupBox1.Controls.Add(this.textBoxOldFname);
            this.groupBox1.Controls.Add(this.textBoxOldPatronymic);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.comboBoxOldRole);
            this.groupBox1.Location = new System.Drawing.Point(483, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 187);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбранный сотрудник";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 18;
            this.label20.Text = "Тип аккаунта";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Фамилия";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(7, 151);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(86, 23);
            this.buttonDelete.TabIndex = 35;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Имя";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(99, 151);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(214, 23);
            this.buttonEdit.TabIndex = 34;
            this.buttonEdit.Text = "Изменить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // textBoxOldLname
            // 
            this.textBoxOldLname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOldLname.Location = new System.Drawing.Point(99, 19);
            this.textBoxOldLname.Name = "textBoxOldLname";
            this.textBoxOldLname.Size = new System.Drawing.Size(214, 20);
            this.textBoxOldLname.TabIndex = 21;
            // 
            // textBoxOldFname
            // 
            this.textBoxOldFname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOldFname.Location = new System.Drawing.Point(99, 45);
            this.textBoxOldFname.Name = "textBoxOldFname";
            this.textBoxOldFname.Size = new System.Drawing.Size(214, 20);
            this.textBoxOldFname.TabIndex = 22;
            // 
            // textBoxOldPatronymic
            // 
            this.textBoxOldPatronymic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOldPatronymic.Location = new System.Drawing.Point(99, 71);
            this.textBoxOldPatronymic.Name = "textBoxOldPatronymic";
            this.textBoxOldPatronymic.Size = new System.Drawing.Size(214, 20);
            this.textBoxOldPatronymic.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Отделение";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "Отчество";
            // 
            // comboBoxOldRole
            // 
            this.comboBoxOldRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOldRole.DisplayMember = "Name";
            this.comboBoxOldRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOldRole.FormattingEnabled = true;
            this.comboBoxOldRole.Location = new System.Drawing.Point(99, 97);
            this.comboBoxOldRole.Name = "comboBoxOldRole";
            this.comboBoxOldRole.Size = new System.Drawing.Size(214, 21);
            this.comboBoxOldRole.TabIndex = 28;
            this.comboBoxOldRole.ValueMember = "Id";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Список сотрудников";
            // 
            // listBoxEmployees
            // 
            this.listBoxEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEmployees.DisplayMember = "Info";
            this.listBoxEmployees.FormattingEnabled = true;
            this.listBoxEmployees.Location = new System.Drawing.Point(6, 19);
            this.listBoxEmployees.Name = "listBoxEmployees";
            this.listBoxEmployees.Size = new System.Drawing.Size(256, 459);
            this.listBoxEmployees.TabIndex = 0;
            this.listBoxEmployees.ValueMember = "Id";
            this.listBoxEmployees.SelectedIndexChanged += new System.EventHandler(this.listBoxEmployees_SelectedIndexChanged);
            // 
            // timerUpdateInfo
            // 
            this.timerUpdateInfo.Enabled = true;
            this.timerUpdateInfo.Interval = 10000;
            this.timerUpdateInfo.Tick += new System.EventHandler(this.timerUpdateInfo_Tick);
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewPassword.Location = new System.Drawing.Point(95, 171);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(392, 20);
            this.textBoxNewPassword.TabIndex = 10;
            // 
            // textBoxNewLogin
            // 
            this.textBoxNewLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewLogin.Location = new System.Drawing.Point(95, 145);
            this.textBoxNewLogin.Name = "textBoxNewLogin";
            this.textBoxNewLogin.Size = new System.Drawing.Size(392, 20);
            this.textBoxNewLogin.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Логин";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Пароль";
            // 
            // comboBoxOldDepartment
            // 
            this.comboBoxOldDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOldDepartment.DisplayMember = "Name";
            this.comboBoxOldDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOldDepartment.FormattingEnabled = true;
            this.comboBoxOldDepartment.Location = new System.Drawing.Point(99, 124);
            this.comboBoxOldDepartment.Name = "comboBoxOldDepartment";
            this.comboBoxOldDepartment.Size = new System.Drawing.Size(214, 21);
            this.comboBoxOldDepartment.TabIndex = 37;
            this.comboBoxOldDepartment.ValueMember = "Id";
            // 
            // ControlAdministrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ControlAdministrator";
            this.Size = new System.Drawing.Size(1030, 511);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.ListBox listBoxRequests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonReject;
        private System.Windows.Forms.Button buttonCreateEmployee;
        private System.Windows.Forms.ComboBox comboBoxNewRole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNewPatronymic;
        private System.Windows.Forms.TextBox textBoxNewFname;
        private System.Windows.Forms.TextBox textBoxNewLname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxOldRole;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxOldPatronymic;
        private System.Windows.Forms.TextBox textBoxOldFname;
        private System.Windows.Forms.TextBox textBoxOldLname;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBoxEmployees;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timerUpdateInfo;
        private System.Windows.Forms.ComboBox comboBoxNewDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.TextBox textBoxNewLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxOldDepartment;
    }
}
