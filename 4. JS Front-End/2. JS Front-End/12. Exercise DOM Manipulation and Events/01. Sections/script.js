function create(words) {
   const mainDiv = document.querySelector("#content");

   for (const word of words) {
      let div = document.createElement("div");
      let p = document.createElement("p");

      p.textContent = word;
      p.style.display = "none";

      div.appendChild(p);
      mainDiv.appendChild(div);

      div.addEventListener("click", () => {
         p.style.display = '';
      });
   }
}

// -----------------Method 2--------------------

function create(words) {
   const mainDiv = document.querySelector('#content');

   for (const word of words) {

      let div = document.createElement('div');
      let p = document.createElement('p');
      
      p.textContent = word;
      p.style.display = 'none';

      div.appendChild(p);
      mainDiv.appendChild(div);

      div.addEventListener('click', () => {
         p.style.display = 'block';
      });
   }
}