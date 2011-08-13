namespace NUnit.Core.Tests
{
	[TestFixture]	
	public class TestNodeTests
	{
		[Test]
		public void ConstructFromMultipleTests()
		{
			ITest[] tests = new ITest[testFixture.Tests.Count];
			for( int index = 0; index < tests.Length; index++ )
				tests[index] = (ITest)testFixture.Tests[index];

			TestName testName = new TestName();
			testName.FullName = testName.Name = "Combined";
			testName.TestID = new TestID( 1000 );
			TestNode test = new TestNode( testName, tests );
			Assert.AreEqual( "Combined", test.TestName.Name );
			Assert.AreEqual( "Combined", test.TestName.FullName );
			Assert.AreEqual( RunState.Runnable, test.RunState );
			Assert.IsTrue( test.IsSuite, "IsSuite" );
			Assert.AreEqual( tests.Length, test.Tests.Count );
			Assert.AreEqual( MockTestFixture.Tests, test.TestCount );
			Assert.AreEqual( 0, test.Categories.Count, "Categories");
			Assert.AreNotEqual( testFixture.TestName.Name, test.TestName.Name, "TestName" );
		}
	}
}
