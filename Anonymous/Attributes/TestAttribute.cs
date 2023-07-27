using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous.Attributes
{
    public class TestAttribute
    {
        public static void test()
        {
            var a = new User();

            // Đọc các Attribute của lớp
            foreach (Attribute attr in a.GetType().GetCustomAttributes(false))
            {
                MotaAttribute mota = attr as MotaAttribute;
                if (mota != null)
                {
                    Console.WriteLine($"{a.GetType().Name,10} : {mota.Description}");
                }
            }

            // Đọc Attribute của từng thuộc tính lớp
            foreach (var thuoctinh in a.GetType().GetProperties())
            {
                foreach (Attribute attr in thuoctinh.GetCustomAttributes(false))
                {
                    MotaAttribute mota = attr as MotaAttribute;
                    if (mota != null)
                    {
                        Console.WriteLine($"{thuoctinh.Name,10} : {mota.Description}");
                    }
                }
            }

            // Đọc Attribute của phương thức
            foreach (var m in a.GetType().GetMethods())
            {
                foreach (Attribute attr in m.GetCustomAttributes(false))
                {
                    MotaAttribute mota = attr as MotaAttribute;
                    if (mota != null)
                    {
                        Console.WriteLine($"{m.Name,10} : {mota.Description}");
                    }
                }
            }
        }

        public static void checkValidationContext()
        {
            Employer user = new Employer();
            user.Name = "AF";
            user.Age = 26;
            user.PhoneNumber = "123-002-2003";
            user.Email = "testbr";


            ValidationContext context = new ValidationContext(user, null, null);
            // results - lưu danh sách ValidationResult, kết quả kiểm tra
            List<ValidationResult> results = new List<ValidationResult>();
            // thực hiện kiểm tra dữ liệu
            bool valid = Validator.TryValidateObject(user, context, results, true);

            if (!valid)
            {
                // Duyệt qua các lỗi và in ra
                foreach (ValidationResult vr in results)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{vr.MemberNames.First(),13}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"    {vr.ErrorMessage}");
                }
            }
        }
    }
}
