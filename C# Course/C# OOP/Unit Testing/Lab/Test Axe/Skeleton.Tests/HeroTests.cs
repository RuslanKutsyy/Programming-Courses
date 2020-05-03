using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void GainXP()
    {
        ITarget dummy = new Dummy(10, 10);
        Hero hero = new Hero("Ivan");

        hero.Attack(dummy);

        Assert.AreEqual(10, hero.Experience);
    }
}