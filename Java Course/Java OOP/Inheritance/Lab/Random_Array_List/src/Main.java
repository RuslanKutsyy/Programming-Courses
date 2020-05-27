import RandomArrayList.*;

public class Main {

    public static void main(String[] args) {
        RandomArrayList rand = new RandomArrayList();
        rand.add("a1");
        rand.add("a2");
        System.out.println(rand.getRandomElement());
    }
}
