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
