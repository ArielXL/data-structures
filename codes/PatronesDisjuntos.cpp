#include<bits/stdc++.h>

using namespace std;

#define endl '\n'

string texto, patron;
long long pot[5000005];
long long hash_texto[5000005];
long long hash_patron[5000005];
int modulo = 1000000009;
int base = 31;

void potencia()
{
    pot[0] = 1;
    for(int i = 1; i < 5000003; i++)
    {
        pot[i] = (pot[i - 1] * base) % modulo;
    }
}

void calcula_hash_texto()
{
    hash_texto[0] = texto[0];
    for(int i = 1; i < texto.length(); i++)
    {
        hash_texto[i] = ((hash_texto[i - 1] * base) % modulo + texto[i]) % modulo;
    }
}

void calcula_hash_patron()
{
    hash_patron[0] = patron[0];
    for(int i = 1; i < patron.length(); i++)
    {
        hash_patron[i] = ((hash_patron[i - 1] * base) % modulo + patron[i]) % modulo;
    }
}

long long dame_hash_texto(int i, int j)
{
    if(i == 0)
        return hash_texto[j];
    else
        return (hash_texto[j] + modulo - (hash_texto[i - 1] * pot[j - i + 1]) % modulo) % modulo;
}

long long dame_hash_patron(int i, int j)
{
    if(i == 0)
        return hash_patron[j];
    else
        return (hash_patron[j] + modulo - (hash_patron[i - 1] * pot[j - i + 1]) % modulo) % modulo;
}

int solucion()
{
    int cont = 0;
    potencia();
    calcula_hash_texto();
    calcula_hash_patron();
    long long aux = dame_hash_patron(0, patron.length() - 1);

    for(int i = 0; i <= texto.length() - patron.length(); i++)
    {
        long long x = dame_hash_texto(i, i + patron.length() - 1);

        if(x == aux)
        {
            cont++;
            i += patron.length() - 1;
        }
    }

    return cont;
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> texto >> patron;
    int resp = solucion();
    cout << resp << endl;
}
