function carWash(array) {
  clean = 0;
  commands = {
    soap: 10,
    water: 0.2,
    "vacuum cleaner": 0.25,
    mud: -0.1,
  };

  array.forEach((element) => {
    if (element === "soap") {
      clean += 10;
    } else {
      clean += clean * commands[element];
    }
  });

  console.log(`The car is ${clean.toFixed(2)}% clean.`);
}

carWash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);

// -----------------Method 2--------------------

function carWash(array) {
  clean = 0;

  const commands = {
    soap: 10,
    water: 0.2,
    "vacuum cleaner": 0.25,
    mud: -0.1,
  }
  
  array.forEach(element => {
    if(element === "soap"){
      clean += commands[element];
    } else{
      clean += clean * commands[element];
    }
  });
  
  console.log(`The car is ${clean.toFixed(2)}% clean.`)
}

carWash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);