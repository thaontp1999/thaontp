using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSVNbaitapOPP
{
    internal class Program
    {   
         
        //khơi tạo class DSNV
        class DSNV

        {
            //Khai bao thuộc tính của đối tượng
            
            public int ID { get; set; }
            public string Hoten { get; set; }
            public string Gioitinh { get; set; }
            public DateTime ngaysinh { get; set; }
            public string diachi { get; set; }
            public string chucvu { get; set; }


        }
        class quanlynhanvien
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
            {
                DSNV nv = new DSNV();
                nv.ID = IDnv();
                Console.WriteLine("Nhap ho ten nhan vien: ");
                nv.Hoten = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Nhap gioi tinh: ");
                nv.Gioitinh = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Nhap ngay sinh: ");
                nv.ngaysinh = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Nhap dia chi: ");
                nv.diachi = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Nhap chuc vu: ");
                nv.chucvu = Convert.ToString(Console.ReadLine());
                ListDSNV.Add(nv);

            }
            //Ham hien thị danh sách nhân viên
            public void hienthi()
            {
                Console.WriteLine("{0, -5} {1, 20} {2, 10} {3, 10} {4, 10} {5, 5}",
                    "ID", "Hoten", "Gioitinh", "ngaysinh", "diachi", "chucvu");
                if (ListDSNV != null && ListDSNV.Count > 0)
                {
                    foreach (DSNV nv in ListDSNV)
                    {
                        Console.WriteLine("{0, -5} {1, 20} {2, 10} {3, 10} {4, 10} {5, 5} ", nv.ID, nv.Hoten, nv.Gioitinh, nv.ngaysinh, nv.diachi, nv.chucvu );
                    }
                }
            }

        }

            static void Main(string[] args)
        {
            quanlynhanvien dSNV = new quanlynhanvien();
            while (true)
            {
                Console.WriteLine(" 1. Hay nhap 1 de them nhan vien moi**");
                Console.WriteLine(" 2. Hay nhap 2 de hien thi danh sach nhan vien");
                Console.WriteLine(" 3. Hay nhap 3 de thoat");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine("Them nham vien");
                        dSNV.ttnv();
                        break;
                    case 2:
                        Console.WriteLine("In danh sach nhan vien");
                        dSNV.hienthi();
                        break;
                    case 0:
                        return;
                    default: 
                        Console.WriteLine("Chi chon 1 hoac 2");
                        
                        break;

                }
            }
               

        //    DSNV nv = new DSNV();
        //    Console.WriteLine("Nhap ten nhan vien");
        //    nv.hotennv = Console.ReadLine();
        //    nv.Inten();
          // Console.ReadLine();
        }
    }
}

