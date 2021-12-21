using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using DataLayer.Models;
using MenuItem = DataLayer.Models.MenuItem;

namespace PresentationDesktopR
{
    public partial class Form1 : Form
    {
        readonly MenuItemBusiness menuItemBusiness = new MenuItemBusiness();

        public Form1()
        {
            InitializeComponent();
            RefreshList();
        }

        private void RefreshList()
        {
            listBox1.Items.Clear();
            foreach (MenuItem menuItem in menuItemBusiness.GetMenuItems())
            {
                listBox1.Items.Add($"{menuItem.Id}. {menuItem.Title}");
            }
        }

        private void btn_Dodaj_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = new MenuItem()
            {
                Title = tb_Title.Text,
                Description = tb_Description.Text,
                Price = Convert.ToDecimal(tb_Price.Text)
            };

            menuItemBusiness.InsertMenuItem(menuItem);

            RefreshList();

            tb_Title.Text = "";
            tb_Description.Text = "";
            tb_Price.Text = "";
            tb_Title.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
