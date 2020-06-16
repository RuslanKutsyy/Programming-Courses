package Animals;

public class Animal implements SoundProducable {
    private String name;
    private int age;
    private String gender;

    public Animal(String name, int age, String gender){
        this.name = name;
        this.age = age;
        this.gender = gender;
    }

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }

    public String getGender() {
        return gender;
    }

    @Override
    public String toString() {
        return this.getClass().getSimpleName() + "\r\n" +
                name + ' ' + age + ' ' + gender + "\r\n" +
                produceSound();
    }
}
