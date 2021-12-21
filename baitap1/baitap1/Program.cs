using System;
using baitap1.Model;
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


        static void Main(string[] args)
        {

            try
            {
                Function.ngaythangnam();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Nhap sai dinh dang ngay thang");
                throw ex;


            }


            //Console.WriteLine(now);
            //TimeSpan t = now - mybirthday;  // TimeSpantính tổng giữa 2 ngày
            //double tuoi = t.TotalYears;
            // Console.WriteLine("   {0,-35} {1,20}", "Value of Years Component:", t.TotalYears);
            Console.ReadKey();
        }
    }
}
