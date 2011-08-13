namespace NUnit.UiException.Tests.StackTraceAnalyzers
{
    [TestFixture]
    public class TestLineNumberParser : TestIErrorParser
    {
        [Test]
        public void Test_Ability_To_Parse_Regular_Line_Number_Values()
        {
            RawError res;

            // a basic test
            res = AcceptValue(_parser, "à get_Text() dans C:\\folder\\file1:line 1");
            Assert.That(res.Line, Is.EqualTo(1));

            // parser doesn't rely upon the presence of words between
            // the colon and the number
            res = AcceptValue(_parser, "à get_Text() dans C:\\folder\\file1:42");
            Assert.That(res.Line, Is.EqualTo(42));

            // parser doesn't rely on the existence of
            // a method name or path value
            res = AcceptValue(_parser, ":43");
            Assert.That(res.Line, Is.EqualTo(43));

            // Works for German
            // NOTE: German provides a period at the end of the line
            res = AcceptValue(_parser, @"bei CT.Business.BusinessObjectXmlSerializer.Deserialize(String serializedObject) in D:\Source\CT5\BASE\CT.Business\BusinessObjectXmlSerializer.cs:Zeile 86.");
            Assert.That(res.Line, Is.EqualTo(86));

            // Russian works too
            // в Samples.ExceptionBrowserTest.Worker.DoSomething() в C:\psgdev\Projects\NUnit\Tests\Samples\ExceptionBrowserTest.cs:строка 16
            // в Samples.ExceptionBrowserTest.Test() в C:\psgdev\Projects\NUnit\Tests\Samples\ExceptionBrowserTest.cs:строка 24
            res = AcceptValue(_parser, @"в Samples.ExceptionBrowserTest.Worker.DoSomething() в C:\psgdev\Projects\NUnit\Tests\Samples\ExceptionBrowserTest.cs:строка 16");
            Assert.That(res.Line, Is.EqualTo(16));
            return;
        }
    }
}
