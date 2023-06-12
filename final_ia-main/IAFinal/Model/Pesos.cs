using System;
using System.Collections.Generic;

namespace IAFinal.Model
{
    public class Pesos
    {
        private List<int> posEntrada;
        private List<int> posSaida;
        private List<double> peso;

        public Pesos()
        {
            this.posEntrada = new List<int>();
            this.posSaida = new List<int>();
            this.peso = new List<double>();
        }

        public int GetPosEntrada(int pos)
        {
            return posEntrada[pos];
        }

        public List<int> GetAllPosEntrada()
        {
            return posEntrada;
        }

        public void SetPosEntrada(int posEntrada)
        {
            this.posEntrada.Add(posEntrada);
        }

        public int GetPosSaida(int pos)
        {
            return posSaida[pos];
        }

        public List<int> GetAllPosSaida()
        {
            return posSaida;
        }

        public void SetPosSaida(int posSaida)
        {
            this.posSaida.Add(posSaida);
        }

        public double GetPeso(int pos)
        {
            return peso[pos];
        }

        public List<double> GetAllPeso()
        {
            return peso;
        }

        public void SetPeso(double peso)
        {
            this.peso.Add(peso);
        }

        public void SetPeso(double peso, int pos)
        {
            this.peso[pos] = peso;
        }

        public void InicializarPesos(int totalEntradas, int totalSaidas, int numCamadaOculta,
                                     int opcaoFuncaoTransferencia)
        {
            int posSaida = totalEntradas * numCamadaOculta + totalEntradas;
            int qtdePesosEntrada = totalEntradas * totalEntradas;
            int qtdePesosSaida = totalSaidas * totalEntradas;
            int qtdeTotalPesos;
            int faixaRadom;

            if (opcaoFuncaoTransferencia == 3)
            {
                if (numCamadaOculta == 1)
                {
                    int posInserir = 0;
                    qtdeTotalPesos = qtdePesosEntrada + qtdePesosSaida;

                    // Para Entrada
                    for (int entrada = 0; entrada < totalEntradas; entrada++)
                    {
                        for (int k = 0; k < totalEntradas; k++)
                        {
                            SetPosEntrada(entrada);
                            SetPosSaida(k + totalEntradas);
                            SetPeso(((new Random().NextDouble() * 2) - 1));
                        }
                    }

                    // Pesos SAIDA
                    int posUltimaCamadaOculta = posSaida - totalEntradas;
                    for (int entrada = posUltimaCamadaOculta; entrada < posSaida; entrada++)
                    {
                        for (int k = 0; k < totalSaidas; k++)
                        {
                            SetPosEntrada(entrada);
                            SetPosSaida(k + posSaida);
                            SetPeso(((new Random().NextDouble() * 2) - 1));
                        }
                    }

                }
                else
                {
                    int posInserir = 0;
                    int qtdePesosIntermediarios = qtdePesosEntrada * (numCamadaOculta - 1);
                    qtdeTotalPesos = qtdePesosEntrada +
                            qtdePesosIntermediarios +
                            qtdePesosSaida;


                    qtdeTotalPesos = qtdePesosEntrada + qtdePesosSaida;
                    int saida;

                    // Pesos ENTRADA
                    for (int entrada = 0; entrada < totalEntradas; entrada++)
                    {
                        for (int k = 0; k < totalEntradas; k++)
                        {
                            SetPosEntrada(entrada);
                            SetPosSaida(k + totalEntradas);
                            SetPeso(((new Random().NextDouble() * 2) - 1));
                        }
                    }

                    // Pesos INTERMEDIARIO
                    int posInicioOculta;
                    int posSaidaOculta;
                    int posLimiteOculta = totalEntradas + totalEntradas;
                    for (int camadaOculta = 0; camadaOculta < numCamadaOculta - 1; camadaOculta++)
                    {
                        posSaidaOculta = posLimiteOculta + (totalEntradas * camadaOculta);
                        posInicioOculta = posSaidaOculta - totalEntradas;
                        for (int entrada = posInicioOculta; entrada < posSaidaOculta; entrada++)
                        {
                            for (int k = 0; k < totalEntradas; k++)
                            {
                                SetPosEntrada(entrada);
                                SetPosSaida(k + posSaidaOculta);
                                SetPeso(((new Random().NextDouble() * 2) - 1));
                            }
                        }
                    }

                    // Pesos SAIDA
                    int posUltimaCamadaOculta = posSaida - totalEntradas;
                    for (int entrada = posUltimaCamadaOculta; entrada < posSaida; entrada++)
                    {
                        for (int k = 0; k < totalSaidas; k++)
                        {
                            SetPosEntrada(entrada);
                            SetPosSaida(k + posSaida);
                            SetPeso(((new Random().NextDouble() * 2) - 1));
                        }
                    }
                }
            }
            else
            {
                if (numCamadaOculta == 1)
                {
                    int posInserir = 0;
                    qtdeTotalPesos = qtdePesosEntrada + qtdePesosSaida;

                    // Para Entrada
                    for (int entrada = 0; entrada < totalEntradas; entrada++)
                    {
                        for (int k = 0; k < totalEntradas; k++)
                        {
                            SetPosEntrada(entrada);
                            SetPosSaida(k + totalEntradas);
                            SetPeso(new Random().NextDouble());
                        }
                    }

                    // Pesos SAIDA
                    int posUltimaCamadaOculta = posSaida - totalEntradas;
                    for (int entrada = posUltimaCamadaOculta; entrada < posSaida; entrada++)
                    {
                        for (int k = 0; k < totalSaidas; k++)
                        {
                            SetPosEntrada(entrada);
                            SetPosSaida(k + posSaida);
                            SetPeso(new Random().NextDouble());
                        }
                    }

                }
                else
                {
                    int posInserir = 0;
                    int qtdePesosIntermediarios = qtdePesosEntrada * (numCamadaOculta - 1);
                    qtdeTotalPesos = qtdePesosEntrada +
                            qtdePesosIntermediarios +
                            qtdePesosSaida;


                    qtdeTotalPesos = qtdePesosEntrada + qtdePesosSaida;
                    int saida;

                    // Pesos ENTRADA
                    for (int entrada = 0; entrada < totalEntradas; entrada++)
                    {
                        for (int k = 0; k < totalEntradas; k++)
                        {
                            SetPosEntrada(entrada);
                            SetPosSaida(k + totalEntradas);
                            SetPeso(new Random().NextDouble());
                        }
                    }

                    // Pesos INTERMEDIARIO
                    int posInicioOculta;
                    int posSaidaOculta;
                    int posLimiteOculta = totalEntradas + totalEntradas;
                    for (int camadaOculta = 0; camadaOculta < numCamadaOculta - 1; camadaOculta++)
                    {
                        posSaidaOculta = posLimiteOculta + (totalEntradas * camadaOculta);
                        posInicioOculta = posSaidaOculta - totalEntradas;
                        for (int entrada = posInicioOculta; entrada < posSaidaOculta; entrada++)
                        {
                            for (int k = 0; k < totalEntradas; k++)
                            {
                                SetPosEntrada(entrada);
                                SetPosSaida(k + posSaidaOculta);
                                SetPeso(new Random().NextDouble());
                            }
                        }
                    }

                    // Pesos SAIDA
                    int posUltimaCamadaOculta = posSaida - totalEntradas;
                    for (int entrada = posUltimaCamadaOculta; entrada < posSaida; entrada++)
                    {
                        for (int k = 0; k < totalSaidas; k++)
                        {
                            SetPosEntrada(entrada);
                            SetPosSaida(k + posSaida);
                            SetPeso(new Random().NextDouble());
                        }
                    }
                }
            }
        }
    }
}

