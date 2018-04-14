using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    public class LetterRepository : ILetterRepository
    {
        DBEntities2 db;

        public LetterRepository()
        {
            db = new DBEntities2();
        }

        public letter_between_administrator_organizationuser Add(letter_between_administrator_organizationuser letter)
        {
            letter=db.letter_between_administrator_organizationuser.Add(letter);
            db.SaveChanges();
            return letter;
        }

        public IEnumerable<letter_between_administrator_organizationuser> Get()
        {
            // 降序排列
            return db.letter_between_administrator_organizationuser.OrderByDescending(p=>p.ID);
        }

        public IEnumerable<letter_between_organizationuser_ordinaryuser> Get1(int organizationUserID)
        {
            return db.letter_between_organizationuser_ordinaryuser.Where(p => p.OrganizationUserID == organizationUserID).OrderByDescending(p => p.ID);
        }

        public IEnumerable<letter_between_administrator_organizationuser> Receive(int organizationUserID)
        {
            // 降序排列
            return db.letter_between_administrator_organizationuser.Where(p => p.organizationUserID == organizationUserID).OrderByDescending(p => p.ID);
        }

        public IEnumerable<letter_between_organizationuser_ordinaryuser> Receive1(int ordinaryUserID)
        {
            return db.letter_between_organizationuser_ordinaryuser.Where(p => p.OrdinaryUserID == ordinaryUserID).OrderByDescending(p => p.ID);
        }

        public letter_between_organizationuser_ordinaryuser Send(letter_between_organizationuser_ordinaryuser letter)
        {
            letter = db.letter_between_organizationuser_ordinaryuser.Add(letter);
            db.SaveChanges();
            return letter;
        }

        public bool Send1(letter_between_organizationuser_ordinaryuser letter)
        {
            // 暂时不做，返回“发送成功”
            return true;
        }
    }
}