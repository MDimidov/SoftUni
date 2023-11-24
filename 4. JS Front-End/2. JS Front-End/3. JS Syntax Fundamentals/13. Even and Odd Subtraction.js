function Substraction(array) {
    let evenSum = 0;
    let oddSum = 0;
    array.forEach(num => {
        if (num % 2 === 0) {
            evenSum += num;
        } else {
            oddSum += num;
        }
    });

    console.log(evenSum - oddSum);
}


Substraction([1,2,3,4,5,6]);
