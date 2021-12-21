using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace connectsqlserver

{
    public  class Connection
    {   //tạo kết nối
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-HSAI5KE;Initial Catalog=PHONE;Integrated Security=True");
        public void Form_Load(object sender, EventArgs e)
        {
            connect.Open(); //mở kết nối
            string sql = "SELECT TenDT, GiaKM, SoLuongTonKho, HeDieuHanh From Dien_Thoai FUll OUter JOIN Thuoc_TinhDT ON Dien_Thoai.idDT = Thuoc_TinhDT.idDT "; //câu lệnh SQl
            SqlCommand cmd = new SqlCommand(sql, connect); //thực hiện lệnh truy vấn
            cmd.CommandType = CommandType.Text; 
            SqlDataAdapter da = new SqlDataAdapter(cmd);//nơi để luu dữ liệu lấy đc
            DataTable dt = new DataTable(); //tạo 1 kho dữ liệu ảo
            da.Fill(dt); //đổ dữ liệu vào kho
            connect.Close();
            
        }
    }
    
        
}
