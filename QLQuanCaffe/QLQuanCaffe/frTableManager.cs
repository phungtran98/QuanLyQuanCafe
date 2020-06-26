using QLQuanCaffe.DAO;
using QLQuanCaffe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCaffe
{
    public partial class frTableManager : Form
    {
        public frTableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
        }
        
        // các phương thức
        #region Method
        
        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instances.LoadTableList();
            foreach(Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name +Environment.NewLine+ item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch(item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.BurlyWood;
                        break;
                }

                flpTable.Controls.Add(btn);

            }
        }

        void ShowBill(int id)
        {
            float totalPrice = 0;
            lsvBill.Items.Clear();

            List<QLQuanCaffe.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);

            foreach (QLQuanCaffe.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.Foodname);
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;

                lsvBill.Items.Add(lsvItem);

                CultureInfo cultrue = new CultureInfo("vi-VN");

                //Thread.CurrentThread.CurrentCulture = cultrue;
                txtTotalPrice.Text = totalPrice.ToString("c",cultrue);
               
            }
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();

            cbxCategory.DataSource = listCategory;
            cbxCategory.DisplayMember = "Name";
        }


        void LoadFoodListCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetListCategoryID(id);
            cbxFood.DataSource = listFood;
            cbxFood.DisplayMember = "Name";
        }


        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetBillUncheckIdByTableID(table.ID);
            int FoodID = (cbxFood.SelectedItem as Food).ID;
            int count = (int)nmfoodCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), FoodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, FoodID, count);
            }
            ShowBill(table.ID);
            LoadTable();
        }


        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetBillUncheckIdByTableID(table.ID);
            if(idBill !=-1)
            {
                if(MessageBox.Show("Bạn có muốn thanh toán? "+table.Name,"Thông báo" ,MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill);

                    ShowBill(table.ID);
                    LoadTable();
                }
            }
        }

        #endregion



        //các sự kiện
        #region Event
        void btn_Click(object sender, EventArgs e)
        {
            txtNumberTable.Clear();
            //lay id bàn
            int tableID = ((sender as Button).Tag as Table).ID;
           
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
            txtNumberTable.Text = tableID.ToString();

           
        }
            private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frAccountProfile f = new frAccountProfile();

                this.Hide();

                f.ShowDialog();

                this.Show();
            }

                private void adminToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frAdmin f = new frAdmin();

                f.ShowDialog();
            }



            private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
            {
                int id = 0;

                ComboBox cb = sender as ComboBox;

                if (cb.SelectedItem == null)
                    return;
                Category selected = cb.SelectedItem as Category;
                id = selected.ID;

                LoadFoodListCategoryID(id);

            }



        #endregion

           

         

           
            
        

            





           

    }
}
