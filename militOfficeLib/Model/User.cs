using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    public enum Permission
    {
        Paramedic = 0,
        TechnicalStaff = 1,     
        AssistChief = 2,
        Chief = 3,
        Admin = 4
    }

    [Flags]
    public enum Commands
    {
        none = 0x0,
        recruitsRead = 0x1,
        recruitsWrite = 0x2,
        orderRead = 0x4,
        orderWrite = 0x8,
		userRead = 0x10,
		userWrite = 0x20

    }



    public class User
    {
        public String login;
        internal String password;
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
            this.permission = permission;
        }
    }
}