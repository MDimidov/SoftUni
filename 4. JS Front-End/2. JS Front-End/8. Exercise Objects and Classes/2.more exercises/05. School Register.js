function getStudents(inputArr) {
  const students = inputArr.reduce((acc, curr) => {
    let [name, grade, score] = curr.split(", ");
    name = name.split(": ")[1];
    grade = grade.split(": ")[1];
    score = score.split(": ")[1];

    if (Number(score) < 3) {
      return acc;
    }

    acc.push({ name, grade, score });
    return acc;
  }, []);

  const regiter = students
    .sort((a, b) => a.grade - b.grade)
    .reduce((acc, curr) => {
      const grade = acc.find((r) => r.grade === curr.grade);
      if (grade) {
        grade.studentsList.push(curr.name);
        grade.totalScore += Number(curr.score);
      } else {
        acc.push({
          grade: curr.grade,
          studentsList: [curr.name],
          totalScore: Number(curr.score),
        });
      }
      return acc;
    }, []);

  regiter.forEach((reg) => {
    const studentCount = reg.studentsList.length;
    if (reg) {
      console.log(`${Number(reg.grade) + 1} Grade`);
      console.log(`List of students: ${reg.studentsList.join(", ")}`);
      console.log(
        `Average annual score from last year: ${(
          reg.totalScore / studentCount
        ).toFixed(2)}\n`
      );
    }
  });
}

registerStudents([
  "Student name: George, Grade: 5, Graduated with an average score: 2.75",
  "Student name: Alex, Grade: 9, Graduated with an average score: 3.66",
  "Student name: Peter, Grade: 8, Graduated with an average score: 2.83",
  "Student name: Boby, Grade: 5, Graduated with an average score: 4.20",
  "Student name: John, Grade: 9, Graduated with an average score: 2.90",
  "Student name: Steven, Grade: 2, Graduated with an average score: 4.90",
  "Student name: Darsy, Grade: 1, Graduated with an average score: 5.15",
]);
