function printOddAndEven(num) {
  let text = num.toString();

  let oddSum = 0;
  let evenSum = 0;

  for (let i = 0; i < text.length; i++) {
    let number = Number(text[i]);
    if (number % 2 === 0) {
      evenSum += number;
    } else {
      oddSum += number;
    }
  }

  console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

printOddAndEven(3495892137259234);
