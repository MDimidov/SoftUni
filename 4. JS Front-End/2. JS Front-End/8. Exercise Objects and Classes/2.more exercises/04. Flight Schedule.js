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

checkFlights([
  [
    "WN269 Delaware",
    "FL2269 Oregon",
    "WN498 Las vegas",
    "WN3145 Ohio",
    "WN612 Alabama",
    "WN4010 New York",
    "WN1173 California",
    "DL2120 Texas",
    "KL5744 Illinois",
    "WN678 Pennsylvania",
  ],
  [
    "DL2120 Cancelled",
    "WN612 Cancelled",
    "WN1173 Cancelled",
    "SK330 Cancelled",
  ],
  ["Ready to fly"],
]);
