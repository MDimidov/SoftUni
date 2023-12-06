function registerHeroes(array) {
  let heroes = [];
  array.reduce((acc, curr) => {
    const [heroName, heroLevel, items] = curr.split(" / ");

    heroes.push({
      heroName,
      heroLevel,
      items,
    });

    return acc;
  }, {});

  heroes.sort((a, b) => a.heroLevel - b.heroLevel);
  heroes.forEach((hero) => {
    console.log(
      `Hero: ${hero.heroName}\nlevel => ${hero.heroLevel}\nitems => ${hero.items}`
    );
  });

  //   console.log(JSON.stringify(heroes));
}

registerHeroes([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);
