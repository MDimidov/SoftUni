#ifndef STACK_H
#define STACK_H

#include "IAbstractStack.h"
#include <stdexcept>

template<typename T>
class Stack : public IAbstractStack<T> {
private:
	size_t count;

	class Node {
	public:
		class Node(T element);
		class Node(T element, Node next);

		T element;
		Node next;
	};

	Node top;

public:
	Stack();
	~Stack();

	size_t Count() const override;
	void Push(T& item) override;
	T& Pop() override;
	T& Peek() const override;
	bool Contains const override;
};

#endif // !STACK_H
