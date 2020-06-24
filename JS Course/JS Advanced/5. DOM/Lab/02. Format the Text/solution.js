function solve() {
  let input = document.querySelector("div > p");
  let output = document.getElementById("output");

  if (input == null) {
    throw new Error("Missing input.");
  }

  let txt = input.innerHTML.split(".").filter(x => x !== '');

  for (let i = 0; i < txt.length; i+=3) {
    let p = document.createElement("p");
    p.innerHTML = txt.slice(i, i+3).join(". ") + '.';
    output.appendChild(p);
  }
}

document.addEventListener("DOMContentLoaded", function(){
  document.getElementById("formatItBtn").addEventListener("click", solve);
});