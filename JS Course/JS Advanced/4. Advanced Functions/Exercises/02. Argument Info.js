function analyze(...info) {
    let types = {};
    for (let data of info) {
        let type = typeof(data);
        console.log(`${type}: ${data}`);
        if (!types.hasOwnProperty(type)) {
            types[type] = 0;
        }
        types[type]++;
    }

    Object.keys(types).sort((a, b) => types[b] - types[a]).forEach(el => console.log(`${el} = ${types[el]}`))
}

analyze('cat', 15, 42, function () { console.log('Hello world!'); });
//string: cat