#include<bits/stdc++.h>
#include<ext/pb_ds/tree_policy.hpp>
#include<ext/pb_ds/assoc_container.hpp>
#define endl '\n'

using namespace __gnu_pbds;
using namespace std;
template <typename T>

using ordered_set = tree<T, null_type, less<T>, rb_tree_tag, tree_order_statistics_node_update>;
int arr[1000005];

int main()
{
    int inversiones = 0;
    int n, a;
    ordered_set<int> avl;

    cin >> n;

    for(int i = 0; i < n; i++)
    {
        cin >> a;
        arr[i] = a;
    }

    for(int i = 0; i < n; i++)
    {
        avl.insert(arr[i]);
        inversiones += i - avl.order_of_key(arr[i]);
    }

    cout << inversiones << endl;
}
