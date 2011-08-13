namespace NUnit.UiException.Tests.CodeFormatters
{
    [TestFixture]
    public class TestTokenClassifier
    {
        [Test]
        public void Test_NewState()
        {
            // STATE_CODE

            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CODE, LexerTag.EndOfLine),
                Is.EqualTo(TokenClassifier.SMSTATE_CODE));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CODE, LexerTag.Separator),
                Is.EqualTo(TokenClassifier.SMSTATE_CODE));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CODE, LexerTag.Text),
                Is.EqualTo(TokenClassifier.SMSTATE_CODE));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CODE, LexerTag.CommentC_Open),
                Is.EqualTo(TokenClassifier.SMSTATE_CCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CODE, LexerTag.CommentC_Close),
                Is.EqualTo(TokenClassifier.SMSTATE_CODE));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CODE, LexerTag.CommentCpp),
                Is.EqualTo(TokenClassifier.SMSTATE_CPPCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CODE, LexerTag.SingleQuote),
                Is.EqualTo(TokenClassifier.SMSTATE_CHAR));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CODE, LexerTag.DoubleQuote),
                Is.EqualTo(TokenClassifier.SMSTATE_STRING));

            // STATE_COMMENT_C

            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CCOMMENT, LexerTag.EndOfLine),
                Is.EqualTo(TokenClassifier.SMSTATE_CCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CCOMMENT, LexerTag.Separator),
                Is.EqualTo(TokenClassifier.SMSTATE_CCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CCOMMENT, LexerTag.Text),
                Is.EqualTo(TokenClassifier.SMSTATE_CCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CCOMMENT, LexerTag.CommentC_Open),
                Is.EqualTo(TokenClassifier.SMSTATE_CCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CCOMMENT, LexerTag.CommentC_Close),
                Is.EqualTo(TokenClassifier.SMSTATE_CODE));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CCOMMENT, LexerTag.CommentCpp),
                Is.EqualTo(TokenClassifier.SMSTATE_CCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CCOMMENT, LexerTag.SingleQuote),
                Is.EqualTo(TokenClassifier.SMSTATE_CCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CCOMMENT, LexerTag.DoubleQuote),
                Is.EqualTo(TokenClassifier.SMSTATE_CCOMMENT));

            // STATE_COMMENT_CPP

            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CPPCOMMENT, LexerTag.EndOfLine),
                Is.EqualTo(TokenClassifier.SMSTATE_CODE));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CPPCOMMENT, LexerTag.Separator),
                Is.EqualTo(TokenClassifier.SMSTATE_CPPCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CPPCOMMENT, LexerTag.Text),
                Is.EqualTo(TokenClassifier.SMSTATE_CPPCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CPPCOMMENT, LexerTag.CommentC_Open),
                Is.EqualTo(TokenClassifier.SMSTATE_CPPCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CPPCOMMENT, LexerTag.CommentC_Close),
                Is.EqualTo(TokenClassifier.SMSTATE_CPPCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CPPCOMMENT, LexerTag.CommentCpp),
                Is.EqualTo(TokenClassifier.SMSTATE_CPPCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CPPCOMMENT, LexerTag.SingleQuote),
                Is.EqualTo(TokenClassifier.SMSTATE_CPPCOMMENT));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CPPCOMMENT, LexerTag.DoubleQuote),
                Is.EqualTo(TokenClassifier.SMSTATE_CPPCOMMENT));

            // SMSTATE_CHAR

            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CHAR, LexerTag.EndOfLine),
                Is.EqualTo(TokenClassifier.SMSTATE_CHAR));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CHAR, LexerTag.Separator),
                Is.EqualTo(TokenClassifier.SMSTATE_CHAR));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CHAR, LexerTag.Text),
                Is.EqualTo(TokenClassifier.SMSTATE_CHAR));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CHAR, LexerTag.CommentC_Open),
                Is.EqualTo(TokenClassifier.SMSTATE_CHAR));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CHAR, LexerTag.CommentC_Close),
                Is.EqualTo(TokenClassifier.SMSTATE_CHAR));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CHAR, LexerTag.CommentCpp),
                Is.EqualTo(TokenClassifier.SMSTATE_CHAR));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CHAR, LexerTag.SingleQuote),
                Is.EqualTo(TokenClassifier.SMSTATE_CODE));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_CHAR, LexerTag.DoubleQuote),
                Is.EqualTo(TokenClassifier.SMSTATE_CHAR));

            // SMSTATE_STRING

            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_STRING, LexerTag.EndOfLine),
                Is.EqualTo(TokenClassifier.SMSTATE_STRING));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_STRING, LexerTag.Separator),
                Is.EqualTo(TokenClassifier.SMSTATE_STRING));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_STRING, LexerTag.Text),
                Is.EqualTo(TokenClassifier.SMSTATE_STRING));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_STRING, LexerTag.CommentC_Open),
                Is.EqualTo(TokenClassifier.SMSTATE_STRING));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_STRING, LexerTag.CommentC_Close),
                Is.EqualTo(TokenClassifier.SMSTATE_STRING));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_STRING, LexerTag.CommentCpp),
                Is.EqualTo(TokenClassifier.SMSTATE_STRING));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_STRING, LexerTag.SingleQuote),
                Is.EqualTo(TokenClassifier.SMSTATE_STRING));
            Assert.That(
                _classifier.GetSMSTATE(TokenClassifier.SMSTATE_STRING, LexerTag.DoubleQuote),
                Is.EqualTo(TokenClassifier.SMSTATE_CODE));

            return;
        }
    }
}
