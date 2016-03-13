using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    public class OrderTerminal
    {
        private Storage storage;
        private Boolean readAccess;
        private Boolean writeAccess;

        internal OrderTerminal(Storage storage, Boolean writeAccess, Boolean readAccess = true)
        {
            this.readAccess = readAccess;
            this.writeAccess = writeAccess;
            this.storage = storage;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            if (readAccess)
                return storage.GetAllOrders();
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Order> GetAllOrdersByDate(DateTime date)
        {
            if (readAccess)
                return storage.GetAllOrdersByDate(date);
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public Order GetOrderByRecruitId(Int32 id)
        {
            if (readAccess)
                return storage.GetOrderByRecruitId(id);
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void AddOrder(Order order)
        {
            if (writeAccess)
                storage.AddOrder(order);
            else
                throw new PermissionDeniedException("today is not your day");
        }
    }
}
