function notify(message) {
    const notificationDiv = document.getElementById("notification");
    const timeToShow = showTempElement.bind(undefined, notificationDiv, 2000);
    const notificationElement = createElement.bind(undefined, "p", message);

    addToHTML(notificationDiv, notificationElement());
    timeToShow();

    function createElement(type, innerText){
        let element = document.createElement(type);
        element.innerText = innerText;
        return element;
    }

    function addToHTML(parent, element){
        parent.appendChild(element);
        return element;
    }

    function showTempElement(element, miliseconds){
        element.style.display = "block";
        setTimeout(function(){
            element.style.display = "none";
            element.removeChild(notificationDiv.firstElementChild);
        }, miliseconds);
    }




}