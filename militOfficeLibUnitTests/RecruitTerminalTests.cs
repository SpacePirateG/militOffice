using System;
using militOfficeLib;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using System.Data;

namespace militOfficeLib.UnitTests
{
    class StorageMock:Storage
    {
        public bool isValidQuery
        {
            get;
            set;
        }

        public StorageMock():base("","","","","")
        {

        }

        public override DataTable Query(string sql)
        {
            isValidQuery = sql != String.Empty;
            return new DataTable();
        }
    }



    [TestClass]
    public class RecruitTerminalTests
    {
        StorageMock storage = new StorageMock();

        Recruit recruit = new Recruit(
                4,
                "Sergey",
                "YREY",
                "YRTE",
                new DateTime(1996, 5, 18),
                "35634",
                "9692352355",
                "adress1",
                "A",
                "a",
                new DateTime(2018, 9, 1)
                );

        [TestInitialize]
        public void intialize()
        {
            storage.isValidQuery = false;
        }


       // GetAll
       [TestMethod]
       public void GetAll_validQuery()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);

           var result = recruitTerminal.GetAll();

           Assert.IsTrue(storage.isValidQuery);
           Assert.IsNotNull(result);
           Assert.AreEqual(0,((List<Recruit>)result).Count);

       }

       [TestMethod]
       [ExpectedException(typeof(PermissionDeniedException))]
       public void GetAll_withoutPermission()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, false);
           recruitTerminal.GetAll();
       }

       // GetByCategory

       [TestMethod]
       [ExpectedException(typeof(ArgumentException))]
       public void GetByCategory_null()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);

           var result = recruitTerminal.GetByCategory(null);

       }

       [TestMethod]
       public void GetByCategory_validQuery()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);

           var result = recruitTerminal.GetByCategory("A");

           Assert.IsTrue(storage.isValidQuery);
           Assert.IsNotNull(result);
           Assert.AreEqual(0, ((List<Recruit>)result).Count);
       }

       [TestMethod]
       [ExpectedException(typeof(PermissionDeniedException))]
       public void GetByCategory_withoutPermission()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, false);
           recruitTerminal.GetByCategory("A");

       }

       // GetByConviction
       [TestMethod]
       [ExpectedException(typeof(ArgumentException))]
       public void GetByConviction_null()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);

           var result = recruitTerminal.GetByConviction(null);
       }

       [TestMethod]
       public void GetByConviction_validQuery()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);

           var result = recruitTerminal.GetByConviction("нет");

           Assert.IsTrue(storage.isValidQuery);
           Assert.IsNotNull(result);
           Assert.AreEqual(0, ((List<Recruit>)result).Count);
       }

       [TestMethod]
       [ExpectedException(typeof(PermissionDeniedException))]
       public void GetByConviction_withoutPermission()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, false);
           recruitTerminal.GetByConviction("Нет");
       }

       // GetByPostponement
       [TestMethod]
       public void GetByPostponement_validQuery()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);

           var result = recruitTerminal.GetByPostponement(DateTime.MinValue);

           Assert.IsTrue(storage.isValidQuery);
           Assert.IsNotNull(result);
           Assert.AreEqual(0, ((List<Recruit>)result).Count);
       }

       [TestMethod]
       [ExpectedException(typeof(PermissionDeniedException))]
       public void GetByPostponement_withoutPermission()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, false);
           recruitTerminal.GetByPostponement(DateTime.MinValue);
       }

       //GetById
       [TestMethod]
       public void GetById_validQuery()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);

           var result = recruitTerminal.GetById(1);

           Assert.IsTrue(storage.isValidQuery);
           Assert.IsNull(result);
       }

       [TestMethod]
       [ExpectedException(typeof(PermissionDeniedException))]
       public void GetById_withoutPermission()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, false);
           recruitTerminal.GetById(1);
       }

       //Add
       [TestMethod]
       [ExpectedException(typeof(ArgumentException))]
       public void Add_null()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);
           recruitTerminal.Add(null);

       }

       [TestMethod]
       public void Add_validQuery()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);

           recruitTerminal.Add(recruit);

           Assert.IsTrue(storage.isValidQuery);
       }

       [TestMethod]
       [ExpectedException(typeof(PermissionDeniedException))]
       public void Add__withoutPermission()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, false);
           recruitTerminal.Add(null);

       }

       //Update
       [TestMethod]
       [ExpectedException(typeof(ArgumentException))]
       public void Update_null()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);
           recruitTerminal.Update(null);

       }

       [TestMethod]
       public void Update_validQuery()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);

           recruitTerminal.Update(recruit);

           Assert.IsTrue(storage.isValidQuery);
       }

       [TestMethod]
       [ExpectedException(typeof(PermissionDeniedException))]
       public void Update__withoutPermission()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, false);
           recruitTerminal.Update(null);
       }

       //DeleteById
       [TestMethod]
       public void DeleteById_validQuery()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, true, true);

           recruitTerminal.DeleteById(1);

           Assert.IsTrue(storage.isValidQuery);
       }

       [TestMethod]
       [ExpectedException(typeof(PermissionDeniedException))]
       public void DeleteById__withoutPermission()
       {
           RecruitTerminal recruitTerminal = new RecruitTerminal(storage, false);
           recruitTerminal.DeleteById(1);
       }
    }
}
