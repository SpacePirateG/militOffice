using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    internal class Constants
    {
        public static string serverName = "localhost";
        public static string userName = "root";
        public static string dbName = "militDB";
        public static string port = "19190";
        public static string password = "root";

        public static Permissions AdminCommands = Permissions.ordersRead |
                                    Permissions.ordersWrite |
                                    Permissions.recruitsRead |
                                    Permissions.recruitsWrite |
                                    Permissions.usersRead |
                                    Permissions.usersWrite;

        public static Permissions ChiefCommands = Permissions.ordersRead |
                                    Permissions.ordersWrite |
                                    Permissions.recruitsRead |
                                    Permissions.recruitsWrite;

        public static Permissions AssistChiefCommands = Permissions.ordersRead |
                                    Permissions.ordersWrite |
                                    Permissions.recruitsRead |
                                    Permissions.recruitsWrite;

        public static Permissions ParamedicCommands = Permissions.recruitsRead;

        public static Permissions TechnicalStaffCommands = Permissions.ordersRead |
                                    Permissions.ordersWrite |
                                    Permissions.recruitsRead |
                                    Permissions.recruitsWrite;

        public static Dictionary<UserTypes, Permissions> availablePermissions = new Dictionary<UserTypes, Permissions>{
             { UserTypes.Admin, AdminCommands },
             { UserTypes.Chief, ChiefCommands },
             { UserTypes.AssistChief, AssistChiefCommands },
             { UserTypes.Paramedic, ParamedicCommands },
             { UserTypes.TechnicalStaff, TechnicalStaffCommands }
        };

    }
}
