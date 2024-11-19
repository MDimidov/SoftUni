function calculateNums(a, b, c) {
  let sum = a + b;
  let subtract = sum - c;

  console.log(subtract);
}

calculateNums(23, 6, 10);

// -----------------Method 2--------------------

function calculateNums(a, b, c) {
  const result = (a + b) - c;
  console.log(result);
}

calculateNums(23, 6, 10);
