function solve() {
  const input = document.querySelector("#input").value.split(".");
  // clear empty last element
  input.pop();
  const container = document.querySelector("#output");

  while (input.length > 0) {
    const p = document.createElement("p");
    p.textContent =
      input
        .splice(0, 3)
        .map((text) => text.trim())
        .join(".") + ".";

    container.appendChild(p);
  }
}

// -----------------Method 2--------------------

function solve() {
  const inputArr = document.getElementById('input').value.split('.');
  inputArr.pop();
  const output = document.getElementById('output');
  const outputArr = [];
  
  while (inputArr.length > 0) {
    p = inputArr
        .splice(0, 3)
        .map((text) => text.trim())
        .join(".") + ".";

    outputArr.push(`<p>${p}</p>`);
  }
  output.innerHTML = outputArr.join('');
}
