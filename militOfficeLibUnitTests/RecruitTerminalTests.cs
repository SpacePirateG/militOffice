using System;
using militOfficeLib;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace militOfficeLibUnitTests
{
    [TestClass]
    public class RecruitTerminalTests
    {

        static String dbName = "test";
        static String tableName = "recruits";

        Recruit[] recruits = new Recruit[]{
                new Recruit(0,"V","Dv","Se",new DateTime(1994,4,17), "5262462", "+7696929626", "adr", "A","Нет", new DateTime(2018,8,1)),
                new Recruit(1,"S","V","Al",new DateTime(1994,5,18), "35634", "+7696346336", "adress", "B3","aga", new DateTime(2018,8,1)),
                new Recruit(1,"HR","TWR","DFD",new DateTime(1994,3,18), "2366346", "+762362366", "ess", "B3","rwga", new DateTime(2018,8,1))
        };

        Storage storage = new Storage(
                Constants.serverName,
                Constants.userName,
                dbName,
                Constants.port,
                Constants.password
        );

        private RecruitTerminal createRecruitTerminal(Boolean writeAccess, Boolean readAccess = true){
            return new RecruitTerminal(storage, writeAccess, readAccess);
        }

        private  void initDB(){
            String query;
            foreach(var recruit in recruits){
                query = String.Format("INSERT INTO {0} VALUES(NULL,'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                        tableName,
                        recruit.name,
                        recruit.surname,
                        recruit.patronymic,
                        recruit.birthday,
                        recruit.pasport,
                        recruit.phoneNumber,
                        recruit.address,
                        recruit.category,
                        recruit.conviction,
                        recruit.postponement
                    );
                storage.Query(query);
            }
        }

        private void clearDB()
        {
            String query = String.Format("TRUNCATE TABLE {0}", tableName);
            storage.Query(query);
        }

        

        //GetAll
        [TestMethod]
        public void GetAll_deleting()
        {
            //initDB();
            //RecruitTerminal terminal = createRecruitTerminal(true, true);
            //terminal.DeleteById(0);
            //terminal.DeleteById(1);
            

        }

        [TestMethod]
        public void GetAll_adding()
        {

        }

        [TestMethod]
        public void GetAll_withoutPermission()
        {

        }

        //GetByCategory
        [TestMethod]
        public void GetByCategory_deleting()
        {

        }

        [TestMethod]
        public void GetByCategory_adding()
        {

        }

        [TestMethod]
        public void GetByCategory_withoutPermission()
        {

        }

        //GetByConviction
        [TestMethod]
        public void GetByConviction_deleting()
        {

        }

        [TestMethod]
         public void GetByConviction_adding()
        {

        }

        [TestMethod]
        public void GetByConviction_withoutPermission()
        {

        }

        //GetByConviction
        [TestMethod]
        public void GetByPostponement_deleting()
        {

        }

        [TestMethod]
        public void GetByPostponement_adding()
        {

        }

        [TestMethod]
        public void GetByPostponement_withoutPermission()
        {

        }

        //GetById
        [TestMethod]
        public void GetById_deleting()
        {

        }

        [TestMethod]
        public void GetById_adding()
        {

        }

        [TestMethod]
        public void GetById_withoutPermission()
        {

        }

        //Add
        public void Add_withPermission()
        {

        }

        public void Add__withoutPermission()
        {

        }


        //Update
        public void Update_withPermission()
        {

        }

        public void Update__withoutPermission()
        {

        }

        //DeleteById
        public void DeleteById_withPermission()
        {

        }

        public void DeleteById__withoutPermission()
        {

        }
    }
}
