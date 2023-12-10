function search() {
  const towns = Array.from(document.getElementById("towns").children);
  const searchText = document.getElementById("searchText").value;
  let matches = 0;

  for (const town of towns) {
    if (town.textContent.includes(searchText.toString())) {
      matches++;
      town.style.fontWeight = "bold";
      town.style.textDecorationLine = "underline";
    }
  }

  const result = document.getElementById("result");
  result.textContent = `${matches} matches found`;
}
