function CalculateTime(input) {
    let first = Number(input.shift());
    let second = Number(input.shift());
    let third = Number(input.shift());
    let allSeconds = first + second + third;
    
    let minutes = Math.floor(allSeconds/60);
    let seconds = allSeconds % 60;

    if (seconds < 10) {
        console.log(`${minutes}:0${seconds}`);
    }
    else{
        console.log(`${minutes}:${seconds}`);
    }
}
CalculateTime(["14", "12", "10"]);
