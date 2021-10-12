using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace dbsk4_2018.Models
{
    public class CustomersModel
    {
        // To access your database on wwwlab.iit.his.se you need to update the connection string below and use wwwlab.iit.his.se instead of localhost.
        // NOTE that you only can connect to wwwlab.iit.his.se from VDI or computors in E101, if you use your own computor you need to setup your own MySQL server
        private string connectionString = "Server=localhost;Database=a00leifo;User ID=myusername;Password=mypassword;Pooling=false;SslMode=none;convert zero datetime=True;";

        public DataTable GetAllCustomers()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM CUSTOMER;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable customerTable = ds.Tables["result"];
            dbcon.Close();

            return customerTable;
        }
    }
}
