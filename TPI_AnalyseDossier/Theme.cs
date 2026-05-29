using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_AnalyseDossier
{
    public static class Theme
    {
        public static Color Background = Color.FromArgb(245, 245, 247);   // fond global (très léger gris)
        public static Color Surface = Color.White;                        // cartes / panels
        public static Color SurfaceLight = Color.FromArgb(230, 230, 235); // hover / zones secondaires

        public static Color Text = Color.FromArgb(30, 30, 30);            // texte principal
        public static Color TextSecondary = Color.FromArgb(100, 100, 100);

        public static Color Accent = Color.FromArgb(99, 102, 241); // violet/indigo

        public static Color Border = Color.FromArgb(210, 210, 210);


        public static void ApplyTheme(Control parent)
            {
                parent.BackColor = Theme.Background;

                foreach (Control c in parent.Controls)
                {
                    ApplyControlTheme(c);

                    if (c.HasChildren)
                        ApplyTheme(c);
                }
            }

            private static void ApplyControlTheme(Control c)
            {
                switch (c)
                {
                    case Panel:
                        c.BackColor = Theme.Surface;
                        break;

                  

                    case Label lbl:
                        lbl.ForeColor = Theme.Text;
                        break;

                    case TextBox txt:
                        txt.BackColor = Theme.Surface;
                        txt.ForeColor = Theme.Text;
                        txt.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case ComboBox cmb:
                        cmb.BackColor = Theme.Surface;
                        cmb.ForeColor = Theme.Text;
                        cmb.FlatStyle = FlatStyle.Flat;
                        break;

                    case TreeView tv:
                        tv.BackColor = Theme.Surface;
                        tv.ForeColor = Theme.Text;
                        tv.BorderStyle = BorderStyle.None;
                        break;

                    case DataGridView dgv:
                        StyleDataGridView(dgv);
                        break;
                }
            }

            private static void StyleDataGridView(DataGridView dgv)
            {
                dgv.BackgroundColor = Theme.Surface;
                dgv.BorderStyle = BorderStyle.None;

                dgv.EnableHeadersVisualStyles = false;

                dgv.ColumnHeadersDefaultCellStyle.BackColor = Theme.SurfaceLight;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Theme.Text;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

                dgv.DefaultCellStyle.BackColor = Theme.Surface;
                dgv.DefaultCellStyle.ForeColor = Theme.Text;
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11);
                dgv.DefaultCellStyle.SelectionBackColor = Theme.Accent;
                dgv.DefaultCellStyle.SelectionForeColor = Color.White;

                dgv.RowHeadersVisible = false;

                dgv.GridColor = Theme.Border;

                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

    }



