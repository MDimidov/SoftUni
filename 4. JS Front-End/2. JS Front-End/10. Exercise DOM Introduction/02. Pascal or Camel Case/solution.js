function solve() {
  const text = document.getElementById("text").value.toLowerCase().split(" ");
  const convention = document.getElementById("naming-convention").value;
  const resultSpan = document.getElementById("result");

  let result = text.reduce((acc, curr) => {
    acc += curr.replace(/^./, curr[0].toUpperCase());
    return acc;
  }, "");

  if (convention === "Pascal Case") {
    resultSpan.textContent = result;
  } else if (convention === "Camel Case") {
    resultSpan.textContent = result.replace(/^./, result[0].toLowerCase());
  } else {
    resultSpan.textContent = "Error!";
  }
}
