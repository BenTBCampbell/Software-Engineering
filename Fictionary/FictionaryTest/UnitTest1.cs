using Fictionary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FictionaryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Filter.IsClean("bad word");

        }
    }
}
