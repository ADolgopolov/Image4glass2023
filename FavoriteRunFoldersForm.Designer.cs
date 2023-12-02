namespace Image4glass
{
    partial class FavoriteRunFoldersForm
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
            listBox = new ListBox();
            SuspendLayout();
            // 
            // listBox
            // 
            listBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 21;
            listBox.Location = new Point(12, 12);
            listBox.Name = "listBox";
            listBox.Size = new Size(820, 319);
            listBox.TabIndex = 0;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // FavoriteRunFoldersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 361);
            Controls.Add(listBox);
            Name = "FavoriteRunFoldersForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Оберіть теку ранів з попередніх";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox;
    }
}