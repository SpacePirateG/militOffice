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
					orderTerminal = new OrderTerminal(storage, AvailableCommands.HasFlag(Commands.orderWrite), AvailableCommands.HasFlag(Commands.orderRead));
				return orderTerminal;
			}
		}
		
		public RecruitTerminal RecruitTerminal{
			get{
				if (recruitTerminal == null && AvailableCommands.HasFlag(Commands.recruitsRead))
					recruitTerminal = new RecruitTerminal(storage, AvailableCommands.HasFlag(Commands.recruitsWrite));
				return recruitTerminal;
			}
		}

		public void Authentication(string login, string password)
        {
            User userByLogin = storage.GetUserBylogin(login);
			if (userByLogin == null || password != user.password)
				throw  new System.Security.Authentication.AuthenticationException("retry authentication");
			user = userByLogin;
        }

		public bool IsAuthenticated()
		{
			return user != null;
		}

        public Commands AvailableCommands
        {
			get{
				if (!IsAuthenticated())
					return Commands.none;

				return Constants.availableCommands[user.permission];
			}
        }

        

    }
}
