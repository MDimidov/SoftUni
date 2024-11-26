function solve() {
    const menu = document.querySelector("#selectMenuTo");
    const option = document.createElement("option");
    const option2 = document.createElement("option");
    option.text = "Binary";
    option.value = "binary";
    option2.text = "Hexadecimal";
    option2.value = "hexadecimal";
    menu.appendChild(option);
    menu.appendChild(option2);

    const button = document.querySelector("button");
    button.onclick = onClick;

    function onClick() {
        const num = Number(document.querySelector("#input").value);
        const result = document.querySelector("#result");

        if (menu.value === "binary") {
            let binary = num.toString(2);
            result.value = binary;
        } else if (menu.value === "hexadecimal") {
            let hexadecimal = num.toString(16);
            result.value = hexadecimal.toUpperCase();
        }
    }

}

// -----------------Method 2--------------------

function solve() {
    const button = document.querySelector('#container>button');
    button.onclick = onClick;

    const menu = document.querySelector("#selectMenuTo");
    const option = document.createElement("option");
    const option2 = document.createElement("option");
    option.text = "Binary";
    option.value = "binary";
    option2.text = "Hexadecimal";
    option2.value = "hexadecimal";
    menu.appendChild(option);
    menu.appendChild(option2);
    

    function onClick() {
        const inputNum = Number(document.querySelector('#input').value);
        const selectedTransfer = Array.from(document.querySelectorAll('#selectMenuTo>option')).find(o => o.selected);
        const result = document.querySelector('#result');
        
        if (selectedTransfer === option) {
            result.value = inputNum.toString(2);
        } else if (selectedTransfer === option2) {
            result.value = inputNum.toString(16).toUpperCase();
        }
    }
}