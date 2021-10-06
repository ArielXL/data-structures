using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP
{
    class Program
    {
        public static int[] PrefixFunction(string patron)
        {
            int k = 0;
            int[] pi = new int[patron.Length];

            for (int i = 2; i < patron.Length; i++)
            {
                while (k > 0 && patron[k + 1] != patron[i])
                    k = pi[k];

                if (patron[k + 1] == patron[i])
                    k++;

                pi[i] = k;
            }

            return pi;
        }

        public static void KMP(string texto, string patron, int[] pi)
        {
            int ocurrencias = 0;
            int k = 0;

            for (int i = 1; i < texto.Length; i++)
            {
                while (k > 0 && texto[i] != patron[k + 1])
                    k = pi[k];

                if (texto[i] == patron[k + 1])
                    k++;

                if (k == patron.Length - 1)
                {
                    Console.WriteLine($"Hay una ocurrencia en el corrimiento {i - patron.Length + 1}");
                    k = pi[k];
                    ocurrencias++;
                }
            }

            Console.WriteLine($"Hay {ocurrencias} ocurrencias");
        }

        static void Main(string[] args)
        {
            // recordar concatenar "$" antes de cada parametro de los metodos prefix_function y KMP

            string texto = Console.ReadLine();
            string patron = Console.ReadLine();

            int[] pi = PrefixFunction("$" + patron);

            KMP("$" + texto, "$" + patron, pi);
        }
    }
}
