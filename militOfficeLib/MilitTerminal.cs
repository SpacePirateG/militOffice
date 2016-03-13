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
                        AvailableCommands.HasFlag(Commands.orderWrite),
                        AvailableCommands.HasFlag(Commands.orderRead)
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
                       AvailableCommands.HasFlag(Commands.recruitsWrite),
                       AvailableCommands.HasFlag(Commands.recruitsRead)
                       );
                
                return recruitTerminal;
            }
        }

        public UserTerminal UserTerminal
        {
            get
            {
                if (userTerminal == null)
                {
                    userTerminal = new UserTerminal(storage,
                        AvailableCommands.HasFlag(Commands.userWrite),
                        AvailableCommands.HasFlag(Commands.userRead)
                        );
                }
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
                    Permission.Admin
                );
            else
            {
                User userByLogin = storage.GetUserBylogin(login);

                if (userByLogin == null || password != user.password)
                    throw new System.Security.Authentication.AuthenticationException("retry authentication");
                user = userByLogin;
            }

        }

        public bool IsAuthenticated()
        {
            return user != null;
        }

        public Commands AvailableCommands
        {
            get
            {
                if (!IsAuthenticated())
                    return Commands.none;

                return Constants.availableCommands[user.permission];
            }
        }



    }
}
