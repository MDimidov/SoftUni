function Occurrences(text, word) {
    let array = text.split(' ');
    let result = 0;
    array.forEach(element => {
        if(element === word){
            result++;
        }
    });

    console.log(result);
}


Occurrences('This is a word and it also is a sentence', 'is');