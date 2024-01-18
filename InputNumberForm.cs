using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image4glass
{
    public partial class InputNumberForm : Form
    {
        public decimal value;
        public InputNumberForm(decimal v)
        {
            InitializeComponent();
            this.value = v;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.value = this.numericUpDown.Value;
            this.Close();
        }

        private void InputNumberForm_Load(object sender, EventArgs e)
        {
            this.numericUpDown.Value = this.value;
            numericUpDown.Select(0, numericUpDown.Text.Length);
        }
    }
}
