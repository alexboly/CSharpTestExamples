namespace Manos.Routing.Tests
{
        [TestFixture]
        public class ActionTargetTest
        {
                [Test]
                public void Ctor_NullArgument_Throws ()
                {
                        Should.Throw<ArgumentNullException> (() => new ActionTarget (null));
                }

                [Test]
                public void Ctor_ValidActon_SetsAction ()
                {
                        var mat = new ActionTarget (ValidAction);

                        Assert.AreEqual (new ManosAction (ValidAction), mat.Action);
                }

                [Test]
                public void ActionSetter_NullAction_Throws ()
                {
                        var mat = new ActionTarget (ValidAction);

                        Should.Throw<ArgumentNullException> (() => mat.Action = null);
                }

                [Test]
                public void ActionSetter_InvalidDelegateType_Throws ()
                {
                        var mat = new ActionTarget (new ManosAction (ValidAction));

                        Should.Throw<InvalidOperationException> (() => mat.Action = new InvalidDelegate (InvalidAction));
                }
	}
}
