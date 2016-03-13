using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		
        public IEnumerable<Recruit> GetAllRecruits()
        {
			if (readAccess)
                return storage.GetAllRecruits();
            else
				throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> GetRecruitsByCategory(string category)
        {
			if (readAccess)
                return storage.GetRecruitsByCategory(category);
            else
				throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> GetRecruitsByConviction(String conviction)
        {
			if (readAccess)
                return storage.GetRecruitsByConviction(conviction);
            else
				throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> GetRecruitsByPostponement(String postponement)
        {
			if (readAccess)
                return storage.GetRecruitsByPostponement(postponement);
            else
				throw new PermissionDeniedException("today is not your day");
        }

        public Recruit GetRecruitById(Int32 id)
        {
			if (readAccess)
                return storage.GetRecruitById(id);
            else
				throw new PermissionDeniedException("today is not your day");
        }

        public void AddRecruit(Recruit recruit)
        {
            if (writeAccess)
                storage.AddRecruit(recruit);
            else
				throw new PermissionDeniedException("today is not your day");
        }
    }
}
