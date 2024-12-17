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

  const inputs = {email, event, location};
  // const fields = Array.from(document.querySelectorAll('form>input'));
  const emailInput = document.querySelector('#email');
  const eventInput = document.querySelector('#event');
  const locationInput = document.querySelector('#location');
  const previewList = document.querySelector('#preview-list');
  const eventList = document.querySelector('#event-list');
  const btnNext = document.querySelector('#next-btn');
  btnNext.addEventListener('click', createEntry);

  function createEntry(e) {
    e.preventDefault();
    inputs.email = emailInput.value;
    inputs.event = eventInput.value;
    inputs.location = locationInput.value;
    console.log(inputs)
    
    if (inputs.email && inputs.event && inputs.location) {
      const entryLi = createElement('li', {className: 'application'}, previewList);
      const article = createElement('article', {}, entryLi);
      createElement('h4', {textContent: inputs.email}, article);
      const p1 = createElement('p', {}, article);
      createElement('strong', {textContent: 'Event:'}, p1);
      createElement('br', {}, p1);
      p1.innerHTML += inputs.event;

      const p2 = createElement('p', {}, article);
      createElement('strong', {textContent: 'Location:'}, p2);
      createElement('br', {}, p2);
      p2.innerHTML += inputs.location;

      createElement('button', {classList: 'action-btn edit', textContent: 'edit', onclick: editHandler}, entryLi);
      createElement('button', {classList: 'action-btn apply', textContent: 'apply', onclick: applyHandler}, entryLi);

      btnNext.disabled = true;
      // fields.forEach(f => f.value = '');
      emailInput.value = '';
      eventInput.value = '';
      locationInput.value = '';
    }
  }

  function editHandler(e) {
    // let input = Object.values(inputs);

    // fields.forEach((f, index) => {
    //   f.value = input[index];
    // });

    emailInput.value = inputs.email;
    eventInput.value = inputs.event;
    locationInput.value = inputs.location;

    btnNext.disabled = false;
    previewList.innerHTML = '';
  }

  function applyHandler() {
    applyEntry(inputs);

    previewList.innerHTML = '';
  }

  function applyEntry({email, event, location}) {
    const entryLi = createElement('li', {className: 'application'}, eventList);
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