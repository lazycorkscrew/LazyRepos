using CaptchaResolver;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CaptchaRecognizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonOpenCaptchaImage_Click(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(openImageFileDialog.FileName);
                pictureBox1.Image = bmp;
                label1.Text = Resolver.Resolve(bmp);
            }
                
        }

        private void buttonResolveBase64_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(new MemoryStream(Convert.FromBase64String(textBox1.Text)));
            label1.Text = Resolver.Resolve(textBox1.Text);
        }
    }
}
