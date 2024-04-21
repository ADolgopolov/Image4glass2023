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
            textBox_2ndPointInfo = new TextBox();
            textBox_1stPointInfo = new TextBox();
            textBox_PixelLength_Info = new TextBox();
            button_CopyToClipboard = new Button();
            button_Reset = new Button();
            label_PixelLength = new Label();
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
            panel_Ruler.AutoSize = true;
            panel_Ruler.BackColor = SystemColors.Control;
            panel_Ruler.BorderStyle = BorderStyle.FixedSingle;
            panel_Ruler.Controls.Add(textBox_2ndPointInfo);
            panel_Ruler.Controls.Add(textBox_1stPointInfo);
            panel_Ruler.Controls.Add(textBox_PixelLength_Info);
            panel_Ruler.Controls.Add(button_CopyToClipboard);
            panel_Ruler.Controls.Add(button_Reset);
            panel_Ruler.Controls.Add(label_PixelLength);
            panel_Ruler.Controls.Add(label_RightClick);
            panel_Ruler.Controls.Add(label_DoubleClick);
            panel_Ruler.Location = new Point(3, 3);
            panel_Ruler.Name = "panel_Ruler";
            panel_Ruler.Size = new Size(216, 124);
            panel_Ruler.TabIndex = 1;
            // 
            // textBox_2ndPointInfo
            // 
            textBox_2ndPointInfo.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_2ndPointInfo.Location = new Point(91, 30);
            textBox_2ndPointInfo.Name = "textBox_2ndPointInfo";
            textBox_2ndPointInfo.ReadOnly = true;
            textBox_2ndPointInfo.Size = new Size(116, 21);
            textBox_2ndPointInfo.TabIndex = 11;
            textBox_2ndPointInfo.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_1stPointInfo
            // 
            textBox_1stPointInfo.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_1stPointInfo.Location = new Point(91, 6);
            textBox_1stPointInfo.Name = "textBox_1stPointInfo";
            textBox_1stPointInfo.ReadOnly = true;
            textBox_1stPointInfo.Size = new Size(116, 21);
            textBox_1stPointInfo.TabIndex = 10;
            textBox_1stPointInfo.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_PixelLength_Info
            // 
            textBox_PixelLength_Info.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBox_PixelLength_Info.Location = new Point(91, 88);
            textBox_PixelLength_Info.Name = "textBox_PixelLength_Info";
            textBox_PixelLength_Info.ReadOnly = true;
            textBox_PixelLength_Info.Size = new Size(116, 26);
            textBox_PixelLength_Info.TabIndex = 9;
            textBox_PixelLength_Info.Text = "Undefined";
            textBox_PixelLength_Info.TextAlign = HorizontalAlignment.Center;
            // 
            // button_CopyToClipboard
            // 
            button_CopyToClipboard.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button_CopyToClipboard.Location = new Point(110, 57);
            button_CopyToClipboard.Name = "button_CopyToClipboard";
            button_CopyToClipboard.Size = new Size(97, 25);
            button_CopyToClipboard.TabIndex = 3;
            button_CopyToClipboard.Text = "Copy {Ctrl-C}";
            button_CopyToClipboard.UseVisualStyleBackColor = true;
            button_CopyToClipboard.Click += button_CopyToClipboard_Click;
            // 
            // button_Reset
            // 
            button_Reset.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button_Reset.Location = new Point(3, 57);
            button_Reset.Name = "button_Reset";
            button_Reset.Size = new Size(101, 25);
            button_Reset.TabIndex = 8;
            button_Reset.Text = "Reset {Space}";
            button_Reset.UseVisualStyleBackColor = true;
            button_Reset.Click += button_Reset_Click;
            // 
            // label_PixelLength
            // 
            label_PixelLength.AutoSize = true;
            label_PixelLength.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label_PixelLength.Location = new Point(3, 94);
            label_PixelLength.Name = "label_PixelLength";
            label_PixelLength.Size = new Size(77, 15);
            label_PixelLength.TabIndex = 6;
            label_PixelLength.Text = "Pixel Length:";
            // 
            // label_RightClick
            // 
            label_RightClick.AutoSize = true;
            label_RightClick.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label_RightClick.Location = new Point(3, 33);
            label_RightClick.Name = "label_RightClick";
            label_RightClick.Size = new Size(71, 15);
            label_RightClick.TabIndex = 3;
            label_RightClick.Text = "{RightClick}";
            // 
            // label_DoubleClick
            // 
            label_DoubleClick.AutoSize = true;
            label_DoubleClick.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label_DoubleClick.Location = new Point(3, 9);
            label_DoubleClick.Name = "label_DoubleClick";
            label_DoubleClick.Size = new Size(82, 15);
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
            panel.PerformLayout();
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
        private Label label_PixelLength;
        private Button button_Reset;
        private Button button_CopyToClipboard;
        private TextBox textBox_PixelLength_Info;
        private TextBox textBox_2ndPointInfo;
        private TextBox textBox_1stPointInfo;
    }
}