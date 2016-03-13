using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
	public class UserTerminal
	{
		private Storage storage;
		private Boolean readAccess;
		private Boolean writeAccess;
		public UserTerminal(Storage storage, Boolean writeAccess, Boolean readAccess = true)
		{
			this.readAccess = readAccess;
			this.writeAccess = writeAccess;
			this.storage = storage;
		}

		public User GetUserBylogin(string login)
		{
			if (readAccess)
				return storage.GetUserBylogin(login);
			else
				throw new PermissionDeniedException("today is not your day");
		}

		public IEnumerable<User> GetAllUsers()
		{
			if (readAccess)
				return storage.GetAllUsers();
			else
				throw new PermissionDeniedException("today is not your day");
		}

		public void AddUser(User user)
		{
			if (writeAccess)
				storage.AddUser(user);
			else
				throw new PermissionDeniedException("today is not your day");
		}

	}
}
