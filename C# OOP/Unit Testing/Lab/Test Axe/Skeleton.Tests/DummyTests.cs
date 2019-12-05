using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        Dummy dummy = new Dummy(20, 10);

        dummy.TakeAttack(5);

        Assert.AreEqual(15, dummy.Health);
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        Dummy dummy = new Dummy(10, 10);

        dummy.TakeAttack(20);

        Assert.That(() => dummy.TakeAttack(20), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        Dummy dummy = new Dummy(10, 10);

        dummy.TakeAttack(15);
        dummy.GiveExperience();

        Assert.AreEqual(10, dummy.GiveExperience());
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {
        Dummy dummy = new Dummy(10, 10);

        dummy.TakeAttack(5);
        dummy.GiveExperience();

        Assert.AreEqual(Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."), dummy.GiveExperience());
    }
}