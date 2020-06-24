function toggle() {
    let btn = document.querySelector("span");
    let extraP = document.getElementById("extra");

    extraP.style.display === "none" ? changeElementDisplayState(extraP, "block", btn, "Less") : changeElementDisplayState(extraP, "none", btn, "More");

    function changeElementDisplayState(el, displayState, button, btnText){
        el.style.display = displayState;
        button.textContent = btnText;
    }
}