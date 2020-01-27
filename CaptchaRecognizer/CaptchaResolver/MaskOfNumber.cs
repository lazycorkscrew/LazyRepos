using System.Collections.Generic;
using System.Drawing;

namespace CaptchaResolver
{
    class MaskOfNumber
    {
        public List<Point> Points { get; set; }
        public char TrueChar { get; set; } // устаревшая, для отладки

           private int Width = 0; // устаревшая, для отладки
           private int Height = 0; // устаревшая, для отладки


        public MaskOfNumber(Bitmap image, char trueChar)
        {
            this.TrueChar = trueChar;
            this.Width = image.Width;
            this.Height = image.Height;

            Points = new List<Point>();

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    if (image.GetPixel(x, y) == Color.FromArgb(255, 255, 255))
                    {
                        /// White !- RGB 255
                        this.Points.Add(new Point(x, y));
                    }
                }
            }
        }

        private Image GetImage() // устаревшая, для отладки
        {
            Bitmap image = new Bitmap(Width, Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    image.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                }
            }

            for (int i = 0; i < Points.Count; i++)
            {
                image.SetPixel(Points[i].X, Points[i].Y, Color.FromArgb(255, 255, 255));
            }
            return image;
        }

        private void ConjunctionMask(Image image2)  // устаревшая, для отладки
        {
            Image image1 = this.GetImage();
            int locWidth = (image1.Width > image2.Width ? image1.Width : image2.Width);
            int locHeight = (image1.Height > image2.Height ? image1.Height : image2.Height);

            if (image1.Width > image2.Width)
                image2 = new Bitmap(image2, locWidth, locHeight);
            else if (image2.Width > image1.Width)
                image1 = new Bitmap(image1, locWidth, locHeight);
            if (image1.Height > image2.Height)
                image2 = new Bitmap(image2, locWidth, locHeight);
            else if (image2.Width > image1.Width)
                image1 = new Bitmap(image1, locWidth, locHeight);

            this.Points.Clear();

            for (int x = 0; x < locWidth; x++)
            {
                for (int y = 0; y < locHeight; y++)
                {
                    if (((Bitmap)image1).GetPixel(x, y) == Color.FromArgb(255, 255, 255) && ((Bitmap)image2).GetPixel(x, y) == Color.FromArgb(255, 255, 255))
                    {
                        this.Points.Add(new Point(x, y));
                    }
                }
            }
        }
    }
}
