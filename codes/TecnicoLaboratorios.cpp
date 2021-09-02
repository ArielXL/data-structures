#include<bits/stdc++.h>
#define endl '\n'

using namespace std;
typedef pair<int, int> pii;

int vertices, aristas, u, v, casos, a, b, x, y;
vector<int> grafo[100005];
int tiempo;
int d[100005];
int f[100005];
int low[100005];
int pi[100005];
bool marcados[100005];
set<pii> aristas_puentes;

void DFS_Visit(int elemento)
{
    marcados[elemento] = true;
    tiempo++;
    d[elemento] = tiempo;
    low[elemento] = d[elemento];

    for(int i = 0; i < grafo[elemento].size(); i++)
    {
        int temp = grafo[elemento][i];

        if(!marcados[temp])
        {
            pi[temp] = elemento;

            DFS_Visit(temp);

            low[elemento] = min(low[elemento], low[temp]);
        }
        else if (pi[elemento] != temp)
            low[elemento] = min(low[elemento], d[temp]);
    }
    if (pi[elemento] != INT_MIN && low[elemento] == d[elemento])
    {
        aristas_puentes.insert(make_pair(pi[elemento], elemento));
        aristas_puentes.insert(make_pair(elemento, pi[elemento]));
    }

    tiempo++;
    f[elemento] = tiempo;
}

void DFS()
{
    for(int i = 1; i <= vertices; i++)
    {
        if(!marcados[i])
            DFS_Visit(i);
    }
}

void dame_aristas_puentes()
{
    tiempo = 0;
    pi[1] = INT_MIN;

    DFS();
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> vertices >> aristas;

    for(int i = 0; i < aristas; i++)
    {
        cin >> u >> v;

        grafo[u].push_back(v);
        grafo[v].push_back(u);
    }

    dame_aristas_puentes();
    cin >> casos;

    while(casos--)
    {
        cin >> a >> b >> x >> y;

        if(aristas_puentes.find(pii(x, y)) != aristas_puentes.end())
        {
            if(d[y] < d[x])
                swap(x, y);

            bool s1 = d[a] >= d[y] && f[a] <= f[y];
            bool s2 = d[b] >= d[y] && f[b] <= f[y];

            if(s1 ^ s2)
                cout << "no" << endl;
            else
                cout << "si" << endl;
        }
        else
            cout << "si" << endl;
    }
}
