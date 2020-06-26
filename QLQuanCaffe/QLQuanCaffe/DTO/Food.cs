using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCaffe.DTO
{
    public class Food
    {
        public Food(int id, string name, int idcategory, float price)
        {
            this.ID = id;
            this.Name = name;
            this.IdCategory = idcategory;
            this.Price = price;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.IdCategory = (int)row["idcategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }





        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private int idCategory;

        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
