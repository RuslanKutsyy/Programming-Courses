function OldBookCheck(input) {
    let neededBook = input.shift();
    let bookCount = parseInt(input.shift());
    let count = 0;
    let found = false;

    while (count != bookCount) {
        let check = input.shift();
        if (check == neededBook) {
            found = true;
            break;
        }
        count++;
    }

    if (found) {
        console.log(`You checked ${count} books and found it.`);
    }
    else{
        console.log("The book you search is not here!");
        console.log(`You checked ${count} books.`);        
    }
}

OldBookCheck([
    "The Spot",
    "4",
    "Hunger Games",
    "Harry Potter",
    "Torronto",
    "Spotify"
]);