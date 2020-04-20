function solve() {
    let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
    let correct = 0;
    let current = 0;
    
    Array.from(document.querySelectorAll(".answer-text")).map((x) => x.addEventListener('click', function(el){
        if (correctAnswers.includes(el.target.innerHTML)) {
            correct++;
        }
        let currentQuestion = document.querySelectorAll("section")[current];
        currentQuestion.style.display = "none";

        if (document.querySelectorAll("section")[current + 1] != undefined) {
            let nextQuestion = document.querySelectorAll("section")[current + 1];
            nextQuestion.style.display = "block";
            current++;
        } else {
            document.getElementById("results").style.display = "block";
            if (correct != 3) {
                document.getElementsByClassName("results-inner")[0].children[0].innerHTML =
                    `You have ${correct} right answers`;
            } else {
                document.getElementsByClassName("results-inner")[0].children[0].innerHTML =
                    "You are recognized as top JavaScript fan!";

            }
        }
    }));
}