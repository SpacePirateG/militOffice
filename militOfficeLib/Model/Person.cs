using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    class Person
    {
        public Int32 id;
        public String name;
        public String surname;
        public String patronymic;
        public DateTime birthday;
        public String pasport;
        public String phoneNumber;
        public String address;
        public Person(
            Int32 id,
            String name,
            String surname,
            String patronymic,
            DateTime birthday,
            String pasport,
            String phoneNumber,
            String address
            )
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.birthday = birthday;
            this.pasport = pasport;
            this.phoneNumber = phoneNumber;
            this.address =  address;
        }
    }
}
