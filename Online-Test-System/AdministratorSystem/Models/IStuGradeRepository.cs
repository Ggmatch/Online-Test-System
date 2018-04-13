using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorSystem.Models
{
    public interface IStuGradeRepository
    {
        // 查询考生考试成绩
        int GetScore(int stuID, int paperID, int state);
        // 成绩统计
        GradeStatistic Count(int testPaperID);
        // 查询补考考生情况
        GradeStatistic Count1(int testPaperID);
    }
}
