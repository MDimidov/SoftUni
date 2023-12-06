function printTowns(input) {
  input
    .map((city) => {
      const [town, latitude, longitude] = city.split(" | ");
      return { town, latitude, longitude };
    })
    .forEach((city) => {
      console.log(
        `{ town: '${city.town}', latitude: '${Number(city.latitude).toFixed(
          2
        )}', longitude: '${Number(city.longitude).toFixed(2)}' }`
      );
    });
}

printTowns([
  "Sofia | 42.696552 | 23.32601",
  "Beijing | 39.913818 | 116.363625",
]);
