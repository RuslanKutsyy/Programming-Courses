import Stack_Of_String.StackOfStrings;

public class Main {

    public static void main(String[] args) {
        StackOfStrings someStack = new StackOfStrings();
        someStack.push("text 1");
        System.out.println(someStack.peek());
        someStack.pop();
    }
}