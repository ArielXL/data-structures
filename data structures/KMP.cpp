#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

string texto, patron;
int pi[100005];
vector<int> lista;

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

void KMP(string texto, string patron)
{
    int ocurrencias = 0;
    int k = 0;

    for (int i = 1; i < texto.length(); i++)
    {
        while (k > 0 && texto[i] != patron[k + 1])
            k = pi[k];

        if (texto[i] == patron[k + 1])
            k++;

        if (k == patron.length() - 1)
        {
            cout << "hay una ocurrencia en el corrimiento " << i - patron.length() + 1 << endl;
            k = pi[k];
            ocurrencias++;
        }
    }

    cout << "hay " << ocurrencias << " ocurrencias" << endl;
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    // recordar concatenar "$" antes de cada parametro de los metodos prefix_function y KMP

    cin >> texto >> patron;

    prefix_function("$" + patron);

    KMP("$" + texto, "$" + patron);
}
