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

    public void Move(string move_artal, int move_levererad, string move_beskrivning)
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = dbcon;
        cmd.CommandText = "CALL proc_onskelista_levererade(@ARTAL, @LEVERERAD, @BESKRIVNING);";
        cmd.Parameters.AddWithValue("@ARTAL", move_artal);
        cmd.Parameters.AddWithValue("@LEVERERAD", move_levererad);
        cmd.Parameters.AddWithValue("@BESKRIVNING", move_beskrivning);
        cmd.ExecuteNonQuery();

        dbcon.Close();

    }

    public DataTable SumModel()
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = dbcon;
        MySqlDataAdapter adapter = new MySqlDataAdapter("CALL getLeksakPris();", dbcon);

        DataSet ds = new DataSet();
        adapter.Fill(ds, "resultSum");
        DataTable resultSum = ds.Tables["resultSum"];
        dbcon.Close();

        return resultSum;
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


    public DataTable dropdownListradArtalModel()
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM listrad, onskelista WHERE onskelista.artal=listrad.onskelistaArtal GROUP BY listrad.onskelistaArtal;", dbcon);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "result");
        DataTable onskelistaArtalTable = ds.Tables["result"];

        dbcon.Close();

        return onskelistaArtalTable;
    }
    public DataTable visaOnskelistaDetaljer(string visa_artal_result)
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM listrad, leksakNamn, onskelista WHERE listrad.onskelistaArtal = @VISA_ARTAL AND onskelista.artal = listrad.onskelistaArtal AND listrad.leksakIdnr=leksakNamn.namnCode;", dbcon);
        adapter.SelectCommand.Parameters.AddWithValue("@VISA_ARTAL", visa_artal_result);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "result");
        DataTable detaljer = ds.Tables["result"];

        dbcon.Close();

        return detaljer;
    }


    public DataTable GetByggarnisseDetaljer()
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT idnr, namn FROM byggarnisse;", dbcon);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "result");
        DataTable byggarnisseLink = ds.Tables["result"];

        dbcon.Close();

        return byggarnisseLink;
    }
    public DataTable byggarnisseDetaljer(int byggarnisse_idnr)
    {
        MySqlConnection dbcon = new MySqlConnection(connectionString);

        dbcon.Open();

        MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT byggarnisse.idnr, byggarnisse.namn AS byggarnisseNamn, byggarnisse.kladfarg, byggarnisse.mellanchefIdnr, byggarnisse.notter, byggarnisse.russin, byggarnisse.sangnr, byggarnisse.barack, mellanchef.idnr, mellanchef.namn AS mellanchefNamn, specialitet.specialitet, specialitet.byggarnisseIdnr, matByggarnisse.matNamn, matByggarnisse.byggarnisseIdnr, mat.namn AS MatNamn, mat.smak, mat.tillverkare, mat.maginiva FROM byggarnisse, mellanchef, specialitet, matByggarnisse, mat WHERE byggarnisse.idnr=@IDNR AND byggarnisse.mellanchefIdnr=mellanchef.idnr AND specialitet.byggarnisseIdnr=byggarnisse.idnr AND matByggarnisse.byggarnisseIdnr=byggarnisse.idnr AND matByggarnisse.matNamn=mat.namn; ", dbcon);
        adapter.SelectCommand.Parameters.AddWithValue("@IDNR", byggarnisse_idnr);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "result");
        DataTable byggarnisseDetaljer = ds.Tables["result"];

        dbcon.Close();

        return byggarnisseDetaljer;
    }
}