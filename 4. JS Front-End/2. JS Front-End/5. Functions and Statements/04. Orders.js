function totalPrice(product, quantity) {
  priceForProduct = {
    coffee: 1.5,
    water: 1,
    coke: 1.4,
    snacks: 2,
  };

  console.log((priceForProduct[product] * quantity).toFixed(2));
}

totalPrice("coffee", 2);
