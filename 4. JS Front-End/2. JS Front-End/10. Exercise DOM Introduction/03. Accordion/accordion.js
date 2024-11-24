function toggle() {
  const extra = document.getElementById("extra");
  const button = document.getElementsByClassName("button")[0];

  if (button.textContent.toLowerCase() === "more") {
    extra.style.display = "block";
    button.textContent = "Less";
  } else {
    extra.style.display = "none";
    button.textContent = "More";
  }
}

// -----------------Method 2--------------------

function toggle() {
  const text = document.getElementById('extra');
  const button = document.getElementsByClassName('button')[0];

  if(button.textContent.toLocaleLowerCase() === 'more'){
    text.style.display = 'block';
    button.textContent = 'Less';
  } else {
    text.style.display = 'none';
    button.textContent = 'More';
  }
}