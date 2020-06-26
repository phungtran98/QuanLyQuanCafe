using QLQuanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCaffe.DAO
{
    public class TableDAO
    {
        private static TableDAO instances;

        public static TableDAO Instances
        {
            get { if (instances == null) instances = new TableDAO(); return TableDAO.instances; }
           private set { TableDAO.instances = value; }
        }

        private TableDAO() { }

        public static int TableWidth = 150;
        public static int TableHeight = 100;

        //danh sach ban
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuey("USP_GetTableList");

            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
    }
}
