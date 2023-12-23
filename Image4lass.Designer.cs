using System.Windows.Forms;

namespace Image4glass
{
    partial class Image4lass
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image4lass));
            numericUpDownFotoNumber = new NumericUpDown();
            buttonOpenFolder = new Button();
            tabControl = new TabControl();
            tabPageForward = new TabPage();
            button_ForwardGetPath = new Button();
            labelForwardImageIndex = new Label();
            pictureBoxForward = new PictureBox();
            tabPageRear = new TabPage();
            button_RearGetPath = new Button();
            labelRearImageIndex = new Label();
            pictureBoxRear = new PictureBox();
            tabPageLeft = new TabPage();
            button_LeftGetPath = new Button();
            labelLeftImageIndex = new Label();
            pictureBoxLeft = new PictureBox();
            tabPageRight = new TabPage();
            button_RightGetPath = new Button();
            labelRightImageIndex = new Label();
            pictureBoxRight = new PictureBox();
            numericUpDownShiftimageIndex = new NumericUpDown();
            folderBrowserDialog = new FolderBrowserDialog();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripSplitButton1 = new ToolStripSplitButton();
            openBasicFolderToolStripMenuItem = new ToolStripMenuItem();
            resetBasicFolderToolStripMenuItem = new ToolStripMenuItem();
            buttonPast = new Button();
            labelLoading = new Label();
            buttonNumberDown = new Button();
            buttonNumberUp = new Button();
            basicFolderBrowserDialog = new FolderBrowserDialog();
            checkBoxFixZoom = new CheckBox();
            buttonZoomFit = new Button();
            textBoxFolderName = new TextBox();
            buttonFavorites = new Button();
            button_GoToImge = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFotoNumber).BeginInit();
            tabControl.SuspendLayout();
            tabPageForward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxForward).BeginInit();
            tabPageRear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRear).BeginInit();
            tabPageLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).BeginInit();
            tabPageRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownShiftimageIndex).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // numericUpDownFotoNumber
            // 
            numericUpDownFotoNumber.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownFotoNumber.Location = new Point(123, 2);
            numericUpDownFotoNumber.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownFotoNumber.Name = "numericUpDownFotoNumber";
            numericUpDownFotoNumber.Size = new Size(69, 27);
            numericUpDownFotoNumber.TabIndex = 0;
            numericUpDownFotoNumber.TextAlign = HorizontalAlignment.Center;
            numericUpDownFotoNumber.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownFotoNumber.ValueChanged += numericUpDownNumber_ValueChanged;
            // 
            // buttonOpenFolder
            // 
            buttonOpenFolder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonOpenFolder.Location = new Point(300, 0);
            buttonOpenFolder.Name = "buttonOpenFolder";
            buttonOpenFolder.Size = new Size(148, 30);
            buttonOpenFolder.TabIndex = 1;
            buttonOpenFolder.Text = "Open Run Folder";
            buttonOpenFolder.UseVisualStyleBackColor = true;
            buttonOpenFolder.Click += buttonOpenFolder_Click;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageForward);
            tabControl.Controls.Add(tabPageRear);
            tabControl.Controls.Add(tabPageLeft);
            tabControl.Controls.Add(tabPageRight);
            tabControl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl.Location = new Point(6, 32);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1252, 554);
            tabControl.TabIndex = 3;
            tabControl.TabStop = false;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            tabControl.DoubleClick += pictureBoxForAll_DoubleClick;
            tabControl.Resize += tabControl_Resize;
            // 
            // tabPageForward
            // 
            tabPageForward.Controls.Add(button_ForwardGetPath);
            tabPageForward.Controls.Add(labelForwardImageIndex);
            tabPageForward.Controls.Add(pictureBoxForward);
            tabPageForward.Location = new Point(4, 30);
            tabPageForward.Name = "tabPageForward";
            tabPageForward.Padding = new Padding(3);
            tabPageForward.Size = new Size(1244, 520);
            tabPageForward.TabIndex = 0;
            tabPageForward.Text = "Forward";
            tabPageForward.UseVisualStyleBackColor = true;
            // 
            // button_ForwardGetPath
            // 
            button_ForwardGetPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_ForwardGetPath.AutoSize = true;
            button_ForwardGetPath.FlatStyle = FlatStyle.Flat;
            button_ForwardGetPath.Location = new Point(1145, 6);
            button_ForwardGetPath.Name = "button_ForwardGetPath";
            button_ForwardGetPath.Size = new Size(93, 33);
            button_ForwardGetPath.TabIndex = 8;
            button_ForwardGetPath.Text = "Get Path";
            button_ForwardGetPath.UseVisualStyleBackColor = true;
            button_ForwardGetPath.Click += button_ForwardGetPath_Click;
            // 
            // labelForwardImageIndex
            // 
            labelForwardImageIndex.AutoSize = true;
            labelForwardImageIndex.Location = new Point(6, 3);
            labelForwardImageIndex.Name = "labelForwardImageIndex";
            labelForwardImageIndex.Size = new Size(14, 21);
            labelForwardImageIndex.TabIndex = 7;
            labelForwardImageIndex.Text = " ";
            labelForwardImageIndex.Click += forAll_labels_ImageIndex_Click;
            // 
            // pictureBoxForward
            // 
            pictureBoxForward.Cursor = Cursors.Cross;
            pictureBoxForward.Location = new Point(366, 6);
            pictureBoxForward.Name = "pictureBoxForward";
            pictureBoxForward.Size = new Size(512, 512);
            pictureBoxForward.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxForward.TabIndex = 0;
            pictureBoxForward.TabStop = false;
            pictureBoxForward.DoubleClick += pictureBoxForAll_DoubleClick;
            pictureBoxForward.MouseDown += pictureBox_MouseDown;
            pictureBoxForward.MouseMove += pictureBox_MouseMove;
            pictureBoxForward.MouseUp += pictureBox_MouseUp;
            pictureBoxForward.MouseWheel += pictureBoxZoomImage_MouseWheel;
            // 
            // tabPageRear
            // 
            tabPageRear.Controls.Add(button_RearGetPath);
            tabPageRear.Controls.Add(labelRearImageIndex);
            tabPageRear.Controls.Add(pictureBoxRear);
            tabPageRear.Location = new Point(4, 30);
            tabPageRear.Name = "tabPageRear";
            tabPageRear.Padding = new Padding(3);
            tabPageRear.Size = new Size(1244, 520);
            tabPageRear.TabIndex = 1;
            tabPageRear.Text = "Rear";
            tabPageRear.UseVisualStyleBackColor = true;
            // 
            // button_RearGetPath
            // 
            button_RearGetPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_RearGetPath.AutoSize = true;
            button_RearGetPath.FlatStyle = FlatStyle.Flat;
            button_RearGetPath.Location = new Point(1145, 6);
            button_RearGetPath.Name = "button_RearGetPath";
            button_RearGetPath.Size = new Size(93, 33);
            button_RearGetPath.TabIndex = 9;
            button_RearGetPath.Text = "Get Path";
            button_RearGetPath.UseVisualStyleBackColor = true;
            button_RearGetPath.Click += button_RearGetPath_Click;
            // 
            // labelRearImageIndex
            // 
            labelRearImageIndex.AutoSize = true;
            labelRearImageIndex.Location = new Point(6, 3);
            labelRearImageIndex.Name = "labelRearImageIndex";
            labelRearImageIndex.Size = new Size(14, 21);
            labelRearImageIndex.TabIndex = 7;
            labelRearImageIndex.Text = " ";
            labelRearImageIndex.Click += forAll_labels_ImageIndex_Click;
            // 
            // pictureBoxRear
            // 
            pictureBoxRear.Cursor = Cursors.Cross;
            pictureBoxRear.Location = new Point(366, 6);
            pictureBoxRear.Name = "pictureBoxRear";
            pictureBoxRear.Size = new Size(512, 512);
            pictureBoxRear.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRear.TabIndex = 0;
            pictureBoxRear.TabStop = false;
            pictureBoxRear.DoubleClick += pictureBoxForAll_DoubleClick;
            pictureBoxRear.MouseDown += pictureBox_MouseDown;
            pictureBoxRear.MouseMove += pictureBox_MouseMove;
            pictureBoxRear.MouseUp += pictureBox_MouseUp;
            pictureBoxRear.MouseWheel += pictureBoxZoomImage_MouseWheel;
            // 
            // tabPageLeft
            // 
            tabPageLeft.Controls.Add(button_LeftGetPath);
            tabPageLeft.Controls.Add(labelLeftImageIndex);
            tabPageLeft.Controls.Add(pictureBoxLeft);
            tabPageLeft.Location = new Point(4, 30);
            tabPageLeft.Name = "tabPageLeft";
            tabPageLeft.Padding = new Padding(3);
            tabPageLeft.Size = new Size(1244, 520);
            tabPageLeft.TabIndex = 2;
            tabPageLeft.Text = "Left";
            tabPageLeft.UseVisualStyleBackColor = true;
            // 
            // button_LeftGetPath
            // 
            button_LeftGetPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_LeftGetPath.AutoSize = true;
            button_LeftGetPath.FlatStyle = FlatStyle.Flat;
            button_LeftGetPath.Location = new Point(1145, 6);
            button_LeftGetPath.Name = "button_LeftGetPath";
            button_LeftGetPath.Size = new Size(93, 33);
            button_LeftGetPath.TabIndex = 10;
            button_LeftGetPath.Text = "Get Path";
            button_LeftGetPath.UseVisualStyleBackColor = true;
            button_LeftGetPath.Click += button_LeftGetPath_Click;
            // 
            // labelLeftImageIndex
            // 
            labelLeftImageIndex.AutoSize = true;
            labelLeftImageIndex.Location = new Point(6, 3);
            labelLeftImageIndex.Name = "labelLeftImageIndex";
            labelLeftImageIndex.Size = new Size(14, 21);
            labelLeftImageIndex.TabIndex = 1;
            labelLeftImageIndex.Text = " ";
            labelLeftImageIndex.Click += forAll_labels_ImageIndex_Click;
            // 
            // pictureBoxLeft
            // 
            pictureBoxLeft.Cursor = Cursors.Cross;
            pictureBoxLeft.Location = new Point(366, 6);
            pictureBoxLeft.Name = "pictureBoxLeft";
            pictureBoxLeft.Size = new Size(512, 512);
            pictureBoxLeft.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLeft.TabIndex = 0;
            pictureBoxLeft.TabStop = false;
            pictureBoxLeft.DoubleClick += pictureBoxForAll_DoubleClick;
            pictureBoxLeft.MouseDown += pictureBox_MouseDown;
            pictureBoxLeft.MouseMove += pictureBox_MouseMove;
            pictureBoxLeft.MouseUp += pictureBox_MouseUp;
            pictureBoxLeft.MouseWheel += pictureBoxZoomImage_MouseWheel;
            // 
            // tabPageRight
            // 
            tabPageRight.Controls.Add(button_RightGetPath);
            tabPageRight.Controls.Add(labelRightImageIndex);
            tabPageRight.Controls.Add(pictureBoxRight);
            tabPageRight.Location = new Point(4, 30);
            tabPageRight.Name = "tabPageRight";
            tabPageRight.Padding = new Padding(3);
            tabPageRight.Size = new Size(1244, 520);
            tabPageRight.TabIndex = 3;
            tabPageRight.Text = "Right";
            tabPageRight.UseVisualStyleBackColor = true;
            // 
            // button_RightGetPath
            // 
            button_RightGetPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_RightGetPath.AutoSize = true;
            button_RightGetPath.FlatStyle = FlatStyle.Flat;
            button_RightGetPath.Location = new Point(1145, 6);
            button_RightGetPath.Name = "button_RightGetPath";
            button_RightGetPath.Size = new Size(93, 33);
            button_RightGetPath.TabIndex = 11;
            button_RightGetPath.Text = "Get Path";
            button_RightGetPath.UseVisualStyleBackColor = true;
            button_RightGetPath.Click += button_RightGetPath_Click;
            // 
            // labelRightImageIndex
            // 
            labelRightImageIndex.AutoSize = true;
            labelRightImageIndex.Location = new Point(6, 3);
            labelRightImageIndex.Name = "labelRightImageIndex";
            labelRightImageIndex.Size = new Size(14, 21);
            labelRightImageIndex.TabIndex = 1;
            labelRightImageIndex.Text = " ";
            labelRightImageIndex.Click += forAll_labels_ImageIndex_Click;
            // 
            // pictureBoxRight
            // 
            pictureBoxRight.Cursor = Cursors.Cross;
            pictureBoxRight.Location = new Point(366, 6);
            pictureBoxRight.Name = "pictureBoxRight";
            pictureBoxRight.Size = new Size(512, 512);
            pictureBoxRight.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRight.TabIndex = 0;
            pictureBoxRight.TabStop = false;
            pictureBoxRight.DoubleClick += pictureBoxForAll_DoubleClick;
            pictureBoxRight.MouseDown += pictureBox_MouseDown;
            pictureBoxRight.MouseMove += pictureBox_MouseMove;
            pictureBoxRight.MouseUp += pictureBox_MouseUp;
            pictureBoxRight.MouseWheel += pictureBoxZoomImage_MouseWheel;
            // 
            // numericUpDownShiftimageIndex
            // 
            numericUpDownShiftimageIndex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownShiftimageIndex.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownShiftimageIndex.Location = new Point(1144, 2);
            numericUpDownShiftimageIndex.Name = "numericUpDownShiftimageIndex";
            numericUpDownShiftimageIndex.Size = new Size(38, 29);
            numericUpDownShiftimageIndex.TabIndex = 4;
            numericUpDownShiftimageIndex.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownShiftimageIndex.ValueChanged += numericUpDownNumber_ValueChanged;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, toolStripSplitButton1 });
            statusStrip.Location = new Point(0, 589);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1264, 22);
            statusStrip.TabIndex = 6;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(254, 17);
            toolStripStatusLabel.Text = "Set basic folder to recognize string in clipboard";
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButton1.DropDownItems.AddRange(new ToolStripItem[] { openBasicFolderToolStripMenuItem, resetBasicFolderToolStripMenuItem });
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(32, 20);
            toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // openBasicFolderToolStripMenuItem
            // 
            openBasicFolderToolStripMenuItem.Name = "openBasicFolderToolStripMenuItem";
            openBasicFolderToolStripMenuItem.Size = new Size(307, 22);
            openBasicFolderToolStripMenuItem.Text = "Open basic folder";
            openBasicFolderToolStripMenuItem.Click += openBasicFolderToolStripMenuItem_Click;
            // 
            // resetBasicFolderToolStripMenuItem
            // 
            resetBasicFolderToolStripMenuItem.Name = "resetBasicFolderToolStripMenuItem";
            resetBasicFolderToolStripMenuItem.Size = new Size(307, 22);
            resetBasicFolderToolStripMenuItem.Text = "Reset basic folder (вставляти тільки номер)";
            resetBasicFolderToolStripMenuItem.Click += resetBasicFolderToolStripMenuItem_Click;
            // 
            // buttonPast
            // 
            buttonPast.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPast.Location = new Point(3, 0);
            buttonPast.Name = "buttonPast";
            buttonPast.Size = new Size(117, 30);
            buttonPast.TabIndex = 7;
            buttonPast.Text = "PHOTO NO ↩";
            buttonPast.UseVisualStyleBackColor = true;
            buttonPast.Click += buttonPast_Click;
            // 
            // labelLoading
            // 
            labelLoading.BorderStyle = BorderStyle.FixedSingle;
            labelLoading.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelLoading.Location = new Point(198, 3);
            labelLoading.Name = "labelLoading";
            labelLoading.Size = new Size(96, 23);
            labelLoading.TabIndex = 8;
            labelLoading.Text = "Loading...";
            labelLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonNumberDown
            // 
            buttonNumberDown.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonNumberDown.Location = new Point(198, 0);
            buttonNumberDown.Name = "buttonNumberDown";
            buttonNumberDown.Size = new Size(48, 30);
            buttonNumberDown.TabIndex = 9;
            buttonNumberDown.Text = "<<";
            buttonNumberDown.UseVisualStyleBackColor = true;
            buttonNumberDown.Click += buttonNumberDown_Click;
            // 
            // buttonNumberUp
            // 
            buttonNumberUp.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonNumberUp.Location = new Point(246, 0);
            buttonNumberUp.Name = "buttonNumberUp";
            buttonNumberUp.Size = new Size(48, 30);
            buttonNumberUp.TabIndex = 10;
            buttonNumberUp.Text = ">>";
            buttonNumberUp.UseVisualStyleBackColor = true;
            buttonNumberUp.Click += buttonNumberUp_Click;
            // 
            // checkBoxFixZoom
            // 
            checkBoxFixZoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxFixZoom.AutoSize = true;
            checkBoxFixZoom.Checked = true;
            checkBoxFixZoom.CheckState = CheckState.Checked;
            checkBoxFixZoom.Location = new Point(1062, 7);
            checkBoxFixZoom.Name = "checkBoxFixZoom";
            checkBoxFixZoom.Size = new Size(76, 19);
            checkBoxFixZoom.TabIndex = 14;
            checkBoxFixZoom.Text = "Fix Zoom";
            checkBoxFixZoom.UseVisualStyleBackColor = true;
            // 
            // buttonZoomFit
            // 
            buttonZoomFit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonZoomFit.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonZoomFit.Location = new Point(1024, 0);
            buttonZoomFit.Name = "buttonZoomFit";
            buttonZoomFit.Size = new Size(32, 30);
            buttonZoomFit.TabIndex = 15;
            buttonZoomFit.Text = "><";
            buttonZoomFit.UseVisualStyleBackColor = true;
            buttonZoomFit.Click += buttonZoomFit_Click;
            // 
            // textBoxFolderName
            // 
            textBoxFolderName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFolderName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFolderName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxFolderName.Location = new Point(542, 2);
            textBoxFolderName.Name = "textBoxFolderName";
            textBoxFolderName.ReadOnly = true;
            textBoxFolderName.RightToLeft = RightToLeft.Yes;
            textBoxFolderName.Size = new Size(476, 29);
            textBoxFolderName.TabIndex = 16;
            textBoxFolderName.TextAlign = HorizontalAlignment.Right;
            // 
            // buttonFavorites
            // 
            buttonFavorites.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonFavorites.Location = new Point(454, 0);
            buttonFavorites.Name = "buttonFavorites";
            buttonFavorites.Size = new Size(82, 30);
            buttonFavorites.TabIndex = 17;
            buttonFavorites.Text = "Favorites";
            buttonFavorites.UseVisualStyleBackColor = true;
            buttonFavorites.Click += buttonFavorites_Click;
            // 
            // button_GoToImge
            // 
            button_GoToImge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_GoToImge.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_GoToImge.Location = new Point(1188, 0);
            button_GoToImge.Name = "button_GoToImge";
            button_GoToImge.Size = new Size(70, 32);
            button_GoToImge.TabIndex = 18;
            button_GoToImge.Text = "Path ↩";
            button_GoToImge.UseVisualStyleBackColor = true;
            button_GoToImge.Click += button_GoToImge_Click;
            // 
            // Image4lass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 611);
            Controls.Add(button_GoToImge);
            Controls.Add(buttonFavorites);
            Controls.Add(textBoxFolderName);
            Controls.Add(buttonZoomFit);
            Controls.Add(checkBoxFixZoom);
            Controls.Add(buttonNumberUp);
            Controls.Add(buttonNumberDown);
            Controls.Add(labelLoading);
            Controls.Add(buttonPast);
            Controls.Add(statusStrip);
            Controls.Add(numericUpDownShiftimageIndex);
            Controls.Add(tabControl);
            Controls.Add(buttonOpenFolder);
            Controls.Add(numericUpDownFotoNumber);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MinimumSize = new Size(960, 480);
            Name = "Image4lass";
            Text = "Image4glass 23-12-2023";
            FormClosing += Image4lass_FormClosing;
            Load += Image4lass_Load;
            KeyUp += Image4lass_KeyUp;
            ((System.ComponentModel.ISupportInitialize)numericUpDownFotoNumber).EndInit();
            tabControl.ResumeLayout(false);
            tabPageForward.ResumeLayout(false);
            tabPageForward.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxForward).EndInit();
            tabPageRear.ResumeLayout(false);
            tabPageRear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRear).EndInit();
            tabPageLeft.ResumeLayout(false);
            tabPageLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLeft).EndInit();
            tabPageRight.ResumeLayout(false);
            tabPageRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownShiftimageIndex).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDownFotoNumber;
        private Button buttonOpenFolder;
        private TabControl tabControl;
        private TabPage tabPageForward;
        private TabPage tabPageRear;
        private TabPage tabPageLeft;
        private TabPage tabPageRight;
        private PictureBox pictureBoxForward;
        private NumericUpDown numericUpDownShiftimageIndex;
        private PictureBox pictureBoxRear;
        private PictureBox pictureBoxRight;
        private FolderBrowserDialog folderBrowserDialog;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private PictureBox pictureBoxLeft;
        private Label labelForwardImageIndex;
        private Label labelRearImageIndex;
        private Button buttonPast;
        private Label labelLoading;
        private Button buttonNumberDown;
        private Button buttonNumberUp;
        private Label labelLeftImageIndex;
        private Label labelRightImageIndex;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem openBasicFolderToolStripMenuItem;
        private FolderBrowserDialog basicFolderBrowserDialog;
        private ToolStripMenuItem resetBasicFolderToolStripMenuItem;
        private CheckBox checkBoxFixZoom;
        private Button buttonZoomFit;
        private TextBox textBoxFolderName;
        private Button buttonFavorites;
        private Button button_GoToImge;
        private Button button_ForwardGetPath;
        private Button button_RearGetPath;
        private Button button_LeftGetPath;
        private Button button_RightGetPath;
    }
}