function FruitShop(input) {
    let fruit = input.shift();
    let day = input.shift();
    let quantity = Number(input.shift());
    let fruitPrice = 0;

    if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday") {
        if (fruit == "banana") {
            fruitPrice = 2.50;
        }
        else if (fruit == "apple") {
            fruitPrice = 1.20;
        }
        else if (fruit == "orange") {
         fruitPrice = 0.85;   
        }
        else if (fruit == "grapefruit") {
            fruitPrice = 1.45;
        }
        else if(fruit =="kiwi"){
            fruitPrice = 2.70;
        }
        else if (fruit == "pineapple") {
            fruitPrice = 5.50;
        }
        else if (fruit == "grapes") {
            fruitPrice = 3.85;
        }
        else{
            console.log("error");
            return;
        }
    }
    else if(day == "Saturday" || day == "Sunday"){
        if (fruit == "banana") {
            fruitPrice = 2.70;
        }
        else if (fruit == "apple") {
            fruitPrice = 1.25;
        }
        else if (fruit == "orange") {
         fruitPrice = 0.90;   
        }
        else if (fruit == "grapefruit") {
            fruitPrice = 1.60;
        }
        else if(fruit =="kiwi"){
            fruitPrice = 3.00;
        }
        else if (fruit == "pineapple") {
            fruitPrice = 5.60;
        }
        else if (fruit == "grapes") {
            fruitPrice = 4.20;
        }
        else{
            console.log("error");
            return;
        }
    }
    else{
        console.log("error");
        return;        
    }

    let genPrice = fruitPrice * quantity;

    console.log(`${genPrice.toFixed(2)}`);


}
FruitShop(["apple", "Tuesday", "2"]);