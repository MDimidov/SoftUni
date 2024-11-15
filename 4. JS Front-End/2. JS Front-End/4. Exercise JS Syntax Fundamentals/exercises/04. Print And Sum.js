function SumArray(startNum, endNum){
    let array = [];
    let sum = 0;

    for (let i = startNum; i <= endNum; i++) {
        array.push(i);
        sum += i;
    }
    console.log(array.join(' '));
    console.log(`Sum: ${sum}`);
}

SumArray(0, 26)

// --------------Variant 2---------------------

function SumArray(startNum, endNum){
    let allNumsBetween = [];
    let sum = 0;

    for (let i = startNum; i <= endNum; i++) {
        sum += i;
        allNumsBetween.push(i);
    }

    console.log(allNumsBetween.join(' '));
    console.log(`Sum: ${sum}`)
}

SumArray(0, 26)