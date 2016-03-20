using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    public class MilitTerminal
    {
        private User user;
        private Storage storage;
        private OrderTerminal orderTerminal;
        private RecruitTerminal recruitTerminal;
        private UserTerminal userTerminal;

        public MilitTerminal()
        {
            storage = new Storage(
                Constants.serverName,
                Constants.userName,
                Constants.dbName,
                Constants.port,
                Constants.password
            );
        }

        public OrderTerminal OrderTerminal
        {
            get
            {
                if (orderTerminal == null)
                    orderTerminal = new OrderTerminal(storage,
                        AvailablePermissions.HasFlag(Permissions.ordersWrite),
                        AvailablePermissions.HasFlag(Permissions.ordersRead)
                    );

                return orderTerminal;
            }
        }

        public RecruitTerminal RecruitTerminal
        {
            get
            {
                if (recruitTerminal == null)
                    recruitTerminal = new RecruitTerminal(storage,
                       AvailablePermissions.HasFlag(Permissions.recruitsWrite),
                       AvailablePermissions.HasFlag(Permissions.recruitsRead)
                    );

                return recruitTerminal;
            }
        }

        public UserTerminal UserTerminal
        {
            get
            {
                if (userTerminal == null)
                    userTerminal = new UserTerminal(storage,
                        AvailablePermissions.HasFlag(Permissions.usersWrite),
                        AvailablePermissions.HasFlag(Permissions.usersRead)
                    );

                return userTerminal;
            }
        }

        public void Authentication(string login, string password)
        {
            if (login == "" && password == "")
                user = new User(login,
                    password,
                    "",
                    "",
                    "",
                    UserTypes.TechnicalStaff
                );
            else
            {
                User userByLogin = userTerminal.GetBylogin(login);

                if (userByLogin == null || password != user.password)
                    throw new System.Security.Authentication.AuthenticationException("retry authentication");
                user = userByLogin;
            }

        }

        public bool IsAuthenticated()
        {
            return user != null;
        }

        public Permissions AvailablePermissions
        {
            get
            {
                if (!IsAuthenticated())
                    return Permissions.none;

                return Constants.availablePermissions[user.permission];
            }
        }



    }
}
