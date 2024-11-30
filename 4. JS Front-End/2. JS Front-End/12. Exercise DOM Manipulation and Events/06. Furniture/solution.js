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

// -----------------Method 2--------------------

function solve() {
  const buttons = document.querySelectorAll('#exercise>button');

  for (const btn of buttons) {
    if(btn.textContent === 'Generate'){
      btn.addEventListener('click', generateFurnitures)
    } else {
      btn.addEventListener('click', takeCheckedFurnitures)
    }
  }

  function generateFurnitures(e) {
    const inputArr = JSON.parse(e.target.parentElement.querySelector('textarea[rows="5"]').value);
    const tbody = e.target.parentElement.querySelector('.table>tbody');
    const sort = {
      img: 1,
      name: 2,
      price: 3,
      decFactor: 4,
    };

    for (const obj of inputArr) {
      const row = document.createElement('tr');
      const safeSort = [];

      Object.entries(obj).forEach(([key, value]) => {
        if(key === 'img'){
          const img = document.createElement('img');
          img.src = value;
          safeSort.push({number: sort[key], element: img});
        } else {
          const p = document.createElement('p');
          p.textContent = value;
          safeSort.push({number: sort[key], element: p});
        }
      });
      
      for (let i = 1; i <= 5; i++) {
        const element = safeSort.find(s => s.number === i);
        const td = document.createElement('td');

        if (i === 5) {
          const checkBox = document.createElement('input');
          checkBox.type = 'checkbox';
          td.appendChild(checkBox);
        } else {
          td.appendChild(element.element);        
        }
        row.appendChild(td);   
      }      
      tbody.appendChild(row);   
    }
  }

  function takeCheckedFurnitures(e) {
    const furnituresArr = e.target.parentElement.querySelectorAll('.table>tbody>tr');
    const boughtFurn = {
      names: [],
      prices: [],
      decFactors: [],
    };

    for (const furniture of furnituresArr) {
      const isFurniterChecked = furniture.querySelector('td>input').checked;
      if(!isFurniterChecked){
        continue
      }      

      const pArr = furniture.querySelectorAll('td>p');
      boughtFurn.names.push(pArr[0].textContent);
      boughtFurn.prices.push(Number(pArr[1].textContent));
      boughtFurn.decFactors.push(Number(pArr[2].textContent));
    }

    const totalPrice = boughtFurn.prices.reduce((acc, curr) => {
      acc += curr;
      return acc;
    }, 0);

    const avgDecFac = boughtFurn.decFactors.reduce((acc, curr) => {
      acc += curr;
      return acc;
    }, 0) / boughtFurn.decFactors.length;

    const textarea = e.target.parentElement.querySelector('textarea[rows="4"]');
    textarea.textContent = `Bought furniture: ${boughtFurn.names.join(', ')}
Total price: ${totalPrice}
Average decoration factor: ${avgDecFac}`;
  }
}