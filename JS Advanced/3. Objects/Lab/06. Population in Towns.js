function calculatePopulation(params) {
    let cityInfo;
    let cityDatabase = {};

    for (let i = 0; i < params.length; i++) {
        cityInfo = params[i].split(" <-> ");
        if (!cityDatabase.hasOwnProperty(cityInfo[0])) {
            cityDatabase[cityInfo[0]] = 0;
        }
        cityDatabase[cityInfo[0]] += Number(cityInfo[1]);
    }

   for (let key in cityDatabase) {
       console.log(`${key} : ${cityDatabase[key]}`);
   }
}

calculatePopulation(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']);