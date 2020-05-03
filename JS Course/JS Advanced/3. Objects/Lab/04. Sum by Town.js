function sumByTown(input) {
    let citiesObj = {};

    for (let i = 0; i < input.length; i+=2) {
        if (! citiesObj.hasOwnProperty(input[i])) {
            citiesObj[input[i]] = 0;
        }
           
        citiesObj[input[i]] += Number(input[i + 1]);
    }

    console.log(JSON.stringify(citiesObj));
    
}

sumByTown(['Sofia',
'20',
'Varna',
'3',
'Sofia',
'5',
'Varna',
'4']
);