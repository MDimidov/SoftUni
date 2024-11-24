function search() {
  const towns = Array.from(document.getElementById("towns").children);
  const searchText = document.getElementById("searchText").value;
  let matches = 0;

  for (const town of towns) {
    if (town.textContent.includes(searchText.toString())) {
      matches++;
      town.style.fontWeight = "bold";
      town.style.textDecorationLine = "underline";
    }
  }

  const result = document.getElementById("result");
  result.textContent = `${matches} matches found`;
}

// -----------------Method 2--------------------

function search() {
  const townsArr = document.querySelectorAll('#towns>li');
  const searchText = document.getElementById('searchText').value.toLowerCase();
  let matches = 0;

  for (const town of townsArr) {
    if (town.textContent.toLowerCase().includes(searchText)) {
      town.style.fontWeight = 'bold';
      town.style.textDecorationLine = 'underline';  
      matches++;    
    } else {
      town.style.fontWeight = 'normal';
      town.style.textDecorationLine = 'none'; 
    }
  };

  const result = document.getElementById('result');
  result.textContent = `${matches} matches found`;
}