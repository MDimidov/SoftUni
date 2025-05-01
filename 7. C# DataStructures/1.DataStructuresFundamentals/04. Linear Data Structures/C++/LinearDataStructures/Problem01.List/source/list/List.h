// List.h
#ifndef LIST_H
#define LIST_H

#include "IAbstractList.h"
#include <stdexcept>
#include <iterator>

template<typename T>
class List : public IAbstractList<T> {
private:
    static const size_t DEFAULT_CAPACITY = 4;
    T* items;
    size_t capacity;
    size_t count;

    void GrowArray();
    bool IsIndexValid(size_t index) const;

public:
    List();
    List(size_t capacity);
    ~List();

    size_t Count() const override;

    T& operator[](size_t index) override;
    const T& operator[](size_t index) const override;

    void Add(const T& item) override;
    void Insert(size_t index, const T& item) override;

    bool Contains(const T& item) const override;
    int IndexOf(const T& item) const override;

    bool Remove(const T& item) override;
    void RemoveAt(size_t index) override;

    // Optional: итератор за range-based for
    T* begin() { return items; }
    T* end() { return items + count; }
};

#include "List.hpp"

#endif
