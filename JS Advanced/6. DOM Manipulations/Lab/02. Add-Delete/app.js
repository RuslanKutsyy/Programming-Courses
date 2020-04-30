function addItem() {
    let list = document.getElementById('items');
    let newElement = document.createElement('li');
    let inputValue = document.querySelectorAll('input')[0].value + " ";
    newElement.appendChild(document.createTextNode(inputValue));
    let deleteURL = document.createElement('a');
    deleteURL.innerText = "[Delete]";
    deleteURL.href = '#';
    deleteURL.addEventListener('click', function(e){
        this.parentElement.remove();

        //e.preventDefault();
    })

    list.appendChild(newElement);
    document.querySelectorAll('input')[0].value = '';

    newElement.appendChild(deleteURL);
}