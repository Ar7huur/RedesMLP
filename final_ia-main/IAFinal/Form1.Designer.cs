namespace IAFinal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            ocultaBox = new TextBox();
            saidaBox = new TextBox();
            entradaBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            erroBox = new TextBox();
            groupBox3 = new GroupBox();
            iterBox = new TextBox();
            groupBox4 = new GroupBox();
            nBox = new TextBox();
            label5 = new Label();
            groupBox5 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            openDialog = new OpenFileDialog();
            button2 = new Button();
            button3 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(176, 32);
            label1.TabIndex = 0;
            label1.Text = "Redes Neurais";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ocultaBox);
            groupBox1.Controls.Add(saidaBox);
            groupBox1.Controls.Add(entradaBox);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(209, 127);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configurar neurônios";
            // 
            // ocultaBox
            // 
            ocultaBox.Location = new Point(125, 94);
            ocultaBox.Name = "ocultaBox";
            ocultaBox.Size = new Size(78, 23);
            ocultaBox.TabIndex = 9;
            ocultaBox.Text = "5";
            // 
            // saidaBox
            // 
            saidaBox.Enabled = false;
            saidaBox.Location = new Point(125, 60);
            saidaBox.Name = "saidaBox";
            saidaBox.Size = new Size(78, 23);
            saidaBox.TabIndex = 8;
            saidaBox.Text = "5";
            // 
            // entradaBox
            // 
            entradaBox.Enabled = false;
            entradaBox.Location = new Point(125, 24);
            entradaBox.Name = "entradaBox";
            entradaBox.Size = new Size(78, 23);
            entradaBox.TabIndex = 5;
            entradaBox.Text = "6";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 98);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 7;
            label4.Text = "Camada Oculta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 65);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 6;
            label3.Text = "Camada de Saída:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 29);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 5;
            label2.Text = "Camada de Entrada:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(erroBox);
            groupBox2.Location = new Point(227, 53);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 59);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Valor do erro";
            // 
            // erroBox
            // 
            erroBox.Location = new Point(6, 24);
            erroBox.Name = "erroBox";
            erroBox.Size = new Size(112, 23);
            erroBox.TabIndex = 10;
            erroBox.Text = "0,00001";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(iterBox);
            groupBox3.Location = new Point(227, 118);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 62);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Numero de Iterações";
            // 
            // iterBox
            // 
            iterBox.Location = new Point(6, 28);
            iterBox.Name = "iterBox";
            iterBox.Size = new Size(112, 23);
            iterBox.TabIndex = 11;
            iterBox.Text = "2000";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(nBox);
            groupBox4.Controls.Add(label5);
            groupBox4.Location = new Point(433, 53);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(153, 127);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            // 
            // nBox
            // 
            nBox.Location = new Point(14, 57);
            nBox.Name = "nBox";
            nBox.Size = new Size(112, 23);
            nBox.TabIndex = 11;
            nBox.Text = "0,2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 27);
            label5.Name = "label5";
            label5.Size = new Size(19, 15);
            label5.TabIndex = 6;
            label5.Text = "N:";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(radioButton3);
            groupBox5.Controls.Add(radioButton2);
            groupBox5.Controls.Add(radioButton1);
            groupBox5.Location = new Point(592, 53);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(196, 127);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Função de Transferência";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(6, 94);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(86, 19);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Hiperbólica";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 61);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(72, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Logística";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 29);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(57, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Linear";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 186);
            button1.Name = "button1";
            button1.Size = new Size(119, 46);
            button1.TabIndex = 5;
            button1.Text = "Arquivo Treino";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 238);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 369);
            dataGridView1.TabIndex = 7;
            // 
            // openDialog
            // 
            openDialog.FileName = "openFileDialog1";
            // 
            // button2
            // 
            button2.Location = new Point(137, 186);
            button2.Name = "button2";
            button2.Size = new Size(119, 46);
            button2.TabIndex = 8;
            button2.Text = "Arquivo Teste";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(669, 186);
            button3.Name = "button3";
            button3.Size = new Size(119, 46);
            button3.TabIndex = 9;
            button3.Text = "Gerar Resultados";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 619);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Redes Neurais 0.0.0";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Label label4;
        private Label label3;
        private Label label2;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private TextBox ocultaBox;
        private TextBox saidaBox;
        private TextBox entradaBox;
        private Label label5;
        private TextBox erroBox;
        private TextBox iterBox;
        private TextBox nBox;
        private Button button1;
        private DataGridView dataGridView1;
        private OpenFileDialog openDialog;
        private Button button2;
        private Button button3;
    }
}