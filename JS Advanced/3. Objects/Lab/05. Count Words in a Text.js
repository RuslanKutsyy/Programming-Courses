function countWords(input) {
    let data = {};
    let arr = input[0].split(/[\s,.\-']+/).filter(item => item);

    for (let i = 0; i < arr.length; i++) {
        if (!data.hasOwnProperty(arr[i])) {
            data[arr[i]] = 0;
        }

        data[arr[i]]++;
    }

    console.log(JSON.stringify(data));
}

countWords(['JS devs use Node.js for server-side JS.-- JS for devs']);