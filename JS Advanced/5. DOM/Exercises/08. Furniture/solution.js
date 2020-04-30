function solve() {
  let generateButton = document.querySelectorAll("#exercise > button")[0];
  let buyButton = document.querySelectorAll("#exercise > button")[1];
  let table = document.querySelector("#exercise > div > div > div > div > table > tbody");
  let outputTextArea = document.querySelectorAll("#exercise > textarea")[1];
  //table.querySelector("input").disabled = false;

  generateButton.addEventListener('click', generate);
  buyButton.addEventListener('click', buy);

  function generate() {
    let textInput = document.querySelector("#exercise > textarea").value;
    let products = JSON.parse(textInput);
    for (let product of products) {
      let tr = document.createElement("tr");
      let innerTd = `<td><img src="${product.img}"></td>`;
      innerTd += `<td><p>${product.name}</p></td>`;
      innerTd += `<td><p>${product.price}</p></td>`;
      innerTd += `<td><p>${product.decFactor}</p></td>`;
      innerTd += "<td><input type=\"checkbox\"></td>";

      tr.innerHTML = innerTd;
      table.appendChild(tr);
    }
  }

  function buy() {
    let checked = Array.from(table.children).filter((x) => x.children[4].firstChild.checked);
    let names = checked.map(x => x.children[1].innerText);
    let sum = checked.map(x => Number(x.children[2].innerText)).reduce((acc, price) => acc + price);
    let factors = checked.map(x => Number(x.children[3].innerText));
    let averageFactor = factors.reduce((acc, factor) => acc + factor) / factors.length;
    outputTextArea.value += `Bought furniture: ${names.join(", ")}\n`;
    outputTextArea.value += `Total price: ${sum.toFixed(2)}\n`;
    outputTextArea.value += `Average decoration factor: ${averageFactor}`;
  }
}