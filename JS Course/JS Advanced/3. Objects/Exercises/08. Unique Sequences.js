function sequenceCatalog(input) {
    let catalog = [];

    for (let line of input) {
        let arr = JSON.parse(line).sort((a, b) => b - a);
        let uniqueArr = true;

        for (let catalogItem of catalog) {
            if (isUnique(arr, catalogItem)) {
                uniqueArr = false;
                break;
            }
        }
        
        if (uniqueArr) {
            catalog.push(arr);
        }
    }

    for (let array of Array.from(catalog.sort((a, b) => a.length - b.length))) {
        console.log('[' + array.join(', ') + ']');
    }


    function isUnique(arr, catalogItem) {        
        if (arr.length !== catalogItem.length) return false;
        else {
            for (let i = 0; i < arr.length; i++) {
                if (arr[i] !== catalogItem[i]) {
                    return false;
                }
            }
        }

        return true;
    }
    
}

sequenceCatalog(["[7.14, 7.180, 7.339, 80.099]",
"[7.339, 80.0990, 7.140000, 7.18]",
"[7.339, 7.180, 7.14, 80.099]"]
);