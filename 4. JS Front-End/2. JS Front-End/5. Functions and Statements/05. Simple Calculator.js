function calculate(x, y, operator) {
  let answer = {
    multiply: x * y,
    divide: x / y,
    add: x + y,
    subtract: x - y,
  };

  console.log(answer[operator]);
}

calculate(40, 8, "divide");
