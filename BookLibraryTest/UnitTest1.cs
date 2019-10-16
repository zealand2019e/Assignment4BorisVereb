using ItemLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookLibraryTest
{

    [TestClass]
    public class BookTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_iSBN()
        {
            _ = new Book("1234567891011", "CatcherInTheRye", "Jerome David Salinger", 277);
        }
        [TestMethod]
        public void Test_Validation()
        {
            _ = new Book("1234567891011", "CatcherInTheRye", "Jerome David Salinger", 277);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Name()
        {
            _ = new Book("1234567891011", "Lo", "Jerome David Salinger", 277);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_PageNumbers()
        {
            _ = new Book("1234567891011", "CatcherInTheRye", "Jerome David Salinger", 277);
        }
    }
}
