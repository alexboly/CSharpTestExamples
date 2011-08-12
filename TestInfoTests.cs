namespace NUnit.Core.Tests
{
	[TestFixture]
	public class TestInfoTests
	{
		private void CheckConstructionFromTest( ITest expected )
		{
			TestInfo actual = new TestInfo( expected );
			Assert.AreEqual( expected.TestName, actual.TestName );
			Assert.AreEqual( expected.TestType, actual.TestType );
			Assert.AreEqual( expected.RunState, actual.RunState );
			Assert.AreEqual( expected.IsSuite, actual.IsSuite, "IsSuite" );
			Assert.AreEqual( expected.TestCount, actual.TestCount, "TestCount" );

			if ( expected.Categories == null )
				Assert.AreEqual( 0, actual.Categories.Count, "Categories" );
			else
			{
				Assert.AreEqual( expected.Categories.Count, actual.Categories.Count, "Categories" );
				for ( int index = 0; index < expected.Categories.Count; index++ )
					Assert.AreEqual( expected.Categories[index], actual.Categories[index], "Category {0}", index );
			}

			Assert.AreEqual( expected.TestName, actual.TestName, "TestName" );
		}
	}
}
