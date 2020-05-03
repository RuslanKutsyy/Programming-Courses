function radToDeg(data){
    let rads = Number(data[0]);
    let degs = rads * 180 / Math.PI;
    console.log(degs.toFixed(0));
}
radToDeg(["3.1416"]);