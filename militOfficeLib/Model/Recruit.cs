using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    class Recruit : Person
    {
        public String category;
        public String conviction;
        public DateTime postponement;
        public Recruit(
            Int32 id,
            String name,
            String surname,
            String patronymic,
            DateTime birthday,
            String pasport,
            String phoneNumber,
            String address,
            String category,
            String conviction,
            DateTime postponement
            )
            : base(
               id,
               name,
               surname,
               patronymic,
               birthday,
               pasport,
               phoneNumber,
               address
              )
        {
            this.category = category;
            this.conviction = conviction;
            this.postponement = postponement;
        }
    }
}
