package Stack_Of_String;

import java.util.ArrayList;

public class StackOfStrings {
    private ArrayList<String> data;

    public StackOfStrings(){
        this.data = new ArrayList<String>();
    }

    public void push(String item){
        this.data.add(item);
    }

    public String pop(){
        String item = this.data.get(this.data.size() - 1);
        this.data.remove(this.data.size() - 1);

        return item;
    }

    public  String peek(){
        return this.data.get(this.data.size() - 1);
    }

    public Boolean isEmpty(){
        return this.data.isEmpty();
    }
}
