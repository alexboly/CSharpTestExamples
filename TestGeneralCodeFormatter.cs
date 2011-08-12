namespace NUnit.UiException.Tests.CodeFormatters
{
    [TestFixture]
    public class TestGeneralCodeFormatter
    {
        [Test]
        public void Format_Pick_Best_Formatter()
        {
            ErrorItem itemHelloTxt;
            ErrorItem itemBasicCs;
            ICodeFormatter txtFormatter;
            ICodeFormatter csFormatter;
            FormattedCode exp;

            using (new TestResource("HelloWorld.txt"))
            {
                itemHelloTxt = new ErrorItem("HelloWorld.txt", 1);
                txtFormatter = new PlainTextCodeFormatter();
                exp = txtFormatter.Format(itemHelloTxt.ReadFile());
                Assert.That(
                    _formatter.FormatFromExtension(itemHelloTxt.ReadFile(), itemHelloTxt.FileExtension),
                    Is.EqualTo(exp));
                FormattedCode.CheckData(exp);
            }

            using (new TestResource("Basic.cs"))
            {
                itemBasicCs = new ErrorItem("Basic.cs", 1);
                csFormatter = new CSharpCodeFormatter();
                exp = csFormatter.Format(itemBasicCs.ReadFile());
                Assert.That(
                    _formatter.FormatFromExtension(itemBasicCs.ReadFile(), itemBasicCs.FileExtension),
                    Is.EqualTo(exp));
                FormattedCode.CheckData(exp);
            }

            return;
        }
    }    
}
