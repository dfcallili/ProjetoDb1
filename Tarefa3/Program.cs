using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Tarefa3
{
    class Program
    {
        /// <summary>
        /// Método principal da aplicação.
        /// </summary>
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                List<int> numerosLidosPrimeiroArray = PedirEntradaDeDadosAteDiferenteDeNuloOuVazio("Primeiro Array");
                List<int> numerosLidosSegudoArray = PedirEntradaDeDadosAteDiferenteDeNuloOuVazio("Segundo Array");

                VerificaNumeroPrimeiroArrayQueNaoExistemNaoSegundoArray(numerosLidosPrimeiroArray, numerosLidosSegudoArray);

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
        /// Método responsável por verificar se existem Números contidos no Primeiro Array informado mas que não existam no Segundo Array.
        /// </summary>
        /// <param name="numerosLidosPrimeiroArray">Lista de Números digitados no Primeiro Array.</param>
        /// <param name="numerosLidosSegudoArray">Lista de Números digitados no Segundo Array.</param>
        private static void VerificaNumeroPrimeiroArrayQueNaoExistemNaoSegundoArray(List<int> numerosLidosPrimeiroArray, List<int> numerosLidosSegudoArray)
        {
            List<int> numerosPrimeiroArrayQueNaoEstaoNoSegundoArray = numerosLidosPrimeiroArray.Where(t => !numerosLidosSegudoArray.Contains(t)).ToList();

            Console.WriteLine("\n");
            if (numerosPrimeiroArrayQueNaoEstaoNoSegundoArray.Any())
            {
                Console.Write("Números do Primeiro Array que não se Existem no Segundo Array : ");
                int totalArrayDiferente = numerosPrimeiroArrayQueNaoEstaoNoSegundoArray.Count();
                for (var i = 0; i < totalArrayDiferente; i++)
                {
                    if (i + 1 != totalArrayDiferente)
                        Console.Write(numerosPrimeiroArrayQueNaoEstaoNoSegundoArray[i] + ",");
                    else
                        Console.Write(numerosPrimeiroArrayQueNaoEstaoNoSegundoArray[i]);
                }
            }
            else
            {
                Console.WriteLine("Não foi localizado nenhum Número do Primeiro Array que NÃO exista no Segundo Array.");
            }
        }

        /// <summary>
        /// Método responsável por pedir ao usuário que digite uma sequência de números até que seja válido.
        /// </summary>
        /// <param name="descricaoNumeroArray">Descrição para diferenciar qual Array estamos lendo.</param>
        /// <returns>Dados digitados pelo Usuário após a validação</returns>
        private static List<int> PedirEntradaDeDadosAteDiferenteDeNuloOuVazio(string descricaoNumeroArray)
        {
            bool entradaValida = false;
            List<int> numerosASeremVerificados = new List<int>();
            string dadosLidos;

            while (!entradaValida)
            {
                Console.Write(string.Format("Informe a sequência de números separados por ',' para o {0} : ", descricaoNumeroArray));
                dadosLidos = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dadosLidos))
                {
                    int testaApenasUmNumero;
                    if (int.TryParse(dadosLidos, out testaApenasUmNumero))
                    {
                        entradaValida = true;
                        numerosASeremVerificados.Add(testaApenasUmNumero);
                    }
                    else
                    {
                        if (dadosLidos.Contains(','))
                        {
                            numerosASeremVerificados = CriaListaDeInteiroASerVerificada(dadosLidos);
                            entradaValida = true;
                        }

                        else
                        {
                            Console.WriteLine("Não foi possível identificar os números separados por ','");
                            Console.WriteLine("\n");
                        }
                    }
                }

            }

            return numerosASeremVerificados;
        }

        /// <summary>
        /// Método responsável por tranformar os dados digitados em uma Lista de Inteiros para serem verificados.
        /// </summary>
        /// <param name="dadosInformados">Dados digitados pelo Usuário.</param>
        /// <returns>Lista de Inteiros que serão verificados.</returns>
        private static List<int> CriaListaDeInteiroASerVerificada(string dadosInformados)
        {
            List<int> numerosLidos = new List<int>();

            string[] arrayStringLido = dadosInformados.Split(',');
            foreach (var item in arrayStringLido)
            {
                int novoInt;
                if (int.TryParse(item, out novoInt))
                    numerosLidos.Add(novoInt);
            }

            return numerosLidos;
        }
    }
}