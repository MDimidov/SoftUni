function ArrayRotation(array, rotations) {
    
    for (let i = 1; i <= rotations; i++) {

        const element = array[0];
        for (let j = 0; j < array.length - 1; j++) {
            array[j] = array[j + 1];
        }

        array[array.length - 1] = element;
    }

    console.log(array.join(' '));
}

ArrayRotation([2, 4, 15, 31], 5)