using LinkList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkListTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            var linkList = new LinkList<int?>();
            linkList.Add(30);

            Assert.IsTrue(linkList.Pop() == 30, "Pop the 30");
            Assert.IsNull(linkList.Pop(), "Pop null");
            
            linkList.Add(20);
            linkList.Add(10);
            Assert.IsTrue(linkList.Pop() == 20, "Pop the 20");
            Assert.IsNull(linkList.FirstObject.Prev, "First Prev Null");
            Assert.IsTrue(linkList.Pop() == 10, "Pop the 10");

            for (var i = 0; i < 10; i++)
            {
                linkList.Add(i);
            }

            Assert.IsTrue(linkList.GetElementByIndex(4) == 4, "index 4 is 4");
            Assert.IsTrue(linkList.GetElementByIndex(6) == 6, "index 6 is 6");

            Assert.IsTrue(linkList.GetObjectByIndex(6) == linkList.GetObjectByIndex(4).Next.Next, "object 6 is 4.next.next");
            Assert.IsTrue(linkList.GetObjectByIndex(4) == linkList.GetObjectByIndex(6).Prev.Prev, "object 4 is 6.next.next");

            Assert.IsTrue(linkList.GetObjectByIndex(0) == linkList.FirstObject, "last is 9");
            Assert.IsTrue(linkList.GetObjectByIndex(9) == linkList.LastObject, "first is 0");
        }
    }
}