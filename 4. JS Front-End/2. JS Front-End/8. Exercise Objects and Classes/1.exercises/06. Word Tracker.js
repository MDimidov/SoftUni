function findWord(array) {
  const findWords = array.shift().split(" ");

  const result = [];

  findWords.forEach((word) => {
    let sum = 0;

    array.forEach((element) => {
      if (word === element) {
        sum++;
      }
    });

    result.push({
      word,
      sum,
    });
  });

  result.sort((a, b) => b.sum - a.sum);

  result.forEach((object) => {
    console.log(`${object.word} - ${object.sum}`);
  });
}

findWord([
  "is the",
  "first",
  "sentence",
  "Here",
  "is",
  "another",
  "the",
  "And",
  "finally",
  "the",
  "the",
  "sentence",
]);
