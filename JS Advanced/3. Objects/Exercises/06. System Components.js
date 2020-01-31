function componentsList(input) {
    let systems = new Map();

    for (let line of input) {
        let data = line.split(' | ');
        let system = data[0];
        let component = data[1];
        let subcomponent = data[2];

        if (!systems.get(system)) {
            systems.set(system, new Map());
        }

        if (!systems.get(system).get(component)) {
            systems.get(system).set(component, []);
        }

        systems.get(system).get(component).push(subcomponent);
    }

    let orderedSystems = Array.from(systems.keys()).sort((a, b) => sortSystems(a, b));


    function sortSystems(a, b) {
        if (systems.ge) {
            
        }
    }

    function sortComponents() {
        
    }

    console.log(orderedSystems);
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