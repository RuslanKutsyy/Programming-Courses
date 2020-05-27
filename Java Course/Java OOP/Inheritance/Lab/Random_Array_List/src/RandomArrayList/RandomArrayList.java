package RandomArrayList;

import java.util.ArrayList;
import java.util.Random;

public class RandomArrayList extends ArrayList {
    public Object getRandomElement(){
        Integer num = new Random().nextInt(this.size());
        var el = this.get(num);
        this.remove(num);

        return el;
    }
}
