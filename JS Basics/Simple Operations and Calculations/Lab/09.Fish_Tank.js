function fishTank(data){
    let length = Number(data[0]);
    let width = Number(data[1]);
    let high = Number(data[2]);
    let percent = Number(data[3]);

    let genAmount = length * width * high * 0.001;
    let finalAmount = genAmount - genAmount * (percent/100);

    console.log(finalAmount.toFixed(3));
}
fishTank(["85", "75", "47", "17"]);