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
		
        public IEnumerable<Recruit> getAllRecruits()
        {
			if (readAccess)
                return storage.getAllRecruits();
            else
				throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> getRecruitsByCategory(string category)
        {
			if (readAccess)
                return storage.getRecruitsByCategory(category);
            else
				throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> getRecruitsByConviction(String conviction)
        {
			if (readAccess)
                return storage.getRecruitsByConviction(conviction);
            else
				throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> getRecruitsByPostponement(String postponement)
        {
			if (readAccess)
                return storage.getRecruitsByPostponement(postponement);
            else
				throw new PermissionDeniedException("today is not your day");
        }

        public Recruit getRecruitById(Int32 id)
        {
			if (readAccess)
                return storage.getRecruitById(id);
            else
				throw new PermissionDeniedException("today is not your day");
        }

        public void addRecruit(Recruit recruit)
        {
            if (writeAccess)
                storage.addRecruit(recruit);
            else
				throw new PermissionDeniedException("today is not your day");
        }
    }
}
