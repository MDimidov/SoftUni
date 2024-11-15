function Multiplicate(num) {
    for (let i = 1; i <= 10; i++) {
        console.log(`${num} X ${i} = ${num * i}`)
    }
}

Multiplicate(5)


// --------------Variant 2---------------------

function Multiplicate(num) {
    for (let i = 1; i <= 10; i++) {
        const product = num * i;
        console.log(`${num} X ${i} = ${product}`)
    }
}

Multiplicate(8)