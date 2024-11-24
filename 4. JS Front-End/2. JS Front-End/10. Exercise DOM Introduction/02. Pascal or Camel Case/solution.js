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

// -----------------Method 2--------------------

function solve() {
  const textArr = document.getElementById('text').value.toLowerCase().split(' ');
  const commandCase = document.getElementById('naming-convention').value;

  let result = textArr.reduce((acc, curr) =>{
    acc += curr.replace(/^./, curr[0].toUpperCase());
    return acc;
  }, '');

  switch (commandCase) {
    case 'Camel Case':
      result = result.replace(result[0], result[0].toLowerCase())
      break;
    case 'Pascal Case':
      break;
    default:
      result = 'Error!';
      break;
  }

  const resultSpan = document.getElementById('result');
  resultSpan.textContent = result;
  console.log(result);
}