function sorting(input) {
    input.sort(sortByLength).forEach(element => {
       console.log(element); 
    });

    function sortByLength(el1, el2) {
        return el1.length - el2.length || sortByName(el1, el2);
    }

    function sortByName(el1, el2) {
        return el1.toLowerCase().localeCompare(el2.toLowerCase());
    }
}

sorting(['test', 
'Deny', 
'omen', 
'Default']
);