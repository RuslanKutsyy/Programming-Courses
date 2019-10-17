function petStore(data){
    let dogsCount = Number(data[0]);
    let otherAnumals = Number(data[1]);
    let genPrice = dogsCount * 2.5 + otherAnumals * 4;
    console.log(`${genPrice.toFixed(2)} lv.`);
}
petStore(["2","3"]);