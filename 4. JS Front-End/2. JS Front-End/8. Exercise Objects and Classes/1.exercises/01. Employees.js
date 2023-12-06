function emplyees(input) {
  const employeers = input.reduce((acc, curr) => {
    acc[curr] = curr.length;
    return acc;
  }, {});

  Object.entries(employeers).forEach(([name, number]) => {
    console.log(`Name: ${name} -- Personal Number: ${number}`);
  });
}

emplyees(["Samuel Jackson", "Will Smith", "Bruce Willis", "Tom Holland"]);
