function deleteByEmail() {
  const email = document.querySelector("input").value;
  const emailsList = Array.from(
    document.querySelectorAll("td:nth-child(even)")
  );

  const userBox = emailsList.find((box) => box.textContent === email);
  userBox.parentElement.remove();
}
