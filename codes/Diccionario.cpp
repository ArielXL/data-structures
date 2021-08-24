#include<bits/stdc++.h>
#include <ext/pb_ds/tree_policy.hpp>
#include <ext/pb_ds/assoc_container.hpp>

using namespace std;
using namespace __gnu_pbds;

typedef tree<int, null_type, less<int>,
        rb_tree_tag, tree_order_statistics_node_update> ordered_set_menores;
typedef tree<int, null_type, greater<int>,
        rb_tree_tag, tree_order_statistics_node_update> ordered_set_mayores;
#define endl '\n'

int n;
int a, x;

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> n;

    ordered_set_menores avl_menores;
    ordered_set_mayores avl_mayores;

    while(n--)
    {
        cin >> a;

        if(a == 1)
        {
            cin >> x;
            if(avl_menores.find(x) == avl_menores.end())
            {
                avl_menores.insert(x);
                avl_mayores.insert(x);
                cout << "True" << endl;
            }
            else
                cout << "False" << endl;
        }
        else if(a == 2)
            cout << avl_menores.size() << endl;
        else if(a == 3)
        {
            cin >> x;
            if(avl_menores.find(x) == avl_menores.end())
                cout << "False" << endl;
            else
                cout << "True" << endl;
        }
        else if(a == 4)
        {
            cin >> x;
            cout << avl_menores.order_of_key(x) << endl;
        }
        else
        {
            cin >> x;
            cout << avl_mayores.order_of_key(x) << endl;
        }
    }
}
