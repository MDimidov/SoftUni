function printPhones(arrayOfPhones) {
  const phoneObject = arrayOfPhones.reduce((acc, curr) => {
    const [name, phone] = curr.split(" ");
    acc[name] = phone;
    return acc;
  }, {});

  Object.entries(phoneObject).forEach(([key, value]) => {
    console.log(`${key} -> ${value}`);
  });
}

printPhones([
  "Tim 0834212554",
  "Peter 0877547887",
  "Bill 0896543112",
  "Tim 0876566344",
]);
