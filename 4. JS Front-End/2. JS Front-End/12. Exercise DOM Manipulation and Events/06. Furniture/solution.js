function solve() {
  const tbody = document.querySelector("tbody");
  const buttons = Array.from(document.querySelectorAll("button"));
  buttons.forEach(button => {
    button.addEventListener('click', action)
  });

  function action(e) {
    if (e.target.textContent === "Generate") {
      const furnitureList = document.querySelector('textarea[rows="5"]');
      const objectArr = JSON.parse(furnitureList.value);
      for (const object of objectArr) {
        createRow(object);
      }

    } else if (e.target.textContent === "Buy") {
      report();
    }
  }

  function createRow(object) {
    let row = document.createElement("tr");
    Object.entries(object).forEach(([key, value]) => {
      let td = document.createElement('td');
      let element = document.createElement(key);
      if (key === "img") {
        element.src = value;
      } else {
        element.textContent = value;
      }
      td.appendChild(element);
      row.appendChild(td);
    })

    let checkBox = document.createElement('input')
    checkBox.type = 'checkbox';
    let checkBoxTd = document.createElement('td'); checkBoxTd.appendChild(checkBox);

    row.appendChild(checkBoxTd);
    tbody.appendChild(row);
  }

  function report() {
    let totalFurniture = {
      totalBought: [],
      totalPrice: 0,
      totalDecFactor: 0,
      count: 0
    }

    const furnituresArr = Array.from(document.querySelectorAll('tbody tr'));
    const reportList = document.querySelector('textarea[rows="4"]');
    for (const furniture of furnituresArr) {
      let isChecked = furniture.lastElementChild.lastElementChild.checked;
      if (isChecked) {
        let name = furniture.querySelector(':nth-child(2)').textContent;
        totalFurniture.totalBought.push(name)

        let price = Number(furniture.querySelector(':nth-child(3)').textContent);
        totalFurniture.totalPrice += price;

        let decFactor = Number(furniture.querySelector(':nth-child(4)').textContent);
        totalFurniture.totalDecFactor += decFactor;

        totalFurniture.count++;
      }
    }

    reportList.value += `Bought furniture: ${totalFurniture.totalBought.join(', ')}\n`;
    reportList.value += `Total price: ${totalFurniture.totalPrice.toFixed(2)}\n`;
    reportList.value += `Average decoration factor: ${totalFurniture.totalDecFactor / totalFurniture.count}\n`;
  }

}