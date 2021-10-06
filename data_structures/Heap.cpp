#include <bits/stdc++.h>

using namespace std;

#define endl '\n'

struct cmp{

    bool operator()(const int &a, const int &b){
        return a < b;
    }
};

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    priority_queue<int, vector<int> , cmp> Q;

    //priority_queue<int, vector<int> , less <int> > Q;

    int N;

    for(int I = 0;I < 5;++I){
        cin >> N;
        Q.push(N);
    }

    while(!Q.empty()){
        cout << Q.top() << endl;
        Q.pop();
    }
}