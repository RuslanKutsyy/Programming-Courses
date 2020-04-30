function solve() {
  let arrOfSites = Array.from(document.querySelectorAll("div")[2].getElementsByClassName("link-1"));
  arrOfSites.forEach(el => (el.children)[0].addEventListener("click", function (){onclickAction(el)}));

  function onclickAction(el){
    let paragraph = el.children[1];
    let dataInP = paragraph.textContent.split(" ");
    dataInP[1] = parseInt(dataInP[1]) + 1;
    paragraph.textContent = dataInP.join(" ");
  }
}