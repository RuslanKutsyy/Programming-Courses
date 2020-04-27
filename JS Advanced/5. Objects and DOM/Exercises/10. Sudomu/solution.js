function solve() {
    let mainSudokuTable = document.querySelector("#exercise > table");
    let internalTable = document.querySelector("#exercise > table > tbody");
    let emptyTable = internalTable.innerHTML;
    let buttons = Array.from(document.querySelectorAll("button"));
    let checkText = document.getElementById('check').children[0];
    let solved = true;

    buttons.forEach(button => button.addEventListener('click', function (e) {
        e.target.textContent === "Clear" ? clearTable() : sudokuCheck();
    }));

    function clearTable() {
        internalTable.innerHTML = emptyTable;
        mainSudokuTable.removeAttribute('style');
        checkText.textContent = '';
    }

    function sudokuCheck() {
        let sudokuMatrix = [];
        for (let row of Array.from(internalTable.children)) {
            let internalRowArray = [];
            for (let cell of Array.from(row.children)) {
                internalRowArray.push(Number(cell.children[0].value));
            }
            sudokuMatrix.push(internalRowArray);
        }

        for (let index = 0; index < sudokuMatrix.length; index++) {
            let internalArray = sudokuMatrix[index];
            for (let intindex = 0; intindex < internalArray.length; intindex++) {
                let tempArr = internalArray.filter(x => x === internalArray[intindex]);
                if (tempArr.length > 1) {
                    solved = false;
                    break;
                }
            }
            if (!solved) {
                break;
            }
        }

        colorSudoku();
    }

    function colorSudoku() {
        if (solved) {
            mainSudokuTable.style.border = '2px solid green';
            checkText.textContent = 'You solve it! Congratulations!';
        } else {
            mainSudokuTable.style.border = '2px solid red';
            checkText.textContent = 'NOP! You are not done yet...';
        }
    }
}