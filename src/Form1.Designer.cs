using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            button1 = new Button();
            textBox1 = new TextBox();
            DFSButton = new Button();
            BFSButton = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            textBox2 = new TextBox();
            progressBar1 = new ProgressBar();
            label2 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.FromArgb(192, 255, 255);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Location = new Point(442, 56);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.Size = new Size(500, 500);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(109, 253);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(199, 66);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.Black;
            textBox1.Location = new Point(157, 213);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(104, 28);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // DFSButton
            // 
            DFSButton.BackColor = Color.Transparent;
            DFSButton.BackgroundImage = (Image)resources.GetObject("DFSButton.BackgroundImage");
            DFSButton.BackgroundImageLayout = ImageLayout.Zoom;
            DFSButton.Cursor = Cursors.Hand;
            DFSButton.FlatAppearance.BorderSize = 0;
            DFSButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            DFSButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            DFSButton.FlatStyle = FlatStyle.Flat;
            DFSButton.ImageAlign = ContentAlignment.TopCenter;
            DFSButton.Location = new Point(93, 361);
            DFSButton.Margin = new Padding(2);
            DFSButton.Name = "DFSButton";
            DFSButton.Size = new Size(239, 81);
            DFSButton.TabIndex = 3;
            DFSButton.UseVisualStyleBackColor = false;
            DFSButton.Click += button2_Click;
            // 
            // BFSButton
            // 
            BFSButton.BackColor = Color.Transparent;
            BFSButton.BackgroundImage = (Image)resources.GetObject("BFSButton.BackgroundImage");
            BFSButton.BackgroundImageLayout = ImageLayout.Zoom;
            BFSButton.Cursor = Cursors.Hand;
            BFSButton.FlatAppearance.BorderSize = 0;
            BFSButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BFSButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BFSButton.FlatStyle = FlatStyle.Flat;
            BFSButton.Location = new Point(93, 475);
            BFSButton.Margin = new Padding(2);
            BFSButton.Name = "BFSButton";
            BFSButton.Size = new Size(239, 81);
            BFSButton.TabIndex = 4;
            BFSButton.UseVisualStyleBackColor = false;
            BFSButton.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(8, 56);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(431, 126);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(442, 561);
            label1.Name = "label1";
            label1.Size = new Size(133, 25);
            label1.TabIndex = 6;
            label1.Text = "Jumlah Operasi";
            label1.Click += label1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(581, 558);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(75, 31);
            textBox2.TabIndex = 7;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(272, 633);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(500, 34);
            progressBar1.TabIndex = 8;
            progressBar1.Click += progressBar1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(464, 670);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 9;
            label2.Text = "Progress Bar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(744, 561);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 10;
            label3.Text = "Runtime(ms)";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.Click += label3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(862, 558);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(80, 31);
            textBox3.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(996, 748);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(BFSButton);
            Controls.Add(DFSButton);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Padding = new Padding(12);
            Text = "    ";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Button button1;
        private TextBox textBox1;
        private Button DFSButton;
        private Button BFSButton;
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox textBox2;
        private ProgressBar progressBar1;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
    }
}

