//#pragma once
#ifndef IABSTRACTLIST_H
#define IABSTRACTLIST_H

#include <cstddef>

template<typename T>
class IAbstractList
{
public:
	virtual ~IAbstractList() = default;

	virtual size_t Count() const = 0;
	virtual T& operator[](size_t index) = 0;
	virtual const T& operator(size_t index) const = 0;

	virtual void Add(const T& item) = 0;
	virtual void Insert(size_t index, const T& item) = 0;
	virtual bool Contains(const T& item) = 0;
	virtual int IndexOf(const T& item) = 0;
	virtual bool Remove(const T& item) = 0;
	virtual void RemoveAt(size_t index) = 0;
};

#endif