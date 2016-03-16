using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace militOfficeLib
{
    public class RecruitTerminal
    {
        private Storage storage;
        private Boolean readAccess;
        private Boolean writeAccess;
        public RecruitTerminal(Storage storage, Boolean writeAccess, Boolean readAccess = true)
        {
            this.readAccess = readAccess;
            this.writeAccess = writeAccess;
            this.storage = storage;
        }

        public IEnumerable<Recruit> GetAll()
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> GetByCategory(string category)
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> GetByConviction(String conviction)
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> GetByPostponement(String postponement)
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public Recruit GetById(Int32 id)
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void Add(Recruit recruit)
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
