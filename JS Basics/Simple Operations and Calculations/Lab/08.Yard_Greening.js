function yardGreening(data){
    let square = Number(data[0]);
    let oneSquareMeterPrice = 7.61;
    let genPrice = square * oneSquareMeterPrice;
    let discount = genPrice * 0.18;
    console.log(`The final price is: ${(genPrice - discount).toFixed(2)} lv.`);
    console.log(`The discount is: ${discount.toFixed(2)} lv.`);
}
yardGreening(["540"]);