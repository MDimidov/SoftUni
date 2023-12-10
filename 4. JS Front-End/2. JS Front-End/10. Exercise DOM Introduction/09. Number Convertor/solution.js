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