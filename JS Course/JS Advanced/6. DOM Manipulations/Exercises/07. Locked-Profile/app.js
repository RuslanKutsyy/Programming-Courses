function lockedProfile() {
    const hiddenDataButtonText = "Show more";
    const visibleDataButtonText = "Hide it";
    const hideElement = true;
    
    function GetHiddenData(element) {
        return element.querySelector("div").id;
    }

    function editProfileView(originalElement, newButtonText, dataID, hideInfo){
        originalElement.textContent = newButtonText;
        let neededEl = document.getElementById(dataID);
        hideInfo ? neededEl.style.display = "none" : neededEl.style.display = "block";
    }

    function isHidden(element) {
        return element.textContent === hiddenDataButtonText;
    }

    function isLocked(element) {
        return element.querySelector("input").checked;
    }

    function eventHandler(evt) {
        if (evt.target.tagName == "BUTTON" && !isLocked(evt.target.parentElement)) {
            isHidden(evt.target) ? editProfileView(evt.target, visibleDataButtonText, GetHiddenData(evt.target.parentElement), !hideElement)
            : editProfileView(evt.target, hiddenDataButtonText, GetHiddenData(evt.target.parentElement), hideElement)
        }
    }

    document.getElementById("main").addEventListener("click", function (e) {
        eventHandler(e);
    })
}