let result = (function processing() {
    let internalSum = 0;

    function add(input) {
        internalSum +=input;
        return add;
    }
    add.toString = () => internalSum;
    return add;
})();

console.log(result(1)(3));