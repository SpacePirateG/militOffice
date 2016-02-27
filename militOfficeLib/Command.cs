using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    interface Command
    {
        object execute(object param);
    }

    class AddRecrut : Command
    {
        public object execute(object recrut)
        {
            return null;
        }
    }

    class SelectRecruts : Command
    {
        public object execute(object recrut)
        {
            string param = (string)recrut;
    //        var result = Storage.query(param);
            var result = new object();
            return result;
        }
    }
}
