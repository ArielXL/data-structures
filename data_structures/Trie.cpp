#include<bits/stdc++.h>

using namespace std;

#define endl '\n'

typedef pair<int, int> pii;

template<typename T, typename V = vector<T> >
struct trie
{
	struct node
	{
		node *parent;
		map<T, node*> child;
		pii count;

		node(node *parent) : parent(parent), count({ 0, 0 }){ }
	} *root;

	trie() : root(new node(NULL)){ }

	void insert(const V &v)
	{
		node *now = root;
		for(auto c : v)
        {
			++(now -> count).first;
			auto it = (now -> child).find(c);
			now = (it == (now -> child).end() ? (now -> child)[ c ] = new node(now) : it -> second);
		}
		++(now -> count).first;
		++(now -> count).second;
	}

	node* find(const V &v) const
	{
	    node *now = root;
		for(auto c : v)
        {
        	auto it = (now -> child).find(c);
			if(it == (now -> child).end())
				return NULL;
			now = (it -> second);
		}
		return now;
	}

	void remove(const V &v, bool all = 0)
	{
		node *now = find(v);
		if(now == NULL || !(now -> count).second)
			return;
		stack<T> pila;
		for(auto c : v)
			pila.push(c);
		int c = (all ? (now -> count).second : 1);
		(now -> count).second -= c;
		for(node *p ; now != NULL ; now = p, pila.pop())
        {
			p = (now -> parent);
			(now -> count).first -= c;
			if(!(now -> count).first){
				delete(now);
				(p -> child).erase(pila.top());
			}
		}
	}
};

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    trie<char, string> _trie;

    _trie.insert("ariel");
    _trie.insert("arielito");
    _trie.insert("ar");

    int a = _trie.find("ar") -> count.first;
    cout << "la cantidad de palabras en el trie que empiezan ar es " << a << endl;

    //_trie.remove("ariel");

    int b = _trie.find("ariel") -> count.second;
    cout << "la cantidad de palabras en el trie que terminan en ariel es " << b << endl;
}
