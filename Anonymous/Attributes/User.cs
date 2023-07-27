using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous.Attributes
{
    [Mota("Lớp người dùng")]
    public class User
    {
        [Mota("Tuổi")]
        public int Age { get; set; }

        [Mota("Hiển thị tuổi")]
        public void showAge()
        {
        }
    }
}
