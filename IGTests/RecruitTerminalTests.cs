using System;
using militOfficeLib;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace militOfficeLib.IntegrationTests
{
    [TestClass]
    public class RecruitTerminalTests
    {

        static String dbName = "test";
        static String tableName = "recruits";
    
        List<Recruit> recruits = new List<Recruit>{
            new Recruit(1,"V","Dv","Se",new DateTime(1994,4,17), "5262462", "9696929626", "adr", "A","Нет", new DateTime(2018,8,1)),
            new Recruit(2,"S","V","Al",new DateTime(1994,5,18), "35634", "9696346336", "adress", "B3","aga", new DateTime(2018,8,1)),
            new Recruit(3,"HR","TWR","DFD",new DateTime(1994,3,18), "2366346", "9623623669", "ess", "B3","rwga", new DateTime(2018,8,1))
        };
    
        Recruit addingRecruit = new Recruit(
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
    
        Storage storage = new Storage(
                Constants.serverName,
                Constants.userName,
                dbName,
                Constants.port,
                Constants.password
        );
    
        private RecruitTerminal omnipotentTerminal;

        public RecruitTerminalTests()
        {
            omnipotentTerminal = CreateRecruitTerminal(true, true);
        }
    
        private RecruitTerminal CreateRecruitTerminal(Boolean writeAccess, Boolean readAccess = true)
        {
            return new RecruitTerminal(storage, writeAccess, readAccess);
        }
    
        [TestInitialize]
        public void InitDB()
        {
            String query = String.Format("TRUNCATE TABLE {0}", tableName);
            storage.Query(query);
    
            foreach (var recruit in recruits)
            {
                query = String.Format("INSERT INTO {0} VALUES(NULL,'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                        tableName,
                        recruit.name,
                        recruit.surname,
                        recruit.patronymic,
                        recruit.birthday.ToString("yyyy-MM-dd H:mm:ss"),
                        recruit.pasport,
                        recruit.phoneNumber,
                        recruit.address,
                        recruit.category,
                        recruit.conviction,
                        recruit.postponement.ToString("yyyy-MM-dd H:mm:ss")
                    );
                storage.Query(query);
            }
        }
    
        //GetAll
        [TestMethod]
        public void GetAll_deleting()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
    
            omnipotentTerminal.DeleteById(1);
            omnipotentTerminal.DeleteById(2);
    
            var result = (List<Recruit>)recruitTerminal.GetAll();
    
            Assert.IsFalse(result.Contains(recruits[0]));
            Assert.IsFalse(result.Contains(recruits[1]));
            Assert.IsTrue(result.Contains(recruits[2]));
        }
    
        [TestMethod]
        public void GetAll_adding()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
    
            omnipotentTerminal.Add(addingRecruit);
            var result = (List<Recruit>)recruitTerminal.GetAll();
    
            Assert.IsTrue(result.Contains(recruits[0]));
            Assert.IsTrue(result.Contains(recruits[1]));
            Assert.IsTrue(result.Contains(recruits[2]));
            Assert.IsTrue(result.Contains(addingRecruit));
    
        }
    
        //GetByCategory
        [TestMethod]
        public void GetByCategory_deleting()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
            String category = "A";
    
            omnipotentTerminal.DeleteById(1);
            var result = (List<Recruit>)recruitTerminal.GetByCategory(category);
    
            Assert.IsFalse(result.Contains(recruits[0]));
        }
    
        [TestMethod]
        public void GetByCategory_adding()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
    
            String category = "A";
    
            addingRecruit.category = category;
            omnipotentTerminal.Add(addingRecruit);
            var result = (List<Recruit>)recruitTerminal.GetByCategory(category);
    
            Assert.IsTrue(result.Contains(addingRecruit));
    
        }
    
        //GetByConviction
        [TestMethod]
        public void GetByConviction_deleting()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
            String conviction = "Нет";
    
            omnipotentTerminal.DeleteById(1);
            var result = (List<Recruit>)recruitTerminal.GetByConviction(conviction);
    
            Assert.IsFalse(result.Contains(recruits[0]));
        }
    
        [TestMethod]
        public void GetByConviction_adding()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
    
            String conviction = "Нет";
    
            addingRecruit.conviction = conviction;
            omnipotentTerminal.Add(addingRecruit);
            var result = (List<Recruit>)recruitTerminal.GetByConviction(conviction);
    
            Assert.IsTrue(result.Contains(addingRecruit));
        }
    
        //GetByPostponement
        [TestMethod]
        public void GetByPostponement_deleting()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
            DateTime postponement = new DateTime(2018, 8, 1);
    
            omnipotentTerminal.DeleteById(1);
            var result = (List<Recruit>)recruitTerminal.GetByPostponement(postponement);
    
            Assert.IsFalse(result.Contains(recruits[0]));
        }
    
        [TestMethod]
        public void GetByPostponement_adding()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
    
            DateTime postponement = new DateTime(2018, 8, 1);
    
            addingRecruit.postponement = postponement;
            omnipotentTerminal.Add(addingRecruit);
            var result = (List<Recruit>)recruitTerminal.GetByPostponement(postponement);
    
            Assert.IsTrue(result.Contains(addingRecruit));
        }
    
        //GetById
        [TestMethod]
        public void GetById_deleting()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
            int id = 1;
    
            omnipotentTerminal.DeleteById(id);
            var result = recruitTerminal.GetById(id);
    
            Assert.IsNull(result);
        }
    
        [TestMethod]
        public void GetById_adding()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
    
            int id = 4;
    
            omnipotentTerminal.Add(addingRecruit);
            var result = recruitTerminal.GetById(id);
    
            Assert.AreEqual(addingRecruit, result);
        }
    
        //Add
        [TestMethod]
        public void Add_withPermission()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
    
            recruitTerminal.Add(addingRecruit);
            var result = (List<Recruit>)omnipotentTerminal.GetAll();
    
            Assert.IsTrue(result.Contains(addingRecruit));
        }
    
        //Update
        [TestMethod]
        public void Update_withPermission()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
            addingRecruit.id = 1;
            recruitTerminal.Update(addingRecruit);
    
            var result = (List<Recruit>)omnipotentTerminal.GetAll();
            var rec = result.Find(recruit => recruit.id == 1);
    
            Assert.AreEqual(addingRecruit, rec);
        }

        //DeleteById
        [TestMethod]
        public void DeleteById_withPermission()
        {
            RecruitTerminal recruitTerminal = CreateRecruitTerminal(true);
            recruitTerminal.DeleteById(1);
    
            var result = (List<Recruit>)omnipotentTerminal.GetAll();
    
            Assert.IsFalse(result.Contains(recruits[0]));
        }
    
       
    }
}
