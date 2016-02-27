using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    class Admin: Command
    {
        Dictionary<string, Command> commands;
        public Admin()
        {
            commands.Add("add_recrut", new AddRecrut());
            commands.Add("select_recrut", new SelectRecruts());
            
        }

        public object execute(object param)
        {
            var key = (string)param;
            var command = commands.First((c) => c.Key == key);

            command.Value.execute(param);
            return new object();
        }
    }
}
