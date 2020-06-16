package Animals;

public interface SoundProducable {
    public default String produceSound() {
        return null;
    }
}
