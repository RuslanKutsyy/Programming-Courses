function NewHome(input) {
    let flowers = input.shift();
    let numOfFlowers = parseInt(input.shift());
    let budget = parseInt(input.shift());

    let rosePrice = 5;
    let dahliaPrice = 3.80;
    let TulipsPrice = 2.80;
    let NarcissusPrice = 3;
    let GladiolusPrice = 2.50;

    let result = 0;

    if (flowers == "Roses") {
        if (numOfFlowers > 80) {
            result = (rosePrice * numOfFlowers) * 0.9;
        } else{
            result = rosePrice * numOfFlowers;
        }
    } else if (flowers == "Dahlias") {
        if (numOfFlowers > 90) {
            result = (dahliaPrice * numOfFlowers) * 0.85;
        } else {
            result = dahliaPrice * numOfFlowers;
        }
    } else if (flowers == "Tulips") {
        if (numOfFlowers > 80) {
            result = (TulipsPrice * numOfFlowers) * 0.85;
        } else {
            result = TulipsPrice * numOfFlowers;
        }
    } else if (flowers == "Narcissus") {
        if (numOfFlowers < 120) {
            result = NarcissusPrice * numOfFlowers * 1.15;
        } else{
            result = NarcissusPrice * numOfFlowers;
        }
    } else if (flowers == "Gladiolus") {
        if (numOfFlowers < 80) {
            result = GladiolusPrice * numOfFlowers * 1.2;
        } else {
            result = GladiolusPrice * numOfFlowers;
        }
    }

    if (budget >= result) {
        console.log(`Hey, you have a great garden with ${numOfFlowers} ${flowers} and ${(budget - result).toFixed(2)} leva left.`);
    } else{
        console.log(`Not enough money, you need ${(result - budget).toFixed(2)} leva more.`);
    }
}

NewHome(["Tulips", 88, 260]);