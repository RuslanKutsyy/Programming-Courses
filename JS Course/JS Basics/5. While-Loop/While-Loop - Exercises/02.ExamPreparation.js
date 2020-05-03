function ExamPrep(input) {
    let fails = parseInt(input.shift());
    let cmd = input.shift();
    let lastExercise;
    let failsCount = 0;
    let scoreSum = 0;
    let failed = false;
    let exerciseCount = 0;

    while (true) {
        if (failsCount ==  fails || cmd == "Enough") {
            break;
        }
        let grade = parseFloat(input.shift());
        if (grade <= 4.00) {
            failsCount++;
            if (failsCount == fails) {
                failed = true;
            }
        }
        scoreSum+= grade;
        exerciseCount++;
        lastExercise = cmd;
        cmd = input.shift();
    }

    if (!failed) {
        console.log(`Average score: ${(scoreSum/exerciseCount).toFixed(2)}`);
        console.log(`Number of problems: ${exerciseCount}`);
        console.log(`Last problem: ${lastExercise}`);
    } else {
        console.log(`You need a break, ${failsCount} poor grades.`);
    }
}
ExamPrep([
    "2",
    "Income",
    "3",
    "Game Info",
    "6",
    "Best Player",
    "4"
]);