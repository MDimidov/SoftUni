function showCourses(inputArr) {
  class Course {
    constructor(name) {
      this.name = name;
      this.capacity = 0;
      this.students = [];
    }

    addStudent(student) {
      if (this.capacity > 0) {
        this.students.push(student);
        this.capacity--;
      }
    }

    sortStudents() {
      this.students = this.students.sort((a, b) => b.credits - a.credits);
    }

    increaseCapacity(capacity) {
      this.capacity += capacity;
    }

    printResult() {
      console.log(`${this.name}: ${this.capacity} places left`);
      this.students.forEach((student) => {
        console.log(
          `--- ${student.credits}: ${student.username}, ${student.email}`
        );
      });
    }
  }

  class Student {
    constructor(username, credits, email) {
      this.username = username;
      this.credits = credits;
      this.email = email;
    }
  }

  let courses = [];
  let students = [];

  inputArr.forEach((row) => {
    if (row.includes(":")) {
      const [courseName, courseCapacity] = row.split(": ");
      let course = courses.find((c) => c.name === courseName);
      if (!course) {
        course = new Course(courseName);
        courses.push(course);
      }
      course.increaseCapacity(Number(courseCapacity));
    } else if (row.includes("with email")) {
      const [usernameAndCredits, emailAndCourseName] =
        row.split(" with email ");

      let [username, credits] = usernameAndCredits.split("[");
      credits = Number(credits.split("]")[0]);
      const [email, courseName] = emailAndCourseName.split(" joins ");

      let student = students.find((s) => s.username === username);
      if (!student) {
        student = new Student(username, credits, email);
        students.push(student);
      }

      let course = courses.find((c) => c.name === courseName);
      if (course) {
        course.addStudent(student);
      }
    }
  });

  courses
    .sort((a, b) => b.students.length - a.students.length)
    .forEach((course) => {
      course.sortStudents();
      course.printResult();
    });
}

showCourses([
  "JavaBasics: 15",
  "user1[26] with email user1@user.com joins JavaBasics",
  "user2[36] with email user11@user.com joins JavaBasics",
  "JavaBasics: 5",
  "C#Advanced: 5",
  "user1[26] with email user1@user.com joins C#Advanced",
  "user2[36] with email user11@user.com joins C#Advanced",
  "user3[6] with email user3@user.com joins C#Advanced",
  "C#Advanced: 1",
  "JSCore: 8",
  "user23[62] with email user23@user.com joins JSCore",
]);
