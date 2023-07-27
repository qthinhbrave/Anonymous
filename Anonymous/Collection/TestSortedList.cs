using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous.Collection
{
    public class TestSortedList
    {
        public static void Test()
        {
            // Khởi tạo SortedList
            var products = new SortedList<string, string>();
            products.Add("Iphone 6", "P-IPHONE-6"); // Thêm vào phần tử mới (key, value)
            products.Add("Laptop Abc", "P-LAP");
            products["Điện thoại Z"] = "P-DIENTHOAI"; // Thêm vào phần tử bằng Indexer
            products["Tai nghe XXX"] = "P-TAI";       // Thêm vào phần tử bằng Indexer

            Console.WriteLine("TÊN VÀ MÃ");
            foreach (KeyValuePair<string, string> p in products)
            {
                Console.WriteLine($"    {p.Key} - {p.Value}");
            }

            string productName = "Tai nghe XXX";
            Console.WriteLine($"{productName} có mã là {products[productName]}");

            products[productName] = "P-TAI-UPDATED";

            // Duyệt qua các giá trị
            Console.WriteLine("\nDANH SÁCH MÃ SẢN PHẢM");
            foreach (var product_code in products.Values)
            {
                Console.WriteLine($"--- {product_code}");
            }

            // Duyệt qua các key
            Console.WriteLine("\nDANH SÁCH TÊN SP");
            foreach (var product_name in products.Keys)
            {
                Console.WriteLine($"... {product_name}");
            }
        }
    }
}
