namespace Image4glass
{
    partial class ZoomImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoomImageForm));
            panel = new Panel();
            panel_Ruler = new Panel();
            button_CopyToClipboard = new Button();
            button_Reset = new Button();
            label_PixelLength_Info = new Label();
            label_PixelLength = new Label();
            label_2ndPointInfo = new Label();
            label_1stPointInfo = new Label();
            label_RightClick = new Label();
            label_DoubleClick = new Label();
            pictureBox = new PictureBox();
            buttonFitImage = new Button();
            panel.SuspendLayout();
            panel_Ruler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.AutoSize = true;
            panel.BackColor = SystemColors.ControlDarkDark;
            panel.Controls.Add(panel_Ruler);
            panel.Controls.Add(pictureBox);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(1008, 985);
            panel.TabIndex = 1;
            panel.MouseDown += panel_MouseDown;
            panel.Resize += panel_Resize;
            // 
            // panel_Ruler
            // 
            panel_Ruler.BackColor = SystemColors.Control;
            panel_Ruler.BorderStyle = BorderStyle.FixedSingle;
            panel_Ruler.Controls.Add(button_CopyToClipboard);
            panel_Ruler.Controls.Add(button_Reset);
            panel_Ruler.Controls.Add(label_PixelLength_Info);
            panel_Ruler.Controls.Add(label_PixelLength);
            panel_Ruler.Controls.Add(label_2ndPointInfo);
            panel_Ruler.Controls.Add(label_1stPointInfo);
            panel_Ruler.Controls.Add(label_RightClick);
            panel_Ruler.Controls.Add(label_DoubleClick);
            panel_Ruler.Location = new Point(3, 3);
            panel_Ruler.Name = "panel_Ruler";
            panel_Ruler.Size = new Size(219, 124);
            panel_Ruler.TabIndex = 1;
            // 
            // button_CopyToClipboard
            // 
            button_CopyToClipboard.Location = new Point(113, 57);
            button_CopyToClipboard.Name = "button_CopyToClipboard";
            button_CopyToClipboard.Size = new Size(94, 25);
            button_CopyToClipboard.TabIndex = 3;
            button_CopyToClipboard.Text = "Copy {Ctrl-C}";
            button_CopyToClipboard.UseVisualStyleBackColor = true;
            button_CopyToClipboard.Click += button_CopyToClipboard_Click;
            // 
            // button_Reset
            // 
            button_Reset.Location = new Point(8, 57);
            button_Reset.Name = "button_Reset";
            button_Reset.Size = new Size(94, 25);
            button_Reset.TabIndex = 8;
            button_Reset.Text = "Reset {Space}";
            button_Reset.UseVisualStyleBackColor = true;
            button_Reset.Click += button_Reset_Click;
            // 
            // label_PixelLength_Info
            // 
            label_PixelLength_Info.BorderStyle = BorderStyle.Fixed3D;
            label_PixelLength_Info.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_PixelLength_Info.Location = new Point(101, 89);
            label_PixelLength_Info.Name = "label_PixelLength_Info";
            label_PixelLength_Info.Size = new Size(106, 22);
            label_PixelLength_Info.TabIndex = 7;
            label_PixelLength_Info.Text = "Undefined";
            label_PixelLength_Info.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_PixelLength
            // 
            label_PixelLength.AutoSize = true;
            label_PixelLength.Location = new Point(12, 94);
            label_PixelLength.Name = "label_PixelLength";
            label_PixelLength.Size = new Size(75, 15);
            label_PixelLength.TabIndex = 6;
            label_PixelLength.Text = "Pixel Length:";
            // 
            // label_2ndPointInfo
            // 
            label_2ndPointInfo.BorderStyle = BorderStyle.Fixed3D;
            label_2ndPointInfo.Location = new Point(101, 27);
            label_2ndPointInfo.Name = "label_2ndPointInfo";
            label_2ndPointInfo.Size = new Size(106, 20);
            label_2ndPointInfo.TabIndex = 5;
            label_2ndPointInfo.Text = "Undefined";
            label_2ndPointInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_1stPointInfo
            // 
            label_1stPointInfo.BorderStyle = BorderStyle.Fixed3D;
            label_1stPointInfo.Location = new Point(101, 7);
            label_1stPointInfo.Name = "label_1stPointInfo";
            label_1stPointInfo.Size = new Size(106, 20);
            label_1stPointInfo.TabIndex = 4;
            label_1stPointInfo.Text = "Undefined";
            label_1stPointInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_RightClick
            // 
            label_RightClick.AutoSize = true;
            label_RightClick.Location = new Point(12, 30);
            label_RightClick.Name = "label_RightClick";
            label_RightClick.Size = new Size(69, 15);
            label_RightClick.TabIndex = 3;
            label_RightClick.Text = "{RightClick}";
            // 
            // label_DoubleClick
            // 
            label_DoubleClick.AutoSize = true;
            label_DoubleClick.Location = new Point(12, 10);
            label_DoubleClick.Name = "label_DoubleClick";
            label_DoubleClick.Size = new Size(79, 15);
            label_DoubleClick.TabIndex = 3;
            label_DoubleClick.Text = "{DoubleClick}";
            // 
            // pictureBox
            // 
            pictureBox.Cursor = Cursors.Cross;
            pictureBox.Location = new Point(230, 278);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(512, 512);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.DoubleClick += pictureBox_DoubleClick;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            pictureBox.MouseUp += pictureBox_MouseUp;
            pictureBox.MouseWheel += PictureBox_MouseWheel;
            // 
            // buttonFitImage
            // 
            buttonFitImage.Location = new Point(1, 1);
            buttonFitImage.Name = "buttonFitImage";
            buttonFitImage.Size = new Size(1, 1);
            buttonFitImage.TabIndex = 2;
            buttonFitImage.UseVisualStyleBackColor = true;
            buttonFitImage.Click += buttonFitImage_Click;
            // 
            // ZoomImageForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            CancelButton = buttonFitImage;
            ClientSize = new Size(1008, 985);
            Controls.Add(buttonFitImage);
            Controls.Add(panel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(1, 1);
            Name = "ZoomImageForm";
            StartPosition = FormStartPosition.Manual;
            Text = "ZoomImageForm";
            WindowState = FormWindowState.Maximized;
            Load += ZoomImageForm_Load;
            KeyDown += ZoomImageForm_KeyDown;
            KeyUp += ZoomImageForm_KeyUp;
            panel.ResumeLayout(false);
            panel_Ruler.ResumeLayout(false);
            panel_Ruler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel;
        private PictureBox pictureBox;
        private Button buttonFitImage;
        private Panel panel_Ruler;
        private Label label_RightClick;
        private Label label_DoubleClick;
        private Label label_2ndPointInfo;
        private Label label_1stPointInfo;
        private Label label_PixelLength_Info;
        private Label label_PixelLength;
        private Button button_Reset;
        private Button button_CopyToClipboard;
    }
}