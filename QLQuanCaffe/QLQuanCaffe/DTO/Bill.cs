using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCaffe.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? datecheckin, DateTime? datecheckout,int idtable, int status )
        {
            this.ID = id;
            this.DateCheckin = dateCheckin;
            this.DateCheckout = datecheckout;
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckin = (DateTime?)row["dateCheckin"];
            var DateCheckoutTem = row["DateCheckout"];

            if (DateCheckoutTem.ToString() != "")
                this.DateCheckout = (DateTime?)DateCheckoutTem;
            this.Status = (int)row["status"];
        }



        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private DateTime? dateCheckout;

        public DateTime? DateCheckout
        {
            get { return dateCheckout; }
            set { dateCheckout = value; }
        }
        private DateTime? dateCheckin;

        public DateTime? DateCheckin
        {
            get { return dateCheckin; }
            set { dateCheckin = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

       
        
    }
}
