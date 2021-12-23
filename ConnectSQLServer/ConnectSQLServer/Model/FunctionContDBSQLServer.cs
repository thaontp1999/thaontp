using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using ConnectSQLServer;
using System.Data.Common;

namespace ConnectSQLServer.Model
{
    public class FunctionContDBSQLServer
    {
        public static void QueryDienthoai(SqlConnection conn)
        {
            string sql = "Select idDT, TenDT, Gia, ThoiDiemNhap, SoLanXem from Dien_Thoai";

            // Tạo một đối tượng Command.
            SqlCommand cmd = new SqlCommand();

            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Console.WriteLine("{0,-4}|{1,10}|{2,5}|{3,5}|{4,5}|", "ID  ", "          TenDT            ", "    Gia        ", "      ThoiDiemNhap          ", "  SoLanXem ");
                    Console.WriteLine("------------------------------------------------------------------------------------------");
                    while (reader.Read())
                    {
                        // Chỉ số của cột Emp_ID trong câu lệnh SQL.
                        //int idDTIndex = reader.GetOrdinal("idDT"); // 0


                        long idDT = Convert.ToInt64(reader.GetValue(0));
                        string TenDT = reader.GetString(1);
                        double Gia = reader.GetDouble(2);
                        DateTime ThoiDiemNhap = reader.GetDateTime(3);
                        int SoLanXem = reader.GetInt32(4);

                        // Chỉ số của cột Mng_Id trong câu lệnh SQL.
                        //int mngIdIndex = reader.GetOrdinal("Mng_Id");
                        //long? mngId = null;


                        //if (!reader.IsDBNull(mngIdIndex))
                        //{
                        //    mngId = Convert.ToInt64(reader.GetValue(mngIdIndex));
                        //}

                        //, "ID", "Hoten", "Gioitinh", "ngaysinh", "diachi", "chucvu"); // "{0, -5} {1, 10} {2, 10} {3, 10} {4, 10} {5, 5}", "ID", "Hoten", "Gioitinh", "ngaysinh", "diachi", "chucvu"
                        if (TenDT.Length < 25)
                        {
                            var noichuoi = "";
                            for (int i = TenDT.Length; i < 25; i++)
                            {
                                noichuoi += " ";
                            }

                            TenDT = TenDT + noichuoi;

                        }


                        Console.WriteLine("{0,4}| {1,3}\t|  {2,-2}\t|   {3,2}   |\t{4,2}\t |", idDT, TenDT, Gia, ThoiDiemNhap, SoLanXem);
                        //Console.WriteLine("--------------------");
                        //Console.WriteLine("idDT:" + idDT);
                        //Console.WriteLine("TenDT:" + TenDT);
                        //Console.WriteLine("Gia:" + Gia);
                        //Console.WriteLine("ThoiDienNhap:" + ThoiDiemNhap);
                        //Console.WriteLine("SoLanXem:" + SoLanXem );
                        Console.WriteLine();

                    }
                }
            }
        }
        public static void InsertDB(SqlConnection conn)
        {
            string query = string.Empty;
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-HSAI5KE;Initial Catalog=PHONE;Integrated Security=True");
            try
            {
                //conn.Open();
                Console.WriteLine("Ban hay nhap ten dien thoai");
                string nameDT = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Ban hay nhap gia dien thoai (dong)");
                string Gia = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Ban hay nhap thoi diem nhap hang dinh dang yyyymmdd: ");
                string TimeNhap = Convert.ToString(Console.ReadLine());
                //Console.WriteLine("B hay nhap so luong ton kho");
                //int soluongtonkho = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ban hay nhap so lan xem");
                int view = Convert.ToInt32(Console.ReadLine());
                query = "INSERT INTO Dien_Thoai(TenDT, Gia, ThoiDiemNhap, SoLanXem) VALUES("; query += "N'" + nameDT + "',N'" + Gia + "','" + TimeNhap + "',N'" + view + "')";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Connection = conn;
                sqlCommand.CommandText = query;
                int i = sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Da insert [" + i.ToString() + "] du lieu");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void UpdateDB(SqlConnection conn)
        {
            string query = string.Empty;
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-HSAI5KE;Initial Catalog=PHONE;Integrated Security=True");
            try
            {
                //conn.Open();
                Console.WriteLine("Ban hay nhap thoi diem nhap cquery update : ");
                Console.WriteLine("Ex : UPDATE Dien_Thoai SET TenDT = 'Dien Thoai vua sua ', Gia = '20000000', ThoiDiemNhap = '20211223', SoLanXem = 10 WHERE idDT = '1008' ");
                query = Convert.ToString(Console.ReadLine());
                //query =  " UPDATE Dien_Thoai SET TenDT = 'Dien Thoai vua sua ', Gia = '20000000', ThoiDiemNhap = '20211223', SoLanXem = 10 WHERE idDT = '1008'";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Connection = conn;
                sqlCommand.CommandText = query;
                int i = sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Da update [" + i.ToString() + "] du lieu");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void DeleteDB(SqlConnection conn)
        {
            string query = string.Empty;
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-HSAI5KE;Initial Catalog=PHONE;Integrated Security=True");
            try
            {
                //conn.Open();
                //query = " DELETE Dien_Thoai WHERE idDT = '1008'";
                Console.WriteLine("Ban hay nhap thoi diem nhap query xoa du lieu : ");
                Console.WriteLine("Ex : DELETE Dien_Thoai WHERE idDT = '1008' ");
                query = Convert.ToString(Console.ReadLine());
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Connection = conn;
                sqlCommand.CommandText = query;
                int i = sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Da xoa [" + i.ToString() + "] du lieu");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        public static void thaotac(SqlConnection conn)
        {
            try
            {
                Console.WriteLine(" 1. Hay nhap 1 de Insert them data dien thoai.");
                Console.WriteLine(" 2. Hay nhap 2 de Update du lieu trong bang. ");
                Console.WriteLine(" 3. Hay nhap 3 de Xoa du lieu trong bang.");
                Console.WriteLine(" 4. Hay nhap 4 de Xem du lieu trong bang.");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {


                    case 1:
                        InsertDB(conn);
                        thaotac(conn);
                        break;
                    case 2:
                        UpdateDB(conn);
                        thaotac(conn);
                        break;
                    case 3:
                        DeleteDB(conn);
                        thaotac(conn);
                        return;
                    case 4:
                        QueryDienthoai(conn);
                        thaotac(conn);
                        break;
                    default:
                        Console.WriteLine("Chi chon 1,  2 hoac 3");
                        thaotac(conn);
                        break;

                }
                Console.ReadLine();

            }
            catch (Exception)
            {
                Console.WriteLine("Loi exception nhap ky tu khong phai la so");
                thaotac(conn);
                throw;
            }

        }
    }
}
