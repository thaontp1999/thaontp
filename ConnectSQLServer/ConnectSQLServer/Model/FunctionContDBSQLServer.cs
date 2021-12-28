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
                string nameDT0 = Convert.ToString(Console.ReadLine());
                string nameDT = nameDT0.Trim();
                if (nameDT == null)
                {
                    Console.WriteLine("Truong khong duoc de trong.");
                    Console.WriteLine("Ban hay nhap ten dien thoai");
                     nameDT0 = Convert.ToString(Console.ReadLine());
                     nameDT = nameDT0.Trim();
                }

                Console.WriteLine("Ban hay nhap gia dien thoai (dong)");
                string Gia0 = Convert.ToString(Console.ReadLine());
                string Gia = Gia0.Trim();
                if (Gia == null)
                {
                    Console.WriteLine("Truong khong duoc de trong.");
                    Console.WriteLine("Ban hay nhap ten dien thoai");
                    Gia0 = Convert.ToString(Console.ReadLine());
                    Gia = Gia0.Trim();
                }

                Console.WriteLine("Ban hay nhap thoi diem nhap hang dinh dang yyyymmdd: ");
                string TimeNhap0 = Convert.ToString(Console.ReadLine());
                string TimeNhap = TimeNhap0.Trim();
                if (TimeNhap == null)
                {
                    Console.WriteLine("Truong khong duoc de trong.");
                    Console.WriteLine("Ban hay nhap ten dien thoai");
                    TimeNhap0 = Convert.ToString(Console.ReadLine());
                    TimeNhap = TimeNhap0.Trim();
                }
                //Console.WriteLine("B hay nhap so luong ton kho");
                //int soluongtonkho = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ban hay nhap so lan xem");
                string view0 = Convert.ToString(Console.ReadLine());
                int view = Convert.ToInt32(view0.Trim());
                if (view == null)
                {
                    Console.WriteLine("Truong khong duoc de trong.");
                    Console.WriteLine("Ban hay nhap ten dien thoai");
                    view0 = Convert.ToString(Console.ReadLine());
                    view = Convert.ToInt32(view0.Trim());
                }
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
                        string fixname0 = Convert.ToString(Console.ReadLine());
                        string fixname = fixname0.Trim();

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

                //cách 1 nhạp từ ban phím câu query để xóa
                //Console.WriteLine("Ban hay nhap query de xoa du lieu trong bang : ");
                //Console.WriteLine("Vi dụ: DELETE Dien_Thoai WHERE idDT = '1008'");
                //query = Convert.ToString(Console.ReadLine());
                //SqlCommand sqlCommand = new SqlCommand(query, conn);
                //sqlCommand.Connection = conn;
                //sqlCommand.CommandText = query;
                //int i = sqlCommand.ExecuteNonQuery();
                //Console.WriteLine("Da xoa [" + i.ToString() + "] du lieu");

                //cách 2 xóa bằng cách truyền SQL parameter;
                Console.WriteLine("Ban hay nhap ID dien thoai muon xoa du lieu : ");
                int id = Convert.ToInt32(Console.ReadLine());
                DeleteSQL( id, conn);
                thaotac(conn);

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
               
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }

        private static void DeleteSQL(int id,  SqlConnection conn)
        {
            // Update the demographics for a store, which is stored
            // in an xml column.

            string commandText = "DELETE Dien_Thoai WHERE idDT = @id ";
            SqlCommand command = new SqlCommand(commandText, conn);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = id;

            // Use AddWithValue to assign Demographics.
            // SQL Server will implicitly convert strings into XML.
            //command.Parameters.AddWithValue("@ten", ten);

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

        private static void GetGia(SqlConnection conn)
        {
            DataSet dt = new DataSet();
            string query = "SELECT Gia FROM Dien_Thoai ";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            foreach (DataRow row in dt.Tables[0].Rows)

            {
                double gia = Convert.ToDouble(row["Gia"]);

            }

        }
        public static void VAT(SqlConnection conn)
        {
            Console.WriteLine("Nhap % tinh thue VAT gia dien thoai.");
            string VAT0 = Convert.ToString(Console.ReadLine());
            int VAT = Convert.ToInt32(VAT0.Trim());
            double thueVAT = 0;
            if (VAT == null)
            {
                Console.WriteLine("Truong khong duoc de trong.");
                Console.WriteLine("Ban hay nhap ten dien thoai");
                VAT0 = Convert.ToString(Console.ReadLine());
                VAT = Convert.ToInt32(VAT0.Trim());
            }
            DataSet dt = new DataSet();
            string query = "SELECT idDT, TenDT, Gia FROM Dien_Thoai ";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            foreach (DataRow row in dt.Tables[0].Rows)

            {
                double gia = Convert.ToDouble(row["Gia"]);
                thueVAT = (VAT * gia) / 100;
            }
            
        }
        public static void Creprocedure (SqlConnection conn)
        {

            Console.WriteLine("Nhap % tinh thue VAT gia dien thoai.");
            int VAT = Int32.Parse(Console.ReadLine());
            //int VAT = Convert.ToInt32(VAT0.Trim());(Console.ReadLine());
            //if (VAT == null)
            //{
            //    Console.WriteLine("Truong khong duoc de trong.");
            //    Console.WriteLine("Ban hay nhap ten dien thoai");
            //    VAT0 = Convert.ToString(Console.ReadLine());
            //    VAT = Convert.ToInt32(VAT0.Trim());
            //}
            string query = "IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spTinhTonggiadienthoai')"
                        + "DROP PROCEDURE spTinhTonggiadienthoai"
                        + "GO"
                        //+ "SET ANSI_NULLS ON"
                        //+ "GO "
                        //+ "SET QUOTED_IDENTIFIER ON"
                        //+ "GO"
                        + "CREATE PROCEDURE spTinhTonggiadienthoai"
                        + "(@VAT int )"
                        + "AS "
                        + "BEGIN"
                        + "	SELECT idDT, TenDT, Gia, (@VAT*Gia)/100 AS GiaThueDT InTO #GiaDT From Dien_Thoai order by idDT"
                        + "ALTER TABLE #GiaDT "
                        + "ADD GiaDTgomVAT AS(GiaThueDT + Gia)"
                        + "SELECT* FROM #GiaDT Order by idDT"
                        + "END";
                        //+ "GO"
                        //+"EXEC spTinhTonggiadienthoai ;"

                        //+ " GO";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@VAT", SqlDbType.Int).Value= VAT;
            //command.Parameters["@VAT"].Value = VAT;
            query = "EXECUTE spTinhTonggiadienthoai @VAT = " +VAT;
            command = new SqlCommand(query, conn);
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-4} | {1,3}|  {2,2} \t| {3,2} |\t{4,2} |", "  ID  ", "          TenDT          ", "    Gia       ", "    GiaThueDT    ", "  GiaDTgomVAT   "); //"{0,-4}|{1,10}|{ 2,5}|{ 3,5}|{ 4,5}|"
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (DataRow row in dt.Tables[0].Rows)

            {
                string idDT = row["idDT"].ToString();
                string tenDT = row["TenDT"].ToString() ;
                
                string gia = row["Gia"].ToString() ;
                string GiaThueDT = row["GiaThueDT"].ToString();
                string GiaDTgomVAT = row["GiaDTgomVAT"].ToString();
                if (tenDT.Length < 25)
                {
                    var noichuoi = "";
                    for (int i = tenDT.Length; i < 25; i++)
                    {
                        noichuoi += " ";
                    }

                    tenDT = tenDT + noichuoi;
                }
                else if (tenDT.Length >= 25) 
                {
                    var ngat = "";
                    for (int i = tenDT.Length; i < tenDT.Length-25; i++)
                    {
                        ngat += "[i]";
                    }

                    tenDT = ngat;
                }


                if (gia.Length < 10)
                {
                    var noichuoi = "";
                    for (int i = gia.Length; i < 10; i++)
                    {
                        noichuoi += " ";
                    }

                    gia = gia + noichuoi;
                }


                if (GiaThueDT.Length < 15)
                {
                    var noichuoi = "";
                    for (int i = GiaThueDT.Length; i < 15; i++)
                    {
                        noichuoi += " ";
                    }

                    GiaThueDT = GiaThueDT + noichuoi;
                }

                if (GiaDTgomVAT.Length < 10)
                {
                    var noichuoi = "";
                    for (int i = GiaDTgomVAT.Length; i < 10; i++)
                    {
                        noichuoi += " ";
                    }

                    GiaDTgomVAT = GiaDTgomVAT + noichuoi;
                }

                Console.WriteLine("  {0,4} | {1,3}|  {2,2} \t|   {3,2} |\t{4,2}\t |", idDT, tenDT, gia, GiaThueDT, GiaDTgomVAT);
                //trong đó số đầu tiên bên trong dấu ngoặc nhọn là chỉ mục và số thứ hai là căn chỉnh. Dấu của số thứ hai cho biết chuỗi nên được căn trái hay phải. Sử dụng số âm cho căn lề trái.

                //Console.WriteLine(" {0,4} | {1,3}|  {2,-2}    |   {3,2}   | {4,2} |", idDT, tenDT, gia, ThoiDiemNhap, SoLanXem);
                //Console.Write(" " + row[column] + " |  ");
                //foreach (DataColumn column in dt.Tables[0].Columns)
                //{
                //    // string ColumnName = column.ColumnName;
                //    //string ColumnData = row[column].ToString();
                //    //Console.WriteLine(column.ColumnName + "  |  ");

                //}
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            
            
            //SqlCommand cmd = new SqlCommand("spTinhTonggiadienthoai", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Float) { Direction = ParameterDirection.Output });
            //conn.Open();
            //var ki = cmd.ExecuteNonQuery();
            //var Tonggiadienthoai = cmd.Parameters["@result"].Value.ToString();
            //Console.WriteLine("Tong gia dien thoai: " + Tonggiadienthoai+ " (dong)");


            //tạo đối tượng command
            //SqlCommand cmd = new SqlCommand()
            //{
            //    CommandText = "spGet",
            //    Connection = conn,
            //    CommandType = CommandType.StoredProcedure
            //};
            //khai báo các thuộc tính của tham số
            //SqlParameter param = new SqlParameter
            //{
            //    ParameterName = "@Id",
            //    SqlDbType = SqlDbType.Int,
            //    Value = 101,
            //    Direction = ParameterDirection.Input
            //};
            ////thêm tham số vào đối tượng SqlCommand
            //cmd.Parameters.Add(param);

        }

    }
        
       
 }
