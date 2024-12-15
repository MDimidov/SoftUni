function loadWorkouts(baseUrl, onSuccess) {
    fetch(baseUrl)
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
}

function createWorkout(baseUrl, workout, onSuccess) {
    fetch(baseUrl, {
        method: 'POST',
        body: JSON.stringify(workout)
    })
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
}

function updateWorkout(baseUrl, workout, onSuccess) {
    fetch(baseUrl + workout._id, {
        method: 'PUT',
        body: JSON.stringify(workout)
    })
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
}

function deleteWorkout(baseUrl, workout, onSuccess) {
    fetch(baseUrl + workout._id, {
        method: 'DELETE'
    })
        .then(response => response.json())
        .then(onSuccess)
        .catch(error => console.error('Error: ', error));
}

function createElement(tag, properties, container) {
    const element = document.createElement(tag)

    Object.keys(properties).forEach(key => {
        if ( typeof properties[key] === 'object' ) {
            Object.assign(element[key], properties[key]);
        } else {
            element[key] = properties[key];
        }
    });
    
    if ( container ) container.appendChild(element);
    
    return element;
}

function init() {
    const baseUrl = 'http://localhost:3030/jsonstore/workout/';
    const btnLoad = document.querySelector('#load-workout');
    const btnAdd = document.querySelector('#add-workout');
    const btnEdit = document.querySelector('#edit-workout');
    const divList = document.querySelector('#list');
    const fields = Array.from(document.querySelectorAll('#form>form>input'));

    btnLoad.addEventListener('click', loadHandler);
    btnAdd.addEventListener('click', createHandler)
    btnEdit.addEventListener('click', editWorkout)

    function loadHandler() {
        divList.innerHTML = '';
        loadWorkouts(baseUrl, (result) => {
            Object.values(result).forEach(createEntry)
        })
    }

    function createEntry({workout, location, date, _id}) {
        const divEl = createElement('div', {className: 'container', dataset: {workout, location, date, _id}}, divList);
        createElement('h2', {textContent: workout}, divEl);
        createElement('h3', {textContent: date}, divEl);
        createElement('h3', {textContent: location, id: 'location'}, divEl);
        const divBtn = createElement('div', {id: 'buttons-container'}, divEl);
        createElement('button', {textContent: 'Change', className: 'change-btn', onclick: changeHandler}, divBtn);
        createElement('button', {textContent: 'Done', className: 'delete-btn', onclick: deleteHandler}, divBtn);
        
    }

    function createHandler() {
        const [workout, location, date] = fields.map(f => f.value);
        const workoutInfo = { workout, location, date };
        if(workout && location && date) {
            createWorkout(baseUrl, workoutInfo, createElement);

            fields.forEach(f => f.value = '');
            loadHandler();
        }
    }

    function editWorkout() {
        
        const [workout, location, date] = fields.map(f => f.value);
        if (workout && location && date) {
            const divEl = document.querySelector('#list>div.active');
            const _id = divEl.dataset._id;
            divEl.classList.remove('active');
            const workoutInfo = {workout, location, date, _id};
            updateWorkout(baseUrl, workoutInfo, loadHandler);
            fields.forEach(f=> f.value = '');

            btnAdd.disabled = false;
            btnEdit.disabled = true;
        }

    }

    function changeHandler(e) {
        btnAdd.disabled = true;
        btnEdit.disabled = false;

        const divEl = e.target.parentElement.parentElement;
        const workout = Object.assign({}, divEl.dataset);
        const values = Object.values(workout);

        fields.forEach((f, i) => f.value = values[i]);
        divEl.classList.add('active');
    }

    function deleteHandler(e) {
        const divEl = e.target.parentElement.parentElement;
        const workout = Object.assign({}, divEl.dataset);
        deleteWorkout(baseUrl, workout, deleteEntry(divEl))
    }

    function deleteEntry(divEl) {
        divEl.remove();
    }
}

document.addEventListener('DOMContentLoaded', init);