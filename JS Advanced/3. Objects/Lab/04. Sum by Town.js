function sumByTown(input) {
    let citiesObj = [];

    for (let i = 0; i < input.length; i+=2) {
        let cityName = input[i];
        let cityValue = Number(input[i + 1]);
        let neededObj = citiesObj.filter(el => Object.keys(el).some(key => key == cityName));

        if (neededObj.length === 0 ) {
            let city = {
                [cityName] : cityValue
            }

            citiesObj.push(city);
        } else {
            neededObj[0][cityName] +=cityValue;
        }
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