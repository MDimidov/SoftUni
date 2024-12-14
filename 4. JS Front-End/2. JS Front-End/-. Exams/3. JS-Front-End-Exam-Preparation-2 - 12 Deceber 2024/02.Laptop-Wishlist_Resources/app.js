window.addEventListener("load", solve);

function solve() {
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

    const fields = [...document.querySelectorAll('input[type][id]')];
    const btnAdd = document.querySelector('#add-btn');
    const checkList = document.querySelector('#check-list');
    const laptopsList = document.querySelector('#laptops-list');
    const btnClear = document.querySelector('button.btn.clear');
    
    btnClear.addEventListener('click', () => {
      location.reload();
    });

    btnAdd.addEventListener('click', createEntry);

    function createEntry() {
      let [model, storage, price] = fields.map(f => f.value);

      if (model && storage && price) {
        const entryLi = createElement('li', {className: 'laptop-item', dataset: {model, storage, price}}, checkList);
        const article = createElement('article', {}, entryLi);
        createElement('p', {textContent: model}, article);
        createElement('p', {textContent: `Memory: ${storage} TB`}, article);
        createElement('p', {textContent: `Price: ${price}$`}, article);
        createElement('button', {classList: 'btn edit', textContent: 'edit', onclick: editHandler}, entryLi);
        createElement('button', {classList: 'btn ok', textContent: 'ok', onclick: addToWishlist}, entryLi);

        btnAdd.disabled = true;
        fields.forEach(f => f.value = '');
      }
    }

    function createWishEntry({model, storage, price}) {
      const entryLi = createElement('li', {className: 'laptop-item', dataset: {model, storage, price}}, laptopsList);
      const article = createElement('article', {}, entryLi);
      createElement('p', {textContent: model}, article);
      createElement('p', {textContent: `Memory: ${storage} TB`}, article);
      createElement('p', {textContent: `Price: ${price}$`}, article);
    }

    function editHandler(e) {
      const laptopInfo = e.target.closest('li.laptop-item').dataset;

      Object.values(laptopInfo).forEach((value, i) => {
        fields[i].value = value
      });

      btnAdd.disabled = false;
      checkList.innerHTML = '';
    }

    function addToWishlist(e) {
      const laptopInfo = e.target.closest('li.laptop-item').dataset;

      const laptop = Object.assign({}, laptopInfo);
      createWishEntry(laptop);

      btnAdd.disabled = false;
      checkList.innerHTML = '';
    }
  }
  