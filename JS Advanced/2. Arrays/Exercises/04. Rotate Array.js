function rotate(input) {
    let arr = input.slice();
    let rotations = Number(arr.pop());

    for (let rotation = 0; rotation < rotations % arr.length; rotation++) {
        arr.unshift(arr.pop());
    }

    console.log(arr.join(" "));
}

rotate(['1', 
'2', 
'3', 
'4', 
'2']);