using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap1.Model
{
    public class Function
    {
        public static void showinfor (int nam, int thang, int ngay)
        { 
            DateTime mybirthday = new DateTime(nam, thang, ngay);
            Console.WriteLine(mybirthday.ToShortDateString());
            DateTime now = DateTime.Now;
            int age = (int)((DateTime.Now - mybirthday).TotalDays / 365.242199);
            Console.WriteLine("Năm nay bạn " + age + "tuổi");
            Console.WriteLine("Neu muon nhap lai vui long nhan phim 1.");
            Console.WriteLine("Neu thoat nhan phim 0.");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
             {
                ngaythangnam();
             }
        }

        public static void nhaplai()
        {
            Console.WriteLine("Ban nhap sai dinh dang ngay. ");
            Console.WriteLine("Neu muon nhap lai vui long nhan phim 1.");
            Console.WriteLine("Neu thoat nhan phim 0.");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                ngaythangnam();
            }
        }

        public static void ngaythangnam()
        {
                int thang, nam, ngay;
                Console.WriteLine("Nhap ten cua ban :");
                string ten = Console.ReadLine();
                Console.WriteLine("Nhap nam sinh cua ban dang yyyy: ");
                nam = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Nhap ngay sinh cua ban dang dd: ");
                ngay = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Nhap thang sinh cua ban dang MM: ");
                thang = Int32.Parse(Console.ReadLine());
                if (nam % 4 == 0)
                {

                    switch (thang)
                    {
                        case 2:

                            if (ngay > 30)
                            {
                               nhaplai();
                            }
                            else
                            {
                                showinfor(nam, thang, ngay);
                            }
                            break;
                        case 1:case 3: case 5: case 7:  case 8: case 10: case 12:
                            if (ngay < 0 && ngay > 32)
                            {
                                nhaplai();
                            }
                            else 
                            {
                                showinfor( nam,  thang,  ngay);
                            }
                            break;

                        case 4:case 6: case 9:case 11:
                            if (ngay < 0 && ngay > 31)
                            {
                                nhaplai();
                            }
                            else
                            {
                                showinfor(nam, thang, ngay);
                            }
                            break;
                           
                        default:
                        nhaplai();
                            break;

                    }
                }
                else
                {
                    switch (thang)
                    {
                        case 2:

                            if (ngay > 29)
                            {
                                nhaplai();
                            }
                            else
                            {
                                showinfor(nam, thang, ngay);
                            }
                            break;
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 8:
                        case 10:
                        case 12:
                            if (ngay < 0 && ngay > 32)
                            {
                                nhaplai();
                            }
                            else
                            {
                                showinfor(nam, thang, ngay);
                            }
                            break;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            if (ngay < 0 && ngay > 31)
                            {
                                nhaplai();
                            }
                            else
                            {
                                showinfor(nam, thang, ngay);
                            }
                            break;
                        default:
                        nhaplai();
                        break;

                    }
                }



            
            {                //throw Exception;
                

                //Console.WriteLine("Ban nhap sai dinh dang ngay thang nam roi ");
                //Console.WriteLine("Neu muon nhap lai vui long nhan phim 1.");
                //Console.WriteLine("Neu thoat nhan phim 0.");
                //int n = int.Parse(Console.ReadLine());
                //if (n == 1)
                //{
                //    ngaythangnam();
                //}
            }

        }
    }
}
        
    





