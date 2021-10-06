#include<bits/stdc++.h>
#define endl '\n'
#define pii pair<int, int>

using namespace std;

int indices[1005];
int cantidad[1005];

void build(int n)
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
    }
    else
    {
        indices[y] = x;
        cantidad[x] += cantidad[y];
        cantidad[y] = 0;
    }

    return 1;
}

void print(int n)
{
    cout << "indices" << endl;
    for(int i = 0; i < n; i++)
    {
        cout << indices[i] << " ";
    }
    cout << endl;

    cout << "cantidad" << endl;
    for(int i = 0; i < n; i++)
    {
        cout << cantidad[i] << " ";
    }
    cout << endl;
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    build(5);
    cout << merges(1, 2) << endl;

    print(5);
}
