function pointValidation(array) {
  const x1 = array[0];
  const y1 = array[1];
  const x2 = array[2];
  const y2 = array[3];

  function CalculateDist(x1, y1, x2, y2) {
    const result = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);
    if (Number.isInteger(result)) {
      console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
      console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
    return result;
  }
  CalculateDist(x1, y1, 0, 0);
  CalculateDist(x2, y2, 0, 0);
  CalculateDist(x1, y1, x2, y2);
}

pointValidation([2, 1, 1, 1]);
