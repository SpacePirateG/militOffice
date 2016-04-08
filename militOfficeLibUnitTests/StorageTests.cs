using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using militOfficeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace militOfficeLib.Tests
{
    [TestClass()]
    public class StorageTests
    {
        public void ConnectionTest()
        {
            var storage = new Storage(
                    "localhost",
                    "",
                    "militdb",
                    "3306",
                    ""
            );
            try
            {
                var result = storage.Query("SELECT * FROM recruits;");
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception was thrown"); 
            }            
        }

        [TestMethod()]
        public void StorageTest()
        {
            ConnectionTest();
        }
    }
}
