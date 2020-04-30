function addItem() {
    let list = document.getElementById('items');
    let newElement = document.createElement('li');
    let inputValue = document.querySelectorAll('input')[0].value;
    newElement.textContent = inputValue;
    list.appendChild(newElement);
    document.querySelectorAll('input')[0].value = '';
}