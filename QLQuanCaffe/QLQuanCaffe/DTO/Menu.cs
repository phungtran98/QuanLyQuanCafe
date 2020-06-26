using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCaffe.DTO
{
    public class Menu
    {

        public Menu(string foodname, int count, float price, float totalPrice = 0)
        {
            this.Foodname = foodname;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            this.Foodname = row["Name"].ToString();
            this.Count =(int)row["count"] ;
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
        private float totalPrice;

        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private string foodname;

        public string Foodname
        {
            get { return foodname; }
            set { foodname = value; }
        }
    }
}
