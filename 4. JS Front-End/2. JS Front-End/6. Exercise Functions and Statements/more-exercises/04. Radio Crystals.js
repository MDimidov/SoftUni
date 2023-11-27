function reduceCrystal([minPoints, ...crystals]) {
  for (let i = 0; i < crystals.length; i++) {
    let currentPoints = crystals[i];

    let counter = 0;

    console.log(`Processing chunk ${currentPoints} microns`);

    if (currentPoints / 4 >= minPoints) {
      while (currentPoints / 4 >= minPoints) {
        currentPoints /= 4;
        counter++;
      }
      console.log(`Cut x${counter}`);

      console.log("Transporting and washing");

      currentPoints = Math.floor(currentPoints);

      if (currentPoints === minPoints) {
        console.log(`Finished crystal ${minPoints} microns`);
        continue;
      }
    }
    counter = 0;

    if (currentPoints * 0.8 >= minPoints) {
      while (currentPoints * 0.8 >= minPoints) {
        currentPoints *= 0.8;
        counter++;
      }
      console.log(`Lap x${counter}`);
      console.log("Transporting and washing");

      currentPoints = Math.floor(currentPoints);
      if (currentPoints === minPoints) {
        console.log(`Finished crystal ${minPoints} microns`);
        continue;
      }
    }
    counter = 0;

    if (currentPoints - 20 >= minPoints) {
      while (currentPoints - 20 >= minPoints) {
        currentPoints -= 20;
        counter++;
      }
      console.log(`Grind x${counter}`);
      console.log("Transporting and washing");
      currentPoints = Math.floor(currentPoints);

      if (currentPoints === minPoints) {
        console.log(`Finished crystal ${minPoints} microns`);
        continue;
      }
    }
    counter = 0;

    if (currentPoints - 2 >= minPoints - 1) {
      while (currentPoints - 2 >= minPoints - 1) {
        currentPoints -= 2;
        counter++;
      }
      console.log(`Etch x${counter}`);
      console.log("Transporting and washing");
      currentPoints = Math.floor(currentPoints);

      if (currentPoints === minPoints) {
        console.log(`Finished crystal ${minPoints} microns`);
        continue;
      }
    }
    counter = 0;

    if (minPoints > currentPoints) {
      currentPoints += 1;
      console.log(`X-ray x1`);
      console.log(`Finished crystal ${minPoints} microns`);
    }
  }
}

reduceCrystal([1000, 4000, 8100]);
