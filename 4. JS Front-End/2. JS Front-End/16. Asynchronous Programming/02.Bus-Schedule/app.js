function solve() {
    let stopId;
    if (!stopId) stopId = 'depot';
    let stopName;
    
    
    const divInfo = document.querySelector('#info>span.info');
    const btnDepart = document.querySelector('#depart');
    const btnArrive = document.querySelector('#arrive');
    
    function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${stopId}`;
        
        fetch(url)
            .then((response) => {
                if(!response.ok){
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }

                return response.json();
            })
            .then((stopInfo) => {
                stopName = stopInfo.name;
                divInfo.textContent = `Next stop ${stopName}`;
                stopId = stopInfo.next;
            });
            
        btnDepart.disabled = true;    
        btnArrive.disabled = false;   
    }
    
    async function arrive() {
        divInfo.textContent = `Arriving at ${stopName}`;
            
        btnArrive.disabled = true; 
        btnDepart.disabled = false;    
    }

    return {
        depart,
        arrive
    };
}

let result = solve();