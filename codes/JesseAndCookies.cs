using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jesse_and_Cookies
{
    class HeapMinimo<T> where T : IComparable<T>
    {
        T[] heap;
        int count;

        public HeapMinimo(int n)
        {
            heap = new T[n];
            count = 0;
        }

        public HeapMinimo()
            : this(100)
        {

        }

        public void ImprimirHeap()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write("{0} ", heap[i]);
            }
            Console.WriteLine();
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public T Peek()
        {
            if (count > 0)
                return heap[0];
            else
                throw new Exception("Heap vacio");
        }

        public void Insert(T valor)
        {
            if (count > heap.Length)
                CreceArray();

            heap[count] = valor;
            HeapifyUp(count);
            count++;
        }

        public T RemoveMinimo()
        {
            if (count > 0)
            {
                T minimo = heap[0];
                heap[0] = heap[count - 1];
                count--;
                HeapifyDown(0, count);
                return minimo;
            }
            else
                throw new Exception("Heap vacio");
        }

        public bool Remove(T valor)
        {
            if (Esta(valor, 0))
            {
                heap[posicion] = heap[count - 1];
                HeapifyUp(posicion);
                count--;
                HeapifyDown(posicion, count);
                return true;
            }
            else
                return false;
        }

        public void Clear()
        {
            heap = new T[100];
            count = 0;
        }

        private int posicion = 0;

        private bool Esta(T valor, int pos)
        {
            if (pos >= count)
                return false;
            else if (valor.CompareTo(heap[pos]) == 0)
            {
                posicion = pos;
                return true;
            }
            else
            {
                if (Esta(valor, pos * 2 + 1))
                    return true;
                if (Esta(valor, pos * 2 + 2))
                    return true;

                return false;
            }
        }

        private void HeapifyDown(int pos, int cantidad)
        {
            int hijoIzquierdo = pos * 2 + 1;
            int hijoDerecho = pos * 2 + 2;

            if (hijoIzquierdo >= cantidad)
                return;
            if (hijoDerecho >= cantidad)
            {
                if (heap[hijoIzquierdo].CompareTo(heap[pos]) < 0)
                    Swap(hijoIzquierdo, pos);
                return;
            }

            int menorDeLosHijos = MenorDeLosHijos(pos);
            if (heap[menorDeLosHijos].CompareTo(heap[pos]) < 0)
            {
                Swap(menorDeLosHijos, pos);
                HeapifyDown(menorDeLosHijos, cantidad);
            }
        }

        private int MenorDeLosHijos(int indice)
        {
            int hijoIzquierdo = indice * 2 + 1;
            int hijoDerecho = indice * 2 + 2;

            if (heap[hijoDerecho].CompareTo(heap[hijoIzquierdo]) < 0)
                return hijoDerecho;
            else
                return hijoIzquierdo;
        }

        private void HeapifyUp(int indice)
        {
            while (heap[indice].CompareTo(heap[Padre(indice)]) < 0)
            {
                Swap(indice, Padre(indice));
                indice = Padre(indice);
            }
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        private int Padre(int indice)
        {
            return (indice - 1) / 2;
        }

        private void CreceArray()
        {
            T[] array = new T[heap.Length * 2];
            for (int i = 0; i < count; i++)
            {
                array[i] = heap[i];
            }
            heap = array;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();
            int numero = int.Parse(linea[0]);
            long galletas = long.Parse(linea[1]);

            HeapMinimo<int> heap = new HeapMinimo<int>();

            linea = Console.ReadLine().Split();
            for (int i = 0; i < linea.Length; i++)
            {
                int a = int.Parse(linea[i]);
                heap.Insert(a);
            }

            int resp = 0;

            while (true)
            {
                if (heap.Peek() >= galletas)
                    break;
                else
                {
                    int primero = heap.RemoveMinimo();
                    int segundo = heap.RemoveMinimo();
                    int dulzura = 1 * primero + 2 * segundo;
                    heap.Insert(dulzura);
                    resp++;
                }
            }

            Console.WriteLine(resp);
        }
    }
}
