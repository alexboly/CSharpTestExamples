namespace NUnit.Core.Tests
{
    [TestFixture]
    public class TestExecutionContextTests
	{
	    [Test]
	    public void SetAndRestoreCurrentDirectory()
	    {
                Assert.AreEqual(currentDirectory, TestExecutionContext.CurrentContext.CurrentDirectory, "Directory not in initial context");

                TestExecutionContext.Save();

                try
                {
                    string otherDirectory = System.IO.Path.GetTempPath();
                    if (otherDirectory[otherDirectory.Length - 1] == System.IO.Path.DirectorySeparatorChar)
                        otherDirectory = otherDirectory.Substring(0, otherDirectory.Length - 1);
                    TestExecutionContext.CurrentContext.CurrentDirectory = otherDirectory;
                    Assert.AreEqual(otherDirectory, Environment.CurrentDirectory, "Directory was not set");
                    Assert.AreEqual(otherDirectory, TestExecutionContext.CurrentContext.CurrentDirectory, "Directory not in new context");
                }
                finally
                {
                    TestExecutionContext.Restore();
                }

		Assert.AreEqual( currentDirectory, Environment.CurrentDirectory, "Directory was not restored" );
                Assert.AreEqual(currentDirectory, TestExecutionContext.CurrentContext.CurrentDirectory, "Directory not in final context");
	    }
	}
}
