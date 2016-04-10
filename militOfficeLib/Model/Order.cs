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
        public Int32 recruitId;
        public DateTime date;
        public String cause;
        public Order() { }
        public Order(
            Int32 id,
            Int32 recruitId,
            DateTime date,
            String cause
            )
        {
            this.id = id;
            this.recruitId = recruitId;
            this.date = date;
            this.cause = cause;
        }
    }
}
