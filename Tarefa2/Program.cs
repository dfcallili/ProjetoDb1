using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarefa2
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
                List<int> numerosLidos = PedirEntradaDeDadosAteDiferenteDeNuloOuVazio();
                VerificaSomenteImpar(numerosLidos);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível executar a verificados com os dados informados.");
                Console.WriteLine(ex);
            }

            Console.WriteLine("Fim da verificação. Informe qualquer tecla para encerrar.");
            Console.ReadKey();
        }

        /// <summary>
        /// Método responsável por pedir ao usuário que digite uma sequência de números até que seja válido.
        /// </summary>
        /// <returns>Dados digitados pelo Usuário após a validação</returns>
        private static List<int> PedirEntradaDeDadosAteDiferenteDeNuloOuVazio()
        {
            bool entradaValida = false;
            List<int> numerosASeremVerificados = new List<int>();
            string dadosLidos;

            while (!entradaValida)
            {
                Console.Write("Informe uma sequência de números separados por ',' : ");
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

        /// <summary>
        /// Método responsável por Verificar se a lista de Inteiros possui apenas números ímpares e escrever o resultado no console da aplicação.
        /// </summary>
        /// <param name="listaASerVerificada">Lista a ser verificada.</param>
        private static void VerificaSomenteImpar(List<int> listaASerVerificada)
        {
            int[] numerosPares = listaASerVerificada.Where(t => t % 2 == 0).Select(t => t).ToArray();

            if (numerosPares.Any())
            {
                Console.WriteLine(string.Format("O array informado não possui apenas números ímpares."));
                Console.Write("Números pares encontrados : ");
                int totalArrayPar = numerosPares.Count();
                for (var i = 0; i < totalArrayPar; i++)
                {
                    if (i+1 != totalArrayPar)
                        Console.Write(numerosPares[i] + ",");
                    else
                        Console.Write(numerosPares[i]);
                }
            }
            else
            {
                Console.WriteLine(string.Format("O array informado possui apenas números ímpares."));

            }
            Console.WriteLine("\n");
        }
    }
}