function CalorieObject(input) {
    let newArrLength = input.length / 2;
    let finalArr = [];

    for (let i = 0; i < newArrLength; i++) {
        let product = input.shift();
        let calories = input.shift();
        let data = product + ': ' + calories;
        finalArr.push(data);
    }

    console.log(`{ ${finalArr.join(', ')} }`);
    
}

CalorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);