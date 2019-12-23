function PersonalTiTles(input) {
    let age = Number(input.shift());
    let gender = input.shift();

    if (age < 16) {
        if (gender == "m") {
            console.log("Master");
        }   
        else if(gender == "f"){
            console.log("Miss");
        }
    }
    else{
        if (gender == "m") {
            console.log("Mr.");
        }
        else if (gender == "f") {
            console.log("Ms.");
        }
    }
}

PersonalTiTles(["13.5", "m"]);