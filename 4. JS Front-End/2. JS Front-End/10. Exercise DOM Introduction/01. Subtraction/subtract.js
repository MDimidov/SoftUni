function subtract() {
  const firstNumber = Number(document.getElementById("firstNumber").value);
  const secondNumber = Number(document.getElementById("secondNumber").value);

  const result = document.getElementById("result");
  result.textContent = firstNumber - secondNumber;
}

// -----------------Method 2--------------------

function subtract() {
  const firstNum = Number(document.getElementById('firstNumber').value);
  const secondNum = Number(document.getElementById('secondNumber').value);

  const result = document.getElementById("result");
  result.textContent = firstNum - secondNum;
}