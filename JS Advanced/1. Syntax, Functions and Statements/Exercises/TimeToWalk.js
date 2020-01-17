function timeToWalk(arg1, arg2, arg3) {
    let steps = arg1;
    let footPrintLength = arg2;
    let speedForSecond = arg3*1000/3600;

    let distanceInMeters = steps * footPrintLength;
    let breaks = Math.floor(distanceInMeters / 500);
    let timeInSeconds = distanceInMeters/speedForSecond + breaks * 60;
    let seconds = Math.round(timeInSeconds % 60);
    let minutes = Math.round(timeInSeconds - seconds) / 60;
    let hours = Math.floor(timeInSeconds / 3600);

    if (hours<10) {
        hours = '0'+ hours;
    }
    if (minutes < 10) {
        minutes = '0' + minutes;
    }

    if (seconds < 10) {
        seconds = '0' + seconds;
    }
    
    console.log(`${hours}:${minutes}:${seconds}`);
    
}

timeToWalk(2564, 0.70, 5.5);