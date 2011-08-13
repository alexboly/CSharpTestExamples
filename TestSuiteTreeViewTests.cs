namespace NUnit.UiKit.Tests
{
	public class TestSuiteTreeViewFixture
	{
		[Test]
		public void BuildFromResult()
		{
            TestResult result = suite.Run(new NullListener(), TestFilter.Empty);
			treeView.Load( result );
			Assert.AreEqual( MockAssembly.Nodes - MockAssembly.Explicit - MockAssembly.ExplicitFixtures, 
				treeView.GetNodeCount( true ) );
			
			TestSuiteTreeNode node = treeView.Nodes[0] as TestSuiteTreeNode;
			Assert.AreEqual( testsDll, node.Text );
			Assert.IsNotNull( node.Result, "No Result on top-level Node" );
	
			node = node.Nodes[0].Nodes[0] as TestSuiteTreeNode;
			Assert.AreEqual( "Tests", node.Text );
			Assert.IsNotNull( node.Result, "No Result on TestSuite" );

			foreach( TestSuiteTreeNode child in node.Nodes )
			{
				if ( child.Text == "Assemblies" )
				{
					node = child.Nodes[0] as TestSuiteTreeNode;
					Assert.AreEqual( "MockTestFixture", node.Text );
					Assert.IsNotNull( node.Result, "No Result on TestFixture" );
					Assert.AreEqual( true, node.Result.Executed, "MockTestFixture: Executed" );

					TestSuiteTreeNode test1 = node.Nodes[2] as TestSuiteTreeNode;
					Assert.AreEqual( "MockTest1", test1.Text );
					Assert.IsNotNull( test1.Result, "No Result on TestCase" );
					Assert.AreEqual( true, test1.Result.Executed, "MockTest1: Executed" );
					Assert.AreEqual( false, test1.Result.IsFailure, "MockTest1: IsFailure");
					Assert.AreEqual( TestSuiteTreeNode.SuccessIndex, test1.ImageIndex );

					TestSuiteTreeNode test4 = node.Nodes[5] as TestSuiteTreeNode;
					Assert.AreEqual( false, test4.Result.Executed, "MockTest4: Executed" );
					Assert.AreEqual( TestSuiteTreeNode.IgnoredIndex, test4.ImageIndex );
					return;
				}
			}

			Assert.Fail( "Cannot locate NUnit.Tests.Assemblies node" );
		}
        }
}
