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

		public IEnumerable<Order> getAllOrders()
		{
			if (readAccess)
				return storage.getAllOrders();
			else
				throw new PermissionDeniedException("today is not your day");
		}

		public IEnumerable<Order> getAllOrdersByDate(DateTime date)
		{
			if (readAccess)
				return storage.getAllOrdersByDate(date);
			else
				throw new PermissionDeniedException("today is not your day");
		}

		public Order getOrderByRecruitId(Int32 id)
		{
			if (readAccess)
				return storage.getOrderByRecruitId(id);
			else
				throw new PermissionDeniedException("today is not your day");
		}

		public void addOrder(Order order)
		{
			if (writeAccess)
				storage.addOrder(order);
			else
				throw new PermissionDeniedException("today is not your day");
		}
	}
}
