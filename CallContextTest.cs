namespace NUnit.Core.Tests
{
	[TestFixture]
	public class CallContextTests
	{
		[Test]
		public void SetCustomPrincipalOnThread()
		{
			MyPrincipal prpal = new MyPrincipal();

			System.Threading.Thread.CurrentPrincipal = prpal;
		}
	}
}
