function JSONtoString(jsonStr) {
  let person = JSON.parse(jsonStr);
  for (const key in person) {
    console.log(`${key}: ${person[key]}`);
  }
}

JSONtoString('{"name": "George", "age": 40, "town": "Sofia"}');
