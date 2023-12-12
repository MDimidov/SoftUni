function encodeAndDecodeMessages() {
    let message = document.querySelector('textarea[placeholder="Write your message here..."]');
    let encodeMessage = document.querySelector('textarea[placeholder="No messages..."]');
    const buttons = Array.from(document.querySelectorAll("button"));

    buttons.forEach(button => {
        button.addEventListener('click', encodeDecodeMessage)
    })

    function encodeDecodeMessage(e) {
        let command = e.target.textContent;

        if (command === "Encode and send it") {
            let encode = "";
            for (let i = 0; i < message.value.length; i++) {
                encode += nextChar(message.value[i]);
            }
            encodeMessage.value = encode;
            message.value = "";
        }
        else if (command === "Decode and read it") {
            let decode = "";
            for (let i = 0; i < encodeMessage.value.length; i++) {
                decode += previousChar(encodeMessage.value[i]);
            }
            encodeMessage.value = decode;
            console.log(decode)
        }
    }

    function nextChar(c) {
        return String.fromCharCode(c.charCodeAt(0) + 1);
    }

    function previousChar(c) {
        return String.fromCharCode(c.charCodeAt(0) - 1);
    }
}