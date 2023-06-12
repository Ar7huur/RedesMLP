using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAFinal.Model.Funcoes
{
    internal class Linear
    {
        public double calcularFuncaoSaida(double net)
        {
            return net / 10.0;
        }
        public double derivada()
        {
            return 1.0 / 10.0;
        }
    }
}
