function addItem() {
    let text = document.querySelector("#newItemText");
    let value = document.querySelector("#newItemValue");
    const menu = document.querySelector("#menu");
    let option = document.createElement('option');

    option.value = value.value;
    option.textContent = text.value;

    menu.appendChild(option);
    text.value = '';
    value.value = '';
}

// -----------------Method 2--------------------

function addItem() {
    const dropDownMenu = document.querySelector('#menu');
    const optionElement = document.createElement('option');

    const newItemText = document.querySelector('#newItemText');
    const newItemValue = document.querySelector('#newItemValue');

    optionElement.textContent = newItemText.value;
    optionElement.value = newItemValue.value;
    dropDownMenu.appendChild(optionElement);

    newItemText.value = '';
    newItemValue.value = '';
}