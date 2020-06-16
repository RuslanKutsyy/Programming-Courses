import java.lang.reflect.Constructor;
import java.security.InvalidParameterException;
import java.util.List;
import java.util.Scanner;
import java.lang.*;

public class InputHandler {
    public void execute(){

        Scanner scanner = new Scanner(System.in);
        try {
            while (true){
                String animalType = scanner.nextLine();
                if (animalType.equals("Beast!")){
                    throw new InvalidParameterException("Invalid input!");
                }
                String[] animalData = scanner.nextLine().split(" ");

                Class AnimalCls = Class.forName("Animals" + "." + animalType);
                Constructor<?> ctr = AnimalCls.getConstructors()[0];
                Object animalObj = AnimalCls.cast(ctr.newInstance(animalData[0],
                        Integer.parseInt(animalData[1]), animalData[2]));
                System.out.println(animalObj.toString());
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

    }
}
