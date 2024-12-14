function loadMatches(baseUrl, onSuccess) {
    fetch(baseUrl)
        .then((response) => response.json())
        .then(onSuccess)
        .catch((error) => console.error('Error: ' + error));
}

function createMatch(baseUrl, match, onSuccess) {
    fetch(baseUrl, {
        method: 'POST',
        body: JSON.stringify(match)
    })
        .then((response) => response.json())
        .then(onSuccess)
        .catch((error) => console.error('Error: ' + error));
}

function updateMatch(baseUrl, match, onSuccess) {
    fetch(baseUrl + match._id, {
        method: 'PUT',
        body: JSON.stringify(match)
    })
        .then((response) => response.json())
        .then(onSuccess)
        .catch((error) => console.error('Error: ' + error));
}

function deleteMatch(url, onSuccess) {
    fetch(url, {
        method: 'DELETE'
    })
        .then((response) => response.json())
        .then(onSuccess)
        .catch((error) => console.error('Error: ' + error));
}

function createElement(tag, properties, container) {
    const element = document.createElement(tag);

    for (const key of Object.keys(properties)) {
        if (typeof properties[key] === 'object') {
            element[key] ??= {};
            Object.assign(element[key], properties[key]);
        } else {
            element[key] = properties[key];
        }
    }

    if (container) container.appendChild(element);

    return element
}

function init() {
    const baseUrl = 'http://localhost:3030/jsonstore/matches/';
    const fields = [...document.querySelectorAll('#form input[type="text"]')];
    const btnAddMatch = document.querySelector('#add-match');
    const btnEditMatch = document.querySelector('#edit-match');
    const listEl = document.querySelector('#list');
    const btnLoadMatches = document.querySelector('#load-matches');
    
    btnAddMatch.addEventListener('click', createHandler);
    btnEditMatch.addEventListener('click', updateHandler);
    btnLoadMatches.addEventListener('click', loadEntries);
    
    
    function loadEntries(){
        listEl.innerHTML = '';
        loadMatches(baseUrl, (result) => {
            Object.values(result).forEach(createEntry);
        });
    }
    
    function createEntry({host, score, guest, _id}) {
        const liEl = createElement('li', {className: 'match', dataset: {host, score, guest, _id}}, listEl);
        const divInfo = createElement('div', {className: 'info'}, liEl);
        createElement('p', {textContent: host}, divInfo);
        createElement('p', {textContent: score}, divInfo);
        createElement('p', {textContent: guest}, divInfo);

        const divWrapper = createElement('div', {className: 'btn-wrapper'}, liEl);
        createElement('button', {className: 'change-btn', onclick: changeHandler, textContent: 'Change'}, divWrapper);
        createElement('button', {className: 'delete-btn', onclick: deleteHandler, textContent: 'Delete'}, divWrapper);
    }

    function createHandler() {
        const [host, score, guest] = fields.map(f => f.value);

        if (host && score && guest) {
            const match = {host, score, guest};

            createMatch(baseUrl, match, () => {
                loadEntries();
            });
            
            fields.forEach(f => f.value = '');
        }

    }

    function changeHandler(e) {
        const li = e.target.closest('li');
        const matchValues = Object.values(li.dataset);

        fields.forEach((field, index) => field.value = matchValues[index]);

        li.classList.add('active');
        btnAddMatch.disabled = true;
        btnEditMatch.disabled = false;
    }

    function updateHandler() {
        const [host, score, guest] = fields.map(f => f.value);

        if (host && score && guest) {
            const liActive = listEl.querySelector('li.active');
            const match = {host, score, guest, _id: liActive.dataset._id}

            updateMatch(baseUrl, match, () => {
                loadEntries();
                fields.forEach(field => field.value = '');
                btnAddMatch.disabled = false;
                btnEditMatch.disabled = true;
            });

            liActive.classList.remove('active')
        }

    }

    function deleteHandler(e) {
        const id = e.target.closest('li').dataset._id;
        deleteMatch(baseUrl + id, (result) => {
            deleteEntry(result);
        });
    }

    function deleteEntry({_id}) {
        listEl.querySelector(`li[data-_id="${_id}"]`).remove();
    }

    // loadEntries();
}

document.addEventListener('DOMContentLoaded', init);