function addItem() {
  const list = document.getElementById("items");
  const value = document.getElementById("newItemText").value;

  const newItem = document.createElement("li");
  newItem.textContent = value;
  list.appendChild(newItem);
}
