function palindromeNumbers(array) {
  const strings = array.map(String);

  for (let i = 0; i < strings.length; i++) {
    let normalText = "";
    let oppositeText = "";

    for (let j = 0; j < strings[i].length; j++) {
      normalText += strings[i][j];
      oppositeText += strings[i][strings[i].length - j - 1];
    }
    if (normalText === oppositeText) {
      console.log(true);
    } else {
      console.log(false);
    }
  }
}

palindromeNumbers([32, 2, 232, 1010]);

// -----------------Method 2--------------------

function palindromeNumbers(array) {
 const stringArr = array.map(String);

 function reverseString(str) {
  return str.split('').reverse().join('');
}

 stringArr.forEach(element => {
    if(element === reverseString(element)){
      console.log(true);
    } else{
      console.log(false);
    }
 });
}

palindromeNumbers([323, 2, 232, 1010]);