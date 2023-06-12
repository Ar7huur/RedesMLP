using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAFinal.Model
{
    internal class MatrizConfusao
    {
        public int[][] matriz;
        public String[] classes;
        public double acuracia;

        //Modificado
        public MatrizConfusao(int linhaColuna, string[] classes)
        {
            this.matriz = new int[linhaColuna][];
            for (int i = 0; i < linhaColuna; i++)
            {
                this.matriz[i] = new int[linhaColuna];
            }

            this.classes = classes;
            this.acuracia = 0;
        }

        public int[][] getMatriz()
        {
            return matriz;
        }

        public void setMatriz(int linha, int coluna)
        {
            this.matriz[linha][coluna]++;
        }

        public String[] getClasses()
        {
            return classes;
        }

        public double getAcuracia()
        {
            return acuracia;
        }

        public void setAcuracia(double acuracia)
        {
            this.acuracia = acuracia;
        }
    }
}
