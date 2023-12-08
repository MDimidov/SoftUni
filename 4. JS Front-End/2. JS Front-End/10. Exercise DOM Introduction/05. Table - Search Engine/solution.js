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
