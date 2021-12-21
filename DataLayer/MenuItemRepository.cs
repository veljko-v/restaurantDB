using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MenuItemRepository
    {
        private string connString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=RestaurantDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> menuItemList = new List<MenuItem>();

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * FROM MENUITEMS";


                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    MenuItem menuItem = new MenuItem();
                    menuItem.Id = dataReader.GetInt32(0);
                    menuItem.Title = dataReader.GetString(1);
                    menuItem.Description = dataReader.GetString(2);
                    menuItem.Price = dataReader.GetDecimal(3);

                    menuItemList.Add(menuItem);
                }
            }
            return menuItemList;
        }
        public int InsertMenuItem(MenuItem menuItem)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = string.Format("INSERT INTO MENUITEMS VALUES ('{0}', '{1}', '{2}')",
                    menuItem.Title, menuItem.Description, menuItem.Price);

                return command.ExecuteNonQuery();
            }
        }
    }
}