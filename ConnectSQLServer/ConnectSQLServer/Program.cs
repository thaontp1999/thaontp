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

                QueryEmployee(conn);
                Console.WriteLine("------------------------------------------------------------------------------------------");

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();

            
            }
        public static void QueryEmployee(SqlConnection conn)
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
    }
}
