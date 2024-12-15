window.addEventListener("load", solve);

function solve() {
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

  const fields = Array.from(document.querySelectorAll('form>input'));
  const previewList = document.querySelector('#preview-list');
  const eventList = document.querySelector('#event-list');
  const btnNext = document.querySelector('#next-btn');
  btnNext.addEventListener('click', createEntry);

  function createEntry(e) {
    e.preventDefault();
    const [email, event, location] = fields.map(f => f.value);
    
    if (email && event && location) {
      const entryLi = createElement('li', {className: 'application', dataset: {email, event, location}}, previewList);
      const article = createElement('article', {}, entryLi);
      createElement('h4', {textContent: email}, article);
      const p1 = createElement('p', {}, article);
      createElement('strong', {textContent: 'Event:'}, p1);
      createElement('br', {}, p1);
      p1.innerHTML += event;

      const p2 = createElement('p', {}, article);
      createElement('strong', {textContent: 'Location:'}, p2);
      createElement('br', {}, p2);
      p2.innerHTML += location;

      createElement('button', {classList: 'action-btn edit', textContent: 'edit', onclick: editHandler}, entryLi);
      createElement('button', {classList: 'action-btn apply', textContent: 'apply', onclick: applyHandler}, entryLi);

      btnNext.disabled = true;
      fields.forEach(f => f.value = '');
    }
  }

  function editHandler(e) {
    const li = e.target.parentElement;
    let input = Object.assign({}, li.dataset);
    input = Object.values(input);

    fields.forEach((f, index) => {
      f.value = input[index];
    });

    btnNext.disabled = false;
    previewList.innerHTML = '';
  }

  function applyHandler(e) {
    const li = e.target.parentElement;
    let eventInfo = Object.assign({}, li.dataset);

    applyEntry(eventInfo);

    previewList.innerHTML = '';
  }

  function applyEntry({email, event, location}) {
    const entryLi = createElement('li', {className: 'application', dataset: {email, event, location}}, eventList);
    const article = createElement('article', {}, entryLi);
    createElement('h4', {textContent: email}, article);
    const p1 = createElement('p', {}, article);
    createElement('strong', {textContent: 'Event:'}, p1);
    createElement('br', {}, p1);
    p1.innerHTML += event;
      
    const p2 = createElement('p', {}, article);
    createElement('strong', {textContent: 'Location:'}, p2);
    createElement('br', {}, p2);
    p2.innerHTML += location;
      
    btnNext.disabled = false;
  }
}