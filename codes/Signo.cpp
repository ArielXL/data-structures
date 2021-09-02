#include <bits/stdc++.h>
#define endl '\n'

using namespace std;

int arr[100005];
int st[4 * 100005];

void build(int nodo, int inicio, int fin)
{
    if(inicio == fin)
        st[nodo] = arr[inicio];
    else
    {
        int medio = (inicio + fin) / 2;

        build(2 * nodo, inicio, medio);
        build(2 * nodo + 1, medio + 1, fin);
        st[nodo] = st[2 * nodo] * st[2 * nodo + 1];
    }
}

void update(int nodo, int inicio, int fin, int pos, int valor)
{
    if(inicio == fin && inicio == pos)
    {
        st[nodo] = valor;
        arr[inicio] = valor;
    }
    else
    {
        int medio = (inicio + fin) / 2;

        if(pos <= medio)
            update(2 * nodo, inicio, medio, pos, valor);
        else
            update(2 * nodo + 1, medio + 1, fin, pos, valor);

        st[nodo] = st[2 * nodo] * st[2 * nodo + 1];
    }
}

int query(int nodo, int inicio, int fin, int i, int j)
{
    if(fin < i || inicio > j)
        return 1;
    if(inicio >= i && fin <= j)
        return st[nodo];

    int medio = (inicio + fin) / 2;

    int derecha = query(2 * nodo, inicio, medio, i, j);
    int izquierda = query(2 * nodo + 1, medio + 1, fin, i, j);

    return derecha * izquierda;
}

int main()
{
    int n, q, a, i, j;
    cin >> n;

    for(int i = 0; i < n; i++)
    {
        cin >> a;
        arr[i] = a;
    }

    build(1, 0, n - 1);
    cin >> q;

    while(q--)
    {
        cin >> a;

        if(a == 1)
        {
            cin >> i;
            update(1, 0, n - 1, i, arr[i] * -1);
        }
        else
        {
            cin >> i >> j;
            int resp = query(1, 0, n - 1, i, j);

            if(resp < 0)
                cout << -1 << endl;
            else if(resp > 0)
                cout << 1 << endl;
            else
                cout << 0 << endl;
        }
    }
}
