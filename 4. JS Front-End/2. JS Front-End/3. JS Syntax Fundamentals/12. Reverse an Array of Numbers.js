function ReverseArray(elements, array) {
    let revercedArray = [];
    for (let i = 0; i < elements; i++) {
        revercedArray.unshift(array[i]);
    }

    console.log(revercedArray.join(' '));
}

ReverseArray(3, [10, 20, 30, 40, 50] );