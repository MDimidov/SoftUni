#include "List.h"

template<typename T>
int List<T>::Count() const {
	return this.Count;
}


template<typename T>
T& List<T>::operator[](int index) {
	if (index >= data.size()) throw std::out_of_range("Index out of range");
	return data[index];
}

template<typename T>
const T& List<T>::operator[](int index) const {
	if (index >= data.size()) throw std::out_of_range("Index out of range");
	return data[index];
}

template<typename T>
void List<T>::Add(const T& item) {
	data.push_back(item);
}

template<typename T>
void List<T>::Insert(int index, const T& item) {
	if (index > data.size()) throw std::out_of_range("Index out of range");
	data.insert(data.begin() + index, item);
}

template<typename T>
bool List<T>::Contains(const T& item) const {
	return std::find(data.begin(), data.end(), item) != data.end();
}

template<typename T>
int List<T>::IndexOf(const T& item) const {
	auto it = std::find(data.begin(), data.end(), item);
	return it != data.end() ? static_cast<int>(std::distance(data.begin(), it)) : -1;
}

template<typename T>
bool List<T>::Remove(const T& item) {
	auto it = std::find(data.begin(), data.end(), item);
	if (it != data.end()) {
		data.erase(it);
		return true;
	}
	return false;
}

template<typename T>
void List<T>::RemoveAt(int index) {
	if (index >= data.size()) throw std::out_of_range("Index out of range");
	data.erase(data.begin() + index);
}