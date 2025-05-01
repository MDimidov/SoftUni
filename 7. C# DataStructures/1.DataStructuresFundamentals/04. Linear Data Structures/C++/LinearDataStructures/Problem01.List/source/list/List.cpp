#include "List.h"

//template<typename T>
//int List<T>::Count() const {
//	return this.Count;
//}


template<typename T>
T& List<T>::operator[](int index) {
	if (index >= this->Count || index < 0) throw std::out_of_range("Index out of range");
	return items[index];
}

template<typename T>
const T& List<T>::operator[](int index) const {
	if (index >= items.size()) throw std::out_of_range("Index out of range");
	return items[index];
}

template<typename T>
void List<T>::Add(const T& item) {
	//To do
}

template<typename T>
void List<T>::Insert(int index, const T& item) {
	if (index > items.size()) throw std::out_of_range("Index out of range");
	items.insert(items.begin() + index, item);
}

template<typename T>
bool List<T>::Contains(const T& item) const {
	return std::find(items.begin(), items.end(), item) != items.end();
}

template<typename T>
int List<T>::IndexOf(const T& item) const {
	auto it = std::find(items.begin(), items.end(), item);
	return it != items.end() ? static_cast<int>(std::distance(items.begin(), it)) : -1;
}

template<typename T>
bool List<T>::Remove(const T& item) {
	auto it = std::find(items.begin(), items.end(), item);
	if (it != items.end()) {
		items.erase(it);
		return true;
	}
	return false;
}

template<typename T>
void List<T>::RemoveAt(int index) {
	if (index >= items.size()) throw std::out_of_range("Index out of range");
	items.erase(items.begin() + index);
}