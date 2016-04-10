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
    public class MilitTerminalTests
    {

        // проверка на выброшенное исключение
        private void AuthenticationExceptionThrown()
        {
            var militTerminal = new MilitTerminal(new ExceptionUserTerminal());

            try
            {
                militTerminal.Authentication("login", "password");
            }
            catch (System.Security.Authentication.AuthenticationException)
            {
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        // пользователь аутентфифиваив
        private void CorrectAuthentication()
        {
            var militTerminal = new MilitTerminal(new CorrectUserTerminal());
            User user = new CorrectUserTerminal().GetBylogin("test");

            try
            {
                militTerminal.Authentication("test", "test");
            }
            catch (System.Security.Authentication.AuthenticationException)
            {
                Assert.Fail("exception was thrown.");
            }

            bool userEqual = user.login == militTerminal.User.login &&
                            user.type == militTerminal.User.type;

            Assert.IsTrue(userEqual);
        }

        //тест на аутентификацию
        [TestMethod()]
        public void AuthenticationTest()
        {
            AuthenticationExceptionThrown(); //тест на выброшенное исключение
            CorrectAuthentication(); //тест на авторизацию
        }


        private void IsAuthenticated()
        {
            var militTerminal = new MilitTerminal(new CorrectUserTerminal());
            militTerminal.Authentication("test", "test");
            Assert.IsTrue(militTerminal.IsAuthenticated());
        }

        private void IsNotAuthenticated()
        {
            var militTerminal = new MilitTerminal(new CorrectUserTerminal());
            Assert.IsFalse(militTerminal.IsAuthenticated());
        }

        //тест на проверку аутентификации
        [TestMethod()]
        public void IsAuthenticatedTest()
        {
            IsAuthenticated();
            IsNotAuthenticated();
        }


        private void AreAvailablePermissions()
        {
            var militTerminal = new MilitTerminal(new CorrectUserTerminal());
            militTerminal.Authentication("test", "test");
            Assert.IsTrue(militTerminal.AvailablePermissions != Permissions.none);
        }

        private void NotAvailablePermissions()
        {
            var militTerminal = new MilitTerminal(new CorrectUserTerminal());
            Assert.IsTrue(militTerminal.AvailablePermissions == Permissions.none);
        }

        //тест на доступные разрешения
        [TestMethod()]
        public void AvailablePermissions()
        {
            AreAvailablePermissions();
            NotAvailablePermissions();
        }

        private void GetUtWithAuthorizated()
        {
            var militTerminal = new MilitTerminal(new CorrectUserTerminal());
            militTerminal.Authentication("test", "test");
            var terminal = militTerminal.UserTerminal;
            Assert.IsTrue(terminal.readAccess && terminal.writeAccess);
        }

        private void GetUtWithNotAuthorizated()
        {
            var militTerminal = new MilitTerminal();
            var terminal = militTerminal.UserTerminal;
            Assert.IsFalse(terminal.readAccess && terminal.writeAccess);
        }

        //проверка на получение UserTerminal
        [TestMethod()]
        public void GetUserTerminal()
        {
            GetUtWithAuthorizated();
            GetUtWithNotAuthorizated();
        }



        private void GetRtWithAuthorizated()
        {
            var militTerminal = new MilitTerminal(new CorrectUserTerminal());
            militTerminal.Authentication("test", "test");
            var terminal = militTerminal.RecruitTerminal;
            Assert.IsTrue(terminal.readAccess && terminal.writeAccess);
        }

        private void GetRtWithNotAuthorizated()
        {
            var militTerminal = new MilitTerminal(new CorrectUserTerminal());
            var terminal = militTerminal.RecruitTerminal;

            Assert.IsFalse(terminal.readAccess && terminal.writeAccess);
        }

        //проверка на получение RecruitTerminal
        [TestMethod()]
        public void GetRecruitTerminal()
        {
            GetRtWithAuthorizated();
            GetRtWithNotAuthorizated();
        }



        private void GetOtWithAuthorizated()
        {
            var militTerminal = new MilitTerminal(new CorrectUserTerminal());
            militTerminal.Authentication("test", "test");
            var terminal = militTerminal.OrderTerminal;
            Assert.IsTrue(terminal.readAccess && terminal.writeAccess);
        }

        private void GetOtWithNotAuthorizated()
        {
            var militTerminal = new MilitTerminal(new CorrectUserTerminal());
            var terminal = militTerminal.OrderTerminal;

            Assert.IsFalse(terminal.readAccess && terminal.writeAccess);
        }

        //проверка на получение OrderTerminal
        [TestMethod()]
        public void GetOrderTerminal()
        {
            GetOtWithAuthorizated();
            GetOtWithNotAuthorizated();
        }
    }


    class ExceptionUserTerminal : UserTerminal
    {
        public ExceptionUserTerminal() { }
        public override User GetBylogin(string login)
        {
            return null;
        }
    }

    class CorrectUserTerminal : UserTerminal
    {
        public CorrectUserTerminal() { readAccess = true; writeAccess = true; }
        public override User GetBylogin(string login)
        {
            return new User("text", "test", "", "", "", UserTypes.Admin);
        }
    }
}
