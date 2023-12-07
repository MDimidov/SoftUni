function colorize() {
  const rows = Array.from(document.querySelectorAll("tr:nth-child(even)"));
  rows.map((row) => {
    row.className = "teal-bg";
  });
}
