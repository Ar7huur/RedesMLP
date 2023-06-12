using IAFinal.Model;
using IAFinal.Model.Funcoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAFinal.Controller
{
    internal class MLPController
    {
        MatrizConfusao matrizConfusao { get; set; }
        CalculationParameters calculationParameters { get; set; }

        String[] classes;

        double[][] dadosOneHotEncoding;

        double taxaAprendizagem;
        double valorErro;
        int opcaoFuncaoTransferencia;

        NormalizacaoValores[] fatorDeNormalizacao;
        List<Neuronio> neuronios;

        Pesos pesos;
        List<MediaErroRede> mediaErroRedeTotal;


        // /grafico
        public List<MediaErroRede> saidaDadosGrafico()
        {
            return mediaErroRedeTotal;
        }


        // /matriz
        public MatrizConfusao saidaDadosMatriz()
        {
            return matrizConfusao;
        }


        // /matriz
        public MatrizConfusao calculaArquivoTeste(EntradaDados dados)
        {
            Console.WriteLine("Calculando matriz de confusão");
            opcaoFuncaoTransferencia = dados.getCalculationParameters().getTransferFunction();

            dadosOneHotEncoding = new OneHotEncoding().TratarDados(dados.getTrainingData(), dados.getCalculationParameters().getOutputLayer(),
                                 classes, opcaoFuncaoTransferencia);

            int numCamadaOculta = dados.getCalculationParameters().getHiddenLayer();
            int totalLinhas = dadosOneHotEncoding.Length;
            int totalColunas = dadosOneHotEncoding[0].Length;
            int totalEntradas = totalColunas - classes.Length;
            int totalSaidas = classes.Length;
            int totalNeuronio = totalEntradas + (totalEntradas * numCamadaOculta) + totalSaidas;
            int posDesejado;

            double valorSaidaArquivo;

            matrizConfusao = new MatrizConfusao(totalSaidas, classes);

            normalizarEntradas(dadosOneHotEncoding, totalEntradas);

            for(int i = 0; i < totalLinhas; i++)
            {
                // -> Gera neuronios de ENTRADA
                neuronios = new List<Neuronio>();
                for (int j = 0; j < totalEntradas; j++)
                {
                    neuronios.Add(new Neuronio(0, dadosOneHotEncoding[i][j], 0));
                }

                // -> Gera CAMADA OCULTA
                for (int camadaAtual = 0; camadaAtual < numCamadaOculta; camadaAtual++)
                {
                    for (int j = 0; j < totalEntradas; j++)
                    {
                        neuronios.Add(new Neuronio(0, 0, 0));
                    }
                }

                // -> Gera neuronios de SAIDA
                for (int j = 0; j < totalSaidas; j++)
                {
                    neuronios.Add(new Neuronio(0, 0, 0));
                }

                if (opcaoFuncaoTransferencia == 1)
                {
                    calcularNetSaida(neuronios, pesos, totalEntradas, new Linear());
                }
                else if (opcaoFuncaoTransferencia == 2)
                {
                    calcularNetSaida(neuronios, pesos, totalEntradas, new Logistica());
                }
                else
                {
                    calcularNetSaida(neuronios, pesos, totalEntradas, new TangenteHiperbolica());
                }

                // --> Verifica quem está mais próximo de 1, que será o resultado
                Neuronio tempNeuronio;
                int posMaior = totalNeuronio - totalSaidas;
                double saidaMenor = neuronios[posMaior].getSaida();
                double valorSaidaAtual;
                for (int atual = posMaior + 1; atual < totalNeuronio; atual++)
                {
                    valorSaidaAtual = neuronios[atual].getSaida();
                    if (valorSaidaAtual > saidaMenor)
                    {
                        saidaMenor = valorSaidaAtual;
                        posMaior = atual;
                    }
                }

                posDesejado = retornaPosDesejado(i, totalEntradas, totalColunas);

                posMaior = posMaior - (totalNeuronio - totalSaidas);

                switch (posMaior)
                {
                    case 0:
                        matrizConfusao.setMatriz(posDesejado, posMaior);
                        break;
                    case 1:
                        matrizConfusao.setMatriz(posDesejado, posMaior);
                        break;
                    case 2:
                        matrizConfusao.setMatriz(posDesejado, posMaior);
                        break;
                    case 3:
                        matrizConfusao.setMatriz(posDesejado, posMaior);
                        break;
                    case 4:
                        matrizConfusao.setMatriz(posDesejado, posMaior);
                        break;
                }
            }

            double acerto = 0;
            double erro = 0;
            int[][] matriz = matrizConfusao.getMatriz();
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz.Length; j++)
                {
                    if (i == j)
                    {
                        acerto += matriz[i][j];
                    }
                    else
                    {
                        erro += matriz[i][j];
                    }
                }
            }

            double acuracia = acerto / (acerto + erro) * 100;
            Console.WriteLine("ACERTO - " + acerto + " | ERRO - " + erro);
            Console.WriteLine("Acurácia - " + acuracia);
            matrizConfusao.setAcuracia(acuracia);

            return matrizConfusao;

        }

        int retornaPosDesejado(int i, int totalEntradas, int totalColunas)
        {
            int posDesejado = 0;
            for (int j = totalEntradas; j < totalColunas; j++)
            {
                if (dadosOneHotEncoding[i][j] == 1)
                {
                    posDesejado = j;
                }
            }
            posDesejado = posDesejado - totalEntradas;
            return posDesejado;
        }


        // /entrada
        public EntradaDados entradaDados(EntradaDados dados)
        {
            opcaoFuncaoTransferencia = dados.getCalculationParameters().getTransferFunction();

            // 1º - Transformar a Matriz e faz One Hot Encode
            classes = new OneHotEncoding()
                    .RetornarClasses(dados.getTrainingData(), dados.getCalculationParameters().getOutputLayer());
            dadosOneHotEncoding = new OneHotEncoding()
                    .TratarDados(dados.getTrainingData(), dados.getCalculationParameters().getOutputLayer(),
                            classes, opcaoFuncaoTransferencia);

            // --- ENTRADA
            bool sorteioPesos = true;

            pesos = new Pesos();
            mediaErroRedeTotal = new List<MediaErroRede>();
            int numRepeticoes = 0;
            int totalRepeticoes = dados.getCalculationParameters().getNumberIterations();
            int numCamadaOculta = dados.getCalculationParameters().getHiddenLayer();
            List<Double> vetorErroRede;
            double mediaErroRedeAtual;
            taxaAprendizagem = dados.getCalculationParameters().getLearningRate();
            valorErro = dados.getCalculationParameters().getErrorValue();
            int totalLinhas = dadosOneHotEncoding.Length;
            int totalEntradas = dadosOneHotEncoding[0].Length - classes.Length;
            int totalSaidas = classes.Length;

            // *** NORMALIZAR DADOS DE ENTRADA
            fatorDeNormalizacao = new NormalizacaoValores[totalEntradas];
            normalizarEntradas(dadosOneHotEncoding, totalEntradas);

            Console.WriteLine("\n --- VALORES - NORMALIZADOS");
            new OneHotEncoding().Exibicao(dadosOneHotEncoding);
            Console.WriteLine("\n\n");


            do
            {
                vetorErroRede = new List<Double>();
                for (int i = 0; i < totalLinhas; i++)
                {
                    // -> Gera neuronios de ENTRADA
                    neuronios = new List<Neuronio>();
                    for (int j = 0; j < totalEntradas; j++)
                    {
                        neuronios.Add(new Neuronio(0, dadosOneHotEncoding[i][j], 0));
                    }

                    // -> Gera CAMADA OCULTA
                    for (int camadaAtual = 0; camadaAtual < numCamadaOculta; camadaAtual++)
                    {
                        for (int j = 0; j < totalEntradas; j++)
                        {
                            neuronios.Add(new Neuronio(0, 0, 0));
                        }
                    }

                    // -> Gera neuronios de SAIDA
                    for (int j = 0; j < totalSaidas; j++)
                    {
                        neuronios.Add(new Neuronio(0, 0, 0));
                    }

                    // Aqui entra só uma vez
                    if (sorteioPesos)
                    {
                        pesos.InicializarPesos(totalEntradas, totalSaidas, numCamadaOculta,
                                opcaoFuncaoTransferencia);
                        sorteioPesos = false;
                      
                    }


                    if (opcaoFuncaoTransferencia == 1)
                    {
                        calcularNetSaida(neuronios, pesos, totalEntradas, new Linear());

                        calcularErroSaida(neuronios, totalSaidas,
                                dadosOneHotEncoding[i], new Linear());

                        calcularErroCamadaOculta(neuronios, pesos, new Linear(),
                                totalEntradas, totalSaidas);
                    }
                    else if (opcaoFuncaoTransferencia == 2)
                    {
                        calcularNetSaida(neuronios, pesos, totalEntradas, new Logistica());

                        calcularErroSaida(neuronios, totalSaidas,
                                dadosOneHotEncoding[i], new Logistica());

                        calcularErroCamadaOculta(neuronios, pesos, new Logistica(),
                                totalEntradas, totalSaidas);
                    }
                    else
                    {
                        calcularNetSaida(neuronios, pesos, totalEntradas, new TangenteHiperbolica());

                        calcularErroSaida(neuronios, totalSaidas,
                                dadosOneHotEncoding[i], new TangenteHiperbolica());

                        calcularErroCamadaOculta(neuronios, pesos, new TangenteHiperbolica(),
                                totalEntradas, totalSaidas);
                    }

                    vetorErroRede.Add(erroRede(neuronios, totalSaidas, dadosOneHotEncoding[i]));

                    // ** Calcular PESOS das ARESTAS
                    atualizaPesos(neuronios, pesos, totalEntradas,
                            taxaAprendizagem);
                }

                mediaErroRedeAtual = calculaMediaRedeAtual(vetorErroRede);
                if (numRepeticoes % 20 == 0)
                {
                    mediaErroRedeTotal.Add(new MediaErroRede(numRepeticoes, mediaErroRedeAtual));
                    Console.WriteLine("MÉDIA ERRO DE REDE [" + (numRepeticoes + 1) + "] - " + mediaErroRedeAtual);
                    Console.WriteLine("");
                }


                numRepeticoes++;



            } while (numRepeticoes < totalRepeticoes &&
        mediaErroRedeAtual > valorErro);
            Console.WriteLine("\n *** FIM CALCULO MLP ***\n");

            return dados;
        }


        public double[] retornaMinMax(double[][] dados, int coluna, int totalLinhas)
        {

            double[] minMax = new double[2];
            minMax[0] = dados[0][coluna]; // Mínimo
            minMax[1] = dados[0][coluna]; // Máximo
            for (int linha = 1; linha < totalLinhas; linha++)
            {
                // Menor
                if (dados[linha][coluna] < minMax[0])
                {
                    minMax[0] = dados[linha][coluna];
                }
                // Maior
                if (dados[linha][coluna] > minMax[1])
                {
                    minMax[1] = dados[linha][coluna];
                }
            }

            return minMax;
        }

        public void normalizarEntradas(double[][] dados, int totalEntradas)
        {
            int totalLinhas = dados.Length;
            double[] minMax;
            for (int coluna = 0; coluna < totalEntradas; coluna++)
            {
                minMax = retornaMinMax(dados, coluna, totalLinhas);
                fatorDeNormalizacao[coluna] = new NormalizacaoValores(minMax[0], minMax[1]);
            }
            // *** NORMALIZAÇÃO
            for (int coluna = 0; coluna < totalEntradas; coluna++)
            {
                for (int linha = 0; linha < totalLinhas; linha++)
                {
                    dados[linha][coluna] = (dados[linha][coluna] - fatorDeNormalizacao[coluna].getMin()) /
                                            (fatorDeNormalizacao[coluna].getMax() -
                                                    fatorDeNormalizacao[coluna].getMin());
                }
            }

        }

        public double somatorioPesoSaida(int totalPesos, int posNeuronioAtual)
        {
            int posNeuronioEntrada;
            double somatorio = 0, tempPeso;
            Neuronio neuronioEntrada;
            int pos = 0;
            while (pos < totalPesos)
            {
                if (posNeuronioAtual == pesos.GetPosSaida(pos))
                {
                    posNeuronioEntrada = pesos.GetPosEntrada(pos);
                    neuronioEntrada = neuronios[posNeuronioEntrada];
                    tempPeso = pesos.GetPeso(pos);
                    somatorio += neuronioEntrada.getSaida() * tempPeso;
                }
                pos++;
            }

            return somatorio;
        }

        public void calcularNetSaida(List<Neuronio> neuronios, Pesos pesos, int totalEntradas,
                                 Linear linear)
        {
            int totalNeuronios = neuronios.Count();
            double somatorio = 0;
            int totalPesos;
            for (int posNeuronioAtual = totalEntradas;
                 posNeuronioAtual < totalNeuronios; posNeuronioAtual++)
            {
                somatorio = 0;
                totalPesos = pesos.GetAllPosSaida().Count();

                somatorio = somatorioPesoSaida(totalPesos, posNeuronioAtual);

                neuronios[posNeuronioAtual].setNet(somatorio);

                // Calcula SAIDA
                double saidaNeuronio = linear.calcularFuncaoSaida(somatorio);
                neuronios[posNeuronioAtual].setSaida(saidaNeuronio);
            }
        }

        public void calcularNetSaida(List<Neuronio> neuronios, Pesos pesos, int totalEntradas,
        Logistica logistica)
        {
            int totalNeuronios = neuronios.Count();
            double somatorio = 0;
            int totalPesos;
            for (int posNeuronioAtual = totalEntradas;
                 posNeuronioAtual < totalNeuronios; posNeuronioAtual++)
            {
                somatorio = 0;
                totalPesos = pesos.GetAllPosSaida().Count();

                somatorio = somatorioPesoSaida(totalPesos, posNeuronioAtual);

                neuronios[posNeuronioAtual].setNet(somatorio);

                // Calcula SAIDA
                double saidaNeuronio = logistica.calcularFuncaoSaida(somatorio);
                neuronios[posNeuronioAtual].setSaida(saidaNeuronio);
            }
        }

        public void calcularNetSaida(List<Neuronio> neuronios, Pesos pesos, int totalEntradas,
                                 TangenteHiperbolica tangenteHiperbolica)
        {
            int totalNeuronios = neuronios.Count();
            double somatorio = 0;
            int totalPesos;
            for (int posNeuronioAtual = totalEntradas;
                 posNeuronioAtual < totalNeuronios; posNeuronioAtual++)
            {
                somatorio = 0;
                totalPesos = pesos.GetAllPosSaida().Count();

                somatorio = somatorioPesoSaida(totalPesos, posNeuronioAtual);

                neuronios[posNeuronioAtual].setNet(somatorio);

                // Calcula SAIDA
                double saidaNeuronio = tangenteHiperbolica.calcularFuncaoSaida(somatorio);
                neuronios[posNeuronioAtual].setSaida(saidaNeuronio);
            }
        }

        public void calcularErroSaida(List<Neuronio> neuronios, int totalSaidas,
                                  double[] dados, Linear linear)
        {

            double desejado, obtido, erro;
            int totalNeuronios = neuronios.Count();
            for (int atual = totalNeuronios - totalSaidas, classe = dados.Length - totalSaidas;
                atual < totalNeuronios; atual++, classe++)
            {
                desejado = dados[classe];
                obtido = neuronios[atual].getSaida();
                erro = (desejado - obtido) * linear.derivada();
                neuronios[atual].setErro(erro);
            }
        }


        public void calcularErroSaida(List<Neuronio> neuronios, int totalSaidas,
                                  double[] dados, Logistica logistica)
        {

            double desejado, obtido, erro;
            int totalNeuronios = neuronios.Count();
            for (int atual = totalNeuronios - totalSaidas, classe = dados.Length - totalSaidas;
                atual < totalNeuronios; atual++, classe++)
            {
                desejado = dados[classe];
                obtido = neuronios[atual].getSaida();
                erro = (desejado - obtido) * logistica.derivada(obtido);
                neuronios[atual].setErro(erro);
            }
        }


        public void calcularErroSaida(List<Neuronio> neuronios, int totalSaidas,
                                  double[] dados, TangenteHiperbolica tangenteHiperbolica)
        {

            double desejado, obtido, erro;
            int totalNeuronios = neuronios.Count();
            for (int atual = totalNeuronios - totalSaidas, classe = dados.Length - totalSaidas;
                atual < totalNeuronios; atual++, classe++)
            {
                desejado = dados[classe];
                obtido = neuronios[atual].getSaida();
                erro = (desejado - obtido) * tangenteHiperbolica.derivada(obtido);
                neuronios[atual].setErro(erro);
            }
        }

        public double erroRede(List<Neuronio> neuronios, int totalSaidas, double[] dados)
        {
            int totalNeuronios = neuronios.Count();
            int inicio = totalNeuronios - totalSaidas;
            double desejado, obtido;
            double erroRede = 0;

            for (int atual = totalNeuronios - totalSaidas, classe = dados.Length - totalSaidas;
                atual < totalNeuronios; atual++, classe++)
            {
                desejado = dados[classe];
                obtido = neuronios[atual].getSaida();
                erroRede += Math.Pow((desejado - obtido), 2);
            }

            erroRede /= 2.0;            
            return erroRede;
        }

        public double calculaMediaRedeAtual(List<Double> erroRede)
        {
            double tamanho = erroRede.Count();
            double somatorioErros = 0;
            for (int i = 0; i < tamanho; i++)
            {
                somatorioErros += erroRede[i];
            }

            return somatorioErros / tamanho;
        }


        double somatorioPesosCamadaOculta(List<Neuronio> neuronios, Pesos pesos, int posInicial,
                                      int posNeuronioAtual, int totalPesos)
        {

            int posNeuronioSaida;
            int pos = posInicial;
            double tempPeso, somatorio = 0;
            Neuronio neuronioSaida;
            while (pos < totalPesos)
            {
                if (posNeuronioAtual == pesos.GetPosEntrada(pos))
                {
                    posNeuronioSaida = pesos.GetPosSaida(pos);
                    neuronioSaida = neuronios[posNeuronioSaida];
                    tempPeso = pesos.GetPeso(pos);
                    somatorio += neuronioSaida.getErro() * tempPeso;
                }
                pos++;
            }

            return somatorio;
        }

        void calcularErroCamadaOculta(List<Neuronio> neuronios, Pesos pesos, Linear linear,
                                  int totalEntrada, int totalSaidas)
        {

            int ateNeuronio = neuronios.Count() - totalSaidas;
            int totalPesos = pesos.GetAllPeso().Count();
            int inicioPesosCamadaOculta = totalEntrada * totalEntrada;
            double somatorio;
            Neuronio neuronioAtual;
            for (int posNeuronioAtual = totalEntrada;
                 posNeuronioAtual < ateNeuronio; posNeuronioAtual++)
            {

                neuronioAtual = neuronios[posNeuronioAtual];

                somatorio = somatorioPesosCamadaOculta(neuronios, pesos, inicioPesosCamadaOculta,
                                            posNeuronioAtual, totalPesos);

                somatorio *= linear.derivada();
                neuronioAtual.setErro(somatorio);
            }
        }

        void calcularErroCamadaOculta(List<Neuronio> neuronios, Pesos pesos, Logistica logistica,
                                  int totalEntrada, int totalSaidas)
        {

            int ateNeuronio = neuronios.Count() - totalSaidas;
            int totalPesos = pesos.GetAllPeso().Count();
            int inicioPesosCamadaOculta = totalEntrada * totalEntrada;
            double somatorio;
            Neuronio neuronioAtual;
            for (int posNeuronioAtual = totalEntrada;
                 posNeuronioAtual < ateNeuronio; posNeuronioAtual++)
            {

                neuronioAtual = neuronios[posNeuronioAtual];

                somatorio = somatorioPesosCamadaOculta(neuronios, pesos, inicioPesosCamadaOculta,
                        posNeuronioAtual, totalPesos);

                somatorio *= logistica.derivada(neuronioAtual.getSaida());
                neuronioAtual.setErro(somatorio);
            }
        }

        void calcularErroCamadaOculta(List<Neuronio> neuronios, Pesos pesos,
                                  TangenteHiperbolica tangenteHiperbolica,
                                  int totalEntrada, int totalSaidas)
        {

            int ateNeuronio = neuronios.Count() - totalSaidas;
            int totalPesos = pesos.GetAllPeso().Count();
            int inicioPesosCamadaOculta = totalEntrada * totalEntrada;
            double somatorio;
            Neuronio neuronioAtual;
            for (int posNeuronioAtual = totalEntrada;
                 posNeuronioAtual < ateNeuronio; posNeuronioAtual++)
            {

                neuronioAtual = neuronios[posNeuronioAtual];

                somatorio = somatorioPesosCamadaOculta(neuronios, pesos, inicioPesosCamadaOculta,
                        posNeuronioAtual, totalPesos);

                somatorio *= tangenteHiperbolica.derivada(neuronioAtual.getSaida());
                neuronioAtual.setErro(somatorio);
            }
        }

        void atualizaPesos(List<Neuronio> neuronios, Pesos pesos, int totalEntradas,
                       double taxaAprendizagem)
        {
           
            int totalPesos = pesos.GetAllPeso().Count();
            int pesosEntradas = totalEntradas * totalEntradas;
            int posEntrada, posSaida;
            Neuronio auxNeuronio;
            double pesoAtual, novoPeso;
            for (int i = 0; i < totalPesos; i++)
            {
                pesoAtual = pesos.GetPeso(i);
                posEntrada = pesos.GetPosEntrada(i);
                posSaida = pesos.GetPosSaida(i);               

                novoPeso = pesoAtual + taxaAprendizagem * neuronios[posSaida].getErro() *
                        neuronios[posEntrada].getSaida();

                pesos.SetPeso(novoPeso, i);
            }
        }
    }
}
