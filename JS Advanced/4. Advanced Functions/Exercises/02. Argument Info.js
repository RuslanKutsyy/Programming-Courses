function analyse(...arguments) {
    let store = new Map();

    for (let el of arguments) {
        let type =  typeof el;

        console.log(`${type}: ${el}`);

        if (!store.get(type)) {
            store.set(type, 0);
        }

        store.set(type, store.get(type) + 1);
    }

    [...store].sort((a, b) => b[1] - a[1]).forEach(el => console.log(`${el[0]} = ${el[1]}`));
    
}

analyse(42);