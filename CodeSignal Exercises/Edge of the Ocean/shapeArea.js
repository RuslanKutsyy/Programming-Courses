function shapeArea(n) {
    let shape = 0;

    for (let i = 1; i <= (n * 2) - 1; i+=2) {
        shape += i;
    }

    for (let i = n *2 -1 - 2; i > 0; i-=2) {
        shape+=i;
    }

    return shape;
}