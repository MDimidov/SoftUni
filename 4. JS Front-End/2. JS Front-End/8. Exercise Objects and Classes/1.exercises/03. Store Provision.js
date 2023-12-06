function storeProvision(currentStock, deliveryStock) {
  const products = [...currentStock, ...deliveryStock];

  //   console.log(products);
  const stock = products.reduce((acc, curr, index) => {
    if (index % 2 === 0) {
      //product name
      if (!acc.hasOwnProperty(curr)) {
        acc[curr] = 0;
      }

      acc[curr] += Number(products[index + 1]);
    }
    return acc;
  }, {});

  Object.entries(stock).forEach(([product, quantity]) => {
    console.log(`${product} -> ${quantity}`);
  });
}

storeProvision(
  ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
  ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
);
