using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAFinal.Model.Funcoes
{
    internal class Logistica
    {
        public double calcularFuncaoSaida(double net)
        {
            return 1.0 / (1.0 + Math.Exp(-net));
        }

        public double derivada(double saida)
        {
            return saida * (1.0 - saida);
        }
    }
}
