function PrintCharacters(input) {
    var  stringData = input.toString();
    var arr = stringData.split();

    for (let i = 0; i < stringData.length; i++) {
        console.log(stringData[i]);
    }
}

PrintCharacters(['softuni']);