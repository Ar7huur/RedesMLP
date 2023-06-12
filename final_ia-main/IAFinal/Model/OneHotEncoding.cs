using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAFinal.Model
{
    internal class OneHotEncoding
    {
        private bool AchouElemento(string[] classes, string novaClasse)
        {
            int tamanho = classes.Length;
            int pos = 0;
            while (pos < tamanho && !novaClasse.Equals(classes[pos], StringComparison.OrdinalIgnoreCase))
            {
                pos++;
            }
            if (pos < tamanho)
            {
                return true;
            }
            return false;
        }

        private int BuscaPos(string[] classes, string novaClasse)
        {
            int tamanho = classes.Length;
            int pos = 0;
            while (pos < tamanho && !novaClasse.Equals(classes[pos], StringComparison.OrdinalIgnoreCase))
            {
                pos++;
            }
            if (pos < tamanho)
            {
                return pos;
            }
            return -1;
        }

        public string[] RetornarClasses(string[][] dados, int numSaidas)
        {
            int numLinhas = dados.Length;
            int numColunas = dados[0].Length;
            int posClasse = numColunas - 1;
            int TLC = 0;
            string[] classes = new string[numSaidas];
            string novaClasse;
            for (int i = 1; i < numLinhas; i++)
            {
                novaClasse = dados[i][posClasse];
                if (!AchouElemento(classes, novaClasse))
                {
                    classes[TLC++] = novaClasse;
                }
            }
            Array.Sort(classes);
            return classes;
        }

        public double[][] TratarDados(string[][] matrizDadosFront, int numSaidas, string[] classes, int funcaoTransferencia)
        {
            int numLinhas = matrizDadosFront.Length;
            int numColunas = matrizDadosFront[0].Length;
            int posClasse = numColunas - 1;
            int qtdeNovasColunas = (numColunas + numSaidas) - 1;
            double[][] oneHotEncoding = new double[numLinhas - 1][];
            for (int i = 0; i < numLinhas - 1; i++)
            {
                oneHotEncoding[i] = new double[qtdeNovasColunas];
            }

            string tempClasse;
            int posAchouClasse;
            if (funcaoTransferencia != 3)
            {
                for (int i = 1, linha = 0; i < numLinhas; i++)
                {
                    for (int j = 0; j < posClasse; j++)
                    {
                        oneHotEncoding[linha][j] = double.Parse(matrizDadosFront[i][j]);
                    }
                    tempClasse = matrizDadosFront[i][posClasse];
                    posAchouClasse = BuscaPos(classes, tempClasse);
                    if (posAchouClasse != -1)
                    {
                        oneHotEncoding[linha][posClasse + posAchouClasse] = 1;
                    }
                    linha++;
                }
            }
            else
            {
                for (int i = 1, linha = 0; i < numLinhas; i++)
                {
                    for (int j = 0; j < posClasse; j++)
                    {
                        oneHotEncoding[linha][j] = double.Parse(matrizDadosFront[i][j]);
                    }
                    for (int j = posClasse; j < qtdeNovasColunas; j++)
                    {
                        oneHotEncoding[linha][j] = -1;
                    }
                    tempClasse = matrizDadosFront[i][posClasse];
                    posAchouClasse = BuscaPos(classes, tempClasse);
                    if (posAchouClasse != -1)
                    {
                        oneHotEncoding[linha][posClasse + posAchouClasse] = 1;
                    }
                    linha++;
                }
            }
            return oneHotEncoding;
        }

        public void Exibicao(double[][] dadosOneHotEncoding)
        {
            for (int i = 0; i < dadosOneHotEncoding.Length; i++)
            {
                for (int j = 0; j < dadosOneHotEncoding[0].Length; j++)
                {
                    Console.Write("{0,-8} ", dadosOneHotEncoding[i][j].ToString("F4"));
                }
                Console.WriteLine();
            }
        }
    }
}
