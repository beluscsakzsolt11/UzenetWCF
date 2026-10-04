using MySql.Data.MySqlClient;
using UzenetWCF.Interfaces;
using UzenetWCF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UzenetWCF.Services
{
    public class UzenetServices : ICRUD
    {
        public string Create(Tablazat tablazat)
        {
            string connectionString = "SERVER = localhost;" +
                          "DATABASE= uzenetkuldo;" +
                          "UID = root;" +
                          "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "INSERT INTO UZENET(Szoveg, KüldesiIdo, UzenetTipus, Telefon, Email) VALUES (@szoveg,@kuldesiido,@uzenettipus,@telefon,@email)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@szoveg", (tablazat as Models.Uzenet).Szoveg);
            cmd.Parameters.AddWithValue("@kuldesiido", (tablazat as Models.Uzenet).KuldesiIdo);
            cmd.Parameters.AddWithValue("@uzenettipus", (tablazat as Models.Uzenet).UzenetTipus);
            cmd.Parameters.AddWithValue("@telefon", (tablazat as Models.Uzenet).Telefon);
            cmd.Parameters.AddWithValue("@email", (tablazat as Models.Uzenet).Email);
            int sorokSzama = cmd.ExecuteNonQuery();

            conn.Close();
            if (sorokSzama > 0)
            {
                return "Sikeres beszúrás!";
            }
            else
            {
                return "Sikertelen beszúrás!";
            }



        }


        public string Delete(int id)
        {
            string connectionString = "SERVER = localhost;" +
                               "DATABASE= uzenetkuldo;" +
                               "UID = root;" +
                               "PASSWORD =;";

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string sql = "DELETE FROM uzenet WHERE Id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            int sorokSzama = cmd.ExecuteNonQuery();
            conn.Close();

            if (sorokSzama > 0)
            {
                return "Sikeres törlés!";
            }
            else
            {
                return "Sikertelen törlés!";
            }
        }



        public List<Tablazat> Read()
        {
            List<Tablazat> tablazatok = new List<Tablazat>();
            string connectionString = "SERVER = localhost;" +
                          "DATABASE= uzenetkuldo;" +
                          "UID = root;" +
                          "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "SELECT * FROM uzenet";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Models.Uzenet uzenet = new Models.Uzenet();
                uzenet.Id = reader.GetInt32("Id");
                uzenet.Szoveg = reader.GetString("Szoveg");
                uzenet.KuldesiIdo = reader.GetDateTime("KüldesiIdo");
                uzenet.UzenetTipus = reader.GetString("UzenetTipus");
                uzenet.Email = reader.IsDBNull(reader.GetOrdinal("Email"))? "": reader.GetString("Email");
                uzenet.Telefon = reader.IsDBNull(reader.GetOrdinal("Telefon"))? "": reader.GetString("Telefon");

                tablazatok.Add(uzenet);

            }
            conn.Close();
            return tablazatok;

        }


        public string Update(Tablazat tablazat)
        {
            string connectionString = "SERVER = localhost;" +
              "DATABASE= uzenetkuldo;" +
              "UID = root;" +
              "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "UPDATE uzenet SET Szoveg = @szoveg, KüldesiIdo = @kuldesiido, UzenetTipus = @Uzenettipus, Telefon = @telefon, Email = @email WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@szoveg", (tablazat as Models.Uzenet).Szoveg);
            cmd.Parameters.AddWithValue("@kuldesiido", (tablazat as Models.Uzenet).KuldesiIdo);
            cmd.Parameters.AddWithValue("@uzenettipus", (tablazat as Models.Uzenet).UzenetTipus);
            cmd.Parameters.AddWithValue("@telefon", (tablazat as Models.Uzenet).Telefon);
            cmd.Parameters.AddWithValue("@email", (tablazat as Models.Uzenet).Email);
            cmd.Parameters.AddWithValue("@id", (tablazat as Models.Uzenet).Id);
            int sorokSzama = cmd.ExecuteNonQuery();
            conn.Close();
            if (sorokSzama > 0)
            {
                return "Sikeres frissítés!";
            }
            else
            {
                return "Sikertelen frissítés";
            }
        }
    }
}
