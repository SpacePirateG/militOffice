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

        public static Dictionary<Permission, Commands> availableCommands = new Dictionary<Permission, Commands>{
             { Permission.Admin, AdminCommands },
             { Permission.Chief, ChiefCommands },
             { Permission.AssistChief, AssistChiefCommands },
             { Permission.Paramedic, ParamedicCommands },
             { Permission.TechnicalStaff, TechnicalStaffCommands }
        };

        public static Commands AdminCommands = Commands.orderRead |
                                    Commands.orderWrite |
                                    Commands.recruitsRead |
                                    Commands.recruitsWrite |
                                    Commands.userWrite;

        public static Commands ChiefCommands = Commands.orderRead |
                                    Commands.orderWrite |
                                    Commands.recruitsRead |
                                    Commands.recruitsWrite;

        public static Commands AssistChiefCommands = Commands.orderRead |
                                    Commands.orderWrite |
                                    Commands.recruitsRead |
                                    Commands.recruitsWrite;

        public static Commands ParamedicCommands = Commands.recruitsRead | Commands.recruitsWrite;

        public static Commands TechnicalStaffCommands = Commands.orderRead |
                                    Commands.orderWrite |
                                    Commands.recruitsRead |
                                    Commands.recruitsWrite;

    }
}
