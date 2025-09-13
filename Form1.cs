using SQLitePCL;
using Microsoft.Data.Sqlite;
using System; 


namespace To_Do_Liste
{
    public partial class Form1 : Form
    {
        public SqliteConnection connection = new SqliteConnection("Data Source=todo.db");

        //Konstruktor
        public Form1()
        {
            

            InitializeComponent();
            Batteries.Init(); //Initialisiert die SQLite-Bibliothek

            connection.Open();
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS tasks (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Description TEXT NOT NULL,
                                IsCompleted INTEGER NOT NULL
                                )";
                

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox.Items.Clear(); //Löscht die Liste bevor sie neu geladen wird
            connection.Open(); //öffnet die Verbindung zur Datenbank
            using (var cmd = connection.CreateCommand()) //Erstellt ein neues SQL-Kommando
            {
               cmd.CommandText = "SELECT Description FROM tasks WHERE IsCompleted = 0;"; //SQL-Befehl um alle Aufgaben die nicht erledigt sind auszuwählen
                using var reader = cmd.ExecuteReader(); //Führt das Kommando aus und gibt einen Reader zurück um die Ergebnisse zu lesen
                while (reader.Read()) //Liest jede Zeile im Ergebnis
                {
                  var description = reader.GetString(0); //Liest die Beschreibung der Aufgabe aus der ersten Spalte
                    ListBox.Items.Add(description); //Fügt die Beschreibung der Liste hinzu
                }
               
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Button zum Löschen der Aufgabe)
        private void button2_Click(object sender, EventArgs e)
        {


        }


        //(Speichern Button) Zum Aufgaben hinzufügen 
        private void button1_Click(object sender, EventArgs e)
        {
            var task = textBox1.Text;

            if (string.IsNullOrWhiteSpace(task))
            {
                MessageBox.Show("Bitte geben Sie eine Aufgabe ein.");
                return;
            }

            
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())

                {
                    cmd.CommandText = "INSERT INTO tasks (Description, IsCompleted) VALUES (@description, 0);";
                    cmd.Parameters.AddWithValue("@description", task);
                    cmd.ExecuteNonQuery();
                }
            }
            textBox1.Clear();
        }
        private void CheckedListBox1_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            
        }

    }
}
