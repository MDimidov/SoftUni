function isThisPerfectNumber(num) {
  let factor = 0;
  const devisors = [];
  for (let i = num - 1; i > 0; i--) {
    if (num % i === 0) {
      devisors.push(i);
    }
  }

  if (devisors.reduce((a, b) => a + b, 0) === num) {
    console.log("We have a perfect number!");
  } else {
    console.log("It's not so perfect.");
  }
}

isThisPerfectNumber(1236498);
