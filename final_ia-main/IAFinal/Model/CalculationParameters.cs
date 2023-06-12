using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAFinal.Model
{
    internal class CalculationParameters
    {
        public int inputLayer;
        public int outputLayer;
        public int hiddenLayer;
        public float errorValue;
        public int numberIterations;
        public float learningRate;
        public int transferFunction;

        public CalculationParameters()
        {
        }

        public CalculationParameters(int inputLayer, int outputLayer, int hiddenLayer, float errorValue, int numberIterations, float learningRate, int transferFunction)
        {
            this.inputLayer = inputLayer;
            this.outputLayer = outputLayer;
            this.hiddenLayer = hiddenLayer;
            this.errorValue = errorValue;
            this.numberIterations = numberIterations;
            this.learningRate = learningRate;
            this.transferFunction = transferFunction;
        }

        public int getInputLayer()
        {
            return inputLayer;
        }

        public int getOutputLayer()
        {
            return outputLayer;
        }

        public int getHiddenLayer()
        {
            return hiddenLayer;
        }

        public float getErrorValue()
        {
            return errorValue;
        }

        public int getNumberIterations()
        {
            return numberIterations;
        }

        public float getLearningRate()
        {
            return learningRate;
        }

        public int getTransferFunction()
        {
            return transferFunction;
        }
    }
}
