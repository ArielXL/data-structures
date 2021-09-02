#include<bits/stdc++.h>

using namespace std;

#define endl '\n'

int n;
long long q, w;
int resp = 0;
long long a[200005];
pair<long long, long long> lista[200005];

bool compare(pair<long long, long long> x, pair<long long, long long> y)
{
    return x.first <= y.first;
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> n;

    for(int i = 0; i < n; i++)
    {
        cin >> q;
        a[i] = q;
    }

    for(int i = 0; i < n; i++)
    {
        cin >> w;
        lista[i] = pair<long long, long long>(a[i], w);
    }

    sort(lista, lista + n, compare);
    priority_queue<pair<long long, long long> > cola;
    cola.push(lista[0]);

    for(int i = 1; i < n; i++)
    {
        if(lista[i].second > cola.top().second)
            cola.push(lista[i]);
        else
            resp++;
    }

    cout << resp << endl;
}
