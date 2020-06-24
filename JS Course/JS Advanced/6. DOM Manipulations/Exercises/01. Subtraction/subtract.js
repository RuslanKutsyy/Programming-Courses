function subtract() {
    let firstField = document.getElementById("firstNumber");
    let secondField = document.getElementById("secondNumber");
    let output = document.getElementById("result");

    output.textContent = Number(firstField.value) - Number(secondField.value);
}