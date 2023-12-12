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