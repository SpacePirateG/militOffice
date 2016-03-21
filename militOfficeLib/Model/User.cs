﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    public enum UserTypes
    {
        Paramedic = 0,
        TechnicalStaff = 1,     
        AssistChief = 2,
        Chief = 3,
        Admin = 4
    }

    [Flags]
    public enum Permissions
    {
        none = 0x0,
        recruitsRead = 0x1,
        recruitsWrite = 0x2,
        ordersRead = 0x4,
        ordersWrite = 0x8,
		usersRead = 0x10,
		usersWrite = 0x20

    }



    public class User
    {
        public String login;
        internal String password;
        public String name;
        public String surname;
        public String patronymic;
        public UserTypes type;
        public User(
        String login,
        String password,
        String name,
        String surname,
        String patronymic,
        UserTypes type
        )
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.type = type;
        }
    }
}