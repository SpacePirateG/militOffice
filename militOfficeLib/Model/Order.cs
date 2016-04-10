using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    public class Order
    {
        public Int32 id { get; set; }
        public Int32 recruitId { get; set; }
        public DateTime date { get; set; }
        public String cause { get; set; }
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
