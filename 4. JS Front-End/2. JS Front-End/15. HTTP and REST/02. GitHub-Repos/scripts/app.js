function loadRepos() {
   const url = "https://api.github.com/users/testnakov/repos";
   const resultDiv = document.querySelector("#res");
 
   fetch(url)
      .then((response) => {
         if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
         } 
         return response.text();
      })
      .then((data) => {
         resultDiv.textContent = data
      })
      .catch((error) => {
         console.error("Error fetching data:", error);
      });
 }
 