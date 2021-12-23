using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using System.Collections.Specialized;
using ConnectSQLServer.Model;


namespace ConnectSQLServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");
            string datasource = ConfigurationManager.AppSettings["datasource"].ToString();
            string database = ConfigurationManager.AppSettings["database"].ToString();
            string username = ConfigurationManager.AppSettings["username"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();

            //var datasource = @"DESKTOP-HSAI5KE";
            //var database = "PHONE";
            //var username = "sa";
            //var password = "123456";
            ////var datasource = @"DESKTOP-HSAI5KE";
            ////var database = "PHONE"; 
            ////var username = "sa"; 
            ////var password = "123456";
            //this.txtServer.Text = ConfigurationManager.AppSettings["Server"].ToString();
            //this.txtDatabase.Text = ConfigurationManager.AppSettings["Database"].ToString();
            //this.txtUsername.Text = ConfigurationManager.AppSettings["Username"].ToString();
            //this.txtPassword.Text = ConfigurationManager.AppSettings["Password"].ToString();

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                
                conn.Open();
                Console.WriteLine("Connection successful!");
                //QueryDienthoai(conn);
                Console.WriteLine("------------------------------------------------------------------------------------------");
                FunctionContDBSQLServer.thaotac(conn);
                
                //InsertDB(conn);
                //QueryDienthoai(conn);

                //UpdateDB(conn);

                //QueryDienthoai(conn);

                //DeleteDB(conn);
                //QueryDienthoai(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();

            
            }
        
    }
}
