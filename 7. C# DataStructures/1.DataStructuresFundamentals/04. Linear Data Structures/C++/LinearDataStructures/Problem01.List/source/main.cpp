// main.cpp
#include <iostream>
#include "list/List.h"

int main() {
    List<int> myList;
    myList.Add(10);
    myList.Add(20);
    myList.Insert(1, 15);

    for (size_t i = 0; i < myList.Count(); ++i) {
        std::cout << myList[i] << " ";
    }
    std::cout << "\nContains 15? " << (myList.Contains(15) ? "Yes" : "No") << std::endl;
    myList.RemoveAt(1);
    std::cout << "After removal: ";
    for (size_t i = 0; i < myList.Count(); ++i) {
        std::cout << myList[i] << " ";
    }
}
