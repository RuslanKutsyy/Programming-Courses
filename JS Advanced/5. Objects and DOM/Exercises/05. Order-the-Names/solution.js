function solve() {
    let inputButton = document.querySelector('button');
    let list = document.querySelectorAll('li');
    
    inputButton.addEventListener('click', function(){
        let inputText = document.querySelector('input').value;
        let letter = inputText[0].toUpperCase();
        inputText = letter + inputText.substr(1).toLowerCase();
        let elementIndex = Number(letter.charCodeAt()) - 65;
        if (list[elementIndex].innerHTML === "") {
            list[elementIndex].innerHTML = inputText;
        } else {
            list[elementIndex].innerHTML += `, ${inputText}`;
        }
        document.querySelector('input').value = ''; 
    })
}