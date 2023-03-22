using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string mazepath;
        bool isButtonClicked = false;
        int delay;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadMazeData(string mazePath)
        {
            string[] lines = File.ReadAllLines(mazePath);
            int numRows = lines.Length;
            int numCols = lines[0].Split(' ').Length;

            dataGridView1.ColumnCount = numCols;
            dataGridView1.RowCount = numRows;
            dataGridView1.ClearSelection();

            for (int i = 0; i < numRows; i++)
            {
                string[] rowValues = lines[i].Split(' ');
                for (int j = 0; j < numCols; j++)
                {
                    string cellValue = rowValues[j];
                    dataGridView1.Rows[i].Cells[j].Value = cellValue;
                    if (cellValue == "K")
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(244, 77, 60);
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = System.Drawing.Color.FromArgb(244, 77, 60);
                    }
                    else if (cellValue == "T")
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(229, 223, 18);
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = System.Drawing.Color.FromArgb(229, 223, 18);
                    }
                    else if (cellValue == "R")
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(236, 237, 156);
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = System.Drawing.Color.FromArgb(236, 237, 156);
                    }
                    else if (cellValue == "X")
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(91, 120, 152);
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = System.Drawing.Color.FromArgb(91, 120, 152);
                    }
                }
            }
        }

        private bool isMazePathLoaded()
        {
            if (mazepath == null)
            {
                return false;
            }
            return true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!isButtonClicked)
            {
                isButtonClicked = true;
                button.Enabled = false;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Text files (*.txt)|*.txt";
                openFileDialog1.Title = "Select a maze file";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFileName = openFileDialog1.FileName;
                    textBox1.Text = Path.GetFileName(selectedFileName);
                    mazepath = openFileDialog1.FileName;
                    try
                    {
                        LoadMazeData(selectedFileName);
                        SetDataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading maze: " + ex.Message);
                    }
                }
            }
            isButtonClicked = false;
            button.Enabled = true;
        }


        /* DFS */
        private async void DFS()
        {
            if (!isMazePathLoaded())
            {
                MessageBox.Show("Please load a maze first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBox2.Text = "0";
            textBox3.Text = "0";
            LoadMazeData(mazepath);

            Solver solve = new Solver(mazepath);
            Vertex start = solve.m.getStartingPoint(solve.m.getMap());

            textBox2.Text = solve.nodesChecked.ToString();

            var startTime = DateTime.Now;
            string paths = solve.DFS();
            var endTime = DateTime.Now;
            var runTime = endTime - startTime;

            dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Blue;
            dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Blue;

            await Task.Delay(trackBar1.Value);

            dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Green;
            dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Green;

            int c = 0;
            foreach (Char move in paths)
            {
                c++;
                if (move == 'R')
                {
                    start.x++;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Blue;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Blue;
                }
                if (move == 'L')
                {
                    start.x--;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Blue;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Blue;
                }
                if (move == 'U')
                {
                    start.y--;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Blue;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Blue;
                }
                if (move == 'D')
                {
                    start.y++;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Blue;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Blue;
                }
                if (solve.m.getVertex(start).GetStatusTreasure())
                {
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Yellow;
                    dataGridView1.Rows[start.y].Cells[start.x].Value = "Treasure";
                }
                await Task.Delay(trackBar1.Value);
                dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Green;
                if (!solve.m.getVertex(start).GetStatusTreasure())
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Green;
            }


            textBox2.Text = c.ToString();
            int run = runTime.Milliseconds;
            textBox3.Text = run.ToString();

            textBox4.Text = paths;

            textBox5.Text = solve.nodesChecked.ToString();
        }

        /* BFS */
        private async void BFS()
        {
            if (!isMazePathLoaded())
            {
                MessageBox.Show("Please load a maze first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /* Load ulang */
            textBox3.Text = "0";
            LoadMazeData(mazepath);

            Solver solver = new Solver(mazepath);

            textBox2.Text = solver.nodesChecked.ToString();

            var startTime = DateTime.Now;
            String path = solver.BFS();
            var endTime = DateTime.Now;
            var runTime = endTime - startTime;
            Vertex start = solver.m.getStartingPoint(solver.m.getMap());

            dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Blue;
            dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Blue;

            await Task.Delay(trackBar1.Value);

            dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Green;
            dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Green;

            int c = 0;
            foreach (Char move in path)
            {
                c++;
                if (move == 'R')
                {
                    start.x++;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Blue;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Blue;
                }
                if (move == 'L')
                {
                    start.x--;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Blue;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Blue;
                }
                if (move == 'U')
                {
                    start.y--;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Blue;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Blue;
                }
                if (move == 'D')
                {
                    start.y++;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Blue;
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Blue;
                }
                if (solver.m.getVertex(start).GetStatusTreasure())
                {
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Yellow;
                    dataGridView1.Rows[start.y].Cells[start.x].Value = "Treasure";
                }
                await Task.Delay(trackBar1.Value);
                dataGridView1.Rows[start.y].Cells[start.x].Style.BackColor = System.Drawing.Color.Green;
                if (!solver.m.getVertex(start).GetStatusTreasure())
                    dataGridView1.Rows[start.y].Cells[start.x].Style.ForeColor = System.Drawing.Color.Green;
            }


            textBox2.Text = c.ToString();

            int run = runTime.Milliseconds;
            textBox3.Text = run.ToString();
            textBox4.Text = path;
            textBox5.Text = solver.nodesChecked.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!isButtonClicked)
            {
                isButtonClicked = true;
                button.Enabled = false;

                if (radioButton1.Checked)
                {
                    DFS();
                }
                else if (radioButton2.Checked)
                {
                    BFS();
                }
                else if (radioButton3.Checked)
                {
                    // TSP();
                }
            }
            isButtonClicked = false;
            button.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}