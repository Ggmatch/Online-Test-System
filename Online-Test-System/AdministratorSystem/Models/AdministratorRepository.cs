using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class AdministratorRepository : IAdministratorRepository
    {
        DBEntities db;

        public AdministratorRepository()
        {
            db = new DBEntities();
        }

        public bool ValidateLogOn(administrator admin)
        {
            administrator result = db.administrator.Where(p=>p==admin).FirstOrDefault();
            if(admin!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}