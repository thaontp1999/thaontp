using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace btap3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            timkiem();
            
            tieptuc();
            //Console.WriteLine("Nhap chuoi day so ");
            //string a = Console.ReadLine();
            //Console.WriteLine("Nhap ky tu can tim trong chuoi ");
            //string b = Console.ReadLine();
            //if ( b == )
            //List<int> mang = new List<int>();
            ////int found = 0;

            //MatchCollection matches = Regex.Matches(a, "(b)");
            //foreach (Match match in matches)
            //{
            //    foreach (Capture capture in match.Captures)
            //    {
            //        Console.WriteLine("Index = {0} , Value  = { 1 }", capture.Index, capture.Value);
            //    }    
            //}    

            //for (int i = 0; i < a.Length; i++)
            //{
            //    for (int j = i+1; j < a.Length - 1; j++)
            //    {
            //        var d = a[i] + a[j];
            //        mang.Add(d);


            //    }


            //}

            // Console.WriteLine("Gia tri " + b + " tim thay o " + found + " vi tri");






            Console.ReadLine();
            return;
        }

        public static void timkiem()
        {
            try
            {
                Console.WriteLine("Mang gom may phan tu ");
                int n = int.Parse(Console.ReadLine());
                int[] arr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    int d = i + 1;
                    Console.Write("Nhap so thu " + d + "la :");
                    arr[i] = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }

                Console.Write("Cac phan tu co trong mang :");
                for (int i = 0; i < n; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.ReadLine();

                Console.WriteLine("Nhap gia tri can tim kiem");
                int timkiem = int.Parse(Console.ReadLine());
                int found = 0;
                int a = -1;
                List<int> dsds = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    if (timkiem == arr[i])
                    {
                        dsds.Add(i);
                        a = i;
                        found += 1;


                    }
                }


                if (a == -1)
                {
                    found = 0;
                    Console.WriteLine("Khong tim thay gia tri nhap ");
                }
                else
                {
                    Console.WriteLine("Gia tri " + timkiem + " tim thay o vi tri");
                    for (int i = 0; i < found; i++)
                    {
                        Console.Write(dsds[i] + " ");
                    }
                    Console.Write("cua day so (dem tu vi tri 0).");
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Vui long nhap dung theo huong dan. ");
                timkiem();
                throw;

            }

        }

        public static void tieptuc ()
        {
            try
            {
                Console.WriteLine(" **********************************************");
                Console.WriteLine(" Ban có muon tiep tuc chuong trinh khong?");
                Console.WriteLine(" 1. Hay nhap 1 neu muon tiep tuc tim kiem day so moi");
                Console.WriteLine(" 2. Hay nhap 0 de thoat.");

                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        timkiem();
                        tieptuc();
                        break;

                    case 0:
                        Console.WriteLine("Ban da thoat chuong trinh");
                        return;

                    default:
                        Console.WriteLine("Chi chon 0 hoac 1 ");
                        tieptuc();
                        break;

                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("Chi chon 0 hoac 1 ");
                tieptuc();
                throw;
            }
            
        }


    }
}
