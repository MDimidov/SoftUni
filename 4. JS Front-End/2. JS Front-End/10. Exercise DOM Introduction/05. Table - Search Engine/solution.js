function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    const searchField = document.querySelector("#searchField").value;
    const cells = Array.from(document.querySelectorAll("tbody td"));
    const activeRows = Array.from(document.querySelectorAll("tbody tr.select"));

    activeRows.forEach((row) => {
      row.classList.remove("select");
    });

    for (const cell of cells) {
      if (cell.textContent.includes(searchField)) {
        cell.parentElement.classList.add("select");
      }
    }
    console.log(activeRows);
  }
}

// -----------------Method 2--------------------

function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  
  function onClick() {  
    const searchField = document.getElementById('searchField').value.toLowerCase();
    const rowsArr = document.querySelectorAll('tbody>tr');

    for (const row of rowsArr) {
      row.classList.remove('select');
      const cells = row.children;
      for (const cell of cells) {
        if (cell.textContent.toLowerCase().includes(searchField) && searchField.length > 0) {
          row.classList.add('select');
        }
      }
    }
    document.getElementById('searchField').value = '';
  }
}