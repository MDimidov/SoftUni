function numberModification(num) {
  let text = num.toString();
  let sum = 0;

  for (let i = 0; i < text.length; i++) {
    sum += Number(text[i]);
  }
  let average = sum / text.length;
  while (average <= 5) {
    sum += 9;
    text += "9";
    average = sum / text.length;
  }

  console.log(text);
}

numberModification(5835);
