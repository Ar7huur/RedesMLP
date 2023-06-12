using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAFinal.Model.Funcoes
{
    internal class TangenteHiperbolica
    {
        public double calcularFuncaoSaida(double net)
        {
            return Math.Tanh(net);            
        }

        public double derivada(double saida)
        {
            return 1.0 - (Math.Pow(saida, 2));
        }
    }
}
