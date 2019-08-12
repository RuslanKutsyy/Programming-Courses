function circleArea_and_Perimeter(data){
    let r = Number(data[0]);
    console.log((Math.PI*r*r).toFixed(2));
    console.log((2 * Math.PI * r).toFixed(2));
}
circleArea_and_Perimeter(["3"]);