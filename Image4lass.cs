using Image4glass.Properties;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Image4glass
{
    public partial class Image4lass : Form
    {
        string folderName;

        

        FilePathBuilder filePathBuilder;

        bool isLoading4Images = false;

        FavoritesRunFolderListStore favoritesRunFolderListStore;

        public static class ImageLabelText
        {
            public static string Forward = "Forward";
            public static string Rear = "Rear";
            public static string Right = "Right";
            public static string Left = "Left";
            public static string Loading = "Loading...";
        }

        public Image4lass()
        {
            InitializeComponent();

            this.folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            this.filePathBuilder = new FilePathBuilder();

            this.toolStripStatusLabel.Text = filePathBuilder.Part1;

            

            favoritesRunFolderListStore = new FavoritesRunFolderListStore(Properties.Settings.Default.FavoritesRunFolders);
        }

        public Image4lass(string fileNameFromCommandString)
        {
            InitializeComponent();

            this.folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            this.filePathBuilder = new FilePathBuilder();

            this.toolStripStatusLabel.Text = filePathBuilder.Part1;

            

            favoritesRunFolderListStore = new FavoritesRunFolderListStore(Properties.Settings.Default.FavoritesRunFolders);

            if (this.filePathBuilder.initByFullPathFileName(fileNameFromCommandString))
            {
                if (int.TryParse(filePathBuilder.Part3, out int fileNumber))
                {
                    folderNameChange(filePathBuilder.RunFolderFullPath);

                    this.numericUpDownFotoNumber.Value = (this.numericUpDownFotoNumber.Value != fileNumber) ? fileNumber : ++fileNumber;
                }
            }
            else { 
                MessageBox.Show($"Помилка парсування шляху: Файл не належить до Базової директорій. Перевірте налаштування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void folderNameChange(string newfolder)
        {
            if (Directory.Exists(newfolder))
            {
                this.folderName = newfolder;
                textBoxFolderName.Text = newfolder;
                favoritesRunFolderListStore.AddNewRunFolder(newfolder);
            }
        }


        private string LoadImageOnTab(string tabFolderName, PictureBox pictureBox, decimal FileNameIndex)
        {
            string path = folderName + tabFolderName;

            path += @"\" + FileNameIndex + ".jpg";
            if (File.Exists(path))
            {
                try
                {
                    pictureBox.Load(path);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    pictureBox.Image = null;
                }
                return Path.GetFileName(Path.GetDirectoryName(path)) + " " + Path.GetFileNameWithoutExtension(path);
            }
            else
            {
                pictureBox.Image = null;
                return path + "; - The file does not exist.";
            }
        }

        private async Task LoadImages(int tabControlSelectedIndex)
        {
            await Task.Run(() =>
            {
                switch (tabControlSelectedIndex)
                {
                    case 0:
                        ImageLabelText.Forward = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        if (isLoading4Images)
                        {
                            ImageLabelText.Rear = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                            ImageLabelText.Left = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                            ImageLabelText.Right = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        }
                        break;
                    case 1:
                        ImageLabelText.Rear = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        if (isLoading4Images)
                        {
                            ImageLabelText.Forward = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                            ImageLabelText.Left = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                            ImageLabelText.Right = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        }
                        break;
                    case 2:
                        ImageLabelText.Left = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        if (isLoading4Images)
                        {
                            ImageLabelText.Right = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                            ImageLabelText.Rear = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                            ImageLabelText.Forward = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        }
                        break;
                    case 3:
                        ImageLabelText.Right = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
                        if (isLoading4Images)
                        {
                            ImageLabelText.Left = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                            ImageLabelText.Rear = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                            ImageLabelText.Forward = LoadImageOnTab(@"\Forward", this.pictureBoxForward, this.numericUpDownFotoNumber.Value - this.numericUpDownShiftimageIndex.Value);
                        }
                        break;
                }
            });
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderNameChange(this.folderBrowserDialog.SelectedPath);

                if (this.numericUpDownFotoNumber.Value == this.numericUpDownShiftimageIndex.Value + 1)
                    this.numericUpDownFotoNumber.Value = this.numericUpDownShiftimageIndex.Value + 2;
                else this.numericUpDownFotoNumber.Value = this.numericUpDownShiftimageIndex.Value + 1;
            }
        }

        /// <summary>
        /// Блокуємо і розблоковуємо елементи керування, що впливають на зміну номера зображення, щоб не спричинити конфлікт з уже запущеним асинхронним методом
        /// завантаження зображень
        /// </summary>
        /// <param name="isEnable"></param>
        private void enabledCommandTools(bool isEnable)
        {
            buttonPast.Enabled = isEnable;
            numericUpDownFotoNumber.Enabled = isEnable;
            buttonNumberDown.Visible = isEnable;
            buttonNumberUp.Visible = isEnable;
            buttonOpenFolder.Enabled = isEnable;
            buttonFavorites.Enabled = isEnable;
            buttonZoomFit.Enabled = isEnable;
            checkBoxFixZoom.Enabled = isEnable;
            numericUpDownShiftimageIndex.Enabled = isEnable;
            if (!isLoading4Images)
                tabControl.Enabled = isEnable;
        }
        /// <summary>
        /// Тут відбувається вся магія. Міняється номер, запускається загрузка зображень.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            this.enabledCommandTools(false);

            this.labelForwardImageIndex.Text = ImageLabelText.Loading;
            this.labelRearImageIndex.Text = ImageLabelText.Loading;
            this.labelLeftImageIndex.Text = ImageLabelText.Loading;
            this.labelRightImageIndex.Text = ImageLabelText.Loading;
            try
            {
                await this.LoadImages(this.tabControl.SelectedIndex);
            }
            finally
            {
                this.enabledCommandTools(true);
                this.numericUpDownFotoNumber.Focus();
                this.labelForwardImageIndex.Text = ImageLabelText.Forward;
                this.labelRearImageIndex.Text = ImageLabelText.Rear;
                this.labelLeftImageIndex.Text = ImageLabelText.Left;
                this.labelRightImageIndex.Text = ImageLabelText.Right;

                if (!this.checkBoxFixZoom.Checked)
                {
                    PictureBox senderPictureBox = new PictureBox();
                    switch (this.tabControl.SelectedIndex)
                    {
                        case 0:
                            senderPictureBox = this.pictureBoxForward;
                            break;
                        case 1:
                            senderPictureBox = this.pictureBoxRear;
                            break;
                        case 2:
                            senderPictureBox = this.pictureBoxLeft;
                            break;
                        case 3:
                            senderPictureBox = this.pictureBoxRight;
                            break;
                    }
                    senderPictureBox.Width = this.tabPageForward.Height - 6;
                    senderPictureBox.Height = senderPictureBox.Width;
                    CenterPictureBox(senderPictureBox);
                }
            }
        }

        private void buttonPast_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                if (this.filePathBuilder.IsInitializated)
                {
                    string part2 = Clipboard.GetText();
                    try
                    {
                        part2 = Regex.Replace(part2, @"\p{C}+", ""); // for desktop version 
                        if (part2.Contains("|") && part2.Contains("Run"))
                        {
                            filePathBuilder.Part2 = part2.Substring(0, part2.LastIndexOf("|")).Replace("Run", "Photos\\Run");
                        }
                        else
                        {
                            if (part2.Contains("-") && part2.Contains("Run"))
                            {
                                filePathBuilder.Part2 = part2.Substring(0, part2.LastIndexOf("-")).Replace("Run", "Photos\\Run");
                            }
                            else
                            {
                                if (part2.Contains("_") && part2.Contains("Run"))
                                {
                                    filePathBuilder.Part2 = part2.Substring(0, part2.LastIndexOf("_")).Replace("Run", "Photos\\Run");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка парсування шляху: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    int lastSeparatorIndex = 0;
                    if (part2.Contains("|"))
                    {
                        lastSeparatorIndex = part2.LastIndexOf("|") + 1;
                    }
                    else
                    {
                        if (part2.Contains("-"))
                        {
                            lastSeparatorIndex = part2.LastIndexOf("-") + 1;
                        }
                        else
                        {
                            if (part2.Contains("_"))
                            {
                                lastSeparatorIndex = part2.LastIndexOf("_") + 1;
                            }
                        }
                    }
                    filePathBuilder.Part3 = part2.Substring(lastSeparatorIndex, part2.Length - lastSeparatorIndex);

                    if (int.TryParse(filePathBuilder.Part3, out int fileNumber))
                    {

                        folderNameChange(filePathBuilder.RunFolderFullPath);

                        this.numericUpDownFotoNumber.Value = (this.numericUpDownFotoNumber.Value != fileNumber) ? fileNumber : ++fileNumber;
                    }
                    else
                    {
                        MessageBox.Show(filePathBuilder.FullImageFilePath + "; - Файл не знайдено. Виберіть теку самостійно.", "Інформація");
                    }
                }
                else
                {
                    string clipboardTextString = Clipboard.GetText();
                    int cutStringToIndex = 0;
                    int digitsAmount = 0;
                    for (int i = clipboardTextString.Length - 1; i >= 0; i--)
                    {
                        if (Char.IsDigit(clipboardTextString[i]))
                        {
                            digitsAmount++;
                        }
                        else
                        {
                            cutStringToIndex = i + 1;
                            break;
                        }
                    }

                    if (digitsAmount == 0)
                    {
                        MessageBox.Show("Буфер обміну не містить рядок з номером.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string subStr = clipboardTextString.Substring(cutStringToIndex);

                        if (int.TryParse(subStr, out int fileNumber))
                        {
                            this.numericUpDownFotoNumber.Value = (this.numericUpDownFotoNumber.Value != fileNumber) ? fileNumber : ++fileNumber;
                        }
                        else
                        {
                            Console.WriteLine("Рядок не є цілим числом.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Буфер обміну не містить текстовий рядок.", "Інформація");
            }
        }
        private void buttonNumberDown_Click(object sender, EventArgs e)
        {
            if (this.numericUpDownFotoNumber.Value > this.numericUpDownFotoNumber.Minimum)
            {
                this.numericUpDownFotoNumber.Value--;
            }
        }

        private void buttonNumberUp_Click(object sender, EventArgs e)
        {
            if (this.numericUpDownFotoNumber.Value < this.numericUpDownFotoNumber.Maximum)
            {
                this.numericUpDownFotoNumber.Value++;
            }
        }

        /// <summary>
        /// Закриває форму. Зберігаєм корисні змінні по файлах:
        /// історія робочих директорій;
        /// базова директорія.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image4lass_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Збереження розміру та розташування вікна
            Properties.Settings.Default.WindowSize = this.Size;
            Properties.Settings.Default.WindowLocation = this.Location;
            Properties.Settings.Default.LoadImgesMode = this.isLoading4Images;
            Properties.Settings.Default.BaseFolderPath = this.filePathBuilder.Part1;
            Properties.Settings.Default.FavoritesRunFolders = favoritesRunFolderListStore.ReturnList();
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// При загрузці форми 
        /// Зчитуєм файл з набором директорій, що відкривались недавно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image4lass_Load(object sender, EventArgs e)
        {
            // Відновлення розміру та розташування вікна
            this.Size = Properties.Settings.Default.WindowSize;
            this.Location = Properties.Settings.Default.WindowLocation;
            this.isLoading4Images = Properties.Settings.Default.LoadImgesMode;
            if (this.isLoading4Images) { labelLoading.ForeColor = Color.ForestGreen; }
        }

        private void openBasicFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.basicFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.toolStripStatusLabel.Text = this.basicFolderBrowserDialog.SelectedPath;
                filePathBuilder.Part1 = this.basicFolderBrowserDialog.SelectedPath;

            }
        }

        private void resetBasicFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel.Text = "Set basic folder to recognize string in clipboard";
            filePathBuilder.Reset();
        }

        private void pictureBoxZoomImage_MouseWheel(object sender, MouseEventArgs e)
        {
            PictureBox senderPictureBox = (PictureBox)sender;
            float zoomFactor = ((float)senderPictureBox.Width) / 2048.0f;
            const float ZoomIncrement = 0.2f;
            // Змінюємо масштаб відповідно до кількості клацань колеса мишки
            if (e.Delta > 0)
            {
                zoomFactor += (zoomFactor < 4.0f) ? ZoomIncrement : 0;
            }
            else
            {
                zoomFactor -= (zoomFactor > 0.25f) ? ZoomIncrement : 0;
            }

            // Зберігаємо старі розміри PictureBox
            int previousWidth = senderPictureBox.Width;
            int previousHeight = senderPictureBox.Height;

            // Змінюємо розмір зображення
            senderPictureBox.Width = (int)(senderPictureBox.Image.Width * zoomFactor);
            senderPictureBox.Height = (int)(senderPictureBox.Image.Height * zoomFactor);

            // При зміні масштабу, центруємо PictureBox по курсору
            senderPictureBox.Left -= (int)((senderPictureBox.Width - previousWidth) / 2);
            senderPictureBox.Top -= (int)((senderPictureBox.Height - previousHeight) / 2);

            if (senderPictureBox.Size.Height < this.Height)
            {
                CenterPictureBox(senderPictureBox);
            }
        }

        private void CenterPictureBox(PictureBox senderPictureBox)
        {
            int x = (int)((tabControl.Width - 24 - senderPictureBox.Width) / 2);
            int y = (int)((tabControl.Height - 24 - senderPictureBox.Height) / 2);
            senderPictureBox.Location = new Point(x, y);
        }


        private Point startPoint;

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                Cursor = Cursors.Hand;
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (pictureBox.Image != null)
                    {
                        ZoomImageForm zoomImage = new ZoomImageForm(pictureBox.Image);
                        zoomImage.Text = pictureBox.ImageLocation;
                        zoomImage.Show();
                    }
                }
                else
                {
                    pictureBox.Left = (int)(this.Width / 2 - e.Location.X);
                    pictureBox.Top = (int)(this.Height / 2 - e.Location.Y);
                }
            }

        }

        private async void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
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
            if (e.Button == MouseButtons.Left)
            {
                Cursor = Cursors.Default;
            }
        }

        private void pictureBoxForAll_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (pictureBox.Image != null)
            {
                ZoomImageForm zoomImage = new ZoomImageForm(pictureBox.Image);
                zoomImage.Text = pictureBox.ImageLocation;
                zoomImage.Show();
            }
        }

        private void tabControl_Resize(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { pictureBoxForward, pictureBoxRear, pictureBoxLeft, pictureBoxRight };

            int desiredSize = tabControl.Height - 42;

            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Width = desiredSize;
                pictureBox.Height = desiredSize;
                CenterPictureBox(pictureBox);
            }
        }

        private void forAll_labels_ImageIndex_Click(object sender, EventArgs e)
        {
            string textOnLabel = ((Label)sender).Text;
            Clipboard.SetText(textOnLabel);
            MessageBox.Show(textOnLabel, "Напис в буфері клавіатури", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonZoomFit_Click(object sender, EventArgs e)
        {
            tabControl_Resize(sender, e);
        }

        private void Image4lass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                buttonZoomFit_Click(sender, e);
            }
            if (e.KeyCode == Keys.Right)
            {
                if (buttonNumberUp.Visible)
                    buttonNumberUp_Click(sender, e);
            }
            if (e.KeyCode == Keys.Left)
            {
                if (buttonNumberDown.Visible)
                    buttonNumberDown_Click(sender, e);
            }
            if (e.KeyCode == Keys.F1)
            {
                tabControl.SelectTab(0);
            }
            if (e.KeyCode == Keys.F2)
            {
                tabControl.SelectTab(1);
            }
            if (e.KeyCode == Keys.F3)
            {
                tabControl.SelectTab(2);
            }
            if (e.KeyCode == Keys.F4)
            {
                tabControl.SelectTab(3);
            }
            if (e.KeyCode == Keys.F5)
            {
                this.buttonFavorites_Click(sender, e);
            }
            if (e.KeyCode == Keys.F8)
            {
                if (MessageBox.Show($"Змінити режим загрузки зображень?", "Налаштування", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (isLoading4Images)
                    {
                        isLoading4Images = false;
                        MessageBox.Show($"При наступній зміні номеру. \nЗображення будуть вантажитись по ОДНОМУ.", "Налаштування", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        labelLoading.ForeColor = Color.Black;
                    }
                    else
                    {
                        isLoading4Images = true;
                        MessageBox.Show($"При наступній зміні номеру. \nЗображення будуть вантажитись по ЧОТИРИ.", "Налаштування", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        labelLoading.ForeColor = Color.ForestGreen;
                    }
                }
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading4Images)
                numericUpDownNumber_ValueChanged(sender, e);
        }

        private void buttonFavorites_Click(object sender, EventArgs e)
        {
            FavoriteRunFoldersForm favoriteRunFoldersForm = new FavoriteRunFoldersForm(favoritesRunFolderListStore.GetListBoxItems());
            favoriteRunFoldersForm.ShowDialog();

            if ( !string.IsNullOrEmpty(favoriteRunFoldersForm.selectedRunFolder) )
            {
                folderNameChange(favoriteRunFoldersForm.selectedRunFolder);

                if (this.numericUpDownFotoNumber.Value == this.numericUpDownShiftimageIndex.Value + 1)
                    this.numericUpDownFotoNumber.Value = this.numericUpDownShiftimageIndex.Value + 2;
                else this.numericUpDownFotoNumber.Value = this.numericUpDownShiftimageIndex.Value + 1;
            }
        }
    }
}