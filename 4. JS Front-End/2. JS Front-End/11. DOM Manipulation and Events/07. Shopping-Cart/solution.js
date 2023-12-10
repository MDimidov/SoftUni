function solve() {
   const textArea = document.querySelector("textarea");
   const checkoutButton = document.querySelector(".checkout");
   const addButtons = Array.from(document.querySelectorAll(".add-product"));

   let listOfNames = [];
   let totalPrice = 0;

   addButtons.forEach(button => {
      button.addEventListener("click", addProduct);
   })

   checkoutButton.addEventListener("click", calculateResult);

   function addProduct(e) {
      let name = e.srcElement.parentElement.parentElement
         .querySelector(".product-title").textContent;

      let money = Number(e.srcElement.parentElement.parentElement
         .querySelector(".product-line-price").textContent);

      listOfNames.push(name);
      totalPrice += money;

      textArea.value += `Added ${name} for ${money.toFixed(2)} to the cart.\n`;
   }

   function calculateResult(e) {
      let uniqueList = listOfNames.filter((item, index) => listOfNames.indexOf(item) === index);
      let list = uniqueList.join(', ');

      textArea.value += `You bought ${list} for ${totalPrice.toFixed(2)}.\n`;

      addButtons.forEach(button => {
         button.removeEventListener("click", addProduct);
      })

   }
}