using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    struct Person
    {
        public String name;
        public String surname;
        public DateTime birthday;
        public String pasport;
        public String phoneNumber;
        public String address;
        public Person(
            String name,
            String surname,
            DateTime birthday,
            String pasport,
            String phoneNumber,
            String address
            )
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
            this.pasport = pasport;
            this.phoneNumber = phoneNumber;
            this.address =  address;
        }
    }
}
