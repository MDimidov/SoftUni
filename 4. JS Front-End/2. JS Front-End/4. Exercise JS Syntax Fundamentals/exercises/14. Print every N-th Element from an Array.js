function NElement(array, step) {
    let newArray = [];
    for (let i = 0; i < array.length; i) {
        newArray.push(array[i]);
        i += step;
    }

    newArray.forEach(element => {
        console.log(element);
    });
}

NElement(['5', '20', '31', '4', '20'], 2)