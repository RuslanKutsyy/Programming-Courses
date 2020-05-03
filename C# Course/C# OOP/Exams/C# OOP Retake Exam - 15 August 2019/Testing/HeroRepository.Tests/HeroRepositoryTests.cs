using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void CreateObjectWithCorrectNameAndLevel()
    {
        var hero = new Hero("Ivan", 15);

        Assert.That(hero.Name == "Ivan" && hero.Level == 15);
    }

    [Test]
    public void ThrowArgumentExceptionWhenAddNullToRepository()
    {
        Hero hero = null;
        HeroRepository repository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => repository.Create(hero), "Hero is null");
    }

    [Test]
    public void ThrowsExceptionWhenAddDuplicateHeros()
    {
        Hero hero = new Hero("Ivan", 15);
        HeroRepository repository = new HeroRepository();
        repository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => repository.Create(hero), "Hero with name Ivan already exists");
    }

    [Test]
    public void AddHeroToRepository()
    {
        Hero hero = new Hero("Ivan", 15);
        HeroRepository repository = new HeroRepository();
        repository.Create(hero);

        Assert.That(repository.GetHero("Ivan") == hero);
    }

    [Test]
    public void ThrowsExceptionWhenHeroIsNullOrWhiteSpaceWhenRemoveHeroFromRepository()
    {
        string name = " ";

        HeroRepository repository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => repository.Remove(name));
    }

    [Test]
    public void ReturnsTrueWhenRemoveHero()
    {
        Hero hero = new Hero("Ivan", 15);
        HeroRepository repository = new HeroRepository();
        repository.Create(hero);

        Assert.True(repository.Remove(hero.Name));
    }

    [Test]
    public void ReturnsFalseWhenRemoveNonExistantHero()
    {
        Hero hero = new Hero("Ivan", 15);
        HeroRepository repository = new HeroRepository();
        repository.Create(hero);

        Assert.False(repository.Remove("Rus"));
    }

    [Test]
    public void ReturnsHeroWithHigherLevel()
    {
        Hero hero1 = new Hero("Ivan", 15);
        Hero hero2 = new Hero("Rus", 20);
        HeroRepository repository = new HeroRepository();
        repository.Create(hero1);
        repository.Create(hero2);

        Assert.AreEqual(hero2, repository.GetHeroWithHighestLevel());
    }

    [Test]
    public void ReturnsHeroWithSameLevel()
    {
        Hero hero1 = new Hero("Ivan", 15);
        Hero hero2 = new Hero("Rus", 15);
        HeroRepository repository = new HeroRepository();
        repository.Create(hero1);
        repository.Create(hero2);

        Assert.AreEqual(hero1, repository.GetHeroWithHighestLevel());
    }

    [Test]
    public void ReturnsNullIfNoSuchHeroWhenGettingAHero()
    {
        string name = "Max";
        Hero hero = new Hero("Rus", 20);
        HeroRepository repository = new HeroRepository();
        repository.Create(hero);

        Assert.IsNull(repository.GetHero(name));
    }

    [Test]
    public void ReturnsHeroIfNoSuchHeroWhenGettingAHero()
    {
        string name = "Rus";
        Hero hero = new Hero("Rus", 20);
        HeroRepository repository = new HeroRepository();
        repository.Create(hero);

        Assert.AreEqual(hero ,repository.GetHero(name));
    }
}