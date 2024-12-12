
function loadStudents(baseURL, onSuccess) {
  fetch(baseURL)
      .then((response) => response.json())
      .then(onSuccess)
      .catch((error) => console.error('Error: ', error));
}

function postStudent(baseURL, student, onSuccess) {
  fetch(baseURL, {
      method: 'POST',
      body: JSON.stringify(student)
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
  const baseURL = 'http://localhost:3030/jsonstore/collections/students/';

  const studentListEl = document.querySelector('#results>tbody');
  const btnCreate = document.querySelector('#submit');

  function createEntry({firstName, lastName, facultyNumber, grade}) {
      const entryEl = createElement('tr', {}, studentListEl);
      createElement('td', {textContent: firstName}, entryEl);
      createElement('td', {textContent: lastName}, entryEl);
      createElement('td', {textContent: facultyNumber}, entryEl);
      createElement('td', {textContent: grade}, entryEl);
  }

  function createEntryHandler(e) {
      const inputs = document.querySelectorAll('div.inputs>input');

      const [firstName, lastName, facultyNumber, grade] = [...inputs].map(i => i.value);

      if (!firstName ||  !lastName || !facultyNumber ||  !grade) return;

      const student = {firstName, lastName, facultyNumber, grade};

      postStudent(baseURL, student, (result) => {
          createEntry(result);
      });
  }

  loadStudents(baseURL, (result) => {
      Object.values(result).forEach(createEntry);
  });

  btnCreate.addEventListener('click', createEntryHandler);
}

document.addEventListener('DOMContentLoaded', init);