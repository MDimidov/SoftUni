function countOdd(text) {
  const array = text.split(" ");
  const result = new Set();

  array.forEach((word) => {
    let sum = 0;
    array.forEach((word2) => {
      if (word.toLowerCase() === word2.toLowerCase()) {
        sum++;
        delete array.word2;
      }
    });

    if (sum % 2 !== 0) {
      result.add(word.toLowerCase());
    }
  });
  const final = Array.from(result);
  console.log(final.join(" "));
}

countOdd("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
