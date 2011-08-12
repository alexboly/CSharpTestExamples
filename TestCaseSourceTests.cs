namespace NUnit.Core.Tests
{
    [TestFixture]
    public class TestCaseSourceTests
    {
        [Test, TestCaseSource("MyData")]
        public void SourceMayReturnArgumentsAsObjectArray(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }
    }
}
