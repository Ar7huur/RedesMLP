using IAFinal.Controller;
using IAFinal.Model;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IAFinal
{
    public partial class Form1 : Form
    {

        MLPController controller;

        DataTable arquivoTreino;
        DataTable arquivoTeste;

        int transf = 0;

        public Form1()
        {
            InitializeComponent();
        }

        void sendData(string parametros)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            AllocConsole();
            // Configuração do OpenFileDialog
            openDialog.Filter = "Arquivos CSV (*.csv)|*.csv";
            openDialog.Title = "Selecionar arquivo CSV";

            controller = new MLPController();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        static string[][] dataToString(DataTable dataTable)
        {
            string[][] matriz = new string[dataTable.Rows.Count][];

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                matriz[i] = new string[dataTable.Columns.Count];

                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    matriz[i][j] = dataTable.Rows[i][j].ToString();
                }
            }

            return matriz;
        }

        static DataTable intToData(int[][] matriz)
        {
            DataTable dataTable = new DataTable();

            // Adicionar colunas ao DataTable
            int numeroColunas = matriz[0].Length;
            for (int i = 0; i < numeroColunas; i++)
            {
                dataTable.Columns.Add("Coluna" + (i + 1));
            }

            // Adicionar linhas ao DataTable
            for (int i = 0; i < matriz.Length; i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < numeroColunas; j++)
                {
                    row[j] = matriz[i][j];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Leitura do arquivo CSV e preenchimento do DataTable
                    DataTable dataTable = new DataTable();
                    string[] lines = System.IO.File.ReadAllLines(openDialog.FileName);

                    if (lines.Length > 0)
                    {

                        // Definir as colunas do DataTable com base na primeira linha do arquivo CSV
                        string[] columns = lines[0].Split(',');
                        foreach (string column in columns)
                        {
                            dataTable.Columns.Add(column);
                        }

                        // Adicionar as linhas ao DataTable, ignorando a primeira linha (cabeçalho)
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] data = lines[i].Split(',');
                            dataTable.Rows.Add(data);
                        }
                    }

                    // Exibir o DataTable no DataGridView
                    arquivoTreino = dataTable;
                    dataGridView1.DataSource = dataTable;

                    //SEND DATA              




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao ler o arquivo CSV: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Leitura do arquivo CSV e preenchimento do DataTable
                    DataTable dataTable = new DataTable();
                    string[] lines = System.IO.File.ReadAllLines(openDialog.FileName);

                    if (lines.Length > 0)
                    {

                        // Definir as colunas do DataTable com base na primeira linha do arquivo CSV
                        string[] columns = lines[0].Split(',');
                        foreach (string column in columns)
                        {
                            dataTable.Columns.Add(column);
                        }

                        // Adicionar as linhas ao DataTable, ignorando a primeira linha (cabeçalho)
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] data = lines[i].Split(',');
                            dataTable.Rows.Add(data);
                        }
                    }

                    // Exibir o DataTable no DataGridView
                    arquivoTeste = dataTable;
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao ler o arquivo CSV: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CalculationParameters cp = new CalculationParameters();
            cp.inputLayer = int.Parse(entradaBox.Text.ToString());
            cp.outputLayer = int.Parse(saidaBox.Text.ToString());
            cp.hiddenLayer = int.Parse(ocultaBox.Text.ToString());
            cp.errorValue = float.Parse(erroBox.Text.ToString());
            cp.learningRate = float.Parse(nBox.Text.ToString());
            cp.numberIterations = int.Parse(iterBox.Text.ToString());
            cp.transferFunction = transf;

            //Passa parâmetros para a entrada de dados 
           EntradaDados ed = new EntradaDados();
            ed.calculationParameters = cp;
            //Setar 


            if (arquivoTreino != null)
            {
                ed.trainingData = dataToString(arquivoTreino);

                controller.entradaDados(ed);

                //Parte 2: Testes

                EntradaDados testes = new EntradaDados();
                testes.calculationParameters = cp;
                testes.trainingData = dataToString(arquivoTeste);

                if(arquivoTeste != null)
                {
                    //Calcula matriz de confusão
                    controller.calculaArquivoTeste(testes);                   

                    //Popula matriz de confusão
                    MatrizConfusao matriz = controller.saidaDadosMatriz();                   

                    DataTable matrizConfusao = intToData(matriz.matriz);

                    MatrizConfu mf = new MatrizConfu();
 

                    mf.PopulaTable(matrizConfusao);

                    mf.ShowDialog();                 


                }
                else
                {
                    MessageBox.Show("Arquivo teste vazio!!!");
                }

            }
            else
            {
                MessageBox.Show("Arquivo treino vazio!!!");
            }

           

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            transf = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            transf = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            transf = 3;
        }
    }
}