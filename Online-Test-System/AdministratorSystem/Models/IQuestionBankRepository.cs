using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorSystem.Models
{
    // 管理员题库管理
    public interface IQuestionBankRepository
    {
        // 统计题库题目数量
        int Count(int id);

        // 绑定工种
        bool Binding(int id, int type);

        // 查询试题
        IEnumerable<trueorfalse> Get1(int id);
        IEnumerable<completion> Get2(int id);
        IEnumerable<selection> Get3(int id);
        IEnumerable<questionandanswer> Get4(int id);
        IEnumerable<reading> Get5(int id);
        IEnumerable<composition> Get6(int id);

        // 删除试题
        bool Delete1(int id,int QuestionID);
        bool Delete2(int id,int QuestionID);
        bool Delete3(int id,int QuestionID);
        bool Delete4(int id,int QuestionID);
        bool Delete5(int id,int QuestionID);
        bool Delete6(int id,int QuestionID);

        // 更改试题
        bool Update1(int id, trueorfalse question);
        bool Update2(int id, completion question);
        bool Update3(int id, selection question);
        bool Update4(int id, questionandanswer question);
        bool Update5(int id, reading question);
        bool Update6(int id, composition question);

        // 增加试题
        trueorfalse Add1(int id, trueorfalse question);
        completion Add2(int id, completion question);
        selection Add3(int id, selection question);
        questionandanswer Add4(int id, questionandanswer question);
        reading Add5(int id, reading question);
        composition Add6(int id, composition question);
    }
}
