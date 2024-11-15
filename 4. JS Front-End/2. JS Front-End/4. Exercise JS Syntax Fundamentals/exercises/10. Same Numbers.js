//First Method

// function isAllDigitsTheSame(num) {
//     let sum = 0;
//     let isDigitsAreTheSame = true;
//     let lastDigit = num % 10;
//     while (num > 0) {

//         if (num % 10 != lastDigit) {
//             isDigitsAreTheSame = false;
//         }

//         sum += num % 10;
//         num = Math.floor(num / 10);
//     }

//     console.log(isDigitsAreTheSame);
//     console.log(sum);
// }

//Second Method
function isAllDigitsTheSame(num) {
  const digits = Array.from(String(num), Number);
  const isConsistant = new Set(digits).size === 1;
  const sum = digits.reduce(function (total, number) {
    return total + number;
  }, 0);

  console.log(isConsistant);
  console.log(sum);
}

isAllDigitsTheSame(22222); 


// --------------Variant 2---------------------



function isAllDigitsTheSame(num) {
  const digits = num
  .toString()
  .split('');

  const allSame = digits
  .every(digit => digit === digits[0]);

  const sum = digits
  .map(Number)
  .reduce(function (a, b) {
    return a + b;
  })
  
  console.log(allSame);
  console.log(sum);
}

isAllDigitsTheSame(222223); 