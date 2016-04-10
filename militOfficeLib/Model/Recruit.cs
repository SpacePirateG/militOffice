using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    public class Recruit : Person
    {
        public String category {get; set;}
        public String conviction { get; set; }
        public DateTime postponement { get; set; }

        public Recruit():base() { }
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

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Recruit p = obj as Recruit;
            if ((System.Object)p == null)
            {
                return false;
            }

            return name == p.name &&
                surname == p.surname &&
                patronymic == p.patronymic &&
                birthday == p.birthday &&
                pasport == p.pasport &&
                phoneNumber == p.phoneNumber &&
                address == p.address &&
                category == p.category &&
                conviction == p.conviction &&
                postponement == p.postponement;
        }

        public bool Equals(Recruit p)
        {
            if ((object)p == null)
            {
                return false;
            }

            return name == p.name &&
                surname == p.surname &&
                patronymic == p.patronymic &&
                birthday == p.birthday &&
                pasport == p.pasport &&
                phoneNumber == p.phoneNumber &&
                address == p.address &&
                category == p.category &&
                conviction == p.conviction &&
                postponement == p.postponement;
        }

        public override int GetHashCode()
        {
            string str = id +
                        name +
                        surname +
                        patronymic +
                        birthday +
                        pasport +
                        phoneNumber +
                        address +
                        category +
                        conviction +
                        postponement;

            return str.GetHashCode();
        }
    }
}
