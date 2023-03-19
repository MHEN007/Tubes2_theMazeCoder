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
            string mazepath;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //LoadMazeData();
            //button1.Click += new EventHandler(button1_Click);
        }

        // public void LoadMazeData()
        //{
        //    string[] lines = File.ReadAllLines("../maze.txt");
        //    int numRows = lines.Length;
        //    int numCols = lines[0].Split(' ').Length;

        //    dataGridView1.ColumnCount = numCols;
        //    dataGridView1.RowCount = numRows;

        //    for (int i = 0; i < numRows; i++)
        //   {
        //        string[] rowValues = lines[i].Split(' ');
        //        for (int j = 0; j < numCols; j++)
        //        {
        //            string cellValue = rowValues[j];
        //           dataGridView1.Rows[i].Cells[j].Value = cellValue;

        //            if (cellValue == "K")
        //                dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(244, 77, 60);
        //            else if (cellValue == "T")
        //                dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(229, 223, 18);
        //            else if (cellValue == "R")
        //                dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(236, 237, 156);
        //            else if (cellValue == "X")
        //                dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.FromArgb(91, 120, 152);
        //       }
        //   }
        //}

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

        //private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        //    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string mazePath = openFileDialog.FileName;
        //        LoadMazeData(mazePath);
        //    }

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a maze file";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                textBox1.Text = Path.GetFileName(selectedFileName);
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

    private async void button3_Click(object sender, EventArgs e)
    {
        // Queue for BFS
        Queue<Vertex> queue = new Queue<Vertex>();

        // Already visited vertices
        HashSet<Vertex> visited = new HashSet<Vertex>();

        // Start vertex
        Solver start = new Solver();

        // Treasure found
        int treasureFound = 0;
        int treasure = start.m.getTreasureCount();

        // Add start vertex to queue
        Vertex startVertex = start.m.getStartingPoint(start.m.getMap());
        dataGridView1.Rows[startVertex.getRow()].Cells[startVertex.getCol()].Style.BackColor = System.Drawing.Color.FromArgb(115, 147, 179);
        queue.Enqueue(startVertex);

        // Add start vertex to visited
        visited.Add(startVertex);

        // While queue is not empty
        while (queue.Count > 0)
        {
            // Dequeue vertex
            Vertex currentVertex = queue.Dequeue();
            visited.Add(currentVertex);

            // If treasure is found
            if (currentVertex.getValue() == 'T')
            {
                // Increment treasure found
                treasureFound++;

                // If all treasure is found
                if (treasureFound == treasure)
                {
                    // Print path
                    // printPath(path, currentVertex);
                    // break;
                }
            }

            if (start.m.isDownValid(currentVertex, start.m.getMap()))
            {
                Vertex downVertex = start.m.getDown(currentVertex);
                if (!visited.Contains(downVertex))
                {
                    queue.Enqueue(downVertex);
                    visited.Add(downVertex);
                    dataGridView1.Rows[downVertex.getRow()].Cells[downVertex.getCol()].Style.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                }
            }

            if (start.m.isUpValid(currentVertex, start.m.getMap()))
            {
                Vertex upVertex = start.m.getUp(currentVertex);
                if (!visited.Contains(upVertex))
                {
                    queue.Enqueue(upVertex);
                    visited.Add(upVertex);
                    dataGridView1.Rows[upVertex.getRow()].Cells[upVertex.getCol()].Style.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                }
            }

            if (start.m.isLeftValid(currentVertex, start.m.getMap()))
            {
                Vertex leftVertex = start.m.getLeft(currentVertex);
                if (!visited.Contains(leftVertex))
                {
                    queue.Enqueue(leftVertex);
                    visited.Add(leftVertex);
                    dataGridView1.Rows[leftVertex.getRow()].Cells[leftVertex.getCol()].Style.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                }
            }

            if (start.m.isRightValid(currentVertex, start.m.getMap()))
            {
                Vertex rightVertex = start.m.getRight(currentVertex);
                if (!visited.Contains(rightVertex))
                {
                    queue.Enqueue(rightVertex);
                    visited.Add(rightVertex);
                    dataGridView1.Rows[rightVertex.getRow()].Cells[rightVertex.getCol()].Style.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                }
            }

            // Wait for 100 milliseconds before updating the DataGridView
            await Task.Delay(1000);
        }
    }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}