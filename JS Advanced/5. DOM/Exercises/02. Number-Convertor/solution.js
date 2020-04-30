function solve() {
    let dropdown = document.getElementById('selectMenuTo');

    let firstOption = document.createElement('option');
    firstOption.value = "binary";
    firstOption.textContent = "Binary";
    dropdown.add(firstOption);

    let newOption = document.createElement('option');
    newOption.setAttribute('value', 'hexadecimal');
    newOption.text = "Hexadecimal";
    dropdown.add(newOption);
    
    document.getElementsByTagName('button')[0].addEventListener('click', function(){
        let number = parseInt(document.getElementById("input").value);
        let result = document.getElementById("result");
        if (dropdown.value === 'binary') {
            result.value = number.toString(2);
        } else if(dropdown.value === 'hexadecimal') {
            result.value = number.toString(16).toUpperCase();
        }
    });
}