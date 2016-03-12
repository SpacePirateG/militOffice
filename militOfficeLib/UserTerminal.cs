using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
	class UserTerminal
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

		public User getUserBylogin(string login)
		{
			if (readAccess)
				return storage.getUserBylogin(login);
			else
				throw new PermissionDeniedException("today is not your day");
		}

		public IEnumerable<User> getAllUsers()
		{
			if (readAccess)
				return storage.getAllUsers();
			else
				throw new PermissionDeniedException("today is not your day");
		}

		public void addUser(User user)
		{
			if (writeAccess)
				storage.addUser(user);
			else
				throw new PermissionDeniedException("today is not your day");
		}

	}
}
