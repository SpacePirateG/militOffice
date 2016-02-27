using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    enum Permission
    {
        Paramedic = 0,
        TechnicalStaff = 1,     
        AssistChief = 2,
        Chief = 3,
        Admin = 4
    }

    enum Command
    {
        recruitsRead,
        recruitsWrite,
        recruitsReadWrite,
        userWrite,
        orderRead,
        orderWrite,
        orderReadWrite
    }



    class User
    {
        public String login;
        public String password;
        public String name;
        public String surname;
        public String patronymic;
        public Permission permission;
        public User(
        String login,
        String password,
        String name,
        String surname,
        String patronymic,
        Permission permission
        )
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
        }
    }
}