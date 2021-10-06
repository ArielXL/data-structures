#include <bits/stdc++.h>

using namespace std;

int arr[100005];
int st[4 * 100005];
int n, update, indice, valor, a;
int nulo = INT_MAX;

int Merge(int a, int b)
{
    return min(a, b);
}

void Build(int node, int inicio, int fin)
{
    if(inicio == fin)
        st[node] = arr[inicio];
    else
    {
        int medio = (inicio + fin) / 2;

        Build(node * 2, inicio, medio);
        Build(node * 2 + 1, medio + 1, fin);

        st[node] = Merge(st[2 * node], st[2 * node + 1]);
    }
}

void Update(int node, int inicio, int fin, int indice, int valor)
{
    if(inicio == fin && inicio == indice)
    {
        st[node] = valor;
        arr[inicio] = valor;
    }
    else
    {
        int medio = (inicio + fin) / 2;

        if (indice <= medio)
            Update(2 * node, inicio, medio, indice, valor);
        else
            Update(2 * node + 1, medio + 1, fin, indice, valor);

        st[node] = Merge(st[2 * node], st[2 * node + 1]);
    }
}

int Query(int node, int inicio, int fin, int i, int j)
{
    if (fin < i || inicio > j)
        return nulo;
    if (inicio >= i && fin <= j)
        return st[node];

    int medio = (inicio + fin) / 2;

    int l = Query(2 * node, inicio, medio, i, j);
    int r = Query(2 * node + 1, medio + 1, fin, i, j);

    return Merge(l, r);
}

int main()
{
    cin >> n;

    for(int i = 0; i < n; i++)
    {
        cin >> a;
        arr[i] = a;
    }

    Build(1, 0, n - 1);
    cin >> update;

    while(update--)
    {
        cin >> indice >> valor;
        Update(1, 0, n - 1, indice - 1, valor);
        cout << Query(1, 0, n - 1, 0, n - 1) << endl;
    }
}
