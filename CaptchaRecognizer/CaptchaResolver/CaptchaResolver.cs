using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptchaResolver
{
    public static class Resolver
    {
        
        private static string resolved = string.Empty;
        private static readonly Color colorOldFigure = Color.FromArgb(0, 0, 0);
        private static readonly Color colorNewFigure = Color.FromArgb(255, 255, 255);
        private static List<MaskOfNumber> masks = new List<MaskOfNumber>();
        private static List<MaskOfNumber> graphics = new List<MaskOfNumber>();

        static Resolver()
        {
            try
            {
                masks.Add(new MaskOfNumber(Resource1._1, '1'));
                masks.Add(new MaskOfNumber(Resource1._2, '2'));
                masks.Add(new MaskOfNumber(Resource1._8, '8'));
                masks.Add(new MaskOfNumber(Resource1._9, '9'));
                masks.Add(new MaskOfNumber(Resource1._3, '3'));
                masks.Add(new MaskOfNumber(Resource1._5, '5'));
                masks.Add(new MaskOfNumber(Resource1._7, '7'));
                graphics.Add(new MaskOfNumber(Resource1._4, '4'));
                graphics.Add(new MaskOfNumber(Resource1._6, '6'));
            }
            catch(Exception capEx1)
            {

            }
        }

        private static char[] ResolveFromGraphic( Bitmap resImg)
        {
            char[] result = new char[] { '*', '*', '*', '*', '*' };
            for (int m = 0; m < graphics.Count; m++) 
            {
                for (int x = 22; x < resImg.Width - 30; x++)
                {
                    for (int y = 1; y < 14; y++)
                    {
                        if ((resImg.GetPixel(x, y)) == Color.FromArgb(255, 255, 255)) //Когда мы находим каждый белый пиксель
                        {
                            bool[] pos = new bool[5];
                            pos[0] = false;
                            pos[1] = false;
                            pos[2] = false;
                            pos[3] = false;
                            pos[4] = false;

                            int overlap = 0;
                            for (int p = 0; p < graphics[m].Points.Count; p++)
                            {
                                if ((resImg.GetPixel(graphics[m].Points[p].X + x, graphics[m].Points[p].Y + y)) == Color.FromArgb(255, 255, 255))
                                {
                                    overlap++;
                                }
                            }
                            int disregard = 4;
                            if (graphics[m].TrueChar == '1') disregard = 0;
                            if (graphics[m].TrueChar == '4') disregard *= 2;
                            if (graphics[m].TrueChar == '6') disregard *= 2;

                            if (overlap >= graphics[m].Points.Count - disregard)
                            {
                                

                                if (x >= 28 && x < 40) result[0] = graphics[m].TrueChar;
                                if (x >= 40 && x < 62) result[1] = graphics[m].TrueChar;
                                if (x >= 62 && x < 79) result[2] = graphics[m].TrueChar;
                                if (x >= 79 && x < 97) result[3] = graphics[m].TrueChar;
                                if (x >= 97) result[4] = graphics[m].TrueChar;                                
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static char[] ResolveFromImage(Bitmap resImg)
        {
            Dictionary<char, int> dopusk = new Dictionary<char, int> { { '1',5},{ '2',5},{ '3',5},{ '4',10},{ '5',5},{ '6',10},{ '7',5},{ '8',10},{ '9', 6 } };
            char[] result = new char[] { '*', '*', '*', '*', '*'};

            for (int m = 0; m < masks.Count; m++) //сравниваем его со всеми масками
            {
                for (int x = 28; x < resImg.Width - 30; x++)
                {
                    for (int y = 1; y < 14; y++)
                    {
                        if ((resImg.GetPixel(x, y)) == Color.FromArgb(255, 255, 255)) //Когда мы находим каждый белый пиксель
                        {
                            int overlap = 0;
                            for (int p = 0; p < masks[m].Points.Count; p++)
                            {
                                if ((resImg.GetPixel(masks[m].Points[p].X + x, masks[m].Points[p].Y + y)) == Color.FromArgb(255, 255, 255))
                                {
                                    overlap++;
                                }
                            }
                            
                            if (overlap >= masks[m].Points.Count - dopusk[masks[m].TrueChar])
                            {
                                if (x >= 28 && x < 40) result[0] = masks[m].TrueChar;
                                if (x >= 40 && x < 60) result[1] = masks[m].TrueChar;
                                if (x >= 60 && x < 79) result[2] = masks[m].TrueChar;
                                if (x >= 79 && x < 97) result[3] = masks[m].TrueChar;
                                if (x >= 97 ) result[4] = masks[m].TrueChar;                                
                            }
                            
                        }
                    }
                }
            }
            return result;
        }

        public static string Resolve(string base64)
        {
            int indexOf = base64.IndexOf(',');
            if(indexOf >= 0)
            {
                base64 = base64.Substring(indexOf + 1);
            }

            return Resolve(new Bitmap(new MemoryStream(Convert.FromBase64String(base64))));
        }


        public static string Resolve(Image imageToResolve)
        {
            string captcha = string.Empty;
            try
            {
                Bitmap cleanedImage = MonochromeNegative(new Bitmap(imageToResolve), Color.FromArgb(0, 0, 0), Color.FromArgb(255, 255, 255));
                bool[,] matrix = GatherMatrix(cleanedImage);
                char[] result1 = ResolveFromImage(cleanedImage);
                char[] result2 = ResolveFromGraphic(cleanedImage);

                for (int i = 0; i < 5; i++)
                {
                    if (result1[i] == '*')
                    {
                        if (result2[i] == '*')
                        {
                            result1[i] = '4';
                        }
                        else
                        {
                            result1[i] = result2[i];
                        }
                    }
                }

                captcha =  new string(result1);

                if(captcha=="44444")
                {
                    captcha = "ERROR";
                }
            }
            catch(Exception e)
            {
                captcha = "ERROR";
            }

            return captcha;
        }

        public static Bitmap ExtractCaptcha(Bitmap fullScreenShot)
        {
            int captchaWidth = 180;
            int captchaHeight = 50;
            Color blackColor = Color.FromArgb(0, 0, 0);

            for (int y = 0; y < fullScreenShot.Size.Height - captchaHeight; y++)
            {
                int blackPiexelsCountX = 0;

                for (int x = 0; x < fullScreenShot.Size.Width; x++)
                {
                    if (fullScreenShot.GetPixel(x, y) == blackColor)
                    {
                        blackPiexelsCountX++;
                    }
                    else
                    {
                        blackPiexelsCountX = 0;
                    }

                    if (blackPiexelsCountX == captchaWidth)
                    {
                        if (fullScreenShot.GetPixel(x, y + 1) == blackColor &&
                            fullScreenShot.GetPixel(x, y + (captchaHeight - 1)) == blackColor &&
                            fullScreenShot.GetPixel(x, y + (captchaHeight - 2)) == blackColor &&
                            fullScreenShot.GetPixel(x - 1, y + (captchaHeight - 1)) == blackColor)
                        {
                            return fullScreenShot.Clone(new Rectangle((x + 1 - captchaWidth), y, captchaWidth, captchaHeight), fullScreenShot.PixelFormat);
                        }
                    }
                }
            }

            return new Bitmap(captchaWidth, captchaHeight);
        }

        private static Bitmap MonochromeNegative(Bitmap imagetoFill, Color colorOldFigure, Color colorNewFigure) //Замена всех пикселей одного цвета на другой цвет
        {
            for (int x = 0; x < imagetoFill.Width; x++)
            {
                for (int y = 0; y < imagetoFill.Height; y++)
                {
                    if (imagetoFill.GetPixel(x, y) == colorOldFigure)
                    {
                        imagetoFill.SetPixel(x, y, colorNewFigure);
                    }
                    else
                    {
                        imagetoFill.SetPixel(x, y, colorOldFigure);
                    }
                }
            }

            return imagetoFill;
        }

        private static bool[,] GatherMatrix(Bitmap monochromeImage) //Сбор
        {
            bool[,] matrixBig = new bool[monochromeImage.Width,monochromeImage.Height];
            int[] verticalSum = new int[monochromeImage.Width];
            int[] horizontalSum = new int[monochromeImage.Height];

            try
            {
                for (int x = 0; x < monochromeImage.Width; x++)
                {
                    verticalSum[x] = 0;
                    for (int y = 0; y < monochromeImage.Height; y++)
                    {
                        if (x == 0)
                        {
                            horizontalSum[y] = 0;
                        }

                        if (monochromeImage.GetPixel(x, y) == colorNewFigure )
                        {
                            matrixBig[x, y] = true;
                            verticalSum[x]++;
                            horizontalSum[y]++;
                        }
                        else
                        {
                            matrixBig[x, y] = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            int xMin =0, xMax=0, yMin=0, yMax=0;
            try
            {
                for (int x = 25; x < 35; x++)
                {
                    xMin = x;
                    if (verticalSum[x] >9)
                    {
                        break;
                    }
                }

                for (int x = 110; x < verticalSum.Length - 1; x++)
                {
                    xMax = x-1;
                    if (verticalSum[x] <10)
                    {
                        break;
                    }
                }

                for (int y = 1; y < horizontalSum.Length - 1; y++)
                {
                    if (horizontalSum[y] >30 && yMin == 0)
                    {
                        yMin = y;
                    }

                    if (yMin > 0 && (horizontalSum[y]<30))
                    {
                        yMax = y - 1;
                        break;
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }

            bool[,] matrixResult = new bool[xMax - xMin + 1, yMax - yMin + 1];
            int newX = 0, newY = 0;

            try
            {
                for (int x = xMin; x <= xMin; x++)
                {
                    newY = 0;
                    for (int y = yMin; y <= yMax; y++)
                    {
                        matrixResult[newX, newY] = matrixBig[x, y];
                        newY++;
                    }
                    newX++;
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return matrixBig;
        }           
    }
}