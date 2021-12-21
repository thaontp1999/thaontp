using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSVNbaitapOPP.Model
{
    public class quanlynhanvien
    {
        private List<DSNV> ListDSNV = null;
        //taoID tự động
        public quanlynhanvien()
        {
            ListDSNV = new List<DSNV>();
        }
        public int IDnv()
        {
            int max = 1;
            if (ListDSNV != null && ListDSNV.Count > 0)
            {
                max = ListDSNV[0].ID;
                foreach (DSNV sv in ListDSNV)
                {
                    if (max < sv.ID)
                    {
                        max = sv.ID;
                    }
                }
                max++;
            }
            return max;
        }

        //Hàm Nhap thong tin nhan viên
        public void ttnv()
        { //Nhập thêm try catch 
            try
            {
                DSNV nv = new DSNV();
                nv.ID = IDnv();


                Console.WriteLine("Nhap ho ten nhan vien: ");
                string ten = Convert.ToString(Console.ReadLine());
                nv.Hoten = ten;
                if (nv.Hoten.Length < 25)
                {
                    var noichuoi = "";
                    for (int i = ten.Length; i < 25; i++)
                    {
                        noichuoi += " ";
                    }

                    nv.Hoten = ten + noichuoi;
                    //Console.WriteLine(noichuoi.Length);
                }
                else
                {
                    nv.Hoten = ten;
                }


                Console.WriteLine("Nhap gioi tinh: ");
                string Gt = Convert.ToString(Console.ReadLine());
                nv.Gioitinh = Gt;
                if (nv.Gioitinh.Length < 12)
                {
                    var noichuoi = "";
                    for (int i = Gt.Length; i < 12; i++)
                    {
                        noichuoi += " ";
                    }
                    nv.Gioitinh = Gt + noichuoi;
                    //Console.WriteLine(noichuoi.Length);
                }
                else
                {
                    nv.Gioitinh = Gt;
                }

                //if(nv.Gioitinh.Length<20)
                //if(){
                //    Console.WriteLine("")
                //}
                


                Console.WriteLine("Nhap ngay thang nam sinh dang MM/dd/yyyy: ");
                string birthday = Console.ReadLine();
                DateTime sn = DateTime.Parse(birthday);
                string ngay = sn.ToString("dd/MM/yyyy");
                nv.ngaysinh = ngay;
                //DateTime date = DateTime.Parse(birthday);
                //DateTime datasasae = DateTime.ParseExact(birthday, "dd/MM/yyyy", new CultureInfo("en-US"));
                //Console.WriteLine("ahhhh: " + datasasae.ToString("dd/MM/yyyy"));
                //Console.WriteLine("ahhhh: " + date.ToString("dd/MM/yyyy"));
                /*Console.WriteLine("Nhap ngay sinh dinh dang dd: ");
                int day = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhap thang sinh mm: ");
                int month = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhap nam sinh yyyy");
                int year = int.Parse(Console.ReadLine());
                DateTime birthday = new DateTime(year,month,day);
                //String sn = birthday.ToString("dd/mm/yyyy");
                //DateTime dt = DateTime.Parse(Console.ReadLine());
                //nv.ngaysinh = Console.WriteLine($"{day}/{month}/{year}");*/
                if (ngay.Length < 18)
                {
                    var noichuoi = "";
                    for (int i = ngay.Length; i < 18; i++)
                    {
                        noichuoi += " ";
                    }
                    //Console.WriteLine(noichuoi.Length);
                    nv.ngaysinh = ngay + noichuoi;
                    //Console.WriteLine(nv.ngaysinh.Length);
                }
                else
                {
                    nv.ngaysinh = ngay;
                }


                Console.WriteLine("Nhap dia chi: ");
                string Address = Convert.ToString(Console.ReadLine());
                nv.diachi = Address;
                if (nv.diachi.Length < 20)
                {
                    var noichuoi = "";
                    for (int i = Address.Length; i < 20; i++)
                    {
                        noichuoi += " ";
                    }
                    nv.diachi = Address + noichuoi;
                }
                else
                {
                    nv.diachi = Address;
                }


                Console.WriteLine("Nhap chuc vu: ");
                String CV = Convert.ToString(Console.ReadLine());
                nv.chucvu = CV;
                if (nv.chucvu.Length < 20)
                {
                    var noichuoi = "";
                    for (int i = CV.Length; i < 20; i++)
                    {
                        noichuoi += " ";
                    }
                    //Console.WriteLine(noichuoi.Length);
                    nv.chucvu = CV + noichuoi;
                    //Console.WriteLine(nv.ngaysinh.Length);
                }
                else
                {
                    nv.chucvu = CV;
                }
                ListDSNV.Add(nv);
            }


            catch
            {
                Console.WriteLine("Ban nhap sai dinh dang ngay thang ");
                Console.WriteLine("Neu muon nhap lai thong tin vui long nhan phim 1. ");
                Console.WriteLine("Neu thoat nhan phim 0");
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                { ttnv(); }
            }


        }
        //Ham hien thị danh sách nhân viên
        public void hienthi()
        {
            Console.WriteLine("{0,-3}|{1,10}|{2,5}|{3,5}|{4,5}|{5,5}|", "ID  ", "          Hoten          ", " Gioi tinh  ", "    Ngay sinh     ", "         Diachi     ", "     Chuc vu        ");//, "ID", "Hoten", "Gioitinh", "ngaysinh", "diachi", "chucvu"); // "{0, -5} {1, 10} {2, 10} {3, 10} {4, 10} {5, 5}", "ID", "Hoten", "Gioitinh", "ngaysinh", "diachi", "chucvu"
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");                                                                                                                     //   "ID", "Hoten", "Gioitinh", "ngaysinh", "diachi", "chucvu");
            if (ListDSNV != null && ListDSNV.Count > 0)
            {
                foreach (DSNV nv in ListDSNV)
                {
                    Console.WriteLine("{0,-3} |{1}|{2}|{3}|{4}|{5}|",
                        nv.ID, nv.Hoten, nv.Gioitinh, nv.ngaysinh, nv.diachi, nv.chucvu);
                }
            }
        }

        //public void Chonlenh()
        //{
        //    Console.WriteLine(" 1. Hay nhap 1 de them nhan vien moi**");
        //    Console.WriteLine(" 2. Hay nhap 2 de hien thi danh sach nhan vien");
        //    Console.WriteLine(" 3. Hay nhap 3 de thoat");
        //    int key = Convert.ToInt32(Console.ReadLine());
        //     switch (key)
        //    {
        //        case 1:
        //            Console.WriteLine("Them nham vien");
        //            ttnv();
        //            break;
        //        case 2:

        //            Console.WriteLine("In danh sach nhan vien");
        //            Console.WriteLine("-------------------------------------------------------------------------------------");
        //            hienthi();
        //            Console.WriteLine("-------------------------------------------------------------------------------------");
        //            break;
        //        case 0:
        //            return;
        //        default:
        //            Console.WriteLine("Chi chon 0,  1 hoac 2");

        //            break;

        //    }
        //}
    }
}
