using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap1
{
    internal class Program

    {
        //static int ngay = Int32.Parse(Console.ReadLine());

        //static int thang = Int32.Parse(Console.ReadLine());

        //static int nam = Int32.Parse(Console.ReadLine());

         static void ngaythangnam()
        {
            Console.WriteLine("Nhap ten cua ban :");
            string ten = Console.ReadLine();
            Console.WriteLine("Nhap ngay sinh cua ban: ");
            int ngay = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Nhap thang sinh cua ban: ");
            int thang = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Nhap nam sinh cua ban: ");
            int nam = Int32.Parse(Console.ReadLine());
            DateTime mybirthday = new DateTime(nam, thang, ngay);
            Console.WriteLine(mybirthday);
            DateTime now = DateTime.Now;
            int age = (int)((DateTime.Now - mybirthday).TotalDays / 365.242199);
            Console.WriteLine("Năm nay bạn " + age + "tuổi");
            Console.WriteLine("Neu muon nhap lai vui long nhan phim 1.Neu thoat nhan phim 0.");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                ngaythangnam();
            }
        }

        static void Main(string[] args)
        {
            
            try
            {
                ngaythangnam();
            }
            catch
            {
                Console.WriteLine("Ban nhap sai dinh dang ngay thang nam roi ");
                Console.WriteLine("Neu muon nhap lai vui long nhan phim 1.Neu thoat nhan phim 0.");
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                {
                    
                    ngaythangnam();
                }
            }




            //Console.WriteLine(now);
            //TimeSpan t = now - mybirthday;  // TimeSpantính tổng giữa 2 ngày
            //double tuoi = t.TotalYears;
            // Console.WriteLine("   {0,-35} {1,20}", "Value of Years Component:", t.TotalYears);
            Console.ReadKey();
        }
    }
}
