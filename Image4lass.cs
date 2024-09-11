using Image4glass.Properties;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Image4glass
{
    public partial class Image4lass : Form
    {
        string folderName;

        /// <summary>
        /// При відкриті фото по шляху, потрібно відкрити відповідну вкладку,
        /// але при зміні вкладки повторно перезапускається завантаження фото.
        /// ця змінна дає можливість виключити реакцію на tabControl_SelectedIndexChanged
        /// </summary>
        bool stopReOpenPhoto = false;

        Point tabControlCenter = new Point(626, 277);

        FilePathBuilder filePathBuilder;

        bool isEnableScrolImages = false;

        FavoritesRunFolderListStore favoritesRunFolderListStore;

        MainWindowUserSettings mainWindowUserSettings = new MainWindowUserSettings();

        System.Windows.Forms.CheckBox checkBoxEnableScrolImages = new System.Windows.Forms.CheckBox();
        System.Windows.Forms.CheckBox checkBoxDisableOpenPhotoByDirection = new System.Windows.Forms.CheckBox();

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

            this.filePathBuilder = new FilePathBuilder(mainWindowUserSettings.BaseFolderPath);

            this.toolStripStatusLabel.Text = filePathBuilder.Part1;



            favoritesRunFolderListStore = new FavoritesRunFolderListStore(mainWindowUserSettings.FavoritesRunFolders);
        }

        public Image4lass(string fileNameFromCommandString)
        {
            InitializeComponent();

            this.folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            this.filePathBuilder = new FilePathBuilder(mainWindowUserSettings.BaseFolderPath);

            this.toolStripStatusLabel.Text = filePathBuilder.Part1;

            if (fileNameFromCommandString.Contains("Forward")) { tabControl.SelectTab(0); }
            if (fileNameFromCommandString.Contains("Rear")) { tabControl.SelectTab(1); }
            if (fileNameFromCommandString.Contains("Left")) { tabControl.SelectTab(2); }
            if (fileNameFromCommandString.Contains("Right")) { tabControl.SelectTab(3); }

            favoritesRunFolderListStore = new FavoritesRunFolderListStore(mainWindowUserSettings.FavoritesRunFolders);

            if (this.filePathBuilder.initByFullPathFileName(fileNameFromCommandString))
            {
                if (int.TryParse(filePathBuilder.Part3, out int fileNumber))
                {
                    folderNameChange(filePathBuilder.RunFolderFullPath);

                    this.numericUpDownFotoNumber.Value = (this.numericUpDownFotoNumber.Value != fileNumber) ? fileNumber : ++fileNumber;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(filePathBuilder.Part1))
                    MessageBox.Show($"Помилка парсування шляху: Файл не належить до Базової директорій. Перевірте налаштування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                folderNameChange(GetFolderPathWithRun(fileNameFromCommandString));

                this.numericUpDownFotoNumber.Value = int.Parse(Path.GetFileNameWithoutExtension(fileNameFromCommandString));
            }
        }
        public static string GetFolderPathWithRun(string filePath)
        {
            // Розділення шляху до файлу на складові частини
            string[] parts = filePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            // Перебір складових частин шляху
            for (int i = parts.Length - 1; i >= 0; i--)
            {
                // Перевірка, чи містить складова частина слово "Run"
                if (parts[i].Contains("Run"))
                {
                    // Повернення шляху до папки зі словом "Run"
                    return string.Join(Path.DirectorySeparatorChar.ToString(), parts, 0, i + 1);
                }
            }

            // Якщо не знайдено папки зі словом "Run", повертаємо порожній рядок
            return string.Empty;
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
                        break;
                    case 1:
                        ImageLabelText.Rear = LoadImageOnTab(@"\Rear", this.pictureBoxRear, this.numericUpDownFotoNumber.Value + this.numericUpDownShiftimageIndex.Value);
                        break;
                    case 2:
                        ImageLabelText.Left = LoadImageOnTab(@"\Left", this.pictureBoxLeft, this.numericUpDownFotoNumber.Value);
                        break;
                    case 3:
                        ImageLabelText.Right = LoadImageOnTab(@"\Right", this.pictureBoxRight, this.numericUpDownFotoNumber.Value);
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
            textBoxFolderName.Enabled = isEnable;
            buttonZoomFit.Enabled = isEnable;
            checkBoxFixZoom.Enabled = isEnable;
            numericUpDownShiftimageIndex.Enabled = isEnable;
            tabControl.Enabled = isEnable;
            //button_FileCopier.Enabled = isEnable;
            button_GoToImge.Enabled = isEnable;
        }
        /// <summary>
        /// Тут відбувається вся магія. Міняється номер, запускається загрузка зображень.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            this.enabledCommandTools(false);

            switch (this.tabControl.SelectedIndex)
            {
                case 0:
                    this.labelForwardImageIndex.Text = ImageLabelText.Loading;
                    break;
                case 1:
                    this.labelRearImageIndex.Text = ImageLabelText.Loading;
                    break;
                case 2:
                    this.labelLeftImageIndex.Text = ImageLabelText.Loading;
                    break;
                case 3:
                    this.labelRightImageIndex.Text = ImageLabelText.Loading;
                    break;
            }

            try
            {
                await this.LoadImages(this.tabControl.SelectedIndex);
            }
            finally
            {
                this.enabledCommandTools(true);
                //this.numericUpDownFotoNumber.Focus(); // убрав фокус, що б не плямкало на вводі
                this.buttonOpenFolder.Focus();

                switch (this.tabControl.SelectedIndex)
                {
                    case 0:
                        this.labelForwardImageIndex.Text = ImageLabelText.Forward;
                        break;
                    case 1:
                        this.labelRearImageIndex.Text = ImageLabelText.Rear;
                        break;
                    case 2:
                        this.labelLeftImageIndex.Text = ImageLabelText.Left;
                        break;
                    case 3:
                        this.labelRightImageIndex.Text = ImageLabelText.Right;
                        break;
                }

                if (!this.checkBoxFixZoom.Checked)
                {
                    PictureBox senderPictureBox = new();
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
                if (Clipboard.GetText().Contains(".jpg"))
                {
                    if (MessageBox.Show("Буфер місить назву JPG файлу, спробувати його відкрити?", "Не відповідність вводу. Користуйтесь кнопкою PATH ↩", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        this.button_GoToImge_Click(sender, e);
                    }
                    return;
                }
                if (this.filePathBuilder.IsInitializated)
                {
                    string part2 = Clipboard.GetText();
                    try
                    {
                        part2 = Regex.Replace(part2, @"\p{C}+", ""); // for desktop version 
                        if (part2.Contains('|') && part2.Contains("Run"))
                        {
                            this.stopReOpenPhoto = true;
                            if (part2.Contains("|Forward"))
                            {
                                part2 = part2.Replace("|Forward", "");
                                if (!checkBoxDisableOpenPhotoByDirection.Checked) tabControl.SelectTab(0);
                            }
                            if (part2.Contains("|Rear"))
                            {
                                part2 = part2.Replace("|Rear", "");
                                if (!checkBoxDisableOpenPhotoByDirection.Checked) tabControl.SelectTab(1);
                            }
                            if (part2.Contains("|Left"))
                            {
                                part2 = part2.Replace("|Left", "");
                                if (!checkBoxDisableOpenPhotoByDirection.Checked) tabControl.SelectTab(2);
                            }
                            if (part2.Contains("|Right"))
                            {
                                part2 = part2.Replace("|Right", "");
                                if (!checkBoxDisableOpenPhotoByDirection.Checked) tabControl.SelectTab(3);
                            }
                            this.stopReOpenPhoto = false;
                            filePathBuilder.Part2 = part2.Substring(0, part2.LastIndexOf("|")).Replace("Run", "Photos\\Run");

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка парсування шляху: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    int lastSeparatorIndex = 0;
                    if (part2.Contains('|'))
                    {
                        lastSeparatorIndex = part2.LastIndexOf("|") + 1;
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
            try
            {
                // Збереження розміру та розташування вікна
                mainWindowUserSettings.WindowLocation = new Point(0, 0);
                foreach (var screen in Screen.AllScreens)
                {
                    // Отримати розміри екрана
                    // var screenBounds = screen.Bounds;
                    var screenWorkingArea = screen.WorkingArea;

                    // Відобразити розміри екрана
                    // MessageBox.Show($"Екран: {screen.DeviceName}\nРозмір: {screenBounds.Width}x{screenBounds.Height}\nРобоча область: {screenWorkingArea.Width}x{screenWorkingArea.Height}", "Розміри екрану");

                    // Перевірити, чи координати належать робочій області
                    if (screenWorkingArea.Contains(this.Location))
                    {
                        mainWindowUserSettings.WindowLocation = this.Location;
                    }
                }

                mainWindowUserSettings.WindowSize = this.Size;
                mainWindowUserSettings.ScrolingImageMode = this.isEnableScrolImages;
                mainWindowUserSettings.FixZoomChecked = this.checkBoxFixZoom.Checked;
                mainWindowUserSettings.BaseFolderPath = filePathBuilder.Part1;
                mainWindowUserSettings.FavoritesRunFolders = favoritesRunFolderListStore.ReturnList();

                mainWindowUserSettings.SaveSettings();
            }
            catch { }
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
            this.Size = mainWindowUserSettings.WindowSize;
            this.Location = mainWindowUserSettings.WindowLocation;
            this.isEnableScrolImages = mainWindowUserSettings.ScrolingImageMode;
            this.checkBoxFixZoom.Checked = mainWindowUserSettings.FixZoomChecked;

            this.toolTip.SetToolTip(buttonFavorites, "F5");
            this.toolTip.SetToolTip(buttonPast, "Ctrl + V");
            this.toolTip.SetToolTip(button_GoToImge, "Ctrl + V");
            this.toolTip.SetToolTip(button_ForwardGetPath, "Ctrl + С");
            this.toolTip.SetToolTip(button_RearGetPath, "Ctrl + С");
            this.toolTip.SetToolTip(button_LeftGetPath, "Ctrl + С");
            this.toolTip.SetToolTip(button_RightGetPath, "Ctrl + С");
            this.toolTip.SetToolTip(buttonZoomFit, "Esc or key 'F'");
            this.toolTip.SetToolTip(numericUpDownFotoNumber, "Press key 'G'");
            this.toolTip.SetToolTip(buttonNumberDown, "Use the arrow keys");
            this.toolTip.SetToolTip(buttonNumberUp, "Use the arrow keys");

            checkBoxEnableScrolImages.Text = "Enable change photo by scroll";
            checkBoxEnableScrolImages.Checked = isEnableScrolImages;
            checkBoxEnableScrolImages.CheckedChanged += checkBoxEnableScrolImages_CheckedChanged;
            toolStripSplitButton1.DropDownItems.Add(new ToolStripControlHost(checkBoxEnableScrolImages));

            checkBoxDisableOpenPhotoByDirection.Text = "Disable open photo by direction";
            checkBoxDisableOpenPhotoByDirection.Checked = false;
            toolStripSplitButton1.DropDownItems.Add(new ToolStripControlHost(checkBoxDisableOpenPhotoByDirection));

        }

        private void checkBoxEnableScrolImages_CheckedChanged(object? sender, EventArgs e)
        {
            if (isEnableScrolImages)
            {
                isEnableScrolImages = false;
                MessageBox.Show($"Прокручування колеса мишки буде маштабувати зображення. \nДля переходу між зображеннями утримуйте CTRL.", "Налаштування", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                isEnableScrolImages = true;
                MessageBox.Show($"Прокручування колеса мишки буде переключати зображення. \nДля маштабування зображення утримуйте CTRL.", "Налаштування", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            numericUpDownFotoNumber.Focus();
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
            ((HandledMouseEventArgs)e).Handled = true; // Позначаємо подію як вже оброблену, щоб її не обробив, на далі, tabPage(-Forvard, -Rear,...)

            if (isEnableScrolImages) // по скрипту
            {
                if (Control.ModifierKeys.HasFlag(Keys.Control))
                {
                    PictureBox senderPictureBox = (PictureBox)sender;
                    if (senderPictureBox.Image == null) { return; }
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
                else
                {
                    if (e.Delta > 0)
                    {
                        if (buttonNumberUp.Visible)
                            buttonNumberUp_Click(sender, e);
                    }
                    else
                    {
                        if (buttonNumberDown.Visible)
                            buttonNumberDown_Click(sender, e);
                    }
                }
            }
            else
            {
                if (Control.ModifierKeys.HasFlag(Keys.Control))
                {
                    if (e.Delta > 0)
                    {
                        if (buttonNumberUp.Visible)
                            buttonNumberUp_Click(sender, e);
                    }
                    else
                    {
                        if (buttonNumberDown.Visible)
                            buttonNumberDown_Click(sender, e);
                    }
                }
                else
                {
                    PictureBox senderPictureBox = (PictureBox)sender;
                    if (senderPictureBox.Image == null) { return; }
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
            }
        }

        private void CenterPictureBox(PictureBox senderPictureBox)
        {
            int x = (int)((tabControl.Width - 24 - senderPictureBox.Width) / 2);
            int y = (int)((tabControl.Height - 24 - senderPictureBox.Height) / 2);
            senderPictureBox.Location = new Point(x, y);
        }

        private Dictionary<Label, bool> labelStates = new Dictionary<Label, bool>();
        private Dictionary<Label, System.Windows.Forms.Timer> labelTimers = new Dictionary<Label, System.Windows.Forms.Timer>();

        private void forAllLabelsImageIndex_TextChanged(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (label.Text != ImageLabelText.Loading)
            {
                label.Location = new Point(6, 3);
                if (labelStates.ContainsKey(label))
                {
                    labelStates[label] = false;
                    labelTimers[label].Stop();
                }
                return;
            }

            if (!labelStates.ContainsKey(label))
            {
                labelStates[label] = false;
                labelTimers[label] = new System.Windows.Forms.Timer();
                labelTimers[label].Interval = 200; // 0,2 секунди
                labelTimers[label].Tick += (s, ev) =>
                {
                    Label currentLabel = (Label)sender;
                    labelTimers[currentLabel].Stop(); // Зупиняємо таймер, оскільки зміна тексту відбулася
                    currentLabel.Location = this.tabControlCenter;
                    labelStates[currentLabel] = false;
                };
            }

            labelStates[label] = true;
            labelTimers[label].Stop(); // Скасовуємо попередню зміну розташування
            labelTimers[label].Start();
        }


        private Point startPoint;

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (e.Button == MouseButtons.Left || (e.Button == MouseButtons.Middle))
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
                        ZoomImageForm zoomImage = new(pictureBox.Image);
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

        private void pictureBoxForAll_DoubleClick(object sender, EventArgs e)
        {
            buttonZoomFit_Click(sender, e);
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

            // For Label "Loading..."
            this.tabControlCenter = new Point((int)((tabControl.Width - 86) / 2), (int)((tabControl.Height - 48) / 2));
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

        private void Image4lass_KeyDown(object sender, KeyEventArgs e)
        {
            // Перевірка, чи натиснута клавіша не є цифровою
            if (!char.IsDigit((char)e.KeyCode) && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
            {
                this.buttonOpenFolder.Focus(); // Передача фокусу на кнопку buttonFavorites
            }

            if (e.KeyCode == Keys.Q)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            if (e.KeyCode == Keys.F1 || (e.Alt && e.KeyCode == Keys.D1))
            {
                tabControl.SelectTab(0);
            }
            if (e.KeyCode == Keys.F2 || (e.Alt && e.KeyCode == Keys.D2))
            {
                tabControl.SelectTab(1);
            }
            if (e.KeyCode == Keys.F3 || (e.Alt && e.KeyCode == Keys.D3))
            {
                tabControl.SelectTab(2);
            }
            if (e.KeyCode == Keys.F4 || (e.Alt && e.KeyCode == Keys.D4))
            {
                tabControl.SelectTab(3);
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                switch (tabControl.SelectedIndex)
                {
                    case 0:
                        button_ForwardGetPath_Click(sender, e);
                        break;
                    case 1:
                        button_RearGetPath_Click(sender, e);
                        break;
                    case 2:
                        button_LeftGetPath_Click(sender, e);
                        break;
                    case 3:
                        button_RightGetPath_Click(sender, e);
                        break;
                }
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsText())
                {
                    if (Clipboard.GetText().Contains(".jpg"))
                    {
                        this.button_GoToImge_Click(sender, e);
                    }
                    else
                    {
                        buttonPast_Click(sender, e);
                    }
                }
                Clipboard.Clear();
            }
        }

        private void Image4lass_KeyUp(object sender, KeyEventArgs e)
        {
            // Перевірка, чи натиснута клавіша не є цифровою
            if (!char.IsDigit((char)e.KeyCode) && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
            {
                this.buttonOpenFolder.Focus(); // Передача фокусу на кнопку buttonFavorites
            }

            if (e.KeyCode == Keys.Escape || (e.KeyCode == Keys.F))
            {
                buttonZoomFit_Click(sender, e);
            }

            // перехід між зображеннями за допомогою стрілок клавіатури
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Up)
            {
                if (buttonNumberUp.Visible)
                    buttonNumberUp_Click(sender, e);
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Down)
            {
                if (buttonNumberDown.Visible)
                    buttonNumberDown_Click(sender, e);
            }

            if (e.KeyCode == Keys.F5)
            {
                this.ButtonFavorites_Click(sender, e);
            }

            if (e.KeyCode == Keys.F9)
            {
                if (MessageBox.Show($"Змінити налаштування подій при прокручувані колеса мишки?", "Налаштування", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (isEnableScrolImages)
                    {
                        isEnableScrolImages = false;
                        MessageBox.Show($"Прокручування колеса мишки буде маштабувати зображення. \nДля переходу між зображеннями утримуйте CTRL.", "Налаштування", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        isEnableScrolImages = true;
                        MessageBox.Show($"Прокручування колеса мишки буде переключати зображення. \nДля маштабування зображення утримуйте CTRL.", "Налаштування", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (e.KeyCode == Keys.G)
            {
                InputNumberForm fm = new(this.numericUpDownFotoNumber.Value);
                fm.ShowDialog();
                this.numericUpDownFotoNumber.Value = fm.value;
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.stopReOpenPhoto)
            {
                numericUpDownNumber_ValueChanged(sender, e);
            }
        }

        private void ButtonFavorites_Click(object sender, EventArgs e)
        {
            FavoriteRunFoldersForm favoriteRunFoldersForm = new(favoritesRunFolderListStore.GetListBoxItems());
            favoriteRunFoldersForm.ShowDialog();

            if (!string.IsNullOrEmpty(favoriteRunFoldersForm.selectedRunFolder))
            {
                folderNameChange(favoriteRunFoldersForm.selectedRunFolder);

                if (this.numericUpDownFotoNumber.Value == this.numericUpDownShiftimageIndex.Value + 1)
                    this.numericUpDownFotoNumber.Value = this.numericUpDownShiftimageIndex.Value + 2;
                else this.numericUpDownFotoNumber.Value = this.numericUpDownShiftimageIndex.Value + 1;
            }
        }

        private void button_ForwardGetPath_Click(object sender, EventArgs e)
        {
            string fullPath = pictureBoxForward.ImageLocation;
            if (!String.IsNullOrEmpty(fullPath))
            {
                string sourceFolder = @"Sources";

                // Знаходимо індекс, де закінчується "Sources" в fullPath
                int index = fullPath.IndexOf(@"Sources");

                if (index != -1)
                {
                    // Відрізаємо частину шляху після папки "Sources"
                    string result = fullPath.Substring(index + sourceFolder.Length + 1); // Додаємо 1 для включення роздільника

                    this.labelForwardImageIndex.Text = result;
                    Clipboard.SetText(result);
                }
                else
                {
                    MessageBox.Show("Папка 'Sources' не знайдена у шляху.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_RearGetPath_Click(object sender, EventArgs e)
        {
            string fullPath = pictureBoxRear.ImageLocation;
            if (!String.IsNullOrEmpty(fullPath))
            {
                string sourceFolder = @"Sources";

                // Знаходимо індекс, де закінчується "Sources" в fullPath
                int index = fullPath.IndexOf(@"Sources");

                if (index != -1)
                {
                    // Відрізаємо частину шляху після папки "Sources"
                    string result = fullPath.Substring(index + sourceFolder.Length + 1); // Додаємо 1 для включення роздільника

                    this.labelRearImageIndex.Text = result;
                    Clipboard.SetText(result);
                }
                else
                {
                    MessageBox.Show("Папка 'Sources' не знайдена у шляху.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_LeftGetPath_Click(object sender, EventArgs e)
        {
            string fullPath = pictureBoxLeft.ImageLocation;
            if (!String.IsNullOrEmpty(fullPath))
            {
                string sourceFolder = @"Sources";

                // Знаходимо індекс, де закінчується "Sources" в fullPath
                int index = fullPath.IndexOf(@"Sources");

                if (index != -1)
                {
                    // Відрізаємо частину шляху після папки "Sources"
                    string result = fullPath.Substring(index + sourceFolder.Length + 1); // Додаємо 1 для включення роздільника

                    this.labelLeftImageIndex.Text = result;
                    Clipboard.SetText(result);
                }
                else
                {
                    MessageBox.Show("Папка 'Sources' не знайдена у шляху.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_RightGetPath_Click(object sender, EventArgs e)
        {
            string fullPath = pictureBoxRight.ImageLocation;
            if (!String.IsNullOrEmpty(fullPath))
            {
                string sourceFolder = @"Sources";

                // Знаходимо індекс, де закінчується "Sources" в fullPath
                int index = fullPath.IndexOf(@"Sources");

                if (index != -1)
                {
                    // Відрізаємо частину шляху після папки "Sources"
                    string result = fullPath.Substring(index + sourceFolder.Length + 1); // Додаємо 1 для включення роздільника

                    this.labelRightImageIndex.Text = result;
                    Clipboard.SetText(result);
                }
                else
                {
                    MessageBox.Show("Папка 'Sources' не знайдена у шляху.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_GoToImge_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText() && filePathBuilder.Part1 != String.Empty && Clipboard.GetText().Contains(".jpg"))
            {
                string fullPath = filePathBuilder.Part1;

                // Шлях до папки "Sources"
                string sourceFolder = @"Sources";

                // Знаходимо індекс, де закінчується "Sources" в fullPath
                int index = fullPath.IndexOf(sourceFolder);

                if (index != -1)
                {
                    // Відрізаємо частину шляху після папки "Sources"
                    string result = fullPath.Substring(0, index + sourceFolder.Length);

                    string filePath = Path.Combine(result, Clipboard.GetText());

                    if (this.filePathBuilder.initByFullPathFileName(filePath))
                    {
                        if (int.TryParse(filePathBuilder.Part3, out int fileNumber))
                        {
                            folderNameChange(filePathBuilder.RunFolderFullPath);

                            this.stopReOpenPhoto = true;
                            if (filePath.Contains("Forward")) { fileNumber += (int)numericUpDownShiftimageIndex.Value; tabControl.SelectTab(0); }
                            if (filePath.Contains("Rear")) { fileNumber -= (int)numericUpDownShiftimageIndex.Value; tabControl.SelectTab(1); }
                            if (filePath.Contains("Left")) { tabControl.SelectTab(2); }
                            if (filePath.Contains("Right")) { tabControl.SelectTab(3); }
                            this.stopReOpenPhoto = false;
                            this.numericUpDownFotoNumber.Value = fileNumber;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Папка 'Sources' не знайдена у шляху базової дерикторії", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                if (Clipboard.GetText().Contains('|'))
                {
                    if (MessageBox.Show("Буфер місить строку із символом \'|\', спробувати його відкрити, як \"Photo NO\"?", "Не відповідність вводу. Користуйтесь кнопкою PHOTO NO ↩", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        this.buttonPast_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Буфер не місить назву JPG файлу: \n\n" + Clipboard.GetText(), "Не відповідність вводу.", MessageBoxButtons.OK);
                }
            }
        }

        private void emptySpace_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!((HandledMouseEventArgs)e).Handled)
            {
                // Обробляємо подію лише якщо вона не була вже оброблена pictureBox

                if (e.Delta > 0)
                {
                    if (buttonNumberUp.Visible)
                        buttonNumberUp_Click(sender, e);
                }
                else
                {
                    if (buttonNumberDown.Visible)
                        buttonNumberDown_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// Це тільки для раєра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void emptySpace_MouseWheel_invert(object sender, MouseEventArgs e)
        {
            if (!((HandledMouseEventArgs)e).Handled)
            {
                // Обробляємо подію лише якщо вона не була вже оброблена pictureBox

                if (e.Delta < 0)
                {
                    if (buttonNumberUp.Visible)
                        buttonNumberUp_Click(sender, e);
                }
                else
                {
                    if (buttonNumberDown.Visible)
                        buttonNumberDown_Click(sender, e);
                }
            }
        }

        private void button_FileCopier_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "FileCopier\\FileCopier.exe");
            string[] arguments = { textBoxFolderName.Text, numericUpDownFotoNumber.Value.ToString() }; // Масив параметрів командного рядка

            Process.Start(path, arguments);
        }
    }
}