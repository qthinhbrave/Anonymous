using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymous.Collection
{
    public class Product : IComparable<Product>, IFormattable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string[] Colors { set; get; }
        public int Brand { set; get; }
        public string Origin { get; set; }

        public Product(int id, string name, double price, string origin) 
        { 
            ID = id;
            Name = name;
            Price = price;
            Origin = origin;
        }

        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }

        public int CompareTo(Product other)
        {
            double delta = this.Price - other.Price;
            if (delta > 0)
            {
                return -1;
            }
            else if (delta < 0)
            {
                return 1;
            }
            return 0;
        }

        public string ToString(string format, IFormatProvider formatProvider) 
        { 
            if (format == null)
            {
                format = "O";
            }
            switch (format)
            {
                case "O": 
                    return $"Xuất xứ: {Origin} - Tên: {Name} - Giá: {Price} - ID: {ID}";
                case "N": // Tên xứ trước
                    return $"Tên: {Name} - Xuất xứ: {Origin} - Giá: {Price} - ID: {ID}";
                default: // Quăng lỗi nếu format sai
                    throw new FormatException("Không hỗ trợ format này");
            }
        }

        // public override string ToString() => $"{Name} - {Price}";

        override public string ToString() => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

        public string ToString(string format) => this.ToString(format, null) ;

    }

    public class TestCollection
    {
        public static void test()
        {
            var numbers = new List<int>();           // danh sách số nguyên
            var products = new List<Product>(){
                 new Product(1, "Iphone 6", 100, "Trung Quốc")
            };

            var p = new Product(2, "IPhone 7", 200, "Trung Quốc");
            products.Add(p);                                                // Thêm p vào cuối List
            products.Add(new Product(3, "IPhone 8", 400, "Trung Quốc"));

            var arrayProducts = new Product[]                  // Mảng 2 phần tử
            {
                new Product(4, "Glaxy 7", 500, "Việt Nam"),
                new Product(5, "Glaxy 8", 700, "Việt Nam"),
            };
            products.AddRange(arrayProducts);

            foreach (var pi in products)
            {
                Console.WriteLine(pi.ToString());
            }

        }
    }

    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }

    public class Products
    {
        // ...

        // In ra các sản phẩm có giá 400
        public static void ProductPrice(int price)
        {
            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };

            // Viết câu quy vấn, lưu vào ketqua
            //var ketqua = from product in products
            //             where product.Price == price
            //             select product;

            //foreach (var product in ketqua)
            //    Console.WriteLine(product.ToString());


            //var ketqua2 = from product in products
            //              where product.Price == price
            //              select new
            //              {
            //                  ten = product.Name,
            //                  mausac = string.Join(",", product.Colors)
            //              };

            //foreach (var item in ketqua2) Console.WriteLine(item.ten + " - " + item.mausac);

            var ketqua = from product in products
                         where product.Price >= 400 && product.Price <= 500
                         group product by product.Price;
            foreach (var group in ketqua)
            {
                // Key là giá trị dùng để phân loại (nhóm): là giá
                Console.WriteLine(group.Key);
                foreach (var product in group)
                {
                    Console.WriteLine($"    {product.Name} - {product.Price}");
                }

            }
        }

        // ...
        public static void TestJoin()
        {
            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };

                        var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };
            var ketqua = from product in products
                         join brand in brands on product.Brand equals brand.ID
                         select new
                         {
                             name = product.Name,
                             brand = brand.Name,
                             price = product.Price
                         };

            foreach (var item in ketqua)
            {
                Console.WriteLine($"{item.name,10} {item.price,4} {item.brand,12}");
            }
        }
    }
}
