using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

public class StudentsModel
{
    private string connectionString = "Server=localhost;Database=a20sarle_dk;Port=3307;User ID=sqllab;Password=Tomten2009;Pooling=false;SslMode=none;convert zero datetime=True;";

    public void Update(string upd_artal, int upd_levererad)
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = dbcon;
        cmd.CommandText = "UPDATE onskelista SET levererad=@LEVERERAD WHERE artal=@ARTAL;";
        cmd.Parameters.AddWithValue("@ARTAL", upd_artal);
        cmd.Parameters.AddWithValue("@LEVERERAD", upd_levererad);
        cmd.ExecuteNonQuery();

        dbcon.Close();

    }

    public void Insert(string onskelista_artal, string onskelista_beskrivning, int onskelista_levererad)
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = dbcon;
        cmd.CommandText = "INSERT INTO onskelista(artal,beskrivning,levererad) VALUES(@ARTAL,@BESKRIVNING,@LEVERERAD)";
        cmd.Parameters.AddWithValue("@ARTAL", onskelista_artal);
        cmd.Parameters.AddWithValue("@BESKRIVNING", onskelista_beskrivning);
        cmd.Parameters.AddWithValue("@LEVERERAD", onskelista_levererad);
        cmd.ExecuteNonQuery();

        dbcon.Close();

    }

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

    public DataTable GetOnskelistaLevererade()
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM onskelistaLevererade;", dbcon);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "result");
        DataTable onskelistaLevererade = ds.Tables["result"];

        dbcon.Close();

        return onskelistaLevererade;
    }
}