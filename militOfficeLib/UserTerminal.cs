using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

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
                String query = String.Format("SELECT * FROM users WHERE login = '{0}'", login);
                DataTable dataTable = storage.Query(query);
                User user = new User();

                foreach (var row in dataTable.AsEnumerable())
                {
                    foreach (var field in user.GetType().GetFields())
                    {
                        FieldInfo fieldInfo = user.GetType().GetField(field.Name);
                        if (fieldInfo.FieldType.Name == "UserTypes")
                            fieldInfo.SetValue(user, Enum.ToObject(new UserTypes().GetType(), 1));
                        else
                            fieldInfo.SetValue(user, Convert.ChangeType(row[field.Name], fieldInfo.FieldType));
                    }

                    return user;
                }

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
