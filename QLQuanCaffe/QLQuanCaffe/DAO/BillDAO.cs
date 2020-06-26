using QLQuanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCaffe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
          private set { BillDAO.instance = value; }
        }

        private BillDAO() { }


        public int GetBillUncheckIdByTableID(int id)
        {
                    DataTable data = DataProvider.Instance.ExecuteQuey("select * from Bill where idTable = "+ id +" and status = 0");

            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
                
            }
            return -1;
        }


        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNoneQuey("exec USP_InsertBill @idTable", new object[]{id});
        }

        //lay id bill khi duoc them 
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScala("select Max(id) from	Bill;");
            }
            catch
            {
                return 1;
            }
            
        }



        public void CheckOut(int id)
        {
            string query = "update Bill set status =1 where id="+id;
            DataProvider.Instance.ExecuteNoneQuey(query);
        }



    }
}
