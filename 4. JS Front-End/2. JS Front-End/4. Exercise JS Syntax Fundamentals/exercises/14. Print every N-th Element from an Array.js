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



// --------------Variant 2---------------------


function NElement(array, step) {
    const resultArr = [];

    for (let i = 0; i < array.length; i += step) {
        resultArr.push(array[i]);
    }

    console.log(resultArr);
}

NElement(['dsa', 'asd', 'test', 'tset'], 2);


