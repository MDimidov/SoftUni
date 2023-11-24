function Censore(text, word) {
    let censored = text.replace(word, '*'.repeat(word.length));
    while (censored.includes(word)){
        censored = censored.replace(word, '*'.repeat(word.length));
    }

    console.log(censored)
}

Censore('Find the hidden word hidden', 'hidden')