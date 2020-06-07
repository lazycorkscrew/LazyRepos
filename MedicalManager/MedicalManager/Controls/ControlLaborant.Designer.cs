namespace MedicalManager.Controls
{
    partial class ControlLaborant
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
            this.comboBoxAnalysisTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxAnalyses = new System.Windows.Forms.ListBox();
            this.buttonFillAnalysis = new System.Windows.Forms.Button();
            this.textBoxConclusion = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelRequestNumber = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.timerUpdateInfo = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxAnalysisTypes
            // 
            this.comboBoxAnalysisTypes.DisplayMember = "Name";
            this.comboBoxAnalysisTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnalysisTypes.FormattingEnabled = true;
            this.comboBoxAnalysisTypes.Items.AddRange(new object[] {
            "Общий анализ крови"});
            this.comboBoxAnalysisTypes.Location = new System.Drawing.Point(144, 3);
            this.comboBoxAnalysisTypes.Name = "comboBoxAnalysisTypes";
            this.comboBoxAnalysisTypes.Size = new System.Drawing.Size(196, 21);
            this.comboBoxAnalysisTypes.TabIndex = 0;
            this.comboBoxAnalysisTypes.ValueMember = "Id";
            this.comboBoxAnalysisTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxAnalysisTypes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фильтр по типу анализа:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(893, 689);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Заявки на проведение анализов";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxAnalyses, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonFillAnalysis, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxConclusion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(887, 670);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // listBoxAnalyses
            // 
            this.listBoxAnalyses.DisplayMember = "ShowName";
            this.listBoxAnalyses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAnalyses.FormattingEnabled = true;
            this.listBoxAnalyses.Location = new System.Drawing.Point(3, 63);
            this.listBoxAnalyses.Name = "listBoxAnalyses";
            this.listBoxAnalyses.Size = new System.Drawing.Size(437, 564);
            this.listBoxAnalyses.TabIndex = 3;
            this.listBoxAnalyses.ValueMember = "Id";
            this.listBoxAnalyses.SelectedIndexChanged += new System.EventHandler(this.listBoxAnalyses_SelectedIndexChanged);
            // 
            // buttonFillAnalysis
            // 
            this.buttonFillAnalysis.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonFillAnalysis.Location = new System.Drawing.Point(776, 638);
            this.buttonFillAnalysis.Name = "buttonFillAnalysis";
            this.buttonFillAnalysis.Size = new System.Drawing.Size(108, 23);
            this.buttonFillAnalysis.TabIndex = 7;
            this.buttonFillAnalysis.Text = "Подтвердить";
            this.buttonFillAnalysis.UseVisualStyleBackColor = true;
            this.buttonFillAnalysis.Click += new System.EventHandler(this.buttonFillAnalysis_Click);
            // 
            // textBoxConclusion
            // 
            this.textBoxConclusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxConclusion.Location = new System.Drawing.Point(446, 63);
            this.textBoxConclusion.Multiline = true;
            this.textBoxConclusion.Name = "textBoxConclusion";
            this.textBoxConclusion.Size = new System.Drawing.Size(438, 564);
            this.textBoxConclusion.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelRequestNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(446, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 54);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Результат (в свободной форме)";
            // 
            // labelRequestNumber
            // 
            this.labelRequestNumber.AutoSize = true;
            this.labelRequestNumber.Location = new System.Drawing.Point(3, 0);
            this.labelRequestNumber.Name = "labelRequestNumber";
            this.labelRequestNumber.Size = new System.Drawing.Size(79, 13);
            this.labelRequestNumber.TabIndex = 4;
            this.labelRequestNumber.Text = "Заявка № 145";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBoxAnalysisTypes);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 54);
            this.panel2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Найденные заявки:";
            // 
            // timerUpdateInfo
            // 
            this.timerUpdateInfo.Enabled = true;
            this.timerUpdateInfo.Interval = 10000;
            this.timerUpdateInfo.Tick += new System.EventHandler(this.timerUpdateInfo_Tick);
            // 
            // ControlLaborant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.groupBox1);
            this.Name = "ControlLaborant";
            this.Size = new System.Drawing.Size(893, 689);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAnalysisTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxAnalyses;
        private System.Windows.Forms.Button buttonFillAnalysis;
        private System.Windows.Forms.TextBox textBoxConclusion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelRequestNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerUpdateInfo;
    }
}
