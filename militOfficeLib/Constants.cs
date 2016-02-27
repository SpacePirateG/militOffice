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

        public static Dictionary<Permission, IEnumerable<Command>> availableCommands = new Dictionary<Permission, IEnumerable<Command>>{
             { 
                 Permission.Admin, new List<Command>(){
                       Command.orderReadWrite,
                       Command.recruitsReadWrite,
                       Command.userWrite
                    }
             },
             { 
                 Permission.Chief, new List<Command>(){
                       Command.orderReadWrite,
                       Command.recruitsReadWrite
                    }
             },
             { 
                 Permission.AssistChief, new List<Command>(){
                       Command.orderReadWrite,
                       Command.recruitsReadWrite
                    }
             },
             { 
                 Permission.Paramedic, new List<Command>(){
                       Command.recruitsReadWrite
                    }
             },
             { 
                 Permission.TechnicalStaff, new List<Command>(){
                       Command.orderReadWrite,
                       Command.recruitsReadWrite
                    }
             }


       };

    }
}
