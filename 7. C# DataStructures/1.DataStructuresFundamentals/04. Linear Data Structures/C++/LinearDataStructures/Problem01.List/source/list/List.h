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
	//static int const DEFAULT_SIZE = 4;
	int size = 0;
	T items[4];

public:
	///*List() {
	//	items = new T[DEFAULT_SIZE];
	//}*/

	///*List(int newSize) {
	//	items[] = new T[newSize];
	//}*/

	int Count() const override;
	T& operator[](int index) override;
	const T& operator[](int index) const override;

	void Add(const T& item) override;
	void Insert(int index, const T& item) override;
	bool Contains(const T& item) override;
	int IndexOf(const T& item)  override;
	bool Remove(const T& item) override;
	void RemoveAt(int index) override;

};

//#include "List.cpp"


#endif // LIST_H