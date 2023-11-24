function largestNum(x, y, z) {
    let result;
    if (x > y) {
        result = x;
    } else {
        result = y;
    }

    if (result < z) {
        result = z;
    }

    console.log(`The largest number is ${result}.`)
}

largestNum(-3, -5, -22.5)