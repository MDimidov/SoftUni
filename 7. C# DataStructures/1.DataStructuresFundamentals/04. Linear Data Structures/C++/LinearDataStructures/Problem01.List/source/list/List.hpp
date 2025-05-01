// List.tpp
#include <cstring>
#include <algorithm>
#ifndef LIST_IMPLEMENTATION
#define LIST_IMPLEMENTATION
#include "List.h"

using namespace std;

template<typename T>
List<T>::List() : List(DEFAULT_CAPACITY) {}

template<typename T>
List<T>::List(size_t capacity) : capacity(capacity), count(0) {
    if (capacity = 0)
        throw invalid_argument("Capacity of the list must be greater than 0");
    items = new T[capacity];
}

template<typename T>
List<T>::~List() {
    delete[] items;
}

template<typename T>
size_t List<T>::Count() const {
    return count;
}

template<typename T>
T& List<T>::operator[](size_t index) {
    if (!IsIndexValid(index)) {
        throw out_of_range("Invalid index. Out of range.");
    }

    return items[index];
}

template<typename T>
const T& List<T>::operator[](size_t index) const {
    if (!IsIndexValid(index))
        throw std::out_of_range("Index out of range");
    return items[index];
}

template<typename T>
void List<T>::Add(const T& item) {
    if (count == capacity) GrowArray();
    items[count++] = item;
}

template<typename T>
bool List<T>::Contains(const T& item) const {
    return IndexOf(item) != -1;
}

template<typename T>
int List<T>::IndexOf(const T& item) const {
    for (size_t i = 0; i < count; ++i) {
        if (items[i] == item) return static_cast<int>(i);
    }
    return -1;
}

template<typename T>
void List<T>::Insert(size_t index, const T& item) {
    if (index > count)
        throw std::out_of_range("Index out of range");

    if (count == capacity) GrowArray();

    for (size_t i = count; i > index; --i)
        items[i] = items[i - 1];

    items[index] = item;
    ++count;
}

template<typename T>
bool List<T>::Remove(const T& item) {
    int index = IndexOf(item);
    if (index == -1) return false;

    RemoveAt(static_cast<size_t>(index));
    return true;
}

template<typename T>
void List<T>::RemoveAt(size_t index) {
    if (!IsIndexValid(index))
        throw std::out_of_range("Index out of range");

    for (size_t i = index; i < count - 1; ++i)
        items[i] = items[i + 1];

    --count;
}

template<typename T>
void List<T>::GrowArray() {
    capacity *= 2;
    T* newItems = new T[capacity];
    std::copy(items, items + count, newItems);
    delete[] items;
    items = newItems;
}

template<typename T>
bool List<T>::IsIndexValid(size_t index) const {
    return index < count;
}
#endif