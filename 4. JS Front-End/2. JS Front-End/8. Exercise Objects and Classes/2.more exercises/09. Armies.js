function getArmies(inputArr) {
  let armies = inputArr.reduce((acc, curr) => {
    if (curr.includes("arrives")) {
      const leader = curr.split(" arrives")[0];
      acc[leader] = [];
    } else if (curr.includes("defeated")) {
      const leader = curr.split(" defeated")[0];
      //Ако лидерът съществува го маркираме като изтрит
      if (acc[leader]) {
        acc[leader] = "defeated";
      }
    } else if (curr.includes(": ")) {
      let army = {};
      const [leader, armyInfo] = curr.split(": ");
      const [armyName, armyCount] = armyInfo.split(", ");
      army[armyName] = Number(armyCount);
      if (acc[leader]) {
        acc[leader].push(army);
      }
    } else if (curr.includes("+")) {
      const [armyName, addCount] = curr.split(" + ");
      Object.entries(acc).forEach(([leader, army]) => {
        army.forEach((a) => {
          if (a[armyName]) {
            a[armyName] += Number(addCount);
            return;
          }
        });
      });
    }

    return acc;
  }, {});

  armies = Object.entries(armies)
    //премахваме изтритите лидери
    .filter(([leader, value]) => value !== "defeated")
    //сортираме
    .sort(([leader1, value1], [leader2, value2]) => {
      const total1 = value1.reduce((sum, a) => sum + Object.values(a)[0], 0);
      const total2 = value2.reduce((sum, a) => sum + Object.values(a)[0], 0);

      if (total1 === total2) {
        // Ако общият брой на войниците е равен, сортирайте по азбучен ред на имената на лидерите.
        return leader1.localeCompare(leader2);
      }

      return total2 - total1;
    });

  armies.forEach(([leader, value]) => {
    console.log(
      `${leader}: ${value.reduce((sum, a) => sum + Object.values(a)[0], 0)}`
    );
    value
      .sort((a, b) => Object.values(b)[0] - Object.values(a)[0])
      .forEach((army) => {
        const armyName = Object.keys(army)[0];
        const armyCount = Object.values(army)[0];
        console.log(`>>> ${armyName} - ${armyCount}`);
      });
  });
}

getArmies([
  "Rick Burr arrives",
  "Fergus: Wexamp, 30245",
  "Rick Burr: Juard, 50000",
  "Findlay arrives",
  "Findlay: Britox, 34540",
  "Wexamp + 6000",
  "Juard + 1350",
  "Britox + 4500",
  "Porter arrives",
  "Porter: Legion, 55000",
  "Legion + 302",
  "Rick Burr defeated",
  "Porter: Retix, 3205",
]);
