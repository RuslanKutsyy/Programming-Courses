function solution(x) {
    return function addNumbers(y){
        return x + y;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));