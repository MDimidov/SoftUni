function factorialDevision(a, b) {
  let factorial1 = 1;
  let factorial2 = 1;

  for (let i = 2; i <= a; i++) {
    factorial1 *= i;
  }

  for (let i = 2; i <= b; i++) {
    factorial2 *= i;
  }

  console.log((factorial1 / factorial2).toFixed(2));
}

factorialDevision(6, 2);

// -----------------Method 2--------------------

function factorialDevision(a, b) {  
  function getFactorial(num) {
    let factorial = 1;

    for (let i = 2; i <= num; i++) {
      factorial *= i;
    }

    return factorial
  }
  
  console.log((getFactorial(a) / getFactorial(b)).toFixed(2));
}

factorialDevision(5, 2);