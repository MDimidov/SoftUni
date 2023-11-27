function printDNA(length) {
  const pattern = [
    ["A", "T"],
    ["C", "G"],
    ["T", "T"],
    ["A", "G"],
    ["G", "G"],
  ];

  function evenRow(row) {
    console.log(`*${row[0]}--${row[1]}*`);
  }

  function devideBy4(row) {
    console.log(`**${row[0]}${row[1]}**`);
  }

  function lastOption(row) {
    console.log(`${row[0]}----${row[1]}`);
  }
  for (let i = 0; i < length; i++) {
    if (i % 2 !== 0) {
      evenRow(pattern[i % 5]);
    } else if (i % 4 === 0) {
      devideBy4(pattern[i % 5]);
    } else {
      lastOption(pattern[i % 5]);
    }
  }
}

printDNA(18);
