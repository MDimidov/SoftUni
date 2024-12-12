
function loadContacts(baseURL, onSuccess) {
    fetch(baseURL)
        .then((response) => response.json())
        .then(onSuccess)
        .catch((error) => console.error('Error: ', error));
}

function postContact(baseURL, contact, onSuccess) {
    fetch(baseURL, {
        method: 'POST',
        body: JSON.stringify(contact)
    })
        .then((response) => response.json())
        .then(onSuccess)
        .catch((error) => console.error('Error: ', error));
}

function deleteContact(baseURL, contact, onSuccess) {
    fetch(baseURL + contact._id, {
        method: 'DELETE'
    })
        .then((response) => response.json())
        .then(onSuccess)
        .catch((error) => console.error('Error: ', error));
}

function createElement(tag, properties, container = null) {
    const newElement =  document.createElement(tag);

    for (const key of Object.keys(properties)) {
        if (typeof properties[key] === 'object'){
            Object.assign(newElement.dataset, properties[key]);
        } else {
            newElement[key] = properties[key];
        }
    }

    if (container) container.append(newElement);

    return newElement;
}

function init() {
    const baseURL = 'http://localhost:3030/jsonstore/phonebook/';

    const phonebookEl = document.querySelector('#phonebook');
    const btnLoad = document.querySelector('#btnLoad');
    const btnCreate = document.querySelector('#btnCreate');

    function createEntry({person, phone, _id}) {
        createElement(
            'button', 
            {
                textContent: 'Delete',
                onclick: deleteEntryHandler
            },
            createElement(
                'li',
                {
                    textContent: `${person}: ${phone}`,
                    dataset: {person, phone, _id}
                },
                phonebookEl
            ));
    }

    function deleteEntry(contact) {
        phonebookEl.querySelector(`li[data-_id=${contact._id}]`).remove();
    }

    function createEntryHandler(e) {
        const inputs = document.querySelectorAll('input[type="text"][id]');

        const [person, phone] = [...inputs].map(i => i.value);

        if (!person || !phone) return;

        const contact = {person, phone};

        postContact(baseURL, contact, (result) => {
            createEntry(result);
        });
    }

    function deleteEntryHandler(e) {
        const row = e.target.closest('li');

        const contact = Object.assign({}, row.dataset)

        deleteContact(baseURL, contact, (result) => {
            deleteEntry(result);
        });
    }

    btnLoad.addEventListener('click', loadContacts(baseURL, (result) => {
        Object.values(result).forEach(createEntry);
    }));

    btnCreate.addEventListener('click', createEntryHandler);
}

document.addEventListener('DOMContentLoaded', init);