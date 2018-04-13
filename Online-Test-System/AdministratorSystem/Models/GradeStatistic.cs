using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorSystem.Models
{
    // 成绩管理模块中，成绩统计临时表
    public class GradeStatistic
    {
        // 考生个数
        public int Examinee { get; set; }
        // 及格人数
        public int Winner { get; set; }
        // 未及格人数
        public int Loser { get; set; }
        // 合格率
        public double Rate { get; set; }
    }
}