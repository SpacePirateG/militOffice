using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace militOfficeLib
{
    public class RecruitTerminal
    {
        private Storage storage;
        public Boolean readAccess { get; private set; }
        public Boolean writeAccess { get; private set; }

        private IEnumerable<Recruit> DataTableToIEnumerable(DataTable table)
        {
            try
            {
                List<Recruit> recruits = new List<Recruit>();

                foreach (var row in table.AsEnumerable())
                {
                    Recruit recruit = new Recruit();

                    foreach (var property in recruit.GetType().GetProperties())
                    {
                        PropertyInfo propertyInfo = recruit.GetType().GetProperty(property.Name);
                        propertyInfo.SetValue(recruit, Convert.ChangeType(row[property.Name], propertyInfo.PropertyType));
                    }

                    recruits.Add(recruit);
                }

                return recruits;
            }
            catch
            {
                return null;
            }
        }

        public RecruitTerminal(Storage storage, Boolean writeAccess, Boolean readAccess = true)
        {
            this.readAccess = readAccess;
            this.writeAccess = writeAccess;
            this.storage = storage;
        }

        public IEnumerable<Recruit> GetAll()
        {
            if (readAccess)
            {
                String query = String.Format("SELECT * FROM {0}", Constants.recruitsTable);
                DataTable dataTable = storage.Query(query);

                return DataTableToIEnumerable(dataTable);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> GetByCategory(string category)
        {
            if (readAccess)
            {
                if (category == null)
                    throw new ArgumentException();

                String query = String.Format("SELECT * FROM {0} WHERE category = '{1}' ",
                    Constants.recruitsTable,
                    category
                    );
                DataTable dataTable = storage.Query(query);
                return DataTableToIEnumerable(dataTable);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> GetByConviction(String conviction)
        {
            if (readAccess)
            {
                if (conviction == null)
                    throw new ArgumentException();

                String query = String.Format("SELECT * FROM {0} WHERE conviction = '{1}' ",
                    Constants.recruitsTable,
                    conviction
                    );
                DataTable dataTable = storage.Query(query);
                return DataTableToIEnumerable(dataTable);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public IEnumerable<Recruit> GetByPostponement(DateTime postponement)
        {
            if (readAccess)
            {
                String query = String.Format("SELECT * FROM {0} WHERE postponement = '{1}' ",
                    Constants.recruitsTable,
                    postponement.ToString("yyyy-MM-dd H:mm:ss")
                    );
                DataTable dataTable = storage.Query(query);
                return DataTableToIEnumerable(dataTable);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public Recruit GetById(Int32 id)
        {
            if (readAccess)
            {
                String query = String.Format("SELECT * FROM {0} WHERE id = {1} ",
                    Constants.recruitsTable,
                    id
                    );
                DataTable dataTable = storage.Query(query);
                var recruits = (List<Recruit>)DataTableToIEnumerable(dataTable);
                if(recruits.Count == 0)
                    return null;

                return recruits[0];
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void Add(Recruit recruit)
        {
            if (writeAccess)
            {
                if (recruit == null)
                    throw new ArgumentException();

                String query = String.Format("INSERT INTO {0} VALUES(NULL,'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                        Constants.recruitsTable,
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
                DataTable dataTable = storage.Query(query);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void Update(Recruit recruit)
        {
            if (writeAccess)
            {
                if (recruit == null)
                    throw new ArgumentException();

                String query = String.Format(@"UPDATE {0} SET 
                            name = '{1}',
                            surname = '{2}',
                            patronymic = '{3}',
                            birthday = '{4}',
                            pasport = '{5}',
                            phoneNumber = '{6}',
                            address = '{7}',
                            category = '{8}',
                            conviction = '{9}',
                            postponement='{10}' WHERE id = {11}",
                        Constants.recruitsTable,
                        recruit.name,
                        recruit.surname,
                        recruit.patronymic,
                        recruit.birthday.ToString("yyyy-MM-dd H:mm:ss"),
                        recruit.pasport,
                        recruit.phoneNumber,
                        recruit.address,
                        recruit.category,
                        recruit.conviction,
                        recruit.postponement.ToString("yyyy-MM-dd H:mm:ss"),
                        recruit.id
                    );
                storage.Query(query);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }

        public void DeleteById(int id)
        {
            if (writeAccess)
            {
                String query = String.Format("DELETE FROM {0} WHERE id = {1}",
                        Constants.recruitsTable,
                        id
                    );
                storage.Query(query);
            }
            else
                throw new PermissionDeniedException("today is not your day");
        }
    }
}
