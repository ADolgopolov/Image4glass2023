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
    public partial class FavoriteRunFoldersForm : Form
    {
        public string? selectedRunFolder = String.Empty;
        public FavoriteRunFoldersForm(List<string> listBoxItems)
        {
            InitializeComponent();
            listBox.Items.AddRange(listBoxItems.ToArray());
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Перевірка, чи є виділений елемент і чи він не є null
            if (listBox.SelectedItem != null)
            {
                selectedRunFolder = listBox.SelectedItem.ToString();
                //MessageBox.Show($"Виділений елемент: {selectedRunFolder}");
                this.Close();
            }
        }
    }
}
