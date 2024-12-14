window.addEventListener("load", solve);

function solve() {
  
  function createElement(tag, properties, container) {
    const element = document.createElement(tag);
    
    for (const key of Object.keys(properties)) {
      if (typeof properties[key] === 'object') {
        Object.assign(element[key], properties[key]);
      } else {
        element[key] = properties[key];
      }
    }

    if (container) container.appendChild(element);
      
    return element;
  }

  const fields = document.querySelectorAll('#name, #time, #description');
  const btnAdd  = document.querySelector('#add-btn');

  const previewList = document.querySelector('#preview-list');
  const archiveList = document.querySelector('#archive-list');

  btnAdd.addEventListener('click', function(e) {
    e.preventDefault();

    const [name, time, description] = [...fields].map(f => f.value);

    if (name && time && description) {
      
      createEntry({name, time, description});
      e.target.disabled = true;

      for (const element of fields) {
        element.value = '';
      }
    }
  });

  function createEntry({name, time, description}) {
    const liEl = createElement('li', {dataset: {name, time, description}}, previewList);
    const articleEl = createElement('article', {}, liEl);
    createElement('p', {textContent: name, name: name}, articleEl);
    createElement('p', {textContent: time, time}, articleEl);
    createElement('p', {textContent: description, description}, articleEl);

    const divButtons = createElement('div', {className: 'buttons'}, liEl);
    createElement('button', {textContent: 'Edit', className: 'edit-btn', onclick: editText}, divButtons);
    createElement('button', {textContent: 'Next', className: 'next-btn', onclick: addToEvents}, divButtons);
  }

  function createArchive({name, time, description}) {
    const liEl = createElement('li', {dataset: {name, time, description}}, archiveList);
    const articleEl = createElement('article', {}, liEl);
    createElement('p', {textContent: name, name: name}, articleEl);
    createElement('p', {textContent: time, time}, articleEl);
    createElement('p', {textContent: description, description}, articleEl);

    createElement('button', {textContent: 'Archive', className: 'archive-btn', onclick: archiveEvent}, liEl);
  }

  function editText(e) {
    const pEl = previewList.querySelectorAll('li>article>p');
    for (let i = 0; i < pEl.length; i++) {
      fields[i].value = pEl[i].textContent;

      previewList.innerHTML = '';
      btnAdd.disabled = false;      
    }
  }

  function addToEvents() {
    const pEl = previewList.querySelectorAll('li>article>p');
    const [name, time, description] = [...pEl].map(p => p.textContent);

    if (name && time && description) {
      createArchive({name, time, description});
    }

    previewList.innerHTML = '';
  }

  function archiveEvent() {
    archiveList.innerHTML = '';
    btnAdd.disabled = false;
  }
}