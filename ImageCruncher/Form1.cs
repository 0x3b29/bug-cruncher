using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCruncher
{
    public partial class Form1 : Form
    {
        Bitmap originalImage;

        int minHeight;
        int maxHeight;
        int minWidth;
        int maxWidth;
        int imageWidth;
        int imageHeight;

        int oldRectX = 0;
        int oldRectY = 0;
        int oldRectWidth = 0;
        int oldRectHeight = 0;

        int deltaR;
        int deltaG;
        int deltaB;

        int mouseStartX;
        int mouseStartY;

        decimal _ratioX;
        decimal _ratioY;

        volatile Boolean done = false;
        volatile Graphics g;

        List<RectCoords> allRectCords = new List<RectCoords>();

        //volatile Color[,] myImg;

        Bitmap workingImage;

        private static Semaphore _semaphore = new Semaphore(1,1);

        public Form1()
        {
            InitializeComponent();
            originalImage = new Bitmap(pictureBox1.Image);

            _ratioX = (decimal)pictureBox1.Image.Width / pictureBox1.Width;
            _ratioY = (decimal)pictureBox1.Image.Height / pictureBox1.Height;

            //myImg = new Color[pictureBox1.BackgroundImage.Width, pictureBox1.BackgroundImage.Height];
            //workingImage = new Bitmap(pictureBox1.BackgroundImage);

            //for (int i = 0; i < pictureBox1.BackgroundImage.Width; i++)
            //{
            //    for (int j = 0; j < pictureBox1.BackgroundImage.Height; j++)
            //    {
            //        myImg[i, j] = workingImage.GetPixel(i, j);
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

            minHeight = Convert.ToInt16(originalImage.Height / 100 * nudMinHeight.Value);
            maxHeight = Convert.ToInt16(originalImage.Height / 100 * nudMaxHeight.Value);
            minWidth =  Convert.ToInt16(originalImage.Width / 100 * nudMinWidth.Value);
            maxWidth = Convert.ToInt16(originalImage.Width / 100 * nudMaxWidth.Value);

            imageWidth = originalImage.Width;
            imageHeight = originalImage.Height;

            deltaR = Convert.ToInt16(nudDeltaR.Value);
            deltaG = Convert.ToInt16(nudDeltaG.Value);
            deltaB = Convert.ToInt16(nudDeltaB.Value);

            // x = Int16.Parse(tbPosX.Text);
            //y = Int16.Parse(tbPosY.Text);

            //workingImage = new Bitmap(originalImage);
            workingImage = new Bitmap(pictureBox1.Image);

            g = Graphics.FromImage(workingImage);

            progressBar1.Maximum = imageHeight;

            done = false;

            int cruncherCount = 1;

            Thread crunchy1 = new Thread(() => cruncher(0, cruncherCount));
            crunchy1.Start();
            Thread.Sleep(100);

            //Thread crunchy2 = new Thread(() => cruncher(1, cruncherCount));
            //crunchy2.Start();
            //Thread.Sleep(100);

            //Thread crunchy3 = new Thread(() => cruncher(2, cruncherCount));
            //crunchy3.Start();
            //Thread.Sleep(100);

            //Thread crunchy4 = new Thread(() => cruncher(3, cruncherCount));
            //crunchy4.Start();
            //Thread.Sleep(100);

            //Thread crunchy5 = new Thread(() => cruncher(4, cruncherCount));
            //crunchy5.Start();

            progressBar1.Value = 0;
        }

        public class RectCoords
        {
            public int x1 { get; set; }
            public int y1 { get; set; }
            public int x2 { get; set; }
            public int y2 { get; set; }

            public RectCoords(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }

            public int isPixelInside(int x, int y)
            {
                if (x >= x1 && x <= x2 && y >= y1 && y <= y2)
                {
                    return x2 + 1;
                }

                return 0;
            }

            public int isRectInside(int x1, int y1, int x2, int y2)
            {
                if (this.x1 < x2 && this.x2 > x1 && this.y1 > y2 && this.y2 < y1)
                {
                    return this.x2 + 1;
                }

                return 0;
            }
        }

        private void cruncher(int crunchId, int cruncherCount)
        {
            int x = 0;
            int y = crunchId;

            //Bitmap workingImage = new Bitmap(pictureBox1.BackgroundImage);

            while (!done)
            {
                int widthToUse = minWidth; //rnd.Next(minWidth, maxWidth);
                int heightToUse = minHeight; // rnd.Next(minHeight, maxHeight);

                if (x + minWidth >= imageWidth)
                {
                    x = 0;
                    y += cruncherCount;
                    if (crunchId == 0)
                    {
                        if (y < imageHeight)
                        {
                            MethodInvoker m = new MethodInvoker(() => progressBar1.Value = y);
                            progressBar1.Invoke(m);
                        }
                    }
                }

                // Exit if below bottom
                if (y + minHeight >= imageHeight)
                {
                    done = true;
                    continue;
                }

                Color oldColor = workingImage.GetPixel(x, y);

                // Define initial rect
                int x1 = x;
                int y1 = y;
                int x2 = x + minWidth;
                int y2 = y + minHeight;

                // Step -1 (Check if start coordinates already in some rectangle)
                if (coordinatesInsideRect(x1, y1) > 0)
                {
                    Debug.WriteLine("start inside rect");
                    x += coordinatesInsideRect(x1, y1);
                    continue;
                }

                // Step -1 (Check if stop coordinates already in some rectangle)
                if (coordinatesInsideRect(x2, y2) > 0)
                {
                    Debug.WriteLine("stop inside rect");
                    x += coordinatesInsideRect(x2, y2);
                    continue;
                }

                if (coordinatesRectInsideRect(x1,y1,x2,y2) > 0)
                {
                    x += coordinatesRectInsideRect(x1, y1, x2, y2);
                    continue;
                }

                // Step 0 (Check top line)
                if (!isVerticalLineValid(workingImage, x1, y1, y2))
                {
                    x += 1;
                    continue;
                }

                // Step 1 (Check left line)
                if (isHorizontalLineValid(workingImage, x1, y1, x2))
                {
                    x += 1;
                    continue;
                }

                // Step 1.5 (Verify box has content)
                if (!isVerticalLineValid(workingImage, x1, y1, x1 + (maxWidth / 2)) && 
                    !isHorizontalLineValid(workingImage, x1, y1, y1 + (maxHeight / 2)))
                {
                    Debug.WriteLine("no content ");
                    x += 1;
                    continue;
                }

                // step 2 (optimize left line)
                bool didRun = false;
                while (isVerticalLineValid(workingImage, x1, y1, y2) && x1 < x + (maxWidth / 2))
                {
                    x1 += 1;
                    didRun = true;
                }

                if (didRun) { x1 -= 1; }

                // step 3 (optimize top line)
                didRun = false;
                while (isHorizontalLineValid(workingImage, x1, y1, x2) && y1 < y + (maxHeight / 2))
                {
                    y1 += 1;
                    didRun = true;
                }

                if (didRun) { y1 -= 1; }

                // Adjust min rect
                x2 = x1 + minWidth;
                y2 = y1 + minHeight;

                // Step 3.5 (Search for red pixels)
                int horizontalPixels = hasRedHorizontalPixels(workingImage, x1, y1, x2, y2);
                if (horizontalPixels > 0)
                {
                    Debug.WriteLine("found red hor");
                    x += horizontalPixels + 1;
                    continue;
                }

                // Step 3.5 (Search for red pixels)
                int verticalPixels = hasRedVerticalPixels(workingImage, x1, y1, x2, y2);
                if (verticalPixels > 0)
                {
                    Debug.WriteLine("found red ver");
                    x += verticalPixels + 1;
                    continue;
                }

                // Step 4 & 5 (Find right line)
                while (!isVerticalLineValid(workingImage, x2, y1, y2) && x2 - x1 <= maxWidth)
                {
                    x2 += 1;
                }

                // Skip if maxWidth was reached
                if (x2 - x1 > maxWidth)
                {
                    Debug.WriteLine("maxWidth reachecd");
                    x = x2;
                    continue;
                }

                // Step 6 & 7 (Find bottom line)
                while (!isHorizontalLineValid(workingImage, x1, y2, x2) && y2 - y1 <= maxHeight)
                {
                    y2 += 1;
                }

                // Skip if maxHeight was reached
                if (y2 - y1 > maxHeight)
                {
                    Debug.WriteLine("maxHeight reachecd");
                    x = x2;
                    continue;
                }

                ////Step 8(Check entire square(to not cut any legs or stuff))
                //if (
                //    !isHorizontalLineValid(workingImage, x1, y1, x2) ||
                //    !isVerticalLineValid(workingImage, x2, y1, y2) ||
                //    !isHorizontalLineValid(workingImage, x2, y2, x1) ||
                //    !isVerticalLineValid(workingImage, x1, y2, y1)
                //    )
                //{
                //    Debug.WriteLine("Square check failed");
                //    x += 1;
                //    continue;
                //};

                int recWidth = x2 - x1;
                int rectHeight = y2 - y1;
                
                //if (!(workingImage.GetPixel(x1, y1).R == 255) && !(workingImage.GetPixel(x1 + 1, y1 + 1).R == 255) &&
                //    !(oldRectX == x1 && oldRectY == y1 && oldRectWidth == recWidth && oldRectHeight == rectHeight) 
                //    ) //crunchId == 0 && false
                //{
                    Debug.WriteLine(x1 + " " + y1 + " " + recWidth + " " + rectHeight);

                    _semaphore.WaitOne();

                    allRectCords.Add(new RectCoords(x1, y1, x2, y2)); 

                    // Draw the rectangle
                    Pen mypen = new Pen(Color.Red);

                    //// pictureBox1.Image = workingImage;
                    //MethodInvoker m1 = new MethodInvoker(() => g.DrawRectangle(mypen, new Rectangle(x1, y1, recWidth, rectHeight)));
                    //pictureBox1.Invoke(m1);


                    g.DrawRectangle(mypen, new Rectangle(x1, y1, recWidth, rectHeight));
                    pictureBox1.Image = workingImage;
                    // pictureBox1.Update();

                    //MethodInvoker m2 = new MethodInvoker(() => pictureBox1.Image = workingImage);
                    //pictureBox1.Invoke(m2);

                    MethodInvoker m3 = new MethodInvoker(() => pictureBox1.Update());
                    pictureBox1.Invoke(m3);

                    _semaphore.Release();
               // }
                
                // Next pixel
                x += 1;
            }
        }

        private int coordinatesInsideRect (int x, int y)
        {
            foreach (var rect in allRectCords)
            {
                if (rect.isPixelInside(x, y) > 0)
                {
                    return rect.isPixelInside(x, y);
                }
            }

            return 0;
        }

        private int coordinatesRectInsideRect(int x1, int y1, int x2, int y2)
        {
            foreach (var rect in allRectCords)
            {
                if (rect.isRectInside(x1, y1 , x2, y2) > 0)
                {
                    return rect.isRectInside(x1, y1, x2, y2);
                }
            }

            return 0;
        }

        private Boolean checkColorDiff(Color color1, Color color2, int deltaR, int deltaG, int deltaB)
        {
            return Math.Abs(color1.R - color2.R) > deltaR || Math.Abs(color1.G - color2.G) > deltaG || Math.Abs(color1.B - color2.B) > deltaB;
        }

        private Boolean isHorizontalLineValid(Bitmap workingImage, int x1, int y1, int x2)
        {
            // Check if pixel valid
            if (x2 >= imageWidth || y1 >= imageHeight || x2 < 0)
            {
                return false;
            }

            Color oldColor = workingImage.GetPixel(x1, y1);

            if (x2 > x1)
            {
                // From left to right
                for (int i = x1; i < x2; i++)
                {
                    Color newColor = workingImage.GetPixel(i, y1);

                    if (checkColorDiff(oldColor, newColor, deltaR, deltaG, deltaB) || (newColor.R == 255 && newColor.G == 0 && newColor.B == 0))
                    {
                        return false;
                    }

                    oldColor = newColor;
                }
            } else {
                // From right to left
                for (int i = x2; i > x1; i--)
                {
                    Color newColor = workingImage.GetPixel(i, y1);

                    if (checkColorDiff(oldColor, newColor, deltaR, deltaG, deltaB) || (newColor.R == 255 && newColor.G == 0 && newColor.B == 0))
                    {
                        return false;
                    }

                    oldColor = newColor;
                }
            }
            
            return true;
        }

        private Boolean isVerticalLineValid(Bitmap workingImage, int x1, int y1, int y2)
        {
            if (x1 >= imageWidth || y2 >= imageHeight || y2 < 0)
            {
                return false;
            }

            Color oldColor = workingImage.GetPixel(x1, y1);

            if (y2 > y1)
            {
                for (int i = y1; i < y2; i++)
                {
                    Color newColor = workingImage.GetPixel(x1, i);

                    if (checkColorDiff(oldColor, newColor, deltaR, deltaG, deltaB) || (newColor.R == 255 && newColor.G == 0 && newColor.B == 0))
                    {
                        return false;
                    }

                    oldColor = newColor;
                }
            } else {
                for (int i = y2; i > y1; i--)
                {
                    Color newColor = workingImage.GetPixel(x1, i);

                    if (checkColorDiff(oldColor, newColor, deltaR, deltaG, deltaB) || (newColor.R == 255 && newColor.G == 0 && newColor.B == 0))
                    {
                        return false;
                    }

                    oldColor = newColor;
                }
            }

            return true;
        }

        private int hasRedHorizontalPixels(Bitmap workingImage, int x1, int y1, int x2, int y2)
        {

            x2 = Math.Min(x2, imageWidth);
            y2 = Math.Min(y2, imageHeight);

            // Search horizontally
            for (int i = x1; i < x2; i++)
            {
                Color workingPixel = workingImage.GetPixel(i, y1 + ((y2 - y1) / 2));
                if (workingPixel.R == 255 && workingPixel.G == 0 && workingPixel.B == 0)
                {
                    return i;
                }
            }

            return 0;
        }

        private int hasRedVerticalPixels(Bitmap workingImage, int x1, int y1, int x2, int y2)
        {

            x2 = Math.Min(x2, imageWidth);
            y2 = Math.Min(y2, imageHeight);

            // Search vertically

            int xMiddle = x1 + ((x2 - x1) / 2);

            for (int i = y1; i < y2; i++)
            {
                if (workingImage.GetPixel(xMiddle, i).R == 255 && workingImage.GetPixel(xMiddle, i).G == 0 && workingImage.GetPixel(xMiddle, i).B == 0)
                {
                    while (workingImage.GetPixel(xMiddle, i).R == 255 && workingImage.GetPixel(xMiddle, i).G == 0 && workingImage.GetPixel(xMiddle, i).B == 0)
                    {
                        xMiddle += 1;
                    }

                    return xMiddle;
                }
            }

            return 0;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine(e.Button);

            mouseStartX = e.X;
            mouseStartY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    nudMinWidth.Value = (new Decimal(Math.Abs(e.X - mouseStartX)) / originalImage.Width) * 100 * _ratioX;
                    nudMinHeight.Value = (new Decimal(Math.Abs(e.Y - mouseStartY)) / originalImage.Height) * 100 * _ratioY;
                    break;
                case MouseButtons.Right:
                    nudMaxWidth.Value = (new Decimal(Math.Abs(e.X - mouseStartX)) / originalImage.Width) * 100 * _ratioX;
                    nudMaxHeight.Value = (new Decimal(Math.Abs(e.Y - mouseStartY)) / originalImage.Height) * 100 * _ratioY;
                    break;
                case MouseButtons.Middle:
                    tbPosX.Text = e.X.ToString();
                    tbPosY.Text = e.Y.ToString();
                    break;
            } 
        }
    }
}
