function create(words) {
   const content = document.getElementById("content");
   const boundCreateDiv = createElement.bind(undefined, "div");
   const boundCreateP = createElement.bind(undefined, "p");

   words.forEach(word => {
      let p = boundCreateP();
      p.style.display = "none";
      p.textContent = word;
      p.classList.add("elToShow");
      addToHTML(content, addToHTML(boundCreateDiv(), p));
   })

   function createElement(element) {
      return document.createElement(element);
   }

   function addToHTML(parentElement, childElemt){
      parentElement.appendChild(childElemt);
      return parentElement;
   }

   function eventHandler(evt){
      showElementText(evt);
   }

   function showElementText(evt){
      Array.from(document.getElementsByClassName("elToShow")).forEach(el => {
         if (el == evt.target.firstChild) {
            el.style.display = "block";   
         }
      });
   }

   content.addEventListener("click", function(e){
      eventHandler(e);
   });
}