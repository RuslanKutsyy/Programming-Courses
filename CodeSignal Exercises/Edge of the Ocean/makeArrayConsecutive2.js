function makeArrayConsecutive2(statues) {
    let arr = statues.sort((a, b) => a - b);
    let neededStatues = 0;
    for (let i = 0; i < statues.length - 1; i++) {
        if(arr[i + 1] - arr[i] !== 1){
            neededStatues += arr[i + 1] - arr[i] - 1;
        }
    }

    console.log(neededStatues);
}

makeArrayConsecutive2([1, 10, 5, 11]);