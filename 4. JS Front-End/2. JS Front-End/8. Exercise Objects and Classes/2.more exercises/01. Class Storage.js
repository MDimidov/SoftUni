class Storage {
  constructor(capacity) {
    this.capacity = capacity;
    this.storage = [];
    this.totalCost = 0;
  }

  addProduct(product) {
    if (this.capacity >= product.quantity) {
      this.storage.push(product);
      this.totalCost += product.price * product.quantity;
      this.capacity -= product.quantity;
    }
  }

  getProducts() {
    let result = "";
    for (let i = 0; i < this.storage.length; i++) {
      result += JSON.stringify(this.storage[i]);
      if (this.storage.length - 1 !== i) {
        result += "\n";
      }
    }

    return result;
  }
}

let productOne = { name: "Cucamber", price: 1.5, quantity: 15 };
let productTwo = { name: "Tomato", price: 0.9, quantity: 25 };
let productThree = { name: "Bread", price: 1.1, quantity: 8 };
let storage = new Storage(50);
storage.addProduct(productOne);
storage.addProduct(productTwo);
storage.addProduct(productThree);
console.log(storage.getProducts());
console.log(storage.capacity);
console.log(storage.totalCost);
