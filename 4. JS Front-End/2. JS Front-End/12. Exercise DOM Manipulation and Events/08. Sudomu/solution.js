function solve() {
    const [quickCheckBtn, clearBtn] = document.querySelectorAll("button");
    const rows = Array.from(document.querySelectorAll('tbody tr'));

    clearBtn.addEventListener('click', () => {
        for (const row of rows) {
            boxes = Array.from(row.children)

            for (const box of boxes) {
                box.firstElementChild.value = "";
            }
        }
    });
    quickCheckBtn.addEventListener('click', checkSolution);

    function checkSolution(e) {
        matrix = [];
        for (const row of rows) {
            boxes = Array.from(row.children)
            array = [];

            for (const box of boxes) {
                let input = box.firstElementChild;
                let inputNum = Number(input.value);
                if (inputNum <= input.max && inputNum >= input.min) {
                    array.push(inputNum);
                } else {
                    return error();
                }
            }
            matrix.push(array);
        }
        let reverseMatrix = changeMatrix(matrix);
        if (compareArrays(matrix) && compareArrays(reverseMatrix)) {
            successSolution();
        }
    }

    function error() {
        let table = document.querySelector("table");
        table.style.border = '2px solid red';
        let errorMessage = document.querySelector('#check p');
        errorMessage.style.color = "red";
        errorMessage.textContent = 'NOP! You are not done yet...';
    }

    function successSolution() {
        let table = document.querySelector("table");
        table.style.border = '2px solid green';
        let errorMessage = document.querySelector('#check p');
        errorMessage.style.color = "green";
        errorMessage.textContent = 'You solve it! Congratulations!';
    }

    function compareArrays(arrayToCompare) {
        for (let i = 0; i < arrayToCompare.length; i++) {
            for (let j = 0; j < arrayToCompare[i].length; j++) {
                if (arrayToCompare[i][i] === arrayToCompare[i][j] && i !== j) {
                    error();
                    return false
                }
            }
        }
        return true;
    }

    function changeMatrix(matrix) {
        let result = [];
        for (let i = 0; i < matrix.length; i++) {
            let tempArr = [];
            for (let j = 0; j < matrix.length; j++) {
                tempArr.push(matrix[j][i]);
            }
            result.push(tempArr)
        }
        return result;
    }
}