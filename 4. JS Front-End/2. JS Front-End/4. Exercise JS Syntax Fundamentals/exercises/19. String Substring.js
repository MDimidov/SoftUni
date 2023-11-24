function TakeWord(word, sentence) {
  const arrayOfWords = sentence.split(" ");

  for (let i = 0; i < arrayOfWords.length; i++) {
    if (arrayOfWords[i].toLowerCase() === word.toLowerCase()) {
      console.log(word);
      return;
    }
  }

  console.log(`${word} not found!`);
}

TakeWord("python", "JavaScript is the best programming language");
