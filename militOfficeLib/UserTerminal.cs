using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace militOfficeLib
{
    public class UserTerminal
    {
        private Storage storage;
        public Boolean readAccess { get; protected set; }
        public Boolean writeAccess { get; protected set; }

        public UserTerminal() { }

        public UserTerminal(Storage storage, Boolean writeAccess, Boolean readAccess = true)
        {
            this.readAccess = readAccess;
            this.writeAccess = writeAccess;
            this.storage = storage;
        }

        public virtual User GetBylogin(string login)
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public virtual IEnumerable<User> GetAll()
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public virtual void Add(User user)
        {
            if (writeAccess)
            {
                DataTable dataTable = storage.Query("");
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public virtual void Delete(Int32 id)
        {
            if (writeAccess)
            {
                DataTable dataTable = storage.Query("");
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

    }
}
