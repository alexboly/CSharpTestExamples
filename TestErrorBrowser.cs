namespace NUnit.UiException.Tests.Controls
{
    [TestFixture]
    public class TestErrorBrowser
    {
       [Test]
        public void ErrorDisplay_Plugins_life_cycle_events()
        {
		// test #1: Asks ErrorBrowser to register an instance of IErrorDisplay
		//
		// - check the process calls successively IErrorDisplay's
		//   properties & methods.
		//
		// - when registering an IErrorDisplay for the first time, ErrorBrowser
		//   should select the instance automatically.

		DynamicMock mockTraceDisplay = MockHelper.NewMockIErrorRenderer("raw", 1);
		DynamicMock mockSourceDisplay = MockHelper.NewMockIErrorRenderer("browser", 2);

		ToolStripButton tracePlugin = new ToolStripButton();
//              ToolStripItem[] traceOptions = new ToolStripItem[] { };
		Control traceContent = new TextBox();
            
		mockTraceDisplay.SetReturnValue("Text", "Displays the actual stack trace");

		// looks like Mock needs a bit enhancements to handle multiple calls

		mockTraceDisplay.ExpectAndReturn("get_PluginItem", tracePlugin);
		mockTraceDisplay.ExpectAndReturn("get_PluginItem", tracePlugin);
		mockTraceDisplay.ExpectAndReturn("get_PluginItem", tracePlugin);
		mockTraceDisplay.ExpectAndReturn("get_Content", traceContent);
		mockTraceDisplay.Expect("OnStackTraceChanged", new object[] { _errorBrowser.StackTraceSource });

		_errorBrowser.RegisterDisplay((IErrorDisplay)mockTraceDisplay.MockInstance);
		mockTraceDisplay.Verify();

		Assert.That(_errorBrowser.SelectedDisplay, Is.Not.Null);
		Assert.That(_errorBrowser.SelectedDisplay, Is.SameAs(mockTraceDisplay.MockInstance));
		Assert.That(_errorBrowser.LayoutPanel.Content, Is.EqualTo(traceContent));

		// test #2: Asks ErrorBrowser to register another instance of IErrorDisplay
		//
		// - Selection should not change

		ToolStripItem sourcePluginItem = new ToolStripButton();
		Control sourceContent = new Button();

		mockSourceDisplay.SetReturnValue("Text", "Displays source code context");
		mockSourceDisplay.ExpectAndReturn("get_PluginItem", sourcePluginItem);
		mockSourceDisplay.ExpectAndReturn("get_PluginItem", sourcePluginItem);

		_errorBrowser.RegisterDisplay((IErrorDisplay)mockSourceDisplay.MockInstance);
		mockSourceDisplay.Verify();

		Assert.That(_errorBrowser.SelectedDisplay, Is.Not.Null);
		Assert.That(_errorBrowser.SelectedDisplay, Is.SameAs(mockTraceDisplay.MockInstance));

		// test #3: changes current selection

		mockTraceDisplay.ExpectAndReturn("get_PluginItem", tracePlugin);
		mockSourceDisplay.ExpectAndReturn("get_PluginItem", sourcePluginItem);            
		mockSourceDisplay.ExpectAndReturn("get_Content", sourceContent);

		_errorBrowser.Toolbar.SelectedDisplay = (IErrorDisplay)mockSourceDisplay.MockInstance;

		mockSourceDisplay.Verify();
		mockTraceDisplay.Verify();

		Assert.That(_errorBrowser.Toolbar.SelectedDisplay, Is.SameAs(mockSourceDisplay.MockInstance));
		Assert.That(_errorBrowser.LayoutPanel.Content, Is.EqualTo(sourceContent));

		// test #4: changing ErrorSource update all renderers

		string stack = "à test() C:\\file.cs:ligne 1";

		mockTraceDisplay.Expect("OnStackTraceChanged", new object[] { stack });
		mockSourceDisplay.Expect("OnStackTraceChanged", new object[] { stack });
		_errorBrowser.StackTraceSource = stack;
		Assert.That(_errorBrowser.LayoutPanel.Content, Is.TypeOf(typeof(Button)));
		mockSourceDisplay.Verify();
		mockTraceDisplay.Verify();
            
		// clears all renderers

		_errorBrowser.ClearAll();
		Assert.That(_errorBrowser.Toolbar.Count, Is.EqualTo(0));

		Assert.That(_errorBrowser.LayoutPanel.Option, Is.Not.Null);
		Assert.That(_errorBrowser.LayoutPanel.Option, Is.TypeOf(typeof(Panel)));

		Assert.That(_errorBrowser.LayoutPanel.Content, Is.Not.Null);
		Assert.That(_errorBrowser.LayoutPanel.Content, Is.TypeOf(typeof(Panel)));          
            
		return;
		}
	}
}
