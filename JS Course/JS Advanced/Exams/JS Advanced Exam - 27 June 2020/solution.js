function solve() {
    const inputSection = document.getElementById("container");
    const nameInput = inputSection.children[0];
    const ageInput = inputSection.children[1];
    const kindInput = inputSection.children[2];
    const ownerInput = inputSection.children[3];
    const addBtn = document.querySelector("button");
    const adoptionSection = document.getElementById("adoption");
    const adoptedSection = document.getElementById("adopted");
    const contactWithOwnersBtn = document.createElement("button");
    contactWithOwnersBtn.textContent = "Contact with owners";
    const takeBtn = document.createElement("button");
    takeBtn.textContent = "Yes! I take it!";
    const checked = document.createElement("button");
    checked.textContent = "Checked";

    function createLiElement(name, age, kind, owner){
        let el = document.createElement("li")
        let textContent = document.createElement("p");
        textContent.innerHTML = `<strong>${name}</strong> is a <strong>${age}</strong> year old <strong>${kind}</strong>`;
        let span = document.createElement("span");
        span.textContent = `Owner: ${owner}`;
        let btn = document.createElement("button");
        btn.textContent = "Contact with owner";
        el.appendChild(textContent);
        el.appendChild(span);
        el.appendChild(btn);

        return el;
    }

    function createDivElement(){
        let el = document.createElement("div");
        let input = document.createElement("input");
        let btn = document.createElement("button");
        input.setAttribute('placeholder','Enter your names');
        btn.textContent = "Yes! I take it!";
        el.appendChild(input);
        el.appendChild(btn);

        btn.addEventListener("click", (e) => {
            addCheckedAnimal(e);
        });

        return el;
    }

    function addCheckedAnimal(e){
        e.preventDefault();
        let input = e.target.previousElementSibling;
        let ownerName = input.value;
        if (ownerName){
            let liEl = e.target.parentNode.parentNode;
            let span = liEl.querySelector("span");
            span.textContent = `New Owner: ${ownerName}`;
            liEl.removeChild(liEl.lastChild);
            liEl.appendChild(checked);
            let ul = adoptedSection.querySelector("ul");
            ul.appendChild(liEl);
            checked.addEventListener("click", (e) => {
                deleteAnimal(e, ul);
            })
        }
    }

    function deleteAnimal(e, ul){
        let parent = e.target.parentNode;
        ul.removeChild(parent);
    }

    addBtn.addEventListener("click", function (e){
        e.preventDefault();
        const name = nameInput.value;
        const age = Number(ageInput.value);
        const kind = kindInput.value;
        const owner = ownerInput.value;
        const adoptionList = adoptionSection.children[1];
        if (name && age && kind && owner){
            let element = createLiElement(name, age, kind, owner);
            adoptionList.appendChild(element);
            element.querySelector("button").addEventListener("click", function (e){
                e.preventDefault();
                let parent = e.target.parentNode;
                let div = createDivElement();
                parent.removeChild(parent.lastChild);
                parent.appendChild(div);
            })
        }

        nameInput.value = "";
        ageInput.value = "";
        kindInput.value = "";
        ownerInput.value = "";
    });
}

