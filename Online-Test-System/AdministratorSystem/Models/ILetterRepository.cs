using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorSystem.Models
{
    public interface ILetterRepository
    {
        // 管理员给机构用户发站内信息
        letter_between_administrator_organizationuser Add(letter_between_administrator_organizationuser letter);
        // 机构用户给普通用户发站内信息，两种方式：
        // 第一种，站内发送
        letter_between_organizationuser_ordinaryuser Send(letter_between_organizationuser_ordinaryuser letter);
        // 第二种，短信发送
        bool Send1(letter_between_organizationuser_ordinaryuser letter);
        // 管理员查询发送给机构用户的站内消息
        IEnumerable<letter_between_administrator_organizationuser> Get();
        // 机构用户查询来自管理员发送过来的站内消息
        IEnumerable<letter_between_administrator_organizationuser> Receive(int organizationUserID);
        // 机构用户查询发送给普通用户的站内消息
        IEnumerable<letter_between_organizationuser_ordinaryuser> Get1(int organizationUserID);
        // 普通用户查询站内消息
        IEnumerable<letter_between_organizationuser_ordinaryuser> Receive1(int ordinaryUserID);
    }
}
