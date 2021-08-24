using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaberintoHermes
{
    class Program
    {
        static int[] dx = { 1, -1, 0, 0 };
        static int[] dy = { 0, 0, 1, -1 };

        static bool EsValido(char[,] matriz, int i, int j)
        {
            return i >= 0 && j >= 0 && i < matriz.GetLength(0) && j < matriz.GetLength(1);
        }

        static int BFS(char[,] matriz, bool[,] marcados, int i, int j)
        {
            int resp = 0;
            marcados[i, j] = true;
            Queue<Tuple<int, int>> cola = new Queue<Tuple<int, int>>();

            cola.Enqueue(new Tuple<int, int>(i, j));

            while (cola.Count != 0)
            {
                Tuple<int, int> aux = cola.Dequeue();

                for (int k = 0; k < 4; k++)
                {
                    int next_i = aux.Item1 + dx[k];
                    int next_j = aux.Item2 + dy[k];

                    if (EsValido(matriz, next_i, next_j) && !marcados[next_i, next_j] && matriz[next_i, next_j] != 'X')
                    {
                        cola.Enqueue(new Tuple<int, int>(next_i, next_j));
                        marcados[next_i, next_j] = true;
                        if (matriz[next_i, next_j] == 'P')
                            resp++;
                    }
                }
            }

            return resp;
        }

        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int fila = int.Parse(linea[0]);
            int columna = int.Parse(linea[1]);

            char[,] matriz = new char[fila, columna];

            for (int i = 0; i < fila; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < s.Length; j++)
                {
                    matriz[i, j] = s[j];
                }
            }

            int resp = 0;
            bool[,] marcados = new bool[matriz.GetLength(0), matriz.GetLength(1)];

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] == 'E' && !marcados[i, j])
                    {
                        resp += BFS(matriz, marcados, i, j);
                    }
                }
            }

            Console.WriteLine(resp);
        }
    }
}
