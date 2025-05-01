#include <iostream>
#include "list/List.h"

int main() {
    List<int> list;

    list.Add(10);
    list.Add(20);
    list.Add(30);
    list.Insert(1, 15); // между 10 и 20

    for (auto x : list) {
        std::cout << x << " ";
    }

    std::cout << "\nContains 20? " << (list.Contains(20) ? "Yes" : "No") << std::endl;

    list.RemoveAt(2); // премахва 20
    list.Remove(10);  // премахва 10

    std::cout << "After removal: ";
    for (auto x : list) {
        std::cout << x << " ";
    }

    return 0;
}
