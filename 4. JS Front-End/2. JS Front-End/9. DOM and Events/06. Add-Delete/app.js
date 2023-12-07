function addItem() {
  const list = document.getElementById("items");
  const value = document.getElementById("newItemText").value;

  const deleteButton = document.createElement("a");
  deleteButton.href = "#";
  deleteButton.textContent = "[Delete]";
  deleteButton.addEventListener("click", (e) => {
    e.target.parentElement.remove();
  });

  const child = document.createElement("li");
  child.textContent = value;
  child.appendChild(deleteButton);

  list.appendChild(child);
  console.log(value);
}
