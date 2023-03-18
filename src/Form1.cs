using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            LoadMazeData();
            SetDataGridView();
        }

        public void LoadMazeData()
        {
            string[] lines = File.ReadAllLines("../maze.txt");
            int numRows = lines.Length;
            int numCols = lines[0].Split(' ').Length;

            dataGridView1.ColumnCount = numCols;
            dataGridView1.RowCount = numRows;

            for (int i = 0; i < numRows; i++)
            {
                string[] rowValues = lines[i].Split(' ');
                for (int j = 0; j < numCols; j++)
                {
                    string cellValue = rowValues[j];
                    dataGridView1.Rows[i].Cells[j].Value = cellValue;

                    if (cellValue == "K")
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(244, 77, 60);
                    else if (cellValue == "T")
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(229, 223, 18);
                    else if (cellValue == "R")
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(236, 237, 156);
                    else if (cellValue == "X")
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(91, 120, 152);
                }
            }
        }

        private void SetDataGridView()
        {
            int width = dataGridView1.Width / dataGridView1.Columns.Count;
            int height = dataGridView1.Height / dataGridView1.Rows.Count;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = width;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = height;
            }
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.Enabled = false;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.Rows[0].Cells[0].Style.BackColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}