function loadPosts(baseURL, onSuccess) {
    fetch(baseURL)
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
  
  function showHideText(e) {
    const divExtra = e.target.parentElement.parentElement.querySelector('div.extra');
    if(e.target.textContent.toLocaleLowerCase() === 'more'){
        divExtra.style.display = 'block';
        e.target.textContent = 'Less';
    } else {
        divExtra.style.display = 'none';
        e.target.textContent = 'More';
    }
}


function init() {
    const baseURL = 'http://localhost:3030/jsonstore/advanced/articles/';
    
    const mainSection = document.querySelector('#main');
  
    function createEntry({_id, title}) {
        const divAccordion = createElement('div', {classList: 'accordion'}, mainSection);

        //Create Head
        const divHead = createElement('div', {classList: 'head'}, divAccordion);
        createElement('span', {textContent: title}, divHead);
        createElement(
            'button', 
            {
                textContent: 'More', 
                classList: 'button', 
                id: _id,
                onclick: showHideText
            }, 
            divHead);
        
        //Create Extra
        const divExtra = createElement('div', {classList: 'extra'}, divAccordion);
        loadPosts(baseURL + 'details/' + _id, (result) => {
            createElement('p', {textContent: result.content}, divExtra);
        });

    }
  
    loadPosts(baseURL + 'list', (result) => {
        Object.values(result).forEach(createEntry);
    });
  }
  
  document.addEventListener('DOMContentLoaded', init);