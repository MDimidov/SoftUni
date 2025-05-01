//#pragma once
#ifndef IABSTRACTLIST_H
#define IABSTRACTLIST_H

//#include <cstddef>

template<typename T>
class IAbstractList
{
public:
	virtual ~IAbstractList() = default;

	virtual int Count() const = 0;
	virtual T& operator[](int index) = 0;
	virtual const T& operator[](int index) const = 0;

	virtual void Add(const T& item) = 0;
	virtual void Insert(int index, const T& item) = 0;
	virtual bool Contains(const T& item) = 0;
	virtual int IndexOf(const T& item) = 0;
	virtual bool Remove(const T& item) = 0;
	virtual void RemoveAt(int index) = 0;
};

#endif