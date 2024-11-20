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

// showCourses([
//   "JavaBasics: 15",
//   "user1[26] with email user1@user.com joins JavaBasics",
//   "user2[36] with email user11@user.com joins JavaBasics",
//   "JavaBasics: 5",
//   "C#Advanced: 5",
//   "user1[26] with email user1@user.com joins C#Advanced",
//   "user2[36] with email user11@user.com joins C#Advanced",
//   "user3[6] with email user3@user.com joins C#Advanced",
//   "C#Advanced: 1",
//   "JSCore: 8",
//   "user23[62] with email user23@user.com joins JSCore",
// ]);

// -----------------Method 2--------------------

function showCourses(inputArr) {
  let courses = [];

  inputArr.forEach((command) => {
    if (command.includes('with')) {
      const studentInfo = getStudentInfo(command);
      if (checkIfCourseExist(studentInfo.courseName)) {
        addStudentToCourse(studentInfo);
      }
    } else if (command.includes(':')) {
      addCourseOrIncreaseCapacity(command);
    }
  });

  function checkIfCourseExist(courseName) {
    return courses.find((c) => c.courseName === courseName);
  }

  function getStudentInfo(studentCommand) {
    const [username, command] = studentCommand.split('[');
    const [credits, lastCommand] = command.split('] with email ');
    const [email, courseName] = lastCommand.split(' joins ');

    return {
      username,
      credits: Number(credits),
      email,
      courseName,
    };
  }

  function addStudentToCourse(studentInfo) {
    const course = checkIfCourseExist(studentInfo.courseName);
    const student = {
      username: studentInfo.username,
      credits: studentInfo.credits,
      email: studentInfo.email,
    };
    
    if (!course.students) {
      course.students = [];
    }

    if (course.capacity > 0) {
      course.students.push(student);
      course.capacity--;
    }
  }

  function addCourseOrIncreaseCapacity(courseCommand) {
    const [courseName, capacityStr] = courseCommand.split(': ');
    const capacity = Number(capacityStr.split(' places left')[0]);
    
    const course = checkIfCourseExist(courseName);
    if (course) {
      course.capacity += capacity;
    } else {
      courses.push({
        courseName: courseName,
        capacity: capacity,
        students: [],
      });
    }
  }

  courses
  .sort((a, b) => b.students.length - a.students.length)
  .forEach((course) => {
    console.log(`${course.courseName}: ${course.capacity} places left`);
    course.students
    .sort((a, b) => b.credits - a.credits)
    .forEach((student) => {
      console.log(`--- ${student.credits}: ${student.username}, ${student.email}`);
    });
  });
}

// showCourses([
//   "JavaBasics: 15",
//   "user1[26] with email user1@user.com joins JavaBasics",
//   "user2[36] with email user11@user.com joins JavaBasics",
//   "JavaBasics: 5",
//   "C#Advanced: 5",
//   "user1[26] with email user1@user.com joins C#Advanced",
//   "user2[36] with email user11@user.com joins C#Advanced",
//   "user3[6] with email user3@user.com joins C#Advanced",
//   "C#Advanced: 1",
//   "JSCore: 8",
//   "user23[62] with email user23@user.com joins JSCore",
// ]);

showCourses([
  'JavaBasics: 2', 
  'user1[25] with email user1@user.com joins C#Basics', 
  'C#Advanced: 3', 
  'JSCore: 4', 
  'user2[30] with email user2@user.com joins C#Basics',
  'user13[50] with email user13@user.com joins JSCore',
  'user1[25] with email user1@user.com joins JSCore', 
  'user8[18] with email user8@user.com joins C#Advanced',
  'user6[85] with email user6@user.com joins JSCore', 
  'JSCore: 2',
  'user11[3] with email user11@user.com joins JavaBasics',
  'user45[105] with email user45@user.com joins JSCore',
  'user007[20] with email user007@user.com joins JSCore',
  'user700[29] with email user700@user.com joins JSCore',
  'user900[88] with email user900@user.com joins JSCore',
]);