using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    public class MilitTerminal
    {
        public User User { get; private set; }
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

        public MilitTerminal(UserTerminal userTerminal)
        {
            this.userTerminal = userTerminal;
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
                User = new User(login,
                    password,
                    "",
                    "",
                    "",
                    UserTypes.TechnicalStaff
                );
            else
            {
                User userByLogin = UserTerminal.GetBylogin(login);

                if (userByLogin == null || password != User.password)
                    throw new System.Security.Authentication.AuthenticationException("retry authentication");
                User = userByLogin;
            }
             /*
            User userByLogin = UserTerminal.GetBylogin(login);

            if (userByLogin == null || password != userByLogin.password)
                throw new System.Security.Authentication.AuthenticationException("retry authentication");
            User = userByLogin;
              */ 
        }

        public bool IsAuthenticated()
        {
            return User != null;
        }

        public Permissions AvailablePermissions
        {
            get
            {
                if (!IsAuthenticated())
                    return Permissions.none;

                return Constants.availablePermissions[User.type];
            }
        }



    }
}
