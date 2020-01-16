function fruit(arg1, arg2, arg3) {
    let fruitName = arg1;
    let weightInKG = Number(arg2)/1000;
    let pricePerKG = Number(arg3);

    let genPrice = weightInKG * pricePerKG;

    console.log(`I need $${genPrice.toFixed(2)} to buy ${weightInKG.toFixed(2)} kilograms ${fruitName}.`);
}

fruit('apple', 1563, 2.35);