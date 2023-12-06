function getCatalogue(inputArr) {
  const catalogue = inputArr.reduce((acc, curr) => {
    const [product, price] = curr.split(" : ");
    acc[product] = price;
    return acc;
  }, {});

  let set = new Set();
  Object.keys(catalogue)
    .sort(function (a, b) {
      return a.toLowerCase().localeCompare(b.toLowerCase());
    })
    .forEach((product) => {
      set.add(product.substring(0, 1));
      set.add(`  ${product}: ${catalogue[product]}`);
    });

  set.forEach((row) => {
    console.log(row);
  });
}

getCatalogue([
  "Appricot : 20.4",
  "Fridge : 1500",
  "TV : 1499",
  "Deodorant : 10",
  "Boiler : 300",
  "Apple : 1.25",
  "Anti-Bug Spray : 15",
  "T-Shirt : 10",
]);
