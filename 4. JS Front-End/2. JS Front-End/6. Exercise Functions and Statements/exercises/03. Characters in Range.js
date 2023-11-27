function printCharacters(ch1, ch2) {
  function getMin() {
    if (ch1 < ch2) {
      return ch1.charCodeAt(0);
    }
    return ch2.charCodeAt(0);
  }

  function getMax() {
    if (ch1 > ch2) {
      return ch1.charCodeAt(0);
    }
    return ch2.charCodeAt(0);
  }

  const arrayOfChars = [];
  for (let i = parseInt(getMin()) + 1; i < parseInt(getMax()); i++) {
    arrayOfChars.push(String.fromCharCode(i));
  }

  console.log(arrayOfChars.join(" "));
}

printCharacters("#", ":");
