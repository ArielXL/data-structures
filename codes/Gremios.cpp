#include <bits/stdc++.h>
#define endl '\n'

using namespace std;

int n, q, x, y;
int mayor_gremio;
int cuantos_gremio;
int indices[1000005];
int cantidad[1000005];

void build()
{
    for (int i = 0; i < n; i++)
    {
        indices[i] = i;
        cantidad[i] = 1;
    }
}

int set_off(int i)
{
    if (indices[i] == i)
        return i;
    else
        return indices[i] = set_off(indices[i]);
}

int merges(int i, int j)
{
    int x = set_off(i);
    int y = set_off(j);

    if (x == y)
        return 0;

    if (cantidad[x] < cantidad[y])
    {
        indices[x] = y;
        cantidad[y] += cantidad[x];
        cantidad[x] = 0;
        if(cantidad[y] > mayor_gremio)
        {
            mayor_gremio = cantidad[y];
            cuantos_gremio = 1;
        }
        else
        {
            if(cantidad[y] == mayor_gremio)
                cuantos_gremio++;
        }
    }
    else
    {
        indices[y] = x;
        cantidad[x] += cantidad[y];
        cantidad[y] = 0;
        if(cantidad[x] > mayor_gremio)
        {
            mayor_gremio = cantidad[x];
            cuantos_gremio = 1;
        }
        else
        {
            if(cantidad[x] == mayor_gremio)
                cuantos_gremio++;
        }
    }

    return 1;
}

int main()
{
    cin >> n >> q;
    build();

    while(q--)
    {
        cin >> x >> y;

        merges(x, y);
        cout << mayor_gremio << " " << cuantos_gremio << endl;
    }
}
