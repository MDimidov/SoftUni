function repeatString(text, times) {
  let result = "";
  for (let i = 0; i < times; i++) {
    result += text;
  }
  console.log(result);
}

repeatString("abc", 3);
