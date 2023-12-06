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
