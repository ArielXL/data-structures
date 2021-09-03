#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

string s;
long long potencia[1000005];
long long hash_alante[1000005];
long long hash_detras[1000005];
long long modulo = 1000000009;
int base = 31;

void Potencia()
{
    potencia[0] = 1;
    for(int i = 1; i < 1000005; i++)
    {
        potencia[i] = (potencia[i - 1] * base) % modulo;
    }
}

long long DameHashAlante(int i, int j)
{
    if(i == 0)
        return hash_alante[j];
    else
        return (hash_alante[j] + modulo - (hash_alante[i - 1] * potencia[j - i + 1]) % modulo) % modulo;
}

long long DameHashDetras(int i, int j)
{
    if(j == (s.length() - 1))
        return hash_detras[i];
    else
        return (hash_detras[i] + modulo - (hash_detras[j + 1] * potencia[j - i + 1]) % modulo) % modulo;
}

void CalculaHash(string s)
{
    hash_alante[0] = s[0];
    int pos = s.length() - 1;
    hash_detras[pos] = s[pos];
    pos--;

    for(int i = 1; i < s.length(); i++)
    {
        hash_alante[i] = ((hash_alante[i - 1] * base) % modulo + s[i]) % modulo;
        hash_detras[pos] = ((hash_detras[pos + 1] * base) % modulo + s[pos]) % modulo;
        pos--;
    }
}

bool EsPalindromo(int i, int j)
{
    long long x = DameHashAlante(i, j);
    long long y = DameHashDetras(i, j);

    if(x == y)
        return true;
    else
        return false;
}

int EsBipalindromo()
{
    int n = s.length();
    int cont = 0;

    for (int i = 0; i < n - 1; i++)
    {
        if (EsPalindromo(0, i) && EsPalindromo(i + 1, n - 1))
            cont++;
    }

    if (EsPalindromo(0, n - 1))
        cont += 2;

    return cont;
}

int Solucion()
{
    Potencia();
    CalculaHash(s);
    int resp = EsBipalindromo();
    return resp;
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);
    cout.tie(0);

    cin >> s;

    int resp = Solucion();
    cout << resp << endl;
}
