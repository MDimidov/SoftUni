function loadAppointments(baseURL, onResult) {
    fetch(baseURL)
        .then((response) => response.json())
        .then(onResult)
        .catch((error) => console.error('Error: ' + error));
}

function createAppointment(baseURL, appointment, onResult) {
    fetch(baseURL, {
        method: 'POST',
        body: JSON.stringify(appointment)
    })
        .then((response) => response.json())
        .then(onResult)
        .catch((error) => console.error('Error: ' + error));
}

function editAppointment(baseURL, appointment, onResult) {
    fetch(baseURL + appointment._id, {
        method: 'PUT',
        body: JSON.stringify(appointment)
    })
        .then((response) => response.json())
        .then(onResult)
        .catch((error) => console.error('Error: ' + error));
}

function deleteAppointment(baseURL, appointment, onResult) {
    fetch(baseURL + appointment._id, {
        method: 'DELETE'
    })
        .then((response) => response.json())
        .then(onResult)
        .catch((error) => console.error('Error: ' + error));
}

function createElement(tag, properties, container) {
    const element = document.createElement(tag);

    Object.keys(properties).forEach( key => {
      if (typeof properties[key] === 'object') {
        Object.assign(element[key], properties[key]);
      } else {
        element[key] = properties[key];
      }
    });

    if (container) container.appendChild(element);

    return element;
  }

function init() {
    const baseURL = 'http://localhost:3030/jsonstore/appointments/';
    
    const btnLoad = document.querySelector('#load-appointments');
    const btnAdd = document.querySelector('#add-appointment');
    const btnEdit = document.querySelector('#edit-appointment');
    const appointmentList = document.querySelector('#appointments-list');
    const fields = [...document.querySelectorAll('form > input, form > select')];
    

    btnLoad.addEventListener('click', loadHandler);
    btnAdd.addEventListener('click', addHandler);
    btnEdit.addEventListener('click', editHandler)


    function loadHandler() {
        appointmentList.innerHTML = '';
        loadAppointments(baseURL, (result) => {
            Object.values(result).forEach(loadEntry);
        });
    }
    
    function loadEntry({model, service, date, _id}) {
        const entryLi = createElement('li', {className: 'appointment', dataset: {model, service, date, _id}}, appointmentList);
        createElement('h2', {textContent: model}, entryLi);
        createElement('h3', {textContent: date}, entryLi);
        createElement('h3', {textContent: service}, entryLi);
        const divBtns = createElement('div', {className: 'buttons-appointment'}, entryLi);
        createElement('button', {className: 'change-btn', textContent: 'Change', onclick: changeHandler}, divBtns);
        createElement('button', {className: 'delete-btn', textContent: 'Delete', onclick: deleteHandler}, divBtns);
    }

    function addHandler(e) {
        const [model, service, date] = fields.map(f => f.value);
        if (model && service && date) {
            const appointment = {model, service, date};
            createAppointment(baseURL, appointment, addEntry);

            fields.forEach(f => f.value = '');
        }
    }
    
    function  addEntry(appointment) {
        loadEntry(appointment);
    }
    
    function changeHandler(e) {
        const liEl = e.target.closest('li');
        let appointment = Object.assign({}, liEl.dataset);
        appointment = Object.values(appointment);

        fields.forEach((f, i) => {
            f.value = appointment[i];
        });

        liEl.classList.add('active');
        btnAdd.disabled = true;
        btnEdit.disabled = false;
    }

    function editHandler(e) {
        
        const [model, service, date] = fields.map(f => f.value);
        if (model && service && date) {
            
            const liEl = document.querySelector('#appointments-list>li.active');
            let _id = liEl.dataset._id;
            const appointment = {model, service, date, _id};
            editAppointment(baseURL, appointment, loadHandler);
        }
    }
    function deleteHandler(e) {
        const liEl = e.target.closest('li');
        const appointment = Object.assign({}, liEl.dataset);
        deleteAppointment(baseURL, appointment, deleteEntry(liEl));
        console.log(appointment)
    }

    function deleteEntry(liEl) {
        liEl.remove();
    }
}

window.addEventListener('DOMContentLoaded', init);