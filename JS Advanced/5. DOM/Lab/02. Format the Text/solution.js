function solve() {
  let originalText = document.getElementById("input").innerText;
  let textArr = originalText.split('.').filter(x => x);
  let resultArr = [];
  let text = '';
  if (textArr.length <= 3) {
    textArr.forEach(x => text += x);
    resultArr.push(text);
  } else {
    while (textArr.length){
      let tempArr = textArr.slice(0, 3);
      text = tempArr.join(". ") + ".";
      resultArr.push(text);
      textArr.splice(0, 3);
    }
  }

  let exerciseSection = document.getElementById('output');

  for (let el of resultArr) {
    let par = document.createElement('p');
    let textNode = document.createTextNode(el);
    par.appendChild(textNode);
    exerciseSection.appendChild(par);
  }
}