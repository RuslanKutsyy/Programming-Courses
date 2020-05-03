function CinemaPriceCalculator(input) {
    let PremierPrice = 12.00;
    let NormalPrice = 7.50;
    let DiscountPrice = 5.00;

    let ProjectionType = input.shift();
    let rows = parseInt(input.shift());
    let cols = parseInt(input.shift());

    if (ProjectionType == "Premiere") {
        console.log(`${(PremierPrice * rows * cols).toFixed(2)} leva`);
    } else if (ProjectionType == "Normal") {
        console.log(`${(NormalPrice * rows * cols).toFixed(2)} leva`);        
    } else if (ProjectionType == "Discount") {
        console.log(`${(DiscountPrice * rows * cols).toFixed(2)} leva`);        
    }    
}

CinemaPriceCalculator(["Discount", 12, 30]);