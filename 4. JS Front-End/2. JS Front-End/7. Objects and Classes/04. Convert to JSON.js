function objToJSON(name, lastName, hairColor) {
  const person = {
    name,
    lastName,
    hairColor,
  };

  console.log(JSON.stringify(person));
}

objToJSON("George", "Jones", "Brown");
