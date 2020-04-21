function solve() {
    let buttons = document.getElementsByTagName("button");
    let expressionOutput = document.getElementById("expressionOutput");
    let resultOutput = document.getElementById("resultOutput");

    Array.from(buttons).map((x) => x.addEventListener('click', function(e){
        if (e.target.value === "Clear") {
            expressionOutput.innerHTML = "";
            resultOutput.innerHTML = "";
        } else if (e.target.value === "="){
            try {
                resultOutput.innerHTML = eval(expressionOutput.innerHTML);
            } catch (error) {
                resultOutput.innerHTML = "NaN";
            }
        } else if (e.target.value === "+" || e.target.value === "-" || e.target.value === "*" || e.target.value === "/") {
            expressionOutput.innerHTML += ` ${e.target.value} `;
        } else {
            expressionOutput.innerHTML += e.target.value;
        }
    }))
}