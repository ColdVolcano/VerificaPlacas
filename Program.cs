using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace VerificaPlacas
{
    class Program
    {

        static void Main()
        {
            SortedDictionary<string, int> contadores = new SortedDictionary<string, int>();
            SortedList<Placa, string> todasPlacas = new SortedList<Placa, string>();

            Console.WriteLine("Presione una tecla cuando tenga la consola en su mayor tamaño posible");
            Console.ReadKey(true);
            Console.Clear();

            string[] lines = File.ReadAllLines("sample.txt");

            Console.WriteLine("Placas validas:");

            int longitudLinea = 0;

            foreach (string line in lines)
            {
                Placa placa = Placa.VerificarPlacaJalisco(line);

                if (placa == null || todasPlacas.Keys.IndexOf(placa) != -1)
                    continue;

                todasPlacas.Add(placa, null);

                string lote = line.Substring(0, 6);

                if (contadores.Keys.Any(c => c.Equals(lote)))
                    contadores[lote]++;
                else
                    contadores.Add(lote, 1);

                Console.Write(placa);
                longitudLinea += 10;
                if (Console.WindowWidth < longitudLinea + 10 || line == lines[lines.Length - 1])
                {
                    Console.WriteLine();
                    longitudLinea = 0;
                }
                else
                {
                    Console.Write(' ');
                }
            }

            Console.WriteLine("Presione una tecla para mostrar las placas ordenadas alfabeticamente");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("Placas ordenadas");

            foreach (var placa in todasPlacas.Keys)
            {
                Console.Write(placa);
                longitudLinea += 10;
                if (Console.WindowWidth < longitudLinea + 10 || placa == todasPlacas.Keys.Last())
                {
                    Console.WriteLine();
                    longitudLinea = 0;
                }
                else
                {
                    Console.Write(' ');
                }
            }

            Console.WriteLine("Presione una tecla para mostrar las placas que existen por lote");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("Placas por lote");

            foreach (var lote in contadores)
            {
                Console.Write(lote.Key + ' ' + lote.Value);
                longitudLinea += 8 + lote.Value.ToString().Length;
                if (Console.WindowWidth < longitudLinea + 10 || lote.Key == contadores.Last().Key)
                {
                    Console.WriteLine();
                    longitudLinea = 0;
                }
                else
                {
                    Console.Write(' ');
                }
            }

            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey(true);
        }
    }
}
