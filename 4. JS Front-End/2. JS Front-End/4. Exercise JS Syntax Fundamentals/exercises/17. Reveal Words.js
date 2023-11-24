function Segregate(realWords, sentence) {
  const arrayOfWords = realWords.split(", ");

  let text = sentence;
  for (let i = 0; i < arrayOfWords.length; i++) {
    text = text.replace("*".repeat(arrayOfWords[i].length), arrayOfWords[i]);
  }
  console.log(text);
}

Segregate(
  "great, learning",
  "softuni is ***** place for ******** new programming languages"
);
