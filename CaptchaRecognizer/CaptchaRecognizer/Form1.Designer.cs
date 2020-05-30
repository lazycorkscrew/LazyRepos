namespace CaptchaRecognizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButtonOpenCaptchaImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonResolveBase64 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonOpenCaptchaImage
            // 
            this.ButtonOpenCaptchaImage.Location = new System.Drawing.Point(12, 68);
            this.ButtonOpenCaptchaImage.Name = "ButtonOpenCaptchaImage";
            this.ButtonOpenCaptchaImage.Size = new System.Drawing.Size(300, 23);
            this.ButtonOpenCaptchaImage.TabIndex = 0;
            this.ButtonOpenCaptchaImage.Text = "Открыть картинку с капчой и распознать";
            this.ButtonOpenCaptchaImage.UseVisualStyleBackColor = true;
            this.ButtonOpenCaptchaImage.Click += new System.EventHandler(this.ButtonOpenCaptchaImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(70, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тут будет капча.";
            // 
            // openImageFileDialog
            // 
            this.openImageFileDialog.FileName = "openImageFileDialog";
            this.openImageFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 97);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(300, 50);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // buttonResolveBase64
            // 
            this.buttonResolveBase64.Location = new System.Drawing.Point(12, 153);
            this.buttonResolveBase64.Name = "buttonResolveBase64";
            this.buttonResolveBase64.Size = new System.Drawing.Size(300, 23);
            this.buttonResolveBase64.TabIndex = 4;
            this.buttonResolveBase64.Text = "Либо распознать Base64";
            this.buttonResolveBase64.UseVisualStyleBackColor = true;
            this.buttonResolveBase64.Click += new System.EventHandler(this.buttonResolveBase64_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 275);
            this.Controls.Add(this.buttonResolveBase64);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ButtonOpenCaptchaImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOpenCaptchaImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openImageFileDialog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonResolveBase64;
    }
}

