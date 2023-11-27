function loadingBar(num) {
  let bar = num / 10;

  if (bar === 10) {
    console.log(`100% Complete!\n[%%%%%%%%%%]`);
  } else {
    console.log(
      `${num}% [${"%".repeat(bar)}${".".repeat(10 - bar)}]\nStill loading...`
    );
  }
}

loadingBar(25);
