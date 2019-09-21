function concatenate(input){
    let firstName = input.shift();
    let lastName = input.shift();
    let age = input.shift();
    let town = input.shift();
    console.log(`You are ${firstName} ${lastName}, a ${age}-years old person from ${town}.`);
}
concatenate(["Rus", "Kutsyy", "28", "Sofia"]);