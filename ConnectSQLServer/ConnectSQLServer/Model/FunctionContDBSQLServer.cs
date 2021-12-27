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
                    Console.WriteLine("------------------------------------------------------------------------------------------");
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
                        //Console.WriteLine("------------------------------------------------------------------------------------------"44);

                    }
                    Console.WriteLine("------------------------------------------------------------------------------------------");
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

                /*C1 noi chuoi sẽ bị tan cong vào DB
                //query = "INSERT INTO Dien_Thoai(TenDT, Gia, ThoiDiemNhap, SoLanXem) VALUES("; query += "N'" + nameDT + "',N'" + Gia + "','" + TimeNhap + "',N'" + view + "')";
                //SqlCommand sqlCommand = new SqlCommand(query, conn);
                //sqlCommand.Connection = conn;
                //sqlCommand.CommandText = query;
                //int i = sqlCommand.ExecuteNonQuery();
                //Console.WriteLine("Da insert [" + i.ToString() + "] du lieu");
                */

                //C2 dung SQL paramater để không bị tấn công vào dữ liệu
                InsertSQL(nameDT, Gia, TimeNhap, view, conn);

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
            //Cách 1
            /*
            string query = string.Empty;
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-HSAI5KE;Initial Catalog=PHONE;Integrated Security=True");
            try
            {
                //conn.Open();
                Console.WriteLine("Ban hay nhap query update : ");
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

            */
            string query = string.Empty;
            Console.WriteLine("Ban muon update du lieu cot nao : ");
            Console.WriteLine("Nhan phim 1 neu muon update ten dien thoai. ");
            Console.WriteLine("Nhan phim 2 neu muon update gia. ");
            Console.WriteLine("Nhan phim 3 neu muon update thoi diem nhap. ");
            Console.WriteLine("Nhan phim 4 neu muon update so lan xem. ");


            try
            {
                int key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nhap id dien thoai can update. ");
                string id = Convert.ToString(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine("Nhap ten dien thoai  sua moi. ");
                        string fixname = Convert.ToString(Console.ReadLine());
                        UpdateSQL1(fixname, id, conn);
                        break;

                    case 2:
                        Console.WriteLine("Nhap ten gia dien thoai sua moi. ");
                        string fixprice = Convert.ToString(Console.ReadLine());
                        UpdateSQL2(fixprice, id, conn);
                        thaotac(conn);
                        break;
                    case 3:
                        Console.WriteLine("Nhap thoi diem nhap moi dinh dang yyymmdd. ");
                        string fixtime = Convert.ToString(Console.ReadLine());
                        UpdateSQL3(fixtime, id, conn);
                        thaotac(conn);
                        break;
                    case 4:
                        Console.WriteLine("Nhap so lan xem moi. ");
                        string fixview = Convert.ToString(Console.ReadLine());
                        UpdateSQL4(fixview, id, conn);
                        thaotac(conn);
                        break;
                    default:
                        Console.WriteLine("Ban da nhap sai dinh dang.");
                        Console.WriteLine("vui long nhap dung theo huong dan.");
                        break;
                }


            }
            catch (Exception)
            {

                throw;
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


            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-HSAI5KE;Initial Catalog=PHONE;Integrated Security=True");
            /*try
            {
                 Cách 1 //conn.Open();
                string query = string.Empty;
                DataSet dt = new DataSet();
                Console.WriteLine("Ban hay nhap cau query update : ");
                Console.WriteLine("Ex : SELECT idDT, TenDT, Gia, ThoiDiemNhap, SoLanXem FROM Dien_Thoai Where idDT like '%100%';");
                query = Convert.ToString(Console.ReadLine());
                //query =  " UPDATE Dien_Thoai SET TenDT = 'Dien Thoai vua sua ', Gia = '20000000', ThoiDiemNhap = '20211223', SoLanXem = 10 WHERE idDT = '1008'";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                sqlCommand.Connection = conn;
                da.Fill(dt);

                
                //dt.Tables[0].TableName = "Dien Thoai"; --cú pháp đặt tên cho bảng 0 vừa select đc
                //dataSet.Tables[1].TableName = "Orders";--cú pháp đặt tên cho bảng 1 vừa select đc

                //Console.WriteLine("---------------------------------------------------------------------------------");
                //Console.WriteLine("{0,-3}|{1,10}|{2,5}|{3,5}|{4,5}|", " ID  ", "          TenDT          ", "        Gia       ", "    ThoiDiemNhap     ", "         SoLanXem     ");
                
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                foreach (DataColumn column in dt.Tables[0].Columns)
                {
                    string ColumnName = column.ColumnName;
                    //if (column.Co)
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
                */

            /*Cách 2 su dung SQl paramater*/
            Console.WriteLine("Ban muon tim kiem theo truong nao : ");
            Console.WriteLine("Nhan 1 de tim kiem theo TenDT: ");
            Console.WriteLine("Nhan 2 de tim kiem theo Gia: ");
            Console.WriteLine("Nhan 3 de tim kiem theo Thoi diem nhap: ");
            Console.WriteLine("Nhan 4 de tim kiem theo So lan xem: ");
            try
            {
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine("Nhap ten dien thoai can tim kiem. ");
                        string searchname = Convert.ToString(Console.ReadLine());
                        SearchSQL1(searchname, conn);
                        break;

                    case 2:
                        Console.WriteLine("Nhap gia dien thoai can tim kiem. ");
                        string searchprice = Convert.ToString(Console.ReadLine());
                        SearchSQL2(searchprice, conn);
                        thaotac(conn);
                        break;
                    case 3:
                        Console.WriteLine("Nhap thoi diem nhap yyymmdd can tim kiem. ");
                        string searchtime = Convert.ToString(Console.ReadLine());
                        SearchSQL3(searchtime, conn);
                        thaotac(conn);
                        break;
                    case 4:
                        Console.WriteLine("Nhap so lan xem can tim kiem. ");
                        string searchview = Convert.ToString(Console.ReadLine());
                        SearchSQL4(searchview, conn);
                        thaotac(conn);
                        break;
                    default:
                        Console.WriteLine("Ban da nhap sai dinh dang.");
                        Console.WriteLine("vui long nhap dung theo huong dan.");
                        break;
                }

            }
            catch (Exception)
            {

                throw;
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
        private static void InsertSQL(string nameDT, string Gia, string Timenhap, int view, SqlConnection conn)
        {
            // Update the demographics for a store, which is stored
            // in an xml column.

            string commandText = "INSERT Dien_Thoai (TenDT, Gia, ThoiDiemNhap, SoLanXem) VALUES( @nameDT , + @Gia ,  + @TimeNhap , +  @view )";
            SqlCommand command = new SqlCommand(commandText, conn);
            //command.Parameters.Add("@nameDt", SqlDbType.Int);
            //command.Parameters["@ID"].Value = nameDT ;

            // Use AddWithValue to assign Demographics.
            // SQL Server will implicitly convert strings into XML.
            command.Parameters.AddWithValue("@nameDT", nameDT);
            command.Parameters.AddWithValue("@Gia", Gia);
            command.Parameters.AddWithValue("@TimeNhap", Timenhap);
            command.Parameters.Add("@View", SqlDbType.Int);
            command.Parameters["@View"].Value = view;
            try
            {
                //conn.Open();
                Int32 rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }


        private static void UpdateSQL1(string fixname, string id, SqlConnection conn)
        {
            // Update the demographics for a store, which is stored
            // in an xml column.

            string commandText = "UPDATE Dien_Thoai SET TenDT = @Tendt "
                + "WHERE idDT = @ID;";
            SqlCommand command = new SqlCommand(commandText, conn);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;

            // Use AddWithValue to assign Demographics.
            // SQL Server will implicitly convert strings into XML.
            command.Parameters.AddWithValue("@tendt", fixname);

            try
            {
                //conn.Open();
                Int32 rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
        private static void UpdateSQL2(string fixprice, string id, SqlConnection conn)
        {
            // Update the demographics for a store, which is stored
            // in an xml column.

            string commandText = "UPDATE Dien_Thoai SET Gia = @Gia "
                + "WHERE idDT = @ID;";
            SqlCommand command = new SqlCommand(commandText, conn);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;

            // Use AddWithValue to assign Demographics.
            // SQL Server will implicitly convert strings into XML.
            command.Parameters.AddWithValue("@Gia", fixprice);

            try
            {
                //conn.Open();
                Int32 rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private static void UpdateSQL3(string fixtime, string id, SqlConnection conn)
        {
            // Update the demographics for a store, which is stored
            // in an xml column.

            string commandText = "UPDATE Dien_Thoai SET Thoidiemnhap = @Time "
                + "WHERE idDT = @ID;";
            SqlCommand command = new SqlCommand(commandText, conn);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;

            // Use AddWithValue to assign Demographics.
            // SQL Server will implicitly convert strings into XML.
            command.Parameters.AddWithValue("@Time", fixtime);

            try
            {
                //conn.Open();
                Int32 rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private static void UpdateSQL4(string fixview, string id, SqlConnection conn)
        {
            // Update the demographics for a store, which is stored
            // in an xml column.

            string commandText = "UPDATE Dien_Thoai SET Solanxem = @View " + "WHERE idDT = @ID;";
            SqlCommand command = new SqlCommand(commandText, conn);
            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = id;

            // Use AddWithValue to assign Demographics.
            // SQL Server will implicitly convert strings into XML.
            command.Parameters.AddWithValue("@View", fixview);

            try
            {
                //conn.Open();
                Int32 rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private static void SearchSQL1(string searchname, SqlConnection conn)
        {

            DataSet dt = new DataSet();

            string query = "SELECT idDT, TenDT, Gia, ThoiDiemNhap, SoLanXem FROM Dien_Thoai Where TenDT LIKE @name";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@name", "%" + searchname + "%");
            sqlCommand.CommandType = CommandType.Text;

            /* cách 1 chưa can  chỉnh thẳng các cột search ra*/
            //SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            //sqlCommand.Connection = conn;
            //da.Fill(dt);

            //Console.WriteLine("-------------------------------------------------------------------------------------------");
            //Console.WriteLine("{0,-3}|{1,10}|{2,5}|{3,5}|{4,5}|", " ID  ", "          TenDT          ", "        Gia       ", "    ThoiDiemNhap     ", "         SoLanXem     ");
            //Console.WriteLine("-------------------------------------------------------------------------------------------");
            //foreach (DataRow row in dt.Tables[0].Rows)

            //{

            //    foreach (DataColumn column in dt.Tables[0].Columns)
            //    {
            //        // string ColumnName = column.ColumnName;
            //        string ColumnData = row[column].ToString();
            //        //Console.WriteLine(column.ColumnName + "  |  ");
            //        Console.Write(row[column] + " |  ");
            //    }
            //    Console.WriteLine();


            //}
            //Console.WriteLine("-------------------------------------------------------------------------------------------");



            //Cách 2 


            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-4}|{1,10}|{2,5}|{3,5}|{4,5}|", "  ID  ", "          TenDT           ", "    Gia       ", "      ThoiDiemNhap          ", "  SoLanXem ");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            foreach (DataRow row in dt.Tables[0].Rows)

            {
                string idDT = row["idDT"].ToString();
                string tenDT = row["TenDT"].ToString();
                string gia = row["Gia"].ToString();
                string ThoiDiemNhap = row["ThoiDiemNhap"].ToString();
                string SoLanXem = row["Solanxem"].ToString();
                if (tenDT.Length < 25)
                {
                    var noichuoi = "";
                    for (int i = tenDT.Length; i < 25; i++)
                    {
                        noichuoi += " ";
                    }

                    tenDT = tenDT + noichuoi;


                }
                Console.WriteLine(" {0,4} | {1,3}|  {2,-2} \t|   {3,2}   |\t{4,2}\t |", idDT, tenDT, gia, ThoiDiemNhap, SoLanXem);
                //Console.WriteLine(" {0,4} | {1,3}|  {2,-2}    |   {3,2}   | {4,2} |", idDT, tenDT, gia, ThoiDiemNhap, SoLanXem);
                //Console.Write(" " + row[column] + " |  ");
                //foreach (DataColumn column in dt.Tables[0].Columns)
                //{
                //    // string ColumnName = column.ColumnName;
                //    //string ColumnData = row[column].ToString();
                //    //Console.WriteLine(column.ColumnName + "  |  ");
                   
                //}
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }

        private static void SearchSQL2(string gia, SqlConnection conn)
        {

            DataSet dt = new DataSet();

            string query = "SELECT idDT, TenDT, Gia, ThoiDiemNhap, SoLanXem FROM Dien_Thoai Where Gia <= @gia";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@gia", gia);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-4}|{1,10}|{2,5}|{3,5}|{4,5}|", "  ID  ", "          TenDT           ", "    Gia       ", "      ThoiDiemNhap          ", "  SoLanXem ");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            foreach (DataRow row in dt.Tables[0].Rows)

            {
                string idDT = row["idDT"].ToString();
                string tenDT = row["TenDT"].ToString();
                string Gia = row["Gia"].ToString();
                string ThoiDiemNhap = row["ThoiDiemNhap"].ToString();
                string SoLanXem = row["Solanxem"].ToString();
                if (tenDT.Length < 25)
                {
                    var noichuoi = "";
                    for (int i = tenDT.Length; i < 25; i++)
                    {
                        noichuoi += " ";
                    }

                    tenDT = tenDT + noichuoi;


                }
                Console.WriteLine(" {0,4} | {1,3}|  {2,-2} \t|   {3,2}   |\t{4,2}\t |", idDT, tenDT, Gia, ThoiDiemNhap, SoLanXem);

            }
            Console.WriteLine("------------------------------------------------------------------------------------------");
        }
        private static void SearchSQL3(string thoidiemnhap, SqlConnection conn)
        {

            DataSet dt = new DataSet();

            string query = "SELECT idDT, TenDT, Gia, ThoiDiemNhap, SoLanXem FROM Dien_Thoai Where Thoidiemnhap >= @thoidiemnhap";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@thoidiemnhap", thoidiemnhap);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-4}|{1,10}|{2,5}|{3,5}|{4,5}|", "  ID  ", "          TenDT           ", "    Gia       ", "      ThoiDiemNhap          ", "  SoLanXem ");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            foreach (DataRow row in dt.Tables[0].Rows)

            {
                string idDT = row["idDT"].ToString();
                string tenDT = row["TenDT"].ToString();
                string gia = row["Gia"].ToString();
                string ThoiDiemNhap = row["ThoiDiemNhap"].ToString();
                string SoLanXem = row["Solanxem"].ToString();
                if (tenDT.Length < 25)
                {
                    var noichuoi = "";
                    for (int i = tenDT.Length; i < 25; i++)
                    {
                        noichuoi += " ";
                    }

                    tenDT = tenDT + noichuoi;


                }
                Console.WriteLine(" {0,4} | {1,3}|  {2,-2} \t|   {3,2}   |\t{4,2}\t |", idDT, tenDT, gia, ThoiDiemNhap, SoLanXem);
                //Console.WriteLine(" {0,4} | {1,3}|  {2,-2}    |   {3,2}   | {4,2} |", idDT, tenDT, gia, ThoiDiemNhap, SoLanXem);
                //Console.Write(" " + row[column] + " |  ");
                //foreach (DataColumn column in dt.Tables[0].Columns)
                //{
                //    // string ColumnName = column.ColumnName;
                //    //string ColumnData = row[column].ToString();
                //    //Console.WriteLine(column.ColumnName + "  |  ");

                //}
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }
        private static void SearchSQL4(string view, SqlConnection conn)
        {

            DataSet dt = new DataSet();
            string query = "SELECT idDT, TenDT, Gia, ThoiDiemNhap, SoLanXem FROM Dien_Thoai Where Solanxem >= @view";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@view", view);
            sqlCommand.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-4}|{1,10}|{2,5}|{3,5}|{4,5}|", "  ID  ", "          TenDT           ", "    Gia       ", "      ThoiDiemNhap          ", "  SoLanXem ");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            foreach (DataRow row in dt.Tables[0].Rows)

            {
                string idDT = row["idDT"].ToString();
                string tenDT = row["TenDT"].ToString();
                string gia = row["Gia"].ToString();
                string ThoiDiemNhap = row["ThoiDiemNhap"].ToString();
                string SoLanXem = row["Solanxem"].ToString();
                if (tenDT.Length < 25)
                {
                    var noichuoi = "";
                    for (int i = tenDT.Length; i < 25; i++)
                    {
                        noichuoi += " ";
                    }

                    tenDT = tenDT + noichuoi;


                }
                Console.WriteLine(" {0,4} | {1,3}|  {2,-2} \t|   {3,2}   |\t{4,2}\t |", idDT, tenDT, gia, ThoiDiemNhap, SoLanXem);
                //Console.WriteLine(" {0,4} | {1,3}|  {2,-2}    |   {3,2}   | {4,2} |", idDT, tenDT, gia, ThoiDiemNhap, SoLanXem);
                //Console.Write(" " + row[column] + " |  ");
                //foreach (DataColumn column in dt.Tables[0].Columns)
                //{
                //    // string ColumnName = column.ColumnName;
                //    //string ColumnData = row[column].ToString();
                //    //Console.WriteLine(column.ColumnName + "  |  ");

                //}
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }
    }
       
 }
