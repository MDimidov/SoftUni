function getInfo() {
    const stopId = document.querySelector("#stopId").value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    const stopName = document.querySelector('#stopName');
    const busesList = document.querySelector('#buses');
    
    fetch(url)
    .then((response) => {
        if(!response.ok){
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
    })
    .then((stop) => {
            stopName.textContent = stop.name;
            console.log(stop.buses);
            busesList.innerHTML = '';
            Object.entries(stop.buses).forEach(([busId, minutes]) => {
                
                const liElement = document.createElement('li');
                liElement.textContent = `Bus ${busId} arrives in ${minutes} minutes`;
                busesList.appendChild(liElement);
            });
    })
    .catch(() => {
        stopName.textContent = 'Error';
    });
}