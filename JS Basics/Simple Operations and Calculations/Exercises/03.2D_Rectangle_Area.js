function RectangleArea(data){
    let x1 = Number(data[0]);
    let y1 = Number(data[1]);
    let x2 = Number(data[2]);
    let y2 = Number(data[3]);

    let length = Math.abs(x1-x2);
    let high = Math.abs(y1 - y2);
    console.log((length * high).toFixed(2));
    console.log(((length + high) * 2).toFixed(2));
}
RectangleArea(["60", "20", "10", "50"]);