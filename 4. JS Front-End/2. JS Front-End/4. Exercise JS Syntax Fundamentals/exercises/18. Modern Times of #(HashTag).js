function TakeSpecialWords(text) {
  const arrayOfAllWords = text.split(" ");
  //   let arrayOfSpecials = [];
  arrayOfAllWords.forEach((element) => {
    if (element[0] === "#" && element.length > 1) {
      let isTrue = true;
      for (let i = 1; i < element.length; i++) {
        if (element[i].toLowerCase() === element[i].toUpperCase()) {
          isTrue = false;
        }
      }

      if (isTrue) {
        let word = element.replace(element[0], "");
        console.log(word);
      }
    }
  });
}

TakeSpecialWords(
  "The symbol # is known #variously in English-speaking #regions as the #number sign"
);
