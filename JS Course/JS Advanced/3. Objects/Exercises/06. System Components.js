function componentsList(input) {
    let originalSystems = new Map();

    for (let line of input) {
        let data = line.split(/\s*\|\s*/);
        
        if (!originalSystems.get(data[0])) {
            originalSystems.set(data[0], new Map());
        }

        if (!originalSystems.get(data[0]).get(data[1])) {
            originalSystems.get(data[0]).set(data[1], []);
        }

        originalSystems.get(data[0]).get(data[1]).push(data[2]);
    }

    let orderedSystems = Array.from(originalSystems.keys()).sort((a, b) => sortSystems(a, b));
    

    for (let system of orderedSystems) {
        console.log(system);
        let sortedComponents = Array.from(originalSystems.get(system).keys()).sort((comp1, comp2) => sortComponents(system, comp1, comp2));

        for (let component of sortedComponents) {
            console.log(`|||${component}`);
            originalSystems.get(system).get(component).forEach(x => console.log(`||||||${x}`));
        }
    }
    
    function sortSystems(a, b){
        if (originalSystems.get(a).size != originalSystems.get(b).size) {
            return originalSystems.get(b).size - originalSystems.get(a).size;
        } else {
            return a.toLowerCase().localeCompare(b.toLowerCase());
        }
    }

    function sortComponents(system, comp1, comp2) {
        return originalSystems.get(system).get(comp2).length - originalSystems.get(system).get(comp1).length; 
    }
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