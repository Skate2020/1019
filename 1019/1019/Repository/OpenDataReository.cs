using _1019.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace _1019.Repository
{
    class OpenDataReository
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\軟體工程\1019\1019\1019\Data\Database.mdf;Integrated Security=True";
            }
        }
        public void Insert(OpenData item)
        {
            var newItem = item;
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
            INSERT INTO OpenData( 資料集名稱, 主要欄位說明,服務分類)
            VALUES              (N'{0}', N'{1}', N'{2}')
            ", newItem.資料集名稱, newItem.主要欄位說明, newItem.服務分類);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
