using System;
using NUnit.Framework;
using NUnit.Util;

namespace NUnit.Core.Tests
{
    [TestFixture]
    public class SetUpFixtureTests
    {
        /// <summary>
        /// Tests that the TestSuiteBuilder correctly interperets a SetupFixture class as a 'virtual namespace' into which 
        /// all it's sibling classes are inserted.
        /// </summary>
        [NUnit.Framework.Test]
        public void NamespaceSetUpFixtureReplacesNamespaceNodeInTree()
        {
            string nameSpace = "NUnit.TestData.SetupFixture.Namespace1";
            TestSuiteBuilder builder = new TestSuiteBuilder();
			TestPackage package = new TestPackage( testAssembly );
			package.TestName = nameSpace;
			Test suite= builder.Build( package );

            Assert.IsNotNull(suite);

            Assert.AreEqual(testAssembly, suite.TestName.Name);
            Assert.AreEqual(1, suite.Tests.Count);

            string[] nameSpaceBits = nameSpace.Split('.');
            for (int i = 0; i < nameSpaceBits.Length; i++)
            {
                suite = suite.Tests[0] as TestSuite;
                Assert.AreEqual(nameSpaceBits[i], suite.TestName.Name);
                Assert.AreEqual(1, suite.Tests.Count);
            }

            Assert.IsInstanceOf(typeof(SetUpFixture), suite);

            suite = suite.Tests[0] as TestSuite;
            Assert.AreEqual("SomeTestFixture", suite.TestName.Name);
            Assert.AreEqual(1, suite.Tests.Count);
        }
    }
}
