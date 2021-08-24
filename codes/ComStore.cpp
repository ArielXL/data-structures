#include<bits/stdc++.h>
#include <ext/pb_ds/tree_policy.hpp>
#include <ext/pb_ds/assoc_container.hpp>

using namespace std;
using namespace __gnu_pbds;

typedef tree<int, null_type, less<int>,
        rb_tree_tag, tree_order_statistics_node_update> avl;

#define endl '\n'

avl avl_menores;
int casos, a, modelo, dinero, k;

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> casos;

    while(casos--)
    {
        cin >> a;

        if(a == 1)
        {
            cin >> dinero >> k;

            if(k <= avl_menores.size())
            {
                int k_menor = *avl_menores.find_by_order(k - 1);
                //cout << k_menor << endl;

                if(dinero >= k_menor)
                    cout << "SI" << endl;
                else
                    cout << "NO" << endl;
            }
            else
                cout << "NO" << endl;
        }
        else
        {
            cin >> modelo;
            avl_menores.insert(modelo);
        }
    }
}
