using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace militOfficeLib
{
    public class OrderTerminal
    {
        private Storage storage;
        public Boolean readAccess { get; private set; }
        public Boolean writeAccess { get; private set; }

        internal OrderTerminal(Storage storage, Boolean writeAccess, Boolean readAccess = true)
        {
            this.readAccess = readAccess;
            this.writeAccess = writeAccess;
            this.storage = storage;
        }

        private IEnumerable<Order> DataTableToIEnumerable(DataTable table)
        {
            try
            {
                List<Order> orders = new List<Order>();

                foreach (var row in table.AsEnumerable())
                {
                    Order order = new Order();

                    foreach (var field in order.GetType().GetFields())
                    {
                        FieldInfo fieldInfo = order.GetType().GetField(field.Name);
                        fieldInfo.SetValue(order, Convert.ChangeType(row[field.Name], fieldInfo.FieldType));
                    }

                    orders.Add(order);
                }

                return orders;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            if (readAccess)
            {
                String query = "SELECT * FROM orders";
                DataTable dataTable = storage.Query(query);

                return DataTableToIEnumerable(dataTable);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Order> GetAllByDate(DateTime date)
        {
            if (readAccess)
            {
                String query = String.Format("SELECT * FROM WHERE date = '{0}'", date);
                DataTable dataTable = storage.Query(query);

                return DataTableToIEnumerable(dataTable);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public Order GetByRecruitId(Int32 id)
        {
            if (readAccess)
            {
                DataTable dataTable = storage.Query("");
                return null;
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void Add(Order order)
        {
            if (writeAccess)
            {
                String query = String.Format(
                    "INSERT INTO orders VALUES ('{0}','{1})",
                    order.date, order.cause);

               storage.Query(query);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void Update(Order order)
        {
            if (writeAccess)
            {
                String query = String.Format(
                    "UPDATE `orders` SET `id`= {0},`date`='{1}',`cause`= '{2}'",
                    order.id, order.date, order.cause);

                storage.Query(query);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void DeleteById(int id)
        {
            if (writeAccess)
            {
                String query = String.Format(
                    "DELETE FROM `orders` WHERE 1", id);
                storage.Query(query);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }
    }
}
