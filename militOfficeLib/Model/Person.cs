using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    public class Person
    {
        public Int32 id { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String patronymic { get; set; }
        public DateTime birthday { get; set; }
        public String pasport { get; set; }
        public String phoneNumber { get; set; }
        public String address { get; set; }

        public Person() { }
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
