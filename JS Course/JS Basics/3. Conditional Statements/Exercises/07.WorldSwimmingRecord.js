function WorldSwimRecord(input) {
    let recordInSeconds = input.shift();
    let distanceinMeters = input.shift();
    let timeFor1Meter = input.shift();

    let swimTime = distanceinMeters * timeFor1Meter;
    let delayTime = Math.floor(distanceinMeters/15) * 12.5;
    let genTime = swimTime + delayTime;

    if (genTime < recordInSeconds) {
        console.log(`Yes, he succeeded! The new world record is ${genTime.toFixed(2)} seconds.`);        
    }
    else{
        console.log(`No, he failed! He was ${(genTime - recordInSeconds).toFixed(2)} seconds slower.`);
    }
}

WorldSwimRecord(["55555.67", "3017", "5.03"]);