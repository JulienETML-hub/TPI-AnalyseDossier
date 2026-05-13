using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TPI_AnalyseDossier
{
    public partial class resultUserControl : UserControl
    {
        public resultUserControl()
        {
            InitializeComponent();
            Theme.ApplyTheme(this);
            for (int i = 250; i >= 1; i--)
            {
                dataGridViewResults.Rows.Add(
                    $"file{i}.txt",
                    $"{i * 10} MO",
                    DateTime.Now.ToString(),
                    @"C:\Test\file" + i + ".txt"
                );
            }
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.CellSelect;
            CheckedListBox clb = new CheckedListBox();

            clb.Items.AddRange(new object[] { ".txt", ".jpg", ".pdf" });

            ToolStripDropDown dropDown = new ToolStripDropDown();
            ToolStripControlHost host = new ToolStripControlHost(clb);
            dropDown.Items.Add(host);

            comboBox1.Click += (s, e) =>
            {
                dropDown.Show(comboBox1, 0, comboBox1.Height);
            };

            minimalSizeNmr.Minimum = 0;
            minimalSizeNmr.Maximum = 1000;
            minimalSizeNmr.Value = 25;

        }

        private void resultUserControl_Load(object sender, EventArgs e)
        {

        }

        private void filtreExtensionCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchLbl_Click(object sender, EventArgs e)
        {

        }

        private void searchBarTbx_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
