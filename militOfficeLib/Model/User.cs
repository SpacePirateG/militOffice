﻿using System;
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

    [Flags]
    public enum Commands
    {
        none = 0x0,
        recruitsRead = 0x1,
        recruitsWrite = 0x2,
        userWrite = 0x4,
        orderRead = 0x8,
        orderWrite = 0x10
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