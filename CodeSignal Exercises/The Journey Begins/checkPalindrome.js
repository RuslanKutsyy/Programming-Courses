function checkPalindrome(inputString) {
    let newString = inputString.split("").reverse().join("");
    if(inputString === newString){
       return true;
       }
    
    return false;
}