using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _20250703_Datenbankanbindung
{
    public partial class Form1 : Form
    {
        private DBVerbindung db = new DBVerbindung();
        private Dictionary<string, int> produktMap = new Dictionary<string, int>();
        private const int meldebestand = 40;

        public Form1()
        {
            InitializeComponent();
            LadeProdukte(); // Initiale Befüllung beim Start
        }

        private void LadeProdukte()
        {
            try
            {
                using (var conn = db.VerbindungHerstellen())
                {
                    if (conn == null) return;

                    string query = @"
                        SELECT 
                            p.produktid,
                            s.Stein,
                            f.farbe
                        FROM produkte p
                        JOIN stein s ON p.SteinID = s.SteinID
                        JOIN farbe f ON p.FarbID = f.FarbID";

                    var cmd = new MySqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();

                    comboBox1.Items.Clear();
                    produktMap.Clear();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32("produktid");
                        string name = $"{id} – {reader.GetString("Stein")} ({reader.GetString("farbe")})";
                        produktMap[name] = id;
                        comboBox1.Items.Add(name);
                    }

                    if (comboBox1.Items.Count > 0)
                        comboBox1.SelectedIndex = 0;

                    reader.Close();
                    db.VerbindungSchließen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden der Produkte: " + ex.Message);
            }
        }

        private void bn_details_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                richTextBox1.Text = "Bitte ein Produkt auswählen.";
                return;
            }

            string auswahl = comboBox1.SelectedItem.ToString();
            if (!produktMap.ContainsKey(auswahl))
            {
                richTextBox1.Text = "Ungültige Auswahl.";
                return;
            }

            int produktid = produktMap[auswahl];

            try
            {
                using (var conn = db.VerbindungHerstellen())
                {
                    if (conn == null) return;

                    string query = @"
                        SELECT 
                            p.produktid,
                            s.Stein,
                            f.farbe,
                            p.Lagerbestand,
                            p.preis
                        FROM produkte p
                        JOIN stein s ON p.SteinID = s.SteinID
                        JOIN farbe f ON p.FarbID = f.FarbID
                        WHERE p.produktid = @id";

                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", produktid);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int bestand = reader.GetInt32("Lagerbestand");

                        string details = $"Produkt ID: {reader["produktid"]}\n" +
                                         $"Stein: {reader["Stein"]}\n" +
                                         $"Farbe: {reader["farbe"]}\n" +
                                         $"Lagerbestand: {bestand}\n" +
                                         $"Meldebestand: {meldebestand}\n" +
                                         $"Preis: {reader["preis"]} €";

                        if (bestand < meldebestand)
                            details += "\n⚠️ Achtung: Bestand unter Meldebestand!";

                        richTextBox1.Text = details;
                    }
                    else
                    {
                        richTextBox1.Text = "Produkt nicht gefunden.";
                    }

                    reader.Close();
                    db.VerbindungSchließen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Abrufen der Details: " + ex.Message);
            }
        }

        private void btnZurueck_Click(object sender, EventArgs e)
        {
            this.Close(); // Schließt das aktuelle Fenster
        }
    }

    public class DBVerbindung
    {
        private MySqlConnection connection;

        private string connectionString = "server=10.80.0.206;database=team04;uid=team04;pwd=5VVDV;";

        public MySqlConnection VerbindungHerstellen()
        {
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Verbindungsfehler: " + ex.Message);
                return null;
            }
        }

        public void VerbindungSchließen()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}
