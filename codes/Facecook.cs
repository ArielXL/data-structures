using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public class ConjuntoDisjunto
    {
        public int[] Edades;
        public int[] CantHijos;
        public int[] Indices;

        public ConjuntoDisjunto(int[] edades, int tamanno)
        {
            Edades = edades;
            CantHijos = new int[tamanno];
            Indices = new int[tamanno];
            for (int i = 0; i < tamanno; i++)
            {
                CantHijos[i] = 1;
                Indices[i] = i;
            }
        }

        public int SetOf(int elem)
        {
            if (Indices[elem] == elem) 
                return elem;
            else
                return Indices[elem] = SetOf(Indices[elem]);
        }

        public void Merge(int x, int y)
        {
            x = SetOf(x);
            y = SetOf(y);

            if (x == y) 
                return;

            if (CantHijos[x] < CantHijos[y])
            {
                Indices[x] = y;
                CantHijos[y] += CantHijos[x];
                CantHijos[x] = 0;
                Edades[y] += Edades[x];
                Edades[x] = 0;
            }
            else
            {
                Indices[y] = x;
                CantHijos[x] += CantHijos[y];
                CantHijos[y] = 0;
                Edades[x] += Edades[y];
                Edades[y] = 0;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int usuarios = int.Parse(linea[0]);
            int preguntas = int.Parse(linea[1]);

            int[] edades = new int[usuarios];
            linea = Console.ReadLine().Split();
            for (int i = 0; i < linea.Length; i++)
            {
                edades[i] = int.Parse(linea[i]);
            }

            ConjuntoDisjunto conjuntosDisjuntos = new ConjuntoDisjunto(edades, usuarios);

            for (int i = 0; i < preguntas; i++)
            {
                linea = Console.ReadLine().Split();

                if (int.Parse(linea[0]) == 1)
                {
                    int a = int.Parse(linea[1]);
                    int b = int.Parse(linea[2]);

                    conjuntosDisjuntos.Merge(a - 1, b - 1);
                }
                else
                {
                    int valor = int.Parse(linea[1]);
                    int setOf = conjuntosDisjuntos.SetOf(valor - 1);
                    double resp = (double)conjuntosDisjuntos.Edades[setOf] / (double)conjuntosDisjuntos.CantHijos[setOf];
                    Console.WriteLine(resp.ToString("0.00"));
                }
            }
        }
    }
}
