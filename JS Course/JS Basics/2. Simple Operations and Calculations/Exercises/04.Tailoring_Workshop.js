function general(data){
    let tablesAndKare = Number(data[0]);
    let tableLength = Number(data[1]);
    let tablewidth = Number(data[2]);
    let kareSide = tableLength/2;
    let tableSquare = ((tableLength + 0.3*2) * (tablewidth + 0.3 * 2)) * tablesAndKare;
    let kareSquare = kareSide * kareSide * tablesAndKare;
    let genPrice = tableSquare * 7 + kareSquare * 9;
    console.log(`${genPrice.toFixed(2)} USD`);
    console.log(`${(genPrice * 1.85).toFixed(2)} BGN`);
}
general(["5", "1.00", "0.5"]);