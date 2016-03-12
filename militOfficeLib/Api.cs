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
		
		public OrderTerminal OrderTerminal{
			get{
				if (orderTerminal == null)
					orderTerminal = new OrderTerminal(storage, availableCommands.HasFlag(Commands.orderWrite), availableCommands.HasFlag(Commands.orderRead));
				return orderTerminal;
			}
		}
		
		public RecruitTerminal RecruitTerminal{
			get{
				if (recruitTerminal == null && availableCommands.HasFlag(Commands.recruitsRead))
					recruitTerminal = new RecruitTerminal(storage, availableCommands.HasFlag(Commands.recruitsWrite));
				return recruitTerminal;
			}
		}

		public void authentication(string login, string password)
        {
            User userByLogin = storage.getUserBylogin(login);
			if (userByLogin == null || password != user.password)
				throw  new System.Security.Authentication.AuthenticationException("retry authentication");
			user = userByLogin;
        }

		public bool isAuthenticated()
		{
			return user != null;
		}

        public Commands availableCommands
        {
			get{
				if (!isAuthenticated())
					return Commands.none;

				return Constants.availableCommands[user.permission];
			}
        }

        

    }
}
