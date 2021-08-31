#include <bits/stdc++.h>
#define endl '\n'

using namespace std;

int resp = 0;
string a, b, s;
int pi[1000005];

void prefix_function(string patron)
{
    int k = 0;

    for (int i = 2; i < patron.length(); i++)
    {
        while (k > 0 && patron[k + 1] != patron[i])
            k = pi[k];

        if (patron[k + 1] == patron[i])
            k++;

        pi[i] = k;
    }
}

void limpiar_pi()
{
    for(int i = 0; i < 1000003; i++)
    {
        pi[i] = 0;
    }
}

vector<int> KMP(string texto, string patron)
{
    vector<int> lista;
    lista.clear();
    limpiar_pi();
    prefix_function(patron);
    int k = 0;

    for (int i = 1; i < texto.length(); i++)
    {
        while (k > 0 && texto[i] != patron[k + 1])
            k = pi[k];

        if (texto[i] == patron[k + 1])
            k++;

        if (k == patron.length() - 1)
        {
            lista.push_back(i - patron.length() + 1);
            k = pi[k];
        }
    }

    return lista;
}

int main()
{
    cin >> a >> b >> s;

    vector<int> match_a = KMP("$" + s, "$" + a);
    vector<int> match_b = KMP("$" + s, "$" + b);

    for(int i = 0; i < match_b.size(); i++)
    {
        match_b[i] += b.length() - 1;
    }

    for(int i = 0; i < match_a.size(); i++)
    {
        int buscar = match_a[i];
        int pos = upper_bound(match_b.begin(), match_b.end(), buscar) - match_b.begin();
        resp += match_b.size() - pos;
    }

    cout << resp << endl;
}
