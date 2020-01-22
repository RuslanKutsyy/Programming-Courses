function addRemoveElements(params) {
    let arr = [];
    let commands = params;
    let startNum = 1;

    while (commands.length > 0) {
        let cmd = commands.shift();

        if (cmd === 'add') {
            arr.push(startNum);
        } else if (cmd === 'remove') {
            arr.pop();
        }
        startNum++;
    }

    if (arr.length > 0) {
        arr.forEach(element => {
            console.log(element);
        });
    } else {
        console.log('Empty');
    }
}

addRemoveElements(['remove', 
'remove', 
'remove']);