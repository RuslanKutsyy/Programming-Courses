class Stringer{
    constructor(str, lgth){
        this.innerString = str;
        this.innerLength = Number(lgth);
    }

    increase(lght){
        this.innerLength += lght;
    }

    decrease(lght){
        this.innerLength -= lght;
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString(){
        let result = "";

        if (this.innerLength == 0) {
            result += "...";
        } else{
            this.innerString.length < this.innerLength ? result += this.innerString : result = this.innerString.substr(0, this.innerLength) + "...";
        }
        return result;
    }
}