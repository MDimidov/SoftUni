#include <cstring>
#include <algorithm>
#ifndef STACK_IMPLEMENTATION
#define STACK_IMPLEMENTATION

#include "Stack.h"

using namespace std;

template<typename T>
Stack<T>::Stack() {}

template<typename T>
Stack<T>::~Stack() {
	while (top != null) {
		delete top;
		top = top.next;
	}
}

template<typename T>
void Stack<T>::Push(T& item) {
	Node newNode = new Node(item, top);
	top = newNode;
	count++;
}




#endif // !STACK_IMPLEMENTATION