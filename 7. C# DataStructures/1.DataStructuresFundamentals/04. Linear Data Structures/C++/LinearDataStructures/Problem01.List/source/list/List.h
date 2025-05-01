#pragma once
#ifndef LIST_H
#define LIST_H

#include "IAbstractList.h"
#include "vector"
#include "stdexcept"
#include "algorithm"

template <typename T>
class List : public IAbstractList<T>
{
private:
	int DEFAULT_SIZE = 4;
	std::T[] items;
	int Count = 0;
public:
	List() {
		items = new T[DEFAULT_SIZE];
	}

	List(int size) {
		items = new T[size];
	}

	size_t Count() const override;
	T& operator[](size_t index) override;
	const T& operator[](size_t index) const override;

	void Add(const T& item) override;
	void Insert(size_t index, const T& item) override;
	bool Contains(const T& item) const override;
	int IndexOf(const T& item) const override;
	bool Remove(const T& item) override;
	void RemoveAt(size_t index) override;

};

#include "List.cpp"


#endif // LIST_H