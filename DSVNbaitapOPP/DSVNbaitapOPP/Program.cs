using DSVNbaitapOPP.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.WebPages.IValidator;

namespace DSVNbaitapOPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DSNVValidator validator = new DSNVValidator();
            //quanlynhanvien dSNV = new quanlynhanvien();

            while (true)
            {
                try
                {

                    thaotac();
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi exception nhap ky tu khong phai la so");
                    thaotac();
                    throw ex;
                }
                Console.ReadLine();
                return;

            }


            


            

            Console.ReadLine();
            //    DSNV nv = new DSNV();
            //    Console.WriteLine("Nhap ten nhan vien");
            //    nv.hotennv = Console.ReadLine();
            //    nv.Inten();
            // Console.ReadLine();
        }

        static void thaotac()
        {
            DSNVValidator validator = new DSNVValidator();
            quanlynhanvien dSNV = new quanlynhanvien();
            try
            {
                Console.WriteLine(" 1. Hay nhap 1 de them nhan vien moi**");
                Console.WriteLine(" 2. Hay nhap 2 de hien thi danh sach nhan vien");
                Console.WriteLine(" 3. Hay nhap 0 de thoat");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine("Them nham vien");
                        dSNV.ttnv();
                        break;
                    case 2:

                        Console.WriteLine("In danh sach nhan vien");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                        dSNV.hienthi();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                        break;
                    case 0:
                        Console.WriteLine("Ban da thoat chuong trinh");
                        return;

                    default:
                        Console.WriteLine("Chi chon 0,  1 hoac 2");
                        thaotac();
                        break;

                }
                Console.ReadLine();

            }
            catch (Exception)
            {
                Console.WriteLine("Loi exception nhap ky tu khong phai la so");
                thaotac();
                throw;
            }

        }
    }
}