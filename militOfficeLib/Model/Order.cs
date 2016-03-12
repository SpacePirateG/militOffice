using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    public class Order
    {
        public Int32 id;
        public Recruit recruit;
        public DateTime date;
        public String cause;
        public Order(
            Int32 id,
            Recruit recruit,
            DateTime date,
            String cause
            )
        {
            this.id = id;
            this.recruit = recruit;
            this.date = date;
            this.cause = cause;
        }
    }
}
