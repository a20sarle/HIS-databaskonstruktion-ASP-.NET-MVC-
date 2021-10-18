using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


public class ByggarnisseModel
{
    private string connectionString = "Server=localhost;Database=a20sarle_dk;Port=3307;User ID=sqllab;Password=Tomten2009;Pooling=false;SslMode=none;convert zero datetime=True;";

    public DataTable KladfargModel(string visa_kladfarg)
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = dbcon;
        MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT kladfarg, idnr, namn FROM byggarnisse WHERE kladfarg LIKE '%' @KLADFARG '%'", dbcon);
        adapter.SelectCommand.Parameters.AddWithValue("@KLADFARG", visa_kladfarg);

        DataSet ds = new DataSet();
        adapter.Fill(ds, "resultKladfarg");
        DataTable arbetsteam = ds.Tables["resultKladfarg"];
        dbcon.Close();
        return arbetsteam;
    }

    public DataTable BarackModel(string visa_barack)
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = dbcon;
        MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT barack, idnr, namn FROM byggarnisse WHERE barack LIKE '%' @BARACK '%'", dbcon);
        adapter.SelectCommand.Parameters.AddWithValue("@BARACK", visa_barack);

        DataSet ds = new DataSet();
        adapter.Fill(ds, "resultBarack");
        DataTable barackteam = ds.Tables["resultBarack"];
        dbcon.Close();
        return barackteam;
    }
}

