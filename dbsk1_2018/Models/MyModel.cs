using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

public class StudentsModel
{
    private string connectionString = "Server=localhost;Database=a20sarle_dk;Port=3307;User ID=sqllab;Password=Tomten2009;Pooling=false;SslMode=none;convert zero datetime=True;";

    public DataTable GetOnskelista()
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM onskelista;", dbcon);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "result");
        DataTable onskelista = ds.Tables["result"];

        dbcon.Close();

        return onskelista;
    }
}