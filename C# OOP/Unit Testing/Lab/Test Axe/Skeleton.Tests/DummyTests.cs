using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        Axe axe = new Axe(5, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.AreEqual(5, dummy.Health);
    }


    public void DeadDummyThrowsExceptionIfAttacked()
    {

    }
}
