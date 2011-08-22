namespace Manos.Collections.Tests
{
	[TestFixture]
	public class DataDictionaryTest
	{
		[Test]
		public void Get_NoItemAdded_ReturnsNull ()
		{
			var dd = new DataDictionary ();
			
			string res = dd.Get ("foobar");
			Assert.IsNull (res);
		}
		
		[Test]
		public void Get_EmptyChildrenAdded_ReturnsNull ()
		{
			var dd = new DataDictionary ();
			
			dd.Children.Add (new DataDictionary ());
			dd.Children.Add (new DataDictionary ());
			
			string res = dd.Get ("foobar");
			Assert.IsNull (res);
		}
	}
}
