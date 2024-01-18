namespace Image4glass
{
    partial class InputNumberForm
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
            numericUpDown = new NumericUpDown();
            buttonOk = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown
            // 
            numericUpDown.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown.Location = new Point(12, 12);
            numericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(201, 27);
            numericUpDown.TabIndex = 0;
            numericUpDown.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonOk
            // 
            buttonOk.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonOk.Location = new Point(12, 56);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(97, 36);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCancel.Location = new Point(115, 56);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(98, 37);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // InputNumberForm
            // 
            AcceptButton = buttonOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(224, 111);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(numericUpDown);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputNumberForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enter photo number";
            TopMost = true;
            Load += InputNumberForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown numericUpDown;
        private Button buttonOk;
        private Button buttonCancel;
    }
}