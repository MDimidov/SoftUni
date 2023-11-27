function collectAddresses(arrayOfAdresses) {
  const addresObjects = arrayOfAdresses.reduce((acc, curr) => {
    const [name, address] = curr.split(":");
    acc[name] = address;

    return acc;
  }, {});

  let entires = Object.entries(addresObjects)
    .sort((a, b) => {
      return a[0].localeCompare(b[0]);
    })
    .forEach(([key, value]) => {
      console.log(`${key} -> ${value}`);
    });
}

collectAddresses([
  "Tim:Doe Crossing",
  "Bill:Nelson Place",
  "Peter:Carlyle Ave",
  "Bill:Ornery Rd",
]);
