// function garageInfo(inputArr) {
//   const array = inputArr.map((str) => JSON.parse(str));

// }

// class Storage{
//     constructor(capacity){
//         this.name = capacity.name,
//         this.price = capacity.price ,
//         this.quantity = capacity.quantity
//     }

// }

let person = {
  firstName: "Jhon",
  lastName: "Doe",
  age: function (myAge) {
    return `My age is ${myAge}`;
  },
};

//console.log(person.age(20));

const compareNumbers = {
  ascending: (a, b) => a - b,
  descending: (a, b) => b - a,
};

//console.log(compareNumbers.descending(5, 1));

let count = 5;
const parser = {
  increment() {
    count++;
  },
  decrement() {
    count--;
  },
  reset() {
    count = 0;
  },
};
parser.increment();
parser.reset();
parser.decrement();

//console.log(count);

const person1 = {
  firstName: "Peter",
  lastName: "Johnson",
  fullName() {
    return `${this.firstName} ${this.lastName}`;
  },
};

//console.log(person1.fullName());

const getFullName = person1.fullName;
//console.log(getFullName());
const anotherPerson = {
  firstName: "Bob",
  lastName: "Smith",
};

anotherPerson.fullName = getFullName;
//console.log(anotherPerson.fullName());

function cityInfo(city) {
  Object.entries(city).forEach(([key, value]) => {
    console.log(`${key} -> ${value}`);
  });
}

function cityTaxes(name, population, treasury) {
  return {
    name,
    population,
    treasury,
    taxRate: 10,
    collectTaxes() {
      this.treasury += population * this.taxRate;
      this.treasury = Math.floor(this.treasury);
    },
    applyGrowth(percentage) {
      this.population += population * (percentage / 100);
      this.population = Math.floor(this.population);
    },
    applyRecession(percentage) {
      this.treasury -= treasury * (percentage / 100);
      this.treasury = Math.floor(this.treasury);
    },
  };
}

// const city = cityTaxes("Tortuga", 7000, 15000);
// console.log(city);

// const city = cityTaxes("Tortuga", 7000, 15000);
// city.collectTaxes();
// console.log(city.treasury);
// city.applyGrowth(5);
// console.log(city.population);

//4. Convert to object
function getObject(params) {
  let person = JSON.parse(params);

  Object.entries(person).forEach(([key, value]) => {
    console.log(`${key}: ${value}`);
  });
}

// getObject('{"name": "George", "age": 40, "town": "Sofia"}');
// getObject('{"name": "Peter", "age": 35, "town": "Plovdiv"}');

//5. Convert to JSON
function convertToJson(name, lastName, hairColor) {
  const person = {
    name,
    lastName,
    hairColor,
  };

  console.log(JSON.stringify(person));
}

// convertToJson("George", "Jones", "Brown");

//6. Phone Book
function phoneBook(inputArr) {
  const books = inputArr.reduce((acc, curr) => {
    const [name, phone] = curr.split(" ");
    acc[name] = phone;

    return acc;
  }, {});

  Object.entries(books).forEach(([name, phone]) => {
    console.log(`${name} -> ${phone}`);
  });
}

// phoneBook(["George 0552554", "Peter 087587", "George 0453112", "Bill 0845344"]);

//7. Meetings
function getMeetings(inputArr) {
  const meetings = inputArr.reduce((acc, curr) => {
    const [day, name] = curr.split(" ");
    if (!acc.hasOwnProperty(day)) {
      acc[day] = name;
      console.log(`Scheduled for ${day}`);
    } else {
      console.log(`Conflict on ${day}!`);
    }
    return acc;
  }, {});

  Object.entries(meetings).forEach(([day, name]) => {
    console.log(`${day} -> ${name}`);
  });
}

// getMeetings([
//   "Friday Bob",
//   "Saturday Ted",
//   "Monday Bill",
//   "Monday John",
//   "Wednesday George",
// ]);

//8. Address Book
function getSortedAddresses(inputArr) {
  const addresses = inputArr.reduce((acc, curr) => {
    const [name, address] = curr.split(":");
    acc[name] = address;

    return acc;
  }, {});

  Object.entries(addresses)
    .sort()
    .forEach(([name, adress]) => {
      console.log(`${name} -> ${adress}`);
    });
}

// getSortedAddresses([
//   "Bob:Huxley Rd",
//   "John:Milwaukee Crossing",
//   "Peter:Fordem Ave",
//   "Bob:Redwing Ave",
//   "George:Mesta Crossing",
//   "Ted:Gateway Way",
//   "Bill:Gateway Way",
//   "John:Grover Rd",
//   "Peter:Huxley Rd",
//   "Jeff:Gateway Way",
//   "Jeff:Huxley Rd",
// ]);

//9. Cats

function takeArgguments(inputArr) {
  class Cat {
    constructor(name, age) {
      this.name = name;
      this.age = age;
    }

    meow() {
      console.log(`${this.name}, age ${this.age} says Meow`);
    }
  }

  const cats = inputArr.reduce((acc, curr) => {
    const [name, age] = curr.split(" ");
    acc.push(new Cat(name, age));
    return acc;
  }, []);

  cats.forEach((cat) => {
    cat.meow();
  });
}

//takeArgguments(["Mellow 2", "Tom 5"]);

//10. Songs

function getSongsByType(inputArr) {
  class Song {
    constructor(typeList, name, time) {
      (this.typeList = typeList), (this.name = name), (this.time = time);
    }

    getSong(typeList) {
      if (this.typeList === typeList || typeList === "all") {
        console.log(this.name);
      }
    }
  }
  const numOfSongs = inputArr.shift();
  const typeOfSong = inputArr.pop();

  const songs = inputArr.reduce((acc, curr) => {
    const [typeList, name, time] = curr.split("_");
    acc.push(new Song(typeList, name, time));

    return acc;
  }, []);

  songs.forEach((song) => {
    song.getSong(typeOfSong);
  });
}

// getSongsByType([2, "like_Replay_3:15", "ban_Photoshop_3:48", "all"]);

//1.	Employees
function getEmployeesWithNumber(inputArr) {
  inputArr.reduce((acc, curr) => {
    acc[curr] = curr.length;

    console.log(`Name: ${curr} -- Personal Number: ${acc[curr]}`);
    return acc;
  }, {});
}

// getEmployeesWithNumber([
//   "Samuel Jackson",
//   "Will Smith",
//   "Bruce Willis",
//   "Tom Holland",
// ]);

//2.	Towns
function getCityLocation(inputArr) {
  const cities = inputArr.reduce((acc, curr) => {
    const [town, latitude, longitude] = curr.split(" | ");

    acc.push({
      town,
      latitude: Number(latitude).toFixed(2),
      longitude: Number(longitude).toFixed(2),
    });

    return acc;
  }, []);

  cities.forEach((town) => {
    console.log(town);
  });
}

// getCityLocation([
//   "Sofia | 42.696552 | 23.32601",
//   "Beijing | 39.913818 | 116.363625",
// ]);

//3.	Store Provision
function getStores(arr1, arr2) {
  const allStocks = [...arr1, ...arr2];

  const store = allStocks.reduce((acc, curr, i) => {
    if (i % 2 === 0) {
      if (acc[curr] !== undefined) {
        acc[curr] += Number(allStocks[i + 1]);
      } else {
        acc[curr] = Number(allStocks[i + 1]);
      }
    }

    return acc;
  }, {});
  Object.entries(store).forEach(([product, quantity]) => {
    console.log(`${product} -> ${quantity}`);
  });
}

// getStores(
//   ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
//   ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
// );

//4.	Movies
//      Method 1
function getMoviesInfo(inputArr) {
  let movies = [];
  const movieLibrary = {
    addMovie: (command) => {
      const [_, name] = command.split("addMovie ");
      movies.push({ name });
    },
    addDirector: (command) => {
      const [movieName, director] = command.split(" directedBy ");
      const movie = movies.find((m) => m.name === movieName);

      if (movie) {
        movie.director = director;
      }
    },
    addDate: (command) => {
      const [movieName, date] = command.split(" onDate ");
      const movie = movies.find((m) => m.name === movieName);

      if (movie) {
        movie.date = date;
      }
    },
    getMovies() {
      return movies;
    },
  };

  inputArr.forEach((command) => {
    if (command.includes("addMovie")) {
      movieLibrary.addMovie(command);
    } else if (command.includes("directedBy")) {
      movieLibrary.addDirector(command);
    } else if (command.includes("onDate")) {
      movieLibrary.addDate(command);
    }
  });
  movies
    .filter((m) => m.name && m.director && m.date)
    .forEach((movie) => console.log(JSON.stringify(movie)));
}

//        METHOD 2
// function getMoviesInfo(inputArr) {
//   let movies = [];

//   inputArr.forEach((command) => {
//     if (command.includes("addMovie")) {
//       const [_, moiveName] = command.split("addMovie ");
//       movies.push({
//         name: moiveName,
//       });
//     } else if (command.includes("directedBy")) {
//       const [moiveName, director] = command.split(" directedBy ");
//       const movie = movies.find((m) => m.name === moiveName);

//       if (movie) {
//         movie.director = director;
//       }
//     } else if (command.includes("onDate")) {
//       const [movieName, date] = command.split(" onDate ");
//       const movie = movies.find((m) => m.name === movieName);

//       if (movie) {
//         movie.date = date;
//       }
//     }
//   });

//   movies
//     .filter((m) => m.name && m.director && m.date)
//     .forEach((movie) => console.log(JSON.stringify(movie)));
// }

// getMoviesInfo([
//   "addMovie Fast and Furious",
//   "addMovie Godfather",
//   "Inception directedBy Christopher Nolan",
//   "Godfather directedBy Francis Ford Coppola",
//   "Godfather onDate 29.07.2018",
//   "Fast and Furious onDate 30.07.2018",
//   "Batman onDate 01.08.2018",
//   "Fast and Furious directedBy Rob Cohen",
// ]);

//5.	Inventory
function getHeroes(inputArr) {
  const heroes = inputArr.reduce((acc, curr) => {
    const [heroName, heroLevel, items] = curr.split(" / ");
    acc.push({ heroName, heroLevel, items });

    return acc;
  }, []);

  heroes
    .sort((a, b) => a.heroLevel - b.heroLevel)
    .forEach((hero) => {
      console.log(`Hero: ${hero.heroName}`);
      console.log(`level => ${hero.heroLevel}`);
      console.log(`items => ${hero.items}`);
    });
}

// getHeroes([
//   "Isacc / 25 / Apple, GravityGun",
//   "Derek / 12 / BarrelVest, DestructionSword",
//   "Hes / 1 / Desolator, Sentinel, Antara",
// ]);

//6.	Words Tracker
function trackWords(inputArr) {
  let wordsToTrack = inputArr.shift();

  wordsToTrack = wordsToTrack.split(" ");

  const result = wordsToTrack.reduce((acc, curr) => {
    acc[curr] = 0;
    inputArr.forEach((word) => {
      if (word === curr) {
        acc[curr]++;
      }
    });
    return acc;
  }, {});

  Object.entries(result)
    .sort(([, a], [, b]) => b - a)
    .forEach(([word, count]) => {
      console.log(`${word} - ${count}`);
    });
}

// trackWords([
//   "is the",
//   "first",
//   "sentence",
//   "Here",
//   "is",
//   "another",
//   "the",
//   "And",
//   "finally",
//   "the",
//   "the",
//   "sentence",
// ]);

//7.	Odd Occurrences
function extractOddOccurences(input) {
  const occurr = input.split(" ").reduce((acc, curr) => {
    let key = curr.toLowerCase();

    if (!acc[key]) {
      acc[key] = 0;
    }

    acc[key]++;
    return acc;
  }, {});

  const result = Object.entries(occurr)
    .filter(([, b]) => b % 2 === 1)
    .map(([key]) => key);
  console.log(result);
}

// extractOddOccurences("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
// extractOddOccurences("Cake IS SWEET is Soft CAKE sweet Food");

//8.	Piccolo
function getPrakedCars(inputArr) {
  const parkiing = new Set();

  inputArr.forEach((command) => {
    const [operation, regNum] = command.split(", ");

    if (operation === "IN") {
      parkiing.add(regNum);
    } else if (operation === "OUT") {
      parkiing.delete(regNum);
    }
  });

  if (parkiing.size > 0) {
    Array.from(parkiing)
      .sort()
      .forEach((regNum) => {
        console.log(regNum);
      });
  } else {
    console.log("Parking Lot is Empty");
  }
}

// getPrakedCars([
//   "IN, CA2844AA",
//   "IN, CA1234TA",
//   "OUT, CA2844AA",
//   "IN, CA9999TT",
//   "IN, CA2866HI",
//   "OUT, CA1234TA",
//   "IN, CA2844AA",
//   "OUT, CA2866HI",
//   "IN, CA9876HH",
//   "IN, CA2822UU",
// ]);

// getPrakedCars([
//   "IN, CA2844AA",
//   "IN, CA1234TA",
//   "OUT, CA2844AA",
//   "OUT, CA1234TA",
// ]);

//9.	Make a Dictionary

function createDictionary(inputArr) {
  let dic = inputArr
    .map((line) => JSON.parse(line))
    .reduce((acc, curr) => {
      const key = Object.keys(curr);
      acc[key] = curr[key];

      return acc;
    }, {});

  Object.entries(dic)
    .sort()
    .forEach(([term, definition]) => {
      console.log(`Term: ${term} => Definition: ${definition}`);
    });
}

// createDictionary([
//   '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
//   '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
//   '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
//   '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
//   '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}',
// ]);

class Vehicle {
  constructor(type, model, parts, fuel) {
    this.type = type;
    this.model = model;
    this.parts = parts;
    this.parts.quality = this.parts.engine * this.parts.power;
    this.fuel = fuel;
  }

  drive(fuelLoss) {
    this.fuel -= fuelLoss;
  }
}

// let parts = { engine: 6, power: 100 };
// let vehicle = new Vehicle("a", "b", parts, 200);
// vehicle.drive(100);
// console.log(vehicle.fuel);
// console.log(vehicle.parts.quality);

/////////////////////////////////////////////
//More Exercise: Objects and Classes
/////////////////////////////////////////////
//1.	Class Storage

class Storage {
  constructor(capacity) {
    this.capacity = capacity;
    this.storage = [];
    this.totalCost = 0;
  }

  addProduct(product) {
    if (this.capacity >= product.quantity) {
      this.storage.push(product);
      this.totalCost += product.price * product.quantity;
      this.capacity -= product.quantity;
    }
  }

  getProducts() {
    let result = "";
    for (let i = 0; i < this.storage.length; i++) {
      result += JSON.stringify(this.storage[i]);
      if (this.storage.length - 1 !== i) {
        result += "\n";
      }
    }

    return result;
  }
}

// let productOne = { name: "Cucamber", price: 1.5, quantity: 15 };
// let productTwo = { name: "Tomato", price: 0.9, quantity: 25 };
// let productThree = { name: "Bread", price: 1.1, quantity: 8 };
// let storage = new Storage(50);
// storage.addProduct(productOne);
// storage.addProduct(productTwo);
// storage.addProduct(productThree);
// console.log(storage.getProducts());
// console.log(storage.capacity);
// console.log(storage.totalCost);

// let productOne = { name: "Tomato", price: 0.9, quantity: 19 };
// let productTwo = { name: "Potato", price: 1.1, quantity: 10 };
// let storage = new Storage(30);
// storage.addProduct(productOne);
// storage.addProduct(productTwo);
// console.log(storage.totalCost);

//02. Catalogue

function getCatalogue(inputArr) {
  const catalogue = inputArr.reduce((acc, curr) => {
    const [product, price] = curr.split(" : ");
    acc[product] = price;
    return acc;
  }, {});

  let set = new Set();
  Object.keys(catalogue)
    .sort(function (a, b) {
      return a.toLowerCase().localeCompare(b.toLowerCase());
    })
    .forEach((product) => {
      set.add(product.substring(0, 1));
      set.add(`  ${product}: ${catalogue[product]}`);
    });

  set.forEach((row) => {
    console.log(row);
  });
}

// getCatalogue([
//   "Appricot : 20.4",
//   "Fridge : 1500",
//   "TV : 1499",
//   "Deodorant : 10",
//   "Boiler : 300",
//   "Apple : 1.25",
//   "Anti-Bug Spray : 15",
//   "T-Shirt : 10",
// ]);

//3.	Class Laptop
class Laptop {
  constructor(info, quality) {
    this.info = info;
    this.isOn = false;
    this.quality = quality;
    this.price = 800 - this.info.age * 2 + this.quality * 0.5;
  }
  setprice = () => {
    this.price = 800 - this.info.age * 2 + this.quality * 0.5;
  };
  turnOn = () => {
    this.isOn = true;
    this.quality--;
    this.setprice();
  };
  turnOff = () => {
    this.isOn = false;
    this.quality--;
    this.setprice();
  };
  showInfo = () => {
    return JSON.stringify(this.info);
  };
}

// let info = { producer: "Lenovo", age: 1, brand: "Legion" };
// let laptop = new Laptop(info, 10);
// laptop.turnOn();
// console.log(laptop.showInfo());
// laptop.turnOff();
// laptop.turnOn();
// laptop.turnOff();
// console.log(laptop.isOn);

//4.	Flight Schedule
function getFlifghts(inputArr) {
  const AllFlights = inputArr[0].reduce((acc, curr) => {
    const [flight, Destination] = curr.split(" ");
    acc.push({ Destination, flight });

    return acc;
  }, []);

  inputArr[1].forEach((row) => {
    const [flight1, status] = row.split(" ");
    let polet = AllFlights.find((f) => f.flight === flight1);
    if (polet) {
      polet.Status = status;
    }
  });

  const command = inputArr[2].toString();

  if (command === "Ready to fly") {
    AllFlights.forEach((flight) => {
      if (!flight.Status) {
        console.log(
          `{ Destination: '${flight.Destination}', Status: 'Ready to fly' }`
        );
      }
    });
  } else {
    AllFlights.forEach((flight) => {
      if (flight.Status) {
        console.log(
          `{ Destination: '${flight.Destination}', Status: '${flight.Status}' }`
        );
      }
    });
  }
}

// getFlifghts([
//   [
//     "WN269 Delaware",
//     "FL2269 Oregon",
//     "WN498 Las Vegas",
//     "WN3145 Ohio",
//     "WN612 Alabama",
//     "WN4010 New York",
//     "WN1173 California",
//     "DL2120 Texas",
//     "KL5744 Illinois",
//     "WN678 Pennsylvania",
//   ],
//   [
//     "DL2120 Cancelled",
//     "WN612 Cancelled",
//     "WN1173 Cancelled",
//     "SK430 Cancelled",
//   ],
//   ["Cancelled"],
// ]);

// getFlifghts([
//   [
//     "WN269 Delaware",
//     "FL2269 Oregon",
//     "WN498 Las Vegas",
//     "WN3145 Ohio",
//     "WN612 Alabama",
//     "WN4010 New York",
//     "WN1173 California",
//     "DL2120 Texas",
//     "KL5744 Illinois",
//     "WN678 Pennsylvania",
//   ],
//   [
//     "DL2120 Cancelled",
//     "WN612 Cancelled",
//     "WN1173 Cancelled",
//     "SK330 Cancelled",
//   ],
//   ["Ready to fly"],
// ]);

//05. School Register
function getStudents(inputArr) {
  const students = inputArr.reduce((acc, curr) => {
    let [name, grade, score] = curr.split(", ");
    name = name.split(": ")[1];
    grade = grade.split(": ")[1];
    score = score.split(": ")[1];

    if (Number(score) < 3) {
      return acc;
    }

    acc.push({ name, grade, score });
    return acc;
  }, []);

  const regiter = students
    .sort((a, b) => a.grade - b.grade)
    .reduce((acc, curr) => {
      const grade = acc.find((r) => r.grade === curr.grade);
      if (grade) {
        grade.studentsList.push(curr.name);
        grade.totalScore += Number(curr.score);
      } else {
        acc.push({
          grade: curr.grade,
          studentsList: [curr.name],
          totalScore: Number(curr.score),
        });
      }
      return acc;
    }, []);

  regiter.forEach((reg) => {
    const studentCount = reg.studentsList.length;
    if (reg) {
      console.log(`${Number(reg.grade) + 1} Grade`);
      console.log(`List of students: ${reg.studentsList.join(", ")}`);
      console.log(
        `Average annual score from last year: ${(
          reg.totalScore / studentCount
        ).toFixed(2)}\n`
      );
    }
  });
}

// getStudents([
//   "Student name: George, Grade: 5, Graduated with an average score: 2.75",
//   "Student name: Alex, Grade: 9, Graduated with an average score: 3.66",
//   "Student name: Peter, Grade: 8, Graduated with an average score: 2.83",
//   "Student name: Boby, Grade: 5, Graduated with an average score: 4.20",
//   "Student name: John, Grade: 9, Graduated with an average score: 2.90",
//   "Student name: Steven, Grade: 2, Graduated with an average score: 4.90",
//   "Student name: Darsy, Grade: 1, Graduated with an average score: 5.15",
// ]);

//06. Browser History
function browserHistory(browser, inputArr) {
  inputArr.forEach((action) => {
    const [command, ...webSite] = action.split(" ");

    if (command === "Open") {
      browser["Open Tabs"].push(webSite);
      browser["Browser Logs"].push(action);
    } else if (action === "Clear History and Cache") {
      browser["Open Tabs"] = [];
      browser["Recently Closed"] = [];
      browser["Browser Logs"] = [];
    } else if (browser["Open Tabs"].includes(webSite.toString())) {
      const indexToDelete = browser["Open Tabs"].indexOf(webSite.toString());
      browser["Open Tabs"].splice(indexToDelete, 1);
      browser["Recently Closed"].push(webSite);
      browser["Browser Logs"].push(action);
    }
  });

  console.log(browser["Browser Name"]);
  console.log(`Open Tabs: ${browser["Open Tabs"].join(", ")}`);
  console.log(`Recently Closed: ${browser["Recently Closed"].join(", ")}`);
  console.log(`Browser Logs: ${browser["Browser Logs"].join(", ")}`);
}

// browserHistory(
//   {
//     "Browser Name": "Mozilla Firefox",
//     "Open Tabs": ["YouTube"],
//     "Recently Closed": ["Gmail", "Dropbox"],
//     "Browser Logs": [
//       "Open Gmail",
//       "Close Gmail",
//       "Open Dropbox",
//       "Open YouTube",
//       "Close Dropbox",
//     ],
//   },
//   ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
// );

//07. Sequences
function removeDublicates(inputArr) {
  const removed = inputArr
    .reduce((acc, curr) => {
      let test = JSON.parse(curr);
      acc.push(test.sort((a, b) => b - a));
      return acc;
    }, [])
    .sort((a, b) => a.length - b.length);
  const result = new Set();

  removed.forEach((element) => {
    result.add(`[${element.join(", ")}]`);
  });

  result.forEach((element) => {
    console.log(element);
  });
}

// removeDublicates([
//   "[7.14, 7.180, 7.339, 80.099]",
//   "[7.339, 80.0990, 7.140000, 7.18]",
//   "[7.339, 7.180, 7.14, 80.099]",
// ]);

//8.	Garage
function showGarage(inputArr) {
  const garage = inputArr.reduce((acc, curr) => {
    let [garage, carInfo] = curr.split(" - ");
    carInfo = carInfo.split(", ");

    const car = carInfo.reduce((acc, curr) => {
      const [key, value] = curr.split(": ");
      const toPush = key + " - " + value;

      acc.push(toPush);
      return acc;
    }, []);

    if (!acc[garage]) {
      acc[garage] = [];
    }

    acc[garage].push(car);
    return acc;
  }, {});

  Object.entries(garage).forEach(([number, carinfo]) => {
    console.log(`Garage № ${number}`);
    carinfo.forEach((car) => {
      console.log("--- " + car.join(", "));
    });
  });
}

showGarage([
  "1 - color: blue, fuel type: diesel",
  "1 - color: red, manufacture: Audi",
  "2 - fuel type: petrol",
  "4 - color: dark blue, fuel type: diesel, manufacture: Fiat",
]);
