using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militOfficeLib
{
    class Api
    {
        public User user;
        public Storage storage;
        public Api()
        {
            storage = new Storage(
                Constants.serverName,
                Constants.userName,
                Constants.dbName,
                Constants.port,
                Constants.password
            );
        }
        public bool autentificate(string login, string password)
        {
            user = storage.getUserBylogin(login);

            return user != null && password == user.password;
        }

        public Commands getAvailableCommands()
        {
            return Constants.availableCommands[user.permission];
        }


        public IEnumerable<Recruit> getAllRecruits()
        {
            if (getAvailableCommands().HasFlag(Commands.recruitsRead))
                return storage.getAllRecruits();
            else
                throw new PermissionDeniedException();
        }

        public IEnumerable<Recruit> getRecruitsByCategory(string category)
        {
            if (getAvailableCommands().HasFlag(Commands.recruitsRead))
                return storage.getRecruitsByCategory(category);
            else
                throw new PermissionDeniedException();
        }

        public IEnumerable<Recruit> getRecruitsByConviction(String conviction)
        {
            if (getAvailableCommands().HasFlag(Commands.recruitsRead))
                return storage.getRecruitsByConviction(conviction);
            else
                throw new PermissionDeniedException();
        }

        public IEnumerable<Recruit> getRecruitsByPostponement(String postponement)
        {
            if (getAvailableCommands().HasFlag(Commands.recruitsRead))
                return storage.getRecruitsByPostponement(postponement);
            else
                throw new PermissionDeniedException();
        }

        public Recruit getRecruitById(Int32 id)
        {
            if (getAvailableCommands().HasFlag(Commands.recruitsRead))
                return storage.getRecruitById(id);
            else
                throw new PermissionDeniedException();
        }

        public void addRecruit(Recruit recruit)
        {
            if (getAvailableCommands().HasFlag(Commands.recruitsWrite))
                storage.addRecruit(recruit);
            else
                throw new PermissionDeniedException();
        }

        public IEnumerable<Order> getAllOrders()
        {
            if (getAvailableCommands().HasFlag(Commands.orderRead))
                return storage.getAllOrders();
            else
                throw new PermissionDeniedException();
        }

        public IEnumerable<Order> getAllOrdersByDate(DateTime date)
        {
            if (getAvailableCommands().HasFlag(Commands.orderRead))
                return storage.getAllOrdersByDate(date);
            else
                throw new PermissionDeniedException();
        }

        public Order getOrderByRecruitId(Int32 id)
        {
            if (getAvailableCommands().HasFlag(Commands.orderRead))
                return storage.getOrderByRecruitId(id);
            else
                throw new PermissionDeniedException();
        }

        public void addOrder(Order order)
        {
            if (getAvailableCommands().HasFlag(Commands.orderWrite))
                storage.addOrder(order);
            else
                throw new PermissionDeniedException();
        }

        public void addUser(User user)
        {
            if (user.permission >= Permission.TechnicalStaff)
                storage.addUser(user);
            else
                throw new PermissionDeniedException();
        }

    }
}
