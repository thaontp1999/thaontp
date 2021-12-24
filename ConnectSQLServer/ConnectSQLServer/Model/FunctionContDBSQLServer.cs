using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using ConnectSQLServer;
using System.Data.Common;
using System.Data;
using System.Drawing;



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

                //Cách khác dùng đẻ insert dữ liệu vào bảng
                //void AddData(SqlConnection conn, String fullName, String addr, String phoneNumber, String email)
                //{ 
                //        conn.Open();
                //        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Phonebook", conn);
                //        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                //        DataSet dataSet = new DataSet();
                //        adapter.Fill(dataSet, "Phonebook");
                //        DataRow dataRow = dataSet.Tables["Phonebook"].NewRow();
                //        dataRow["fullname"] = fullName;
                //        dataRow["addr"] = addr;
                //        dataRow["phonenumber"] = phoneNumber;
                //        dataRow["email"] = email;
                //        dataSet.Tables["Phonebook"].Rows.Add(dataRow);
                //        adapter.Update(dataSet, "Phonebook");
                //        conn.Close();
                //}   


            }
            catch (Exception ex)
            {
                Console.WriteLine("Ban nhap sai dinh dang cac truong roi.");
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
                int i = 0;
                 i = sqlCommand.ExecuteNonQuery();
                if ( i == 0 )
                {
                    Console.WriteLine(" 0 row(s) da update");
                }
                else
                Console.WriteLine("Da update [" + i.ToString() + "] du lieu");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ban nhap sai dinh dang cau query roi.");
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
                Console.WriteLine("Ban nhap sai dinh dang cau query roi.");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void Search(SqlConnection conn)
        {
            string query = string.Empty;
            DataSet dt = new DataSet();

            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-HSAI5KE;Initial Catalog=PHONE;Integrated Security=True");
            try
            {
                //conn.Open();
                Console.WriteLine("Ban hay nhap thoi diem nhap cquery update : ");
                Console.WriteLine("Ex : SELECT idDT, TenDT, Gia, ThoiDiemNhap, SoLanXem FROM Dien_Thoai Where idDT like '%100%';");
                query = Convert.ToString(Console.ReadLine());
                //query =  " UPDATE Dien_Thoai SET TenDT = 'Dien Thoai vua sua ', Gia = '20000000', ThoiDiemNhap = '20211223', SoLanXem = 10 WHERE idDT = '1008'";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                sqlCommand.Connection = conn;
                da.Fill(dt);

                
                //dt.Tables[0].TableName = "Dien Thoai"; --cú pháp đặt tên cho bảng 0 vừa select đc
                //dataSet.Tables[1].TableName = "Orders";--cú pháp đặt tên cho bảng 2 vừa select đc

                //Console.WriteLine("---------------------------------------------------------------------------------");
                //Console.WriteLine("{0,-3}|{1,10}|{2,5}|{3,5}|{4,5}|", " ID  ", "          TenDT          ", "        Gia       ", "    ThoiDiemNhap     ", "         SoLanXem     ");
                
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                foreach (DataColumn column in dt.Tables[0].Columns)
                {
                    string ColumnName = column.ColumnName;
                    if (column.Co)
                    Console.Write(column.ColumnName + "  |  ");
                    
                }
                Console.ReadLine();
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");

                foreach (DataRow row in dt.Tables[0].Rows)

                {

                    foreach (DataColumn column in dt.Tables[0].Columns)
                    {
                        string ColumnName = column.ColumnName;
                        string ColumnData = row[column].ToString();
                        //Console.WriteLine(column.ColumnName + "  |  ");
                        Console.Write(row[column] + " |  ");
                    }
                    Console.WriteLine();
                    
                    //Console.WriteLine(row["idDT"] + "|  " + row["TenDT"] + "|  " + row["Gia"] + "|  " + row["ThoiDiemNhap" ]+ "|  " + row["SoLanXem"] + "|  ");
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ban nhap sai dinh dang cau query roi.");
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
                Console.WriteLine(" 5. Hay nhap 5 de tim kiem du lieu trong bang.");
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
                    case 5:
                        Search(conn);
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
