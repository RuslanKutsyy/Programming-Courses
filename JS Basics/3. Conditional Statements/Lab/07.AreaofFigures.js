function Area(input) {
    let shapeType = input.shift();

    if (shapeType == `square`) {
        let side = Number(input.shift());
        let area = side * side;
        console.log(area.toFixed(3));
    }
    else if (shapeType == `rectangle`) {
        let side1 = Number(input.shift());
        let side2 = Number(input.shift());

        console.log((side1 * side2).toFixed(3));        
    }
    else if (shapeType == `circle`) {
        let radius = Number(input.shift());

        console.log((Math.PI * radius * radius).toFixed(3));
    }
    else if (shapeType == `triangle`) {
        let base = Number(input.shift());
        let height = Number(input.shift());
        let area = (base * height)/2;
        console.log(area.toFixed(3));
    }
}

Area([`circle`, `6`]);
