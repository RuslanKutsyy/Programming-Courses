function inchesToCentimeters(input){
    let a = Number(input.shift());
    console.log((a*2.54).toFixed(2));
}
inchesToCentimeters(["5"]);