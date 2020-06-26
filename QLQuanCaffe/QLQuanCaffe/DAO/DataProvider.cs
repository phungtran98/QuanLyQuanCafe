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

        public DataTable ExecuteQuey(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();
            // Đối tượng kết nối
           using  (SqlConnection conn = new SqlConnection(strConnectionStr))
           {
               conn.Open();

               SqlCommand command = new SqlCommand(query, conn);

               if(parameter !=null)
               {
                   string[] lisPara = query.Split(' ');
                   int i = 0;
                   foreach(string item in lisPara)
                   {
                       if(item.Contains('@'))
                       {
                           command.Parameters.AddWithValue(item, parameter[i]);
                           i++;
                       }
                   }

               }

               SqlDataAdapter adapter = new SqlDataAdapter(command);

               conn.Close();

               adapter.Fill(data);
               
           }// giai phong tai nguyen
            return data;
        }


        public int ExecuteNoneQuey(string query, object[] parameter = null)
        {
            int data = 0;
            // Đối tượng kết nối
            using (SqlConnection conn = new SqlConnection(strConnectionStr))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] lisPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }


                data = command.ExecuteNonQuery();
                conn.Close();

               

            }// giai phong tai nguyen
            return data;
        }


        public object ExecuteScala(string query, object[] parameter = null)
        {
            object data = 0;
            // Đối tượng kết nối
            using (SqlConnection conn = new SqlConnection(strConnectionStr))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] lisPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }


                data = command.ExecuteScalar();
                conn.Close();



            }// giai phong tai nguyen
            return data;
        }
      
    }
}
