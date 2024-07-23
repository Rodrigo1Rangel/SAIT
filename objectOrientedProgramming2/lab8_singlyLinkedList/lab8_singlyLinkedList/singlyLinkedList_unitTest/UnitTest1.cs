namespace singlyLikedList
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] // InsertFront
        [TestCase("1","2","3", "321")]
        public void TEST_InsertFront(string data1, string data2, string dataToAdd, string expectedOutput)
        {
            SLL sll = new SLL();
            sll.InsertFront(data1);
            sll.InsertFront(data2);
            sll.InsertFront(dataToAdd);

            string remainingData = sll.Head.Data + sll.Head.Next.Data + sll.Head.Next.Next.Data;
            Assert.That(remainingData,
                Is.EqualTo(expectedOutput));
        }

        [Test] // InsertLast
        [TestCase("1", "2", "3", "123")]
        public void TEST_InsertLast(string data1, string data2, string dataToAdd, string expectedOutput)
        {
            SLL sll = new SLL();
            sll.InsertLast(data1);
            sll.InsertLast(data2);
            sll.InsertLast(dataToAdd);

            string remainingData = sll.Head.Data + sll.Head.Next.Data + sll.Head.Next.Next.Data;

            Assert.That(remainingData,
                Is.EqualTo(expectedOutput));
        }

        [Test] // GetLastNode
        [TestCase("1", "2", "3", "3")]
        public void TEST_GetLastNode(string data1, string data2, string data3, string expectedOutput)
        {
            SLL sll = new SLL();
            sll.InsertLast("1");
            sll.InsertLast("2");
            sll.InsertLast("3");

            string lastNodeData = sll.Tail.Data;

            Assert.That(lastNodeData,
                Is.EqualTo(expectedOutput));
        }

        [Test] // InsertAfter
        [TestCase("1", "2", "3", "4", "1243")]
        public void TEST_InsertAfter(string data1, string data2, string data3, string dataToAdd, string expectedOutput)
        {
            SLL sll = new SLL();
            sll.InsertLast(data1);
            sll.InsertLast(data2);
            sll.InsertLast(data3);
            sll.InsertAfter(dataToAdd, data2);

            string remainingData = sll.Head.Data + sll.Head.Next.Data + sll.Head.Next.Next.Data + sll.Head.Next.Next.Next.Data;

            Assert.That(remainingData,
                Is.EqualTo(expectedOutput));
        }


        [Test] // DeleteNodebyKey
        [TestCase("1","2","3","2","13")]
        public void TEST_DeleteNodebyKey(string dataNode1, string dataNode2, string dataNode3, string dataToRemove, string expectedOutput)
        {
            SLL sll5 = new SLL();
            sll5.InsertLast("1");
            sll5.InsertLast("2");
            sll5.InsertLast("3");
            sll5.DeleteNodeByKey("2");

            string remainingData = sll5.Head.Data + sll5.Head.Next.Data;

            Assert.That(
                remainingData, 
                Is.EqualTo(remainingData));
        }

        [Test] // ReverseSLL
        [TestCase("1", "2", "3", "321")]
        public void TEST_ReverseSLL(string dataNode1, string dataNode2, string dataNode3, string expectedOutput)
        {
            SLL sll = new SLL();
            sll.InsertLast("1");
            sll.InsertLast("2");
            sll.InsertLast("3");
            sll.ReverseSLL();

            string remainingData = sll.Head.Data + sll.Head.Next.Data + sll.Head.Next.Next.Data;

            Assert.That(
                remainingData,
                Is.EqualTo(remainingData));
        }
    }
}