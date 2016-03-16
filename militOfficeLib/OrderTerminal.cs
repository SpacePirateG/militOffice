using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace militOfficeLib
{
    public class OrderTerminal
    {
        private Storage storage;
        private Boolean readAccess;
        private Boolean writeAccess;

        internal OrderTerminal(Storage storage, Boolean writeAccess, Boolean readAccess = true)
        {
            this.readAccess = readAccess;
            this.writeAccess = writeAccess;
            this.storage = storage;
        }

        public IEnumerable<Order> GetAll()
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Order> GetAllByDate(DateTime date)
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public Order GetByRecruitId(Int32 id)
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void Add(Order order)
        {
            if (writeAccess)
            {
                DataTable dataTable = storage.Query("");
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void Update(Order order)
        {
            if (writeAccess)
            {
                storage.Query("");
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void DeleteById(int id)
        {
            if (writeAccess)
            {
                storage.Query("");
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }
    }
}
