using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace ConnectSQLServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"DESKTOP-HSAI5KE";
            var database = "PHONE"; 
            var username = "sa"; 
            var password = "123456";

            
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                
                conn.Open();

                //QueryDienthoai(conn);
                //Console.WriteLine("------------------------------------------------------------------------------------------");

                //Console.WriteLine("Connection successful!");
                //InsertDB(conn);
                //QueryDienthoai(conn);

                //UpdateDB(conn);

                //QueryDienthoai(conn);

                DeleteDB(conn);
                QueryDienthoai(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();

            
            }
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
                        int idDTIndex = reader.GetOrdinal("idDT"); // 0


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


                        Console.WriteLine("{0,4}| {1,3}\t|  {2,-2}\t|   {3,2}   |\t{4,2}\t |",  idDT, TenDT, Gia, ThoiDiemNhap, SoLanXem);
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
                query = "INSERT INTO Dien_Thoai(TenDT, Gia, ThoiDiemNhap, SoLanXem) VALUES('Dien Thoai vua them ', '15000000', '20211222', 9)";
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
                query = " UPDATE Dien_Thoai SET TenDT = 'Dien Thoai vua sua ', Gia = '20000000', ThoiDiemNhap = '20211223', SoLanXem = 10 WHERE idDT = '1007'";
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
                query = " DELETE Dien_Thoai WHERE idDT = '1007'";
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
    }
}
