function usernameCatalog(input) {
    let catalog = new Set();

    for (let username of input) {
        catalog.add(username);
    }

    Array.from(catalog.keys()).sort((a, b) => sortByName(a, b)).forEach(element => console.log(element));


    function sortByName(a, b) {
        if (a.length != b.length) {
            return (a.length - b.length);
        } else {
            return a.localeCompare(b);
        }
    }
}

usernameCatalog(['Denise',
'Ignatius',
'Iris',
'Isacc',
'Indie',
'Dean',
'Donatello',
'Enfuego',
'Benjamin',
'Biser',
'Bounty',
'Renard',
'Rot']
);