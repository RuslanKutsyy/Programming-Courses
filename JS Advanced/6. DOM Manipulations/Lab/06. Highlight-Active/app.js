function focus() {
    let body = document.querySelector('body');
    let sections = Array.from(document.querySelectorAll('body > div > div'));
    let lastSection = null;

    sections.forEach(x => x.children[1].addEventListener("focus", function(e) {
        let targetElement = e.target.parentNode;
        let lastSection = sections.filter(x => x.classList.contains('focused'));
        if (lastSection.length) {
            lastSection[0].removeAttribute('class');
        }
        targetElement.classList.add("focused");
        lastSection = targetElement;
    }));
}