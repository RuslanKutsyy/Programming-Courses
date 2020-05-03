function PassGuess(input) {
    let pass = input.shift();
    let statPass = "s3cr3t!P@ssw0rd";

    if (pass == statPass) {
        console.log(`Welcome`);
    }
    else{
        console.log(`Wrong password!`);
    }
}

PassGuess([`s3cr3t!P@ssw0rd`]);