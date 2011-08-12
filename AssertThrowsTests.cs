namespace NUnit.Framework.Tests
{
	[TestFixture]
	public class AssertThrowsTests : MessageChecker
	{
        [Test]
        public void CanCatchUnspecifiedException()
        {
            Exception ex = Assert.Catch(new TestDelegate(TestDelegates.ThrowsArgumentException));
            Assert.That(ex, Is.TypeOf(typeof(ArgumentException)));

#if NET_2_0
            ex = Assert.Catch(TestDelegates.ThrowsArgumentException);
            Assert.That(ex, Is.TypeOf(typeof(ArgumentException)));
#endif
        }
}
