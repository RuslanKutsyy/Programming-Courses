function townsToJSON(input) {
    let towns = [];
    let separators = /\s*\|\s*/;

    for (let line of input.splice(1)) {
        let data = line.split(separators);
        let townObj = {Town:data[1], Latitude: Number(Number(data[2]).toFixed(2)), Longitude: Number(Number(data[3]).toFixed(2))};
        towns.push(townObj);
    }
    
    console.log(JSON.stringify(towns));
}

townsToJSON(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']);