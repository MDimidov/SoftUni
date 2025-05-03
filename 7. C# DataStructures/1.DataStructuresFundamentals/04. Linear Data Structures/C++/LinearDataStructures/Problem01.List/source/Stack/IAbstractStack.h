#ifndef STACK_H
#define STACK_H

#include <cstddef>
#include <iterator>

template<typename T>
class IAbstractStack {
public:
	virtual ~IAbstractStack() = default;

	virtual size_t Count() const = 0;
    virtual void Push(T& item) = 0;
    virtual T& Pop() = 0;
    virtual T& Peek() const = 0;
    virtual bool Contains(T& item) const = 0;
};


#endif
