using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous.Collection
{
    public class TestLinkedList
    {
        public static void Test() 
        {
            LinkedList<string> cacbaihoc = new LinkedList<string>();

            cacbaihoc.AddFirst("Bài học 3");   // thêm vào đầu danh sach
            cacbaihoc.AddLast("Bài học 15");    // thêm vào cuối
            cacbaihoc.AddFirst("Bài học 2");
            cacbaihoc.AddFirst("Bài học 1");

            Console.WriteLine("---------Nút từ đầu về cuối");
            LinkedListNode<string> node = cacbaihoc.First;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;   // node gán bằng nút sau nó
            }

            Console.WriteLine("--------Nút từ cuối đến đầu");
            node = cacbaihoc.Last;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Previous;   // node gán bằng nút phía trước nó
            }
        }
    }
}
