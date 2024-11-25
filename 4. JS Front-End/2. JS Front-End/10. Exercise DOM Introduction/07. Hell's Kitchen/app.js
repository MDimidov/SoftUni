function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let arr = JSON.parse(document.querySelector('#inputs textarea').value);
      let objWinner = findBestRestaurant(arr);
      document.querySelector('#bestRestaurant>p').textContent = getMsgRest(objWinner);
      document.querySelector('#workers>p').textContent = getMsgEmp(objWinner.workers);
   }

   function getMsgRest(objWinner) {
      return `Name: ${objWinner.name} Average Salary: ${objWinner.avgSalary.toFixed(2)} Best Salary: ${objWinner.maxSalary.toFixed(2)}`;
   }

   function getMsgEmp(workers) {
      return workers.map(w => `Name: ${w.worker} With Salary: ${w.salary}`).join(' ');
   }

   function findBestRestaurant(arr) {
      let resultRestaurants = arr.reduce((acc, e) => {
         let [restaurant, ...workers] = e.split(/(?: - )|(?:, )/g);
         workers = workers.map(w => {
            let [worker, salary] = w.split(' ');
            return {
               worker: worker,
               salary: +salary
            };
         });
         let foundRestraunt = acc.find(r => r.name === restaurant);
         if (foundRestraunt) {
            foundRestraunt.workers = foundRestraunt.workers.concat(workers);
         } else {
            acc.push({
               name: restaurant,
               workers: workers
            });
         }
         return acc;
      }, []);

      resultRestaurants.forEach((el, idx) => {
         el.inputOrder = idx;
         el.avgSalary = el.workers.reduce((acc, el) => acc + el.salary, 0) / el.workers.length;
         el.maxSalary = Math.max(...el.workers.map(w => w.salary));
      });

      resultRestaurants.sort((a, b) => b.avgSalary - a.avgSalary || a.inputOrder - b.inputOrder);
      let bestRestaurant = resultRestaurants[0];
      bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

      return bestRestaurant;
   }
}

// -----------------Method 2--------------------

function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   
   function onClick() {
      const inputArr = JSON.parse(document.querySelector('#inputs>textarea').value);
      let restaurants = [];

      for (const restInfo of inputArr) {
         const restObj = getRestObj(restInfo);
         restaurants.push(restObj);
      }
      
      const bestRest = getBestRestaurant(restaurants);
      const bestRestaurant = document.querySelector('#bestRestaurant>p');
      bestRestaurant.textContent = `Name: ${bestRest.restName} Average Salary: ${bestRest.avgSalary.toFixed(2)} Best Salary: ${bestRest.persons.sort((a, b) => b.salary - a.salary)[0].salary.toFixed(2)}`;

      const bestWorkers = getBestWorkers(bestRest);
      const showBestWorkers = document.querySelector('#workers>p');
      showBestWorkers.textContent = bestWorkers;

      function getRestObj(restInfo) {
         const [restName, personInfo] = restInfo.split(' - ');
         const persons = personInfo.split(', ').map( x => {
            const [name, salary] = x.split(' ');
            return {
               name: name,
               salary: Number(salary),
            }
         });

         const avgSalary = persons.reduce((acc, curr) => {
            acc += curr.salary;
            return acc;
         }, 0) / persons.length;

         return {
            restName,
            persons,
            avgSalary,
         }
      }

      function getBestRestaurant(restaurants) {
         return restaurants.sort((a, b) => b.avgSalary - a.avgSalary)[0];
      }

      function getBestWorkers(restaurant) {
         const bestWorkers = restaurant.persons.sort((a, b) => b.salary - a.salary);
         return bestWorkers.reduce((acc, curr) => {
            acc += `Name: ${curr.name} With Salary: ${curr.salary} `;
            return acc;
         }, '')
      }
   }
}