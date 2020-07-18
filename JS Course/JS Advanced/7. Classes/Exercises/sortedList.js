class List{
    constructor(){
        this.list = [];
        this.size = 0;
    }

    add(num){
        this.list.push(num);
        this.list = this.sortArray(this.list);
        this.size++;
    }

    remove(index){
        if (index >= 0 && index < this.list.length) {
            this.list.splice(index, 1);
            this.list = this.sortArray(this.list);
            this.size--;   
        }
    }

    get(index){
        if (index >= 0 && index < this.list.length) {
            return this.list[index];   
        }
    }

    sortArray(arr){
        return arr.sort((a, b) => a - b);
    }
}

let list = new List();
list.get(0);
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(List.hasOwnProperty("size"));