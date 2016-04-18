using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using militOfficeLib;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace militOfficeLibUnitTests
{
    class StorageMock : Storage
    {
        public bool isValidQuery
        {
            get;
            set;
        }
        
        public StorageMock()
            : base("", "", "", "", "")
        {

        }

        public override DataTable Query(string sql)
        {
            isValidQuery = sql != String.Empty;
            return new DataTable();
        }
    }
     [TestClass]
    public class OrderTerminalTests
    {
        StorageMock storage = new StorageMock();

        Order order = new Order(
            1,
            1,
            new DateTime(2016, 4, 14),
            "Первоначальная постановка на воинский учет");

        [TestInitialize]
        public void intialize()
        {
            storage.isValidQuery = false;
        }
        // GetAll
        [TestMethod]
        public void GetAll_validQuery()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, true);

            var result = orderTerminal.GetAll();

            Assert.IsTrue(storage.isValidQuery);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, ((List<Order>)result).Count);

        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void GetAll_withoutPermission()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, false);
            orderTerminal.GetAll();
        }

        //GetAllByDate
        [TestMethod]
        public void GetAllByDate_validQuery()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, true);

            var result = orderTerminal.GetAllByDate(new DateTime(2016, 4, 14));

            Assert.IsTrue(storage.isValidQuery);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, ((List<Order>)result).Count);
        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void GetAllByDate_withoutPermission()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, false);
            orderTerminal.GetAllByDate(new DateTime(2016, 4, 14));

        }
        //GetById
        [TestMethod]
        public void GetByRecruitId_validQuery()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, true);

            var result = orderTerminal.GetByRecruitId(1);

            Assert.IsTrue(storage.isValidQuery);
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void GetByRecruitId_withoutPermission()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, false);
            orderTerminal.GetByRecruitId(1);
        }
        //Add
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_null()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, true);
            orderTerminal.Add(null);

        }

        [TestMethod]
        public void Add_validQuery()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, true);

            orderTerminal.Add(order);

            Assert.IsTrue(storage.isValidQuery);
        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void Add__withoutPermission()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, false);
            orderTerminal.Add(null);

        }

        //Update
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_null()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, true);
            orderTerminal.Update(null);

        }

        [TestMethod]
        public void Update_validQuery()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, true);

            orderTerminal.Update(order);

            Assert.IsTrue(storage.isValidQuery);
        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void Update__withoutPermission()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, false);
            orderTerminal.Update(null);
        }

        //DeleteById
        [TestMethod]
        public void DeleteById_validQuery()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, true, true);

            orderTerminal.DeleteById(1);

            Assert.IsTrue(storage.isValidQuery);
        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void DeleteById__withoutPermission()
        {
            OrderTerminal orderTerminal = new OrderTerminal(storage, false);
            orderTerminal.DeleteById(1);
        }

    }
}
