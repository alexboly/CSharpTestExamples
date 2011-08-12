namespace NUnit.Core.Tests
{
        [TestFixture]
        public class DequeueBlocking_StopTest : ProducerConsumerTest
        {
            [Test]
            [Timeout(1000)]
            public void DequeueBlocking_Stop()
            {
                this.q = new EventQueue();
                this.receivedEvents = 0;
                this.RunProducerConsumer();
                Assert.AreEqual(events.Length + 1, this.receivedEvents);
            }
	}

        [TestFixture]
        public class SetWaitHandle_Enqueue_SynchronousTest : ProducerConsumerTest
        {
            [Test]
            [Timeout(1000)]
            public void SetWaitHandle_Enqueue_Synchronous()
            {
                using (this.waitHandle = new AutoResetEvent(false))
                {
                    this.q = new EventQueue();
                    this.q.SetWaitHandleForSynchronizedEvents(this.waitHandle);
                    this.afterEnqueue = false;
                    this.RunProducerConsumer();
                }
            }

        [TestFixture]
        public class SetWaitHandle_Enqueue_AsynchronousTest : ProducerConsumerTest
        {
            [Test]
            [Timeout(1000)]
            public void SetWaitHandle_Enqueue_Asynchronous()
            {
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    this.q = new EventQueue();
                    this.q.SetWaitHandleForSynchronizedEvents(waitHandle);
                    this.afterEnqueue = false;
                    this.RunProducerConsumer();
                }
            }

	}

}
