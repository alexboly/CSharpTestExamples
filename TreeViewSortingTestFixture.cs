namespace ICSharpCode.CodeCoverage.Tests.Gui
{
	/// <summary>
	/// Tests that the code coverage tree view is sorted correctly for
	/// all node types.
	/// </summary>
	[TestFixture]
	public class TreeViewSortingTestFixture
	{
		IComparer<TreeNode> nodeSorter;
		CodeCoverageTreeView treeView;
		CodeCoverageModuleTreeNode codeCoverageModuleTreeNode;
		CodeCoverageModuleTreeNode zModuleTreeNode;
		CodeCoverageTreeNode betaNamespaceTreeNode;
		CodeCoverageTreeNode testFixtureClassTreeNode;
		CodeCoverageTreeNode aardvarkNamespaceTreeNode;
		CodeCoverageTreeNode anotherTestFixtureTreeNode;
		CodeCoverageTreeNode testFixtureTreeNode;
		CodeCoverageTreeNode addNodeTestTreeNode;
		CodeCoverageTreeNode removeMarkersTestTreeNode;
		
		[TestFixtureSetUp]
		public void SetUpFixture()
		{
			treeView = new CodeCoverageTreeView();
			nodeSorter = treeView.NodeSorter;
			
			List<CodeCoverageModule> modules = new List<CodeCoverageModule>();
			
			// Create a module called Z.
			CodeCoverageModule zModule = new CodeCoverageModule("Z");
			modules.Add(zModule);
		
			// Create a module called CodeCoverage.
			CodeCoverageModule codeCoverageModule = new CodeCoverageModule("CodeCoverage");
			modules.Add(codeCoverageModule);
			
			// Add a method that lives in a class without any namespace.
			CodeCoverageMethod testMethod = new CodeCoverageMethod("Test", "TestFixture");
			codeCoverageModule.Methods.Add(testMethod);
			
			// Add a method which produces a namespace that alphabetically 
			// occurs after the class already added.
			CodeCoverageMethod removeCodeMarkersMethod = new CodeCoverageMethod("RemoveCodeMarkersMethod", "Beta.TestFixture");
			codeCoverageModule.Methods.Add(removeCodeMarkersMethod);
			
			// Add a method that lives in a namespace that 
			// occurs before the removeCodeMarkersMethod. We want to 
			// make sure that this namespace node gets added before the Beta one.
			CodeCoverageMethod zebraMethod = new CodeCoverageMethod("Zebra", "Aardvark.TestFixture");
			codeCoverageModule.Methods.Add(zebraMethod);
			
			// Add a second class in the beta namespace so we check the 
			// sorting of classes.
			CodeCoverageMethod addCodeMarkersMethod = new CodeCoverageMethod("AddCodeMarkersMethod", "Beta.AnotherTestFixture");
			codeCoverageModule.Methods.Add(addCodeMarkersMethod);
			
			// Add a method which produces occurs before the remove code markers method.
			CodeCoverageMethod addNodeMethod = new CodeCoverageMethod("AddNode", "Beta.TestFixture");
			codeCoverageModule.Methods.Add(addNodeMethod);
			
			// Add two get and set properties.
			CodeCoverageMethod method = new CodeCoverageMethod("get_Zebra", "Beta.AnotherTestFixture");
			codeCoverageModule.Methods.Add(method);
			method = new CodeCoverageMethod("set_Zebra", "Beta.AnotherTestFixture");
			codeCoverageModule.Methods.Add(method);
			
			method = new CodeCoverageMethod("set_Aardvark", "Beta.AnotherTestFixture");
			codeCoverageModule.Methods.Add(method);
			method = new CodeCoverageMethod("get_Aardvark", "Beta.AnotherTestFixture");
			codeCoverageModule.Methods.Add(method);
			
			// Add a method which should appear between the two properties.
			method = new CodeCoverageMethod("Chimp", "Beta.AnotherTestFixture");
			codeCoverageModule.Methods.Add(method);

			
			// Add the modules to the tree.
			treeView.AddModules(modules);
			
			codeCoverageModuleTreeNode = (CodeCoverageModuleTreeNode)treeView.Nodes[0];
			zModuleTreeNode = (CodeCoverageModuleTreeNode)treeView.Nodes[1];
			
			// Initialise the code coverage module tree node.
			codeCoverageModuleTreeNode.PerformInitialization();
			aardvarkNamespaceTreeNode = (CodeCoverageTreeNode)codeCoverageModuleTreeNode.Nodes[0];
			betaNamespaceTreeNode = (CodeCoverageTreeNode)codeCoverageModuleTreeNode.Nodes[1];
			testFixtureClassTreeNode = (CodeCoverageTreeNode)codeCoverageModuleTreeNode.Nodes[2];
		
			// Initialise the beta namespace tree node.
			betaNamespaceTreeNode.PerformInitialization();
			anotherTestFixtureTreeNode = (CodeCoverageTreeNode)betaNamespaceTreeNode.Nodes[0];
			testFixtureTreeNode = (CodeCoverageTreeNode)betaNamespaceTreeNode.Nodes[1];
		
			// Initialise the test fixture class tree node
			testFixtureTreeNode.PerformInitialization();
			addNodeTestTreeNode = (CodeCoverageTreeNode)testFixtureTreeNode.Nodes[0];
			removeMarkersTestTreeNode = (CodeCoverageTreeNode)testFixtureTreeNode.Nodes[1];
		
			// Initialise the anotherTestFixtureTreeNode
			anotherTestFixtureTreeNode.PerformInitialization();

		}
	}
}
