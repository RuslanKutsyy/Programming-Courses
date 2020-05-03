using System;

class StartUp
{
    static void Main(string[] args)
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Ivan", 15);

        repository.Create(hero);
    }
}
