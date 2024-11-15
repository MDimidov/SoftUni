function SumOfDigits(num) {
    
    let sum = 0;
    while (num > 0) {
        sum += num % 10;
        num = Math.floor(num / 10);
    }

    console.log(sum)    
}

SumOfDigits(543)


// --------------Variant 2---------------------


function SumOfDigits(num) {
  const sum = num
            .toString()
            .split('')
            .map(Number)
            .reduce(function (a, b) {
                return a + b;
            }, 0);

    console.log(sum);
}

SumOfDigits(256)