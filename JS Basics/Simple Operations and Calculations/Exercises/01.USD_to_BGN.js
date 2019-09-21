function usdTobgn(data){
    let dollars = Number(data[0]);
    let bgn = dollars * 1.79549;

    console.log(bgn.toFixed(2));
}
usdTobgn(["20"]);