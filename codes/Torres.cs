using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres
{
    class DisjointSet
    {
        public int[] Indices;
        public int[] CantidadElementos;

        public DisjointSet(int n)
        {
            Indices = new int[n];
            CantidadElementos = new int[n];

            for (int i = 0; i < n; i++)
            {
                Indices[i] = i;
                CantidadElementos[i] = 1;
            }
        }

        public int SetOf(int i)
        {
            if (Indices[i] == i)
                return i;
            else
                return Indices[i] = SetOf(Indices[i]);
        }

        public int PrimerMayor()
        {
            int mayor = int.MinValue;
            int pos = 0;
            for (int i = 0; i < CantidadElementos.Length; i++)
            {
                if (CantidadElementos[i] > mayor)
                {
                    mayor = CantidadElementos[i];
                    pos = i;
                }
            }
            return pos;
        }

        public int SegundoMayor(int mayor)
        {
            int segundoMayor = int.MinValue;
            int pos = 0;
            for (int i = 0; i < CantidadElementos.Length; i++)
            {
                if (i != mayor && CantidadElementos[i] > segundoMayor)
                {
                    segundoMayor = CantidadElementos[i];
                    pos = i;
                }
            }
            return pos;
        }

        public void Merge(int i, int j)
        {
            int x = SetOf(i);
            int y = SetOf(j);

            if (x == y)
                return;

            if (CantidadElementos[x] > CantidadElementos[y])
            {
                Indices[y] = x;
                CantidadElementos[x] += CantidadElementos[y];
                CantidadElementos[y] = 0;
            }
            else
            {
                Indices[x] = y;
                CantidadElementos[y] += CantidadElementos[x];
                CantidadElementos[x] = 0;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int n = int.Parse(linea[0]);
            int preguntas = int.Parse(linea[1]);

            DisjointSet conjuntosDisjuntos = new DisjointSet(n);

            for (int i = 0; i < preguntas; i++)
            {
                linea = Console.ReadLine().Split();

                int a = int.Parse(linea[0]);
                int b = int.Parse(linea[1]);

                conjuntosDisjuntos.Merge(a - 1, b - 1);
            }

            int primerMayor = conjuntosDisjuntos.PrimerMayor();
            int segundoMayor = conjuntosDisjuntos.SegundoMayor(primerMayor);
            
            int x = conjuntosDisjuntos.SetOf(primerMayor);
            int y = conjuntosDisjuntos.SetOf(segundoMayor);
            
            Console.WriteLine("{0} {1}", x+1, y+1);
        }
    }
}