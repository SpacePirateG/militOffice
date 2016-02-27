using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    class Api
    {
        public User user;
        public Storage storage;
        public Api()
        {
            storage = new Storage(
                Constants.serverName,
                Constants.userName,
                Constants.dbName,
                Constants.port,
                Constants.password
            );
        }
        public bool autentificate(string login, string password)
        {
            user = storage.getUserBylogin(login);

            return user != null && password == user.password;
        }

        public IEnumerable<Command> getAvailableCommands(){
            return Constants.availableCommands[user.permission];
        }

        public IEnumerable<Recruit> getRecruitsByCategory(string category)
        {
            if (user.permission >= Permission.TechnicalStaff)
                return storage.getRecruitsByCategory(category);
            else
                throw new PermissionDeniedException();
        }

    }
}
