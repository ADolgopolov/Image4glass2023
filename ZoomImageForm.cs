using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image4glass
{
    public partial class ZoomImageForm : Form
    {
        private bool isZoomFreeze = false;
        private PolePoint pixelLength_1stPoint;
        private PolePoint pixelLength_2ndPoint;
        private void pixelLength_Refresh()
        {
            if (pixelLength_1stPoint.isDefined) this.isZoomFreeze = true;
            if (pixelLength_2ndPoint.isDefined) this.isZoomFreeze = true;
            this.textBox_1stPointInfo.Text = this.pixelLength_1stPoint.ToString();
            this.textBox_2ndPointInfo.Text = this.pixelLength_2ndPoint.ToString();
            if (pixelLength_1stPoint.isDefined && pixelLength_2ndPoint.isDefined)
            {
                this.textBox_PixelLength_Info.Text = CalculateSegmentLength(pixelLength_1stPoint.ToPoint(), pixelLength_2ndPoint.ToPoint()).ToString();
            }
            else { this.textBox_PixelLength_Info.Text = "Undefined"; }
            pictureBox.Invalidate();
        }

        public static int CalculateSegmentLength(Point startPoint, Point endPoint)
        {
            // Отримайте різницю координат X
            double xDiff = endPoint.X - startPoint.X;

            // Отримайте різницю координат Y
            double yDiff = endPoint.Y - startPoint.Y;

            // Використовуйте теорему Піфагора для обчислення довжини відрізка
            return (int)Math.Truncate(Math.Sqrt(xDiff * xDiff + yDiff * yDiff));
        }

        private float zoomFactor = 0.2f; // Початковий масштаб
        private const float ZoomIncrement = 0.2f; // Збільшення масштабу при кожній прокрутці
        public ZoomImageForm(Image img)
        {
            InitializeComponent();
            this.pixelLength_1stPoint = new PolePoint();
            this.pixelLength_2ndPoint = new PolePoint();
            this.pictureBox.Image = img;
            CenterPictureBox();
        }
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!this.isZoomFreeze)
            {
                // Змінюємо масштаб відповідно до кількості клацань колеса мишки
                if (e.Delta > 0)
                {
                    zoomFactor += (zoomFactor < 3.0f) ? ZoomIncrement : 0;
                }
                else
                {
                    zoomFactor -= (zoomFactor > 0.25f) ? ZoomIncrement : 0;
                }

                // Зберігаємо старі розміри PictureBox
                int previousWidth = pictureBox.Width;
                int previousHeight = pictureBox.Height;

                // Змінюємо розмір зображення
                pictureBox.Width = (int)(pictureBox.Image.Width * zoomFactor);
                pictureBox.Height = (int)(pictureBox.Image.Height * zoomFactor);

                // При зміні масштабу, центруємо PictureBox по курсору
                pictureBox.Left -= (int)((pictureBox.Width - previousWidth) / 2);
                pictureBox.Top -= (int)((pictureBox.Height - previousHeight) / 2);

                if (pictureBox.Size.Height < this.Height)
                {
                    CenterPictureBox();
                }
            }
        }

        private void panel_Resize(object sender, EventArgs e)
        {
            // Під час зміни розмірів Panel, центруємо PictureBox
            CenterPictureBox();
        }

        private void CenterPictureBox()
        {
            int x = (int)((panel.Width - pictureBox.Width) / 2);
            int y = (int)((panel.Height - pictureBox.Height) / 2);

            if (x < 0)
            {
                x = 0;
                panel.HorizontalScroll.Value = 0;
            }
            if (y < 0)
            {
                y = 0;
                panel.VerticalScroll.Value = 0;
            }

            pictureBox.Location = new Point(x, y);
        }

        private async void ZoomImageForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!isZoomFreeze)
            {
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Up)
                {
                    await LoadImageAsync(1);
                }
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Down)
                {
                    await LoadImageAsync(-1);
                }
            }
        }

        private async Task LoadImageAsync(int fileIncrement)
        {
            try
            {
                string newFileImage = this.Text;
                this.Text = "Loading...";
                Image image = await Task.Run(() => LoadImageFromPath(fileIncrement, ref newFileImage));

                // Після завантаження зображення встановлюємо його в PictureBox
                pictureBox.Image = image;
                this.Text = newFileImage;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження зображення: " + ex.Message);
            }
        }
        private Image LoadImageFromPath(int fileNameIncrement, ref string newFullPath)
        {

            string filePath = newFullPath;
            if (int.TryParse(Path.GetFileNameWithoutExtension(filePath), out int fileNameIndex))
            {
                fileNameIndex += fileNameIncrement;
                string? directory = Path.GetDirectoryName(filePath);
                directory ??= string.Empty;
                newFullPath = Path.Combine(directory, fileNameIndex.ToString() + ".jpg");
                if (File.Exists(newFullPath))
                {
                    return Image.FromFile(newFullPath);
                }
            }
            newFullPath = "File request out of name range. Close this window.";
            return new Bitmap(512, 512);
        }

        /// <summary>
        /// Точка для перетягування
        /// </summary>
        private Point startPoint;

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || (e.Button == MouseButtons.Middle))
            {
                startPoint = e.Location;
                Cursor = Cursors.Hand;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.pixelLength_2ndPoint.SetXYCoordinates(e.X, e.Y);
                pixelLength_Refresh();
            }

        }

        private async void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || (e.Button == MouseButtons.Middle))
            {
                Point newLocation = pictureBox.Location;
                newLocation.X += e.X - startPoint.X;
                newLocation.Y += e.Y - startPoint.Y;

                await Task.Run(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        pictureBox.Location = newLocation;
                    }));
                });
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || (e.Button == MouseButtons.Middle))
            {
                Cursor = Cursors.Default;
            }
        }

        private void zoomToFit()
        {
            int desiredSize = this.Height - 42;
            pictureBox.Width = desiredSize;
            pictureBox.Height = desiredSize;
            CenterPictureBox();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            this.button_Reset_Click(sender, e);
            zoomToFit();
        }

        private void buttonFitImage_Click(object sender, EventArgs e)
        {
            zoomToFit();
        }

        private void ZoomImageForm_Load(object sender, EventArgs e)
        {
            zoomToFit();
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                this.pixelLength_1stPoint.SetXYCoordinates(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                this.pixelLength_2ndPoint = new();
                pixelLength_Refresh();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Draw a lines.
            pictureBox_DrawLine(e.Graphics, pixelLength_1stPoint, pixelLength_2ndPoint);
        }
        private void pictureBox_DrawLine(Graphics graphics, PolePoint startPoint, PolePoint endPoint)
        {
            // Create a new Pen object.
            Pen pen = new Pen(Color.Red, 1);
            if (startPoint.isDefined)
            {
                int radius = 6;
                Point center = startPoint.ToPoint();
                graphics.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
            }
            if (startPoint.isDefined && endPoint.isDefined)
            {
                graphics.DrawLine(pen, startPoint.ToPoint(), endPoint.ToPoint());
            }
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            this.pixelLength_1stPoint = new PolePoint();
            this.pixelLength_2ndPoint = new PolePoint();
            this.isZoomFreeze = false;
            pixelLength_Refresh();
        }

        private void button_CopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.textBox_PixelLength_Info.Text);
        }

        private void ZoomImageForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Reset botton
            if (e.KeyCode == Keys.Space)
            {
                button_Reset_Click(sender, e);
            }

            // скопіювати значення висоти
            if (e.Control && e.KeyCode == Keys.C)
            {
                button_CopyToClipboard_Click(sender, e);
            }

            // Past image from Clipboard
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsImage())
                {

                    Image? image = Clipboard.GetImage();

                    if (image != null)
                    {
                        this.pictureBox.Image = new Bitmap(image, new Size(image.Width, image.Height));
                        this.button_Reset_Click(sender, e);
                    }

                }
                else
                {
                    MessageBox.Show(this, "Buffer hasn`t image resourse.");
                }
            }
        }
    }
}
