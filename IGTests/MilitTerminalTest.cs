using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace militOfficeLib.Tests
{
    [TestClass()]
    public class MilitTerminalTests
    {
        [TestMethod()]
        public void AuthenticationTest_Success()
        {
            var militTerminal = new MilitTerminal();
            militTerminal.Authentication("admin", "admin");
            Assert.IsTrue(militTerminal.IsAuthenticated());
        }

        [TestMethod()]
        [ExpectedException(typeof(System.Security.Authentication.AuthenticationException))]
        public void AuthenticationTest_Fail()
        {
            var militTerminal = new MilitTerminal();
            militTerminal.Authentication("admin", "admin1");
        }

    }
}
