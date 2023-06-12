using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAFinal.Model
{
    internal class EntradaDados
    {
        public CalculationParameters calculationParameters;
        public String[][] trainingData;

        public EntradaDados()
        {
        }

        public EntradaDados(CalculationParameters calculationParameters, String[][] trainingData)
        {
            this.calculationParameters = calculationParameters;
            this.trainingData = trainingData;
        }

        public CalculationParameters getCalculationParameters()
        {
            return calculationParameters;
        }

        public String[][] getTrainingData()
        {
            return trainingData;
        }
    }
}
