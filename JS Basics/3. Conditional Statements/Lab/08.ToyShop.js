function ToyShop(input) {
    let excPrice = Number(input.shift());
    let puzzlesCount = Number(input.shift());
    let talkingDollsCount = Number(input.shift());
    let bearsCount = Number(input.shift());
    let minionsCount = Number(input.shift());
    let tracksCount = Number(input.shift());
    let toys = puzzlesCount + talkingDollsCount + bearsCount + minionsCount + tracksCount;

    let puzzlePrice = 2.60;
    let talkingDollPrice = 3.00;
    let bearPrice = 4.10;
    let minionPrice = 8.20;
    let tracksPrice = 2.00;

    let genPrice = puzzlePrice * puzzlesCount + talkingDollPrice * talkingDollsCount + bearPrice * bearsCount + minionPrice
     * minionsCount + tracksPrice * tracksCount;

     if (toys>= 50) {
        genPrice = genPrice * 0.75;
     }
     genPrice = genPrice * 0.9;

     if (genPrice >= excPrice) {
         console.log(`Yes! ${(genPrice - excPrice).toFixed(2)} lv left.`);
     }
     else{
         console.log(`Not enough money! ${(excPrice - genPrice).toFixed(2)} lv needed.`);         
     }

}

ToyShop(['320', '8', '2', '5', '5', '1']);