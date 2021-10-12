using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace dbsk6_2018.Models
{
    public class InvoiceRowsModel
    {
        // To access your database on wwwlab.iit.his.se you need to update the connection string below and use wwwlab.iit.his.se instead of localhost.
        // NOTE that you only can connect to wwwlab.iit.his.se from VDI or computors in E101, if you use your own computor you need to setup your own MySQL server
        private string connectionString = "Server=localhost;Database=a00leifo;User ID=myusername;Password=mypassword;Pooling=false;SslMode=none;convert zero datetime=True;";

        public InvoiceRowsModel()
        {

        }

        public DataTable SearchInvoiceRows(string custno)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM INVOICEROW WHERE CUSTNO=@CUSTNO;", dbcon);
            adapter.SelectCommand.Parameters.AddWithValue("@CUSTNO", custno);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable InvoiceRowsTable = ds.Tables["result"];
            dbcon.Close();
            return InvoiceRowsTable;
        }
    }
}
