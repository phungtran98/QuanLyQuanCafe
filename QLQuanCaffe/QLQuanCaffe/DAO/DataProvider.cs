using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLQuanCaffe.DAO
{
    class DataProvider
    {
        private static DataProvider instance; //CRL + R+E

        internal static DataProvider Instance
        {
            get { if(DataProvider.instance == null) instance=new DataProvider(); return DataProvider.instance; }
           private set { DataProvider.instance = value; }
        }

        private DataProvider() { }
        private string strConnectionStr = @"Data Source=DESKTOP-U1GPCL1\SQLEXPRESS;Initial Catalog=QuanLyQuanCaffe;Integrated Security=True";

        public DataTable ExecuteQuey(string query)
        {
            string strConnectionStr = @"Data Source=DESKTOP-U1GPCL1\SQLEXPRESS;Initial Catalog=QuanLyQuanCaffe;Integrated Security=True";

            DataTable data = new DataTable();
            // Đối tượng kết nối
           using  (SqlConnection conn = new SqlConnection(strConnectionStr))
           {
               conn.Open();
               SqlCommand command = new SqlCommand(query, conn);

               SqlDataAdapter adapter = new SqlDataAdapter(command);

               conn.Close();

               adapter.Fill(data);
               
           }// giai phong tai nguyen
            return data;
        }
    }
}
