function sumTable() {
  const elements = Array.from(
    document.querySelectorAll("tr:not(:first-child, :last-child)")
  );

  const sum = elements.reduce((acc, curr) => {
    acc += Number(curr.lastChild.textContent);
    return acc;
  }, 0);

  document.querySelector("#sum").textContent = sum;
}
