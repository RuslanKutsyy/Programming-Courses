function componentsList(input) {
    let originalSystems = new Map();

    for (let line of input) {
        let data = line.split(' | ');
        
        if (!originalSystems.has(data[0])) {
            originalSystems.set(data[0], new Map());
        }

        if (!originalSystems.get(data[0]).has(data[1])) {
            originalSystems.get(data[0]).set(data[1], []);
        }

        if (!originalSystems.get(data[0]).get(data[1])) {
            originalSystems.get(data[0]).get(data[1]).push(data[2]);
        }
    }

    console.log(originalSystems);
}

componentsList(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security']
);