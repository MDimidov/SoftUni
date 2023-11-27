function ReturnGrade(num) {
  let grade = "Excellent";
  switch (true) {
    case num < 3:
      grade = "Fail";
      break;
    case num < 3.5:
      grade = "Poor";
      break;
    case num < 4.5:
      grade = "Good";
      break;
    case num < 5.5:
      grade = "Very good";
  }

  console.log(`${grade} (${grade == "Fail" ? 2 : num.toFixed(2)})`);
}

ReturnGrade(2.99);
