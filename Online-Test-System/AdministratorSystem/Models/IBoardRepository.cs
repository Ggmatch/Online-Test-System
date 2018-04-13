using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorSystem.Models
{
    // 系统公告
    public interface IBoardRepository
    {
        // 增加三类公告
        board Add(board b);
        board1 Add1(board1 b);
        board2 Add2(board2 b);
        // 查询三类公告
        IEnumerable<board> Get();
        IEnumerable<board1> Get1();
        IEnumerable<board2> Get2();
    }
}
