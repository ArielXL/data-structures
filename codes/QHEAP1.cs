using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHEAP1
{
    class Heap
    {
        int[] value;
        int count;

        public Heap(int n)
        {
            value = new  int[n];
            count = 0;
        }

        public int Count { get { return count; } }

        private int Left(int n)
        {
            return 2 * n + 1;
        }

        private int Right(int n)
        {
            return 2 * n + 2;
        }

        private int father(int n)
        {
            return (n + 1) / 2 - 1;
        }

        public void Insertar(int n)
        {
            value[count] = n;
            UpHeapify(count);
            count++;
        }

        private void UpHeapify(int i)
        {
            int f = father(i);
            if (f >= 0 && value[f] > value[i])
            {
                int temp = value[f];
                value[f] = value[i];
                value[i] = temp;
                UpHeapify(f);
            }
        }

        public int PeekMin()
        {
            if (count == 0)
                throw new InvalidOperationException("Heap empty");
            return value[0];
        }

        public int GetMin()
        {
            if (count == 0)
                throw new InvalidOperationException("Heap empty");
            int n = value[0];
            value[0] = value[count - 1];
            DawnHeapify(0);
            count--;
            return n;
        }

        private void DawnHeapify(int i)
        {
            int l = Left(i);
            int r = Right(i);
            int min = i;
            if (l < count && value[l] < value[min])
                min = l;
            if (r < count && value[r] < value[min])
                min = r;
            if (min != i)
            {
                int temp = value[i];
                value[i] = value[min];
                value[min] = temp;
                DawnHeapify(min);
            }
        }

        public void Remove(int n)
        {
            for (int i = 0; i < count; i++)
            {
                if (value[i] == n)
                {
                    value[i] = value[count - 1];
                    DawnHeapify(i);
                    break;
                }
            }
            count--;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Heap heap = new Heap(1000000);
            int casos = int.Parse(Console.ReadLine());

            while (casos > 0)
            {
                string[] linea = Console.ReadLine().Split();

                int a = int.Parse(linea[0]);

                if (a == 1) 
                {
                    int valor = int.Parse(linea[1]);
                    heap.Insertar(valor);
                }
                else if (a == 2)
                {
                    int valor = int.Parse(linea[1]);
                    heap.Remove(valor);
                }
                else
                    Console.WriteLine(heap.PeekMin());

                casos--;
            }
        }
    }
}
