using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string mazepath;
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
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.Rows[0].Cells[0].Style.BackColor;
            //dataGridView1.Columns[0].Visible = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
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

        /* BFS */
        private async void button3_Click(object sender, EventArgs e)
        {
            /* Load ulang */
            textBox2.Text = "0";
            textBox3.Text = "0";
            LoadMazeData(mazepath);
            // Queue for BFS
            Queue<Vertex> queue = new Queue<Vertex>();

            // Already visited vertices
            Stack<Vertex> visited = new Stack<Vertex>();

            // Start vertex
            Solver start = new Solver(mazepath);

            // Treasure found
            int treasureFound = 0;
            int treasure = start.m.getTreasureCount();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = start.BFS();
            progressBar1.Value = 0;

            // Add start vertex to queue
            Vertex startVertex = start.m.getStartingPoint(start.m.getMap());
            dataGridView1.Rows[startVertex.getCol()].Cells[startVertex.getRow()].Style.BackColor = System.Drawing.Color.FromArgb(115, 147, 179);
            queue.Enqueue(startVertex);

            // Add start vertex to visited
            visited.Push(startVertex);

            int c = 0;
            // While queue is not empty
            var startTime = DateTime.Now;
            while (queue.Count > 0 && treasure != treasureFound)
            {
                c++;
                progressBar1.Value++;
                // Dequeue vertex
                Vertex currentVertex = queue.Dequeue();
                visited.Push(currentVertex);
                dataGridView1.Rows[currentVertex.getCol()].Cells[currentVertex.getRow()].Style.BackColor = System.Drawing.Color.Green;
                dataGridView1.Rows[currentVertex.getCol()].Cells[currentVertex.getRow()].Style.ForeColor = System.Drawing.Color.Green;
                // If treasure is found
                if (currentVertex.GetStatusTreasure())
                {
                    // Increment treasure found
                    treasureFound++;
                }

                if (start.m.isRightValid(currentVertex, start.m.getMap()))
                {
                    Vertex rightVertex = start.m.getRight(currentVertex);
                    if (!visited.Contains(rightVertex))
                    {
                        queue.Enqueue(rightVertex);
                        visited.Push(rightVertex);
                    }
                }

                if (start.m.isLeftValid(currentVertex, start.m.getMap()))
                {
                    Vertex leftVertex = start.m.getLeft(currentVertex);
                    if (!visited.Contains(leftVertex))
                    {
                        queue.Enqueue(leftVertex);
                        visited.Push(leftVertex);
                    }
                }

                if (start.m.isUpValid(currentVertex, start.m.getMap()))
                {
                    Vertex upVertex = start.m.getUp(currentVertex);
                    if (!visited.Contains(upVertex))
                    {
                        queue.Enqueue(upVertex);
                        visited.Push(upVertex);
                    }
                }

                if (start.m.isDownValid(currentVertex, start.m.getMap()))
                {
                    Vertex downVertex = start.m.getDown(currentVertex);
                    if (!visited.Contains(downVertex))
                    {
                        queue.Enqueue(downVertex);
                        visited.Push(downVertex);
                    }
                }


                // Wait for 100 milliseconds before updating the DataGridView
                await Task.Delay(100);
            }
            var endTime = DateTime.Now;
            textBox2.Text = c.ToString();
            var runTime = endTime - startTime;
            int run = runTime.Milliseconds;
            textBox3.Text = run.ToString();
        }

        /* DFS */
        private async void button2_Click(object sender, EventArgs e)
        {
            /* Load ulang */
            textBox2.Text = "0";
            textBox3.Text = "0";
            LoadMazeData(mazepath);
            // Stack for DFS
            Stack<Vertex> stack = new Stack<Vertex>();

            // Already visited vertices
            Stack<Vertex> visited = new Stack<Vertex>();

            // Start vertex
            Solver start = new Solver(mazepath);

            // Treasure found
            int treasureFound = 0;
            int treasure = start.m.getTreasureCount();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = start.DFS();
            progressBar1.Value = 0;

            // Add start vertex to queue
            Vertex startVertex = start.m.getStartingPoint(start.m.getMap());
            dataGridView1.Rows[startVertex.getCol()].Cells[startVertex.getRow()].Style.BackColor = System.Drawing.Color.FromArgb(115, 147, 179);
            stack.Push(startVertex);

            // Add start vertex to visited
            visited.Push(startVertex);

            int c = 0;
            var startTime = DateTime.Now;
            while (stack.Count > 0 && treasureFound != treasure)
            {
                c++;
                progressBar1.Value++;
                Vertex current = stack.Pop();
                visited.Push(current);
                dataGridView1.Rows[current.getCol()].Cells[current.getRow()].Style.BackColor = System.Drawing.Color.Green;
                dataGridView1.Rows[current.getCol()].Cells[current.getRow()].Style.ForeColor = System.Drawing.Color.Green;
                if (current.GetStatusTreasure())
                {
                    treasureFound++;
                }

                if (start.m.isDownValid(current, start.m.getMap()) && !visited.Contains(start.m.getVertex(current.x, current.y + 1)))
                {
                    Vertex down = start.m.getVertex(current.x, current.y + 1);
                    stack.Push(down);
                }

                if (start.m.isUpValid(current, start.m.getMap()) && !visited.Contains(start.m.getVertex(current.x, current.y - 1)))
                {
                    Vertex up = start.m.getVertex(current.x, current.y - 1);
                    stack.Push(up);
                }

                if (start.m.isLeftValid(current, start.m.getMap()) && !visited.Contains(start.m.getVertex(current.x - 1, current.y)))
                {
                    Vertex left = start.m.getVertex(current.x - 1, current.y);
                    stack.Push(left);
                }

                if (start.m.isRightValid(current, start.m.getMap()) && !visited.Contains(start.m.getVertex(current.x + 1, current.y)))
                {
                    Vertex right = start.m.getVertex(current.x + 1, current.y);
                    stack.Push(right);
                }
                await Task.Delay(100);
            }
            var endTime = DateTime.Now;
            textBox2.Text = c.ToString();
            var runTime = endTime - startTime;
            int run = runTime.Milliseconds;
            textBox3.Text = run.ToString();
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

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}