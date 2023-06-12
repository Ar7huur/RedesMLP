using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAFinal.Model
{
    internal class NormalizacaoValores
    {
        private double min;
        private double max;

        public NormalizacaoValores(double min, double max)
        {
            this.min = min;
            this.max = max;
        }

        public double getMin()
        {
            return min;
        }

        public double getMax()
        {
            return max;
        }

        public void setMin(double min)
        {
            this.min = min;
        }

        public void setMax(double max)
        {
            this.max = max;
        }
    }
}
