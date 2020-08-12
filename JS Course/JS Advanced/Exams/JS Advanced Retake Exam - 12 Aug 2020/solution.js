function solve() {
    const inputSection = document.getElementById("container");
    const nameInput = inputSection.children[0];
    const hallInput = inputSection.children[1];
    const priceInput = inputSection.children[2];
    const onScreenBtn = inputSection.querySelector("button");
    const onScreenSection = document.getElementById("movies");
    const archiveSection = document.getElementById("archive");
    const archivedUl = archiveSection.querySelector("ul");
    const clearBtn = archiveSection.querySelector("button");

    function createLiElement(name, hall, price){
        let el = document.createElement("li")
        let span = document.createElement("span");
        span.innerText = `${ name }`;
        let strongEl = document.createElement("strong");
        strongEl.innerText = `Hall: ${ hall }`;
        el.appendChild(span);
        el.appendChild(strongEl);

        el.appendChild(createDivElement(price));

        return el;
    }

    function createDivElement(price){
        let archiveBtn = document.createElement("button");
        archiveBtn.textContent = "Archive";
        let innerDiv = document.createElement("div");
        let innerDivStrong = document.createElement("strong");
        innerDivStrong.textContent = `${ price.toFixed(2) }`;
        let input = document.createElement("input");
        input.setAttribute("placeholder", "Tickets Sold")
        innerDiv.appendChild(innerDivStrong);
        innerDiv.appendChild(input);
        innerDiv.appendChild(archiveBtn);

        return innerDiv;
    }

    function moveToArchive(e,inputValue, price){
        e.preventDefault();
        const deleteFromArchiveBtn = document.createElement("button");
        deleteFromArchiveBtn.textContent = "Delete";
        let totalPrice = inputValue * price;
        let parentLi = e.target.parentNode.parentNode;
        let strongElement = parentLi.querySelector("strong");
        parentLi.removeChild(e.target.parentNode);
        strongElement.innerText = `Total amount: ${ totalPrice.toFixed(2) }`;
        parentLi.appendChild(deleteFromArchiveBtn);

        deleteFromArchiveBtn.addEventListener("click", (e) => {
            deleteArchivedMovies(e);
        });

        archivedUl.appendChild(parentLi);
    }

    function deleteArchivedMovies(e){
        archivedUl.removeChild(e.target.parentNode);
    }

    onScreenBtn.addEventListener("click", function (e){
        e.preventDefault();
        const name = nameInput.value;
        const hallName = hallInput.value;
        const price = Number(priceInput.value);
        const moviesList = onScreenSection.children[1];
        if (name && hallName && price){
            let element = createLiElement(name, hallName, price);
            moviesList.appendChild(element);
            element.querySelector("button").addEventListener("click", (e) => {
                let inputValue = Number(element.querySelector("input").value);
                if (inputValue && inputValue > 0){
                    moveToArchive(e, inputValue, price);
                }
            });
        }

        clearBtn.addEventListener("click", (e) => {
            e.preventDefault();
            archivedUl.innerHTML = "";
        });

        nameInput.value = "";
        hallInput.value = "";
        priceInput.value = "";
    });
}