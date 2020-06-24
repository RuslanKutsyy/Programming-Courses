function addItem() {
    let optionText = document.getElementById("newItemText");
    let optionValue = document.getElementById("newItemValue");
    let dropdown = document.getElementById("menu");
    if (optionText == null || optionValue == null) {
        throw new Error("No Text/Value");
    }

    let optionEl = document.createElement("option");
    optionEl.textContent = optionText.value;
    optionEl.value = optionValue.value;
    dropdown.appendChild(optionEl);

    optionText.value = null;
    optionValue.value = null;
}