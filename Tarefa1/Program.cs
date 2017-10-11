using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefa1
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                bool executaCalculo = PedirEntradaDeDadosAteIgualASimOuNao();
                if (executaCalculo)
                {
                    ProcuraNumeroComMaiorSequencia();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível executar a verificados com os dados informados.");
                Console.WriteLine(ex);
            }

            Console.WriteLine("\n");
            Console.WriteLine("Fim da verificação. Informe qualquer tecla para encerrar.");
            Console.ReadKey();
        }

        /// <summary>
        /// Método responsável por pedir ao usuário que digite um comando para informar se deseja fazer o Cálculo do Problema de Collatz (s ou n).
        /// </summary>
        /// <returns>Boleano verificando se o Usuário pediu para executar ou não a rotina do Problema de Collatz.</returns>
        private static bool PedirEntradaDeDadosAteIgualASimOuNao()
        {
            bool entradaValida = false;
            bool executaVerificacao = false;
            string dadosLidos;

            while (!entradaValida)
            {
                Console.Write("Deseja executar o Cálculo para o Problema de Collatz ? Digite s/S para SIM e n/N para NÃO : ");
                dadosLidos = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dadosLidos))
                {
                    if(dadosLidos == "S" || dadosLidos == "s")
                    {
                        entradaValida = true;
                        executaVerificacao = true;
                        
                    }
                    else if(dadosLidos == "N" || dadosLidos == "n")
                    {
                        entradaValida = true;
                        executaVerificacao = false;
                        Console.WriteLine("Cálculo não será executado.");
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível identificar o comando. Tente novamente.");
                        Console.WriteLine("\n");
                    }
                }

            }

            return executaVerificacao;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void ProcuraNumeroComMaiorSequencia()
        {
            long maximoAVerificar = 1000000;
            long maiorSequencia = 0;
            long maiorNumero = 0;
            long[] listaAVerificar = new long[maximoAVerificar + 1];

            Parallel.For(0, maximoAVerificar + 1, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, index =>
                {
                    listaAVerificar[index] = -1;

                });

            long numeroAtual;
            for (var i = 2; i <= maximoAVerificar; i++)
            {
                numeroAtual = i;
                int totalSequencia = 0;
                while (numeroAtual != 1 && numeroAtual >= i)
                {
                    totalSequencia++;
                    if (numeroAtual % 2 == 0)
                        numeroAtual = numeroAtual / 2;
                    else
                        numeroAtual = 3 * numeroAtual + 1;
                }

                listaAVerificar[i] = totalSequencia + listaAVerificar[numeroAtual];

                if (listaAVerificar[i] > maiorSequencia)
                {
                    maiorSequencia = listaAVerificar[i];
                    maiorNumero = i;
                }
            }

            Console.WriteLine(string.Format("O número {0} possui a maior sequência com {1} termos.", maiorNumero, maiorSequencia));

        }
    }
}