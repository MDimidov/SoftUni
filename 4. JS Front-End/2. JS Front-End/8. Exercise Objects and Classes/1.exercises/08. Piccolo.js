function registerCars(carNums) {
  const parking = new Set();

  carNums.forEach((line) => {
    const [directon, carNumber] = line.split(", ");

    if (directon === "IN") {
      parking.add(carNumber);
    } else {
      parking.delete(carNumber);
    }
  });

  if (parking.size > 0) {
    Array.from(parking)
      .sort()
      .forEach((carNum) => {
        console.log(carNum);
      });
  } else {
    console.log("Parking Lot is Empty");
  }
}

registerCars([
  "IN, CA2844AA",
  "IN, CA1234TA",
  "OUT, CA2844AA",
  "IN, CA9999TT",
  "IN, CA2866HI",
  "OUT, CA1234TA",
  "IN, CA2844AA",
  "OUT, CA2866HI",
  "IN, CA9876HH",
  "IN, CA2822UU",
]);
