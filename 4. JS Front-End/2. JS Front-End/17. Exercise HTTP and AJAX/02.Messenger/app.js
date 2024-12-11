function attachEvents() {
    const baseURL = 'http://localhost:3030/jsonstore/messenger';
    const textarea = document.querySelector('#messages');
    const btnSubmit = document.querySelector('#submit');
    const btnRefresh = document.querySelector('#refresh');
    
    btnRefresh.addEventListener('click', getMessages);
    btnSubmit.addEventListener('click', addMessage);
    
    function getMessages() {
        const text = [];

        fetch(baseURL)
            .then((response) => response.json())
            .then((messages) => {
                for (const key of Object.keys(messages)) {
                    text.push(`${messages[key].author}: ${messages[key].content}`);
                }

                textarea.textContent = text.join('\n')
            })
            .catch((error) => console.error(error));
    }

    function addMessage() {
        const authorName = document.querySelector('input[name="author"]');
        const content = document.querySelector('input[name="content"]');
        const data = {
            author: authorName.value,
            content: content.value
        };

        fetch(baseURL, {
            method: 'POST',
            headers: {'Content-Type': 'application/json'}, 
            body: JSON.stringify(data)
        })
        .catch((error) => console.error(error));

        authorName.value = '';
        content.value = '';

        // If you want tho refresh messages automatic
        // btnRefresh.click();
    }

    btnRefresh.click();
}

attachEvents();