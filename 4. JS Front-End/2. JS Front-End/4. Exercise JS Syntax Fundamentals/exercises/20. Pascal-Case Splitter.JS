function SplitTextPascalCase(text) {
  let result = "";

  for (let i = 0; i < text.length; i++) {
    if (text[i].toUpperCase() === text[i] && i > 0) {
      result += ", " + text[i];
    } else {
      result += text[i];
    }
  }

  console.log(result);
}

SplitTextPascalCase("SplitMeIfYouCanHaHaYouCantOrYouCan");
