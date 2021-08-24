#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

int n, a, mediana;
priority_queue<int, vector<int>, less<int> > cola_mayores;
priority_queue<int, vector<int>, greater<int> > cola_menores;

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);
    cout.tie(0);

    cin >> n;

    for(int i = 0; i < n; i++)
    {
        cin >> a;

        if(i == 0)
            mediana = a;
        else if(a >= mediana)
        {
            cola_menores.push(a);

            if(cola_menores.size() - cola_mayores.size() >= 2)
            {
                cola_mayores.push(mediana);
                mediana = cola_menores.top();
                cola_menores.pop();
            }
        }
        else
        {
            cola_mayores.push(a);

            if(cola_mayores.size() - cola_menores.size() >= 1)
            {
                cola_menores.push(mediana);
                mediana = cola_mayores.top();
                cola_mayores.pop();
            }
        }

        cout << mediana << endl;
    }
}
