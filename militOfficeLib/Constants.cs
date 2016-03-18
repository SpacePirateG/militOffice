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

        public static Commands AdminCommands = Commands.ordersRead |
                                    Commands.ordersWrite |
                                    Commands.recruitsRead |
                                    Commands.recruitsWrite |
                                    Commands.usersRead |
                                    Commands.usersWrite;

        public static Commands ChiefCommands = Commands.ordersRead |
                                    Commands.ordersWrite |
                                    Commands.recruitsRead |
                                    Commands.recruitsWrite;

        public static Commands AssistChiefCommands = Commands.ordersRead |
                                    Commands.ordersWrite |
                                    Commands.recruitsRead |
                                    Commands.recruitsWrite;

        public static Commands ParamedicCommands = Commands.recruitsRead;

        public static Commands TechnicalStaffCommands = Commands.ordersRead |
                                    Commands.ordersWrite |
                                    Commands.recruitsRead |
                                    Commands.recruitsWrite;

        public static Dictionary<Permission, Commands> availableCommands = new Dictionary<Permission, Commands>{
             { Permission.Admin, AdminCommands },
             { Permission.Chief, ChiefCommands },
             { Permission.AssistChief, AssistChiefCommands },
             { Permission.Paramedic, ParamedicCommands },
             { Permission.TechnicalStaff, TechnicalStaffCommands }
        };

    }
}
