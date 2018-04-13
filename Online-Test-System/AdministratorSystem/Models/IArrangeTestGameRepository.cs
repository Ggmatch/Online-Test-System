using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorSystem.Models
{
    public interface IArrangeTestGameRepository
    {
        // 安排考试
        bool ArrangeTestGame(arrange_testgame_between_ordinaryuser_and_testpaper tg);
    }
}
