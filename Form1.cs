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
                                )"; //SQL-Befehl um die Tabelle zu erstellen wenn sie nicht existiert
                cmd.ExecuteReader(); //F�hrt das Kommando aus

            }

        }


        //Form Load Event (wird ausgel�st wenn das Formular geladen wird)
        private void Form1_Load(object sender, EventArgs e)
        {
            
            connection.Open(); //�ffnet die Verbindung zur Datenbank
            using (var cmd = connection.CreateCommand()) //Erstellt ein neues SQL-Kommando
            {
               cmd.CommandText = @"SELECT Description FROM tasks WHERE IsCompleted = 0;"; //SQL-Befehl um alle Aufgaben die nicht erledigt sind auszuw�hlen
                using var reader = cmd.ExecuteReader(); //F�hrt das Kommando aus und gibt einen Reader zur�ck um die Ergebnisse zu lesen
                while (reader.Read()) //Liest jede Zeile im Ergebnis
                {
                  var description = reader.GetString(0); //Liest die Beschreibung der Aufgabe aus der ersten Spalte
                   ListBox.Items.Add(description); //F�gt die Beschreibung der Liste hinzu
                }
               
            }
        }
        


        // CheckedListBox SelectedIndexChanged Event (wird ausgel�st wenn eine Aufgabe abgehakt wird)
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox.SelectedItem == null) return; //�berpr�ft ob eine Aufgabe ausgew�hlt ist
            var selectedTask = ListBox.SelectedItem.ToString(); //Liest die ausgew�hlte Aufgabe aus der Liste
            connection.Open(); //�ffnet die Verbindung zur Datenbank
            using (var cmd = connection.CreateCommand()) //Erstellt ein neues SQL-Kommando
            {
                cmd.CommandText = @"UPDATE tasks SET IsCompleted = 1 WHERE Description = @description;"; //SQL-Befehl um die Aufgabe als erledigt zu markieren
                cmd.Parameters.AddWithValue("@description", selectedTask); //F�gt den Parameter f�r die Beschreibung hinzu
                cmd.ExecuteNonQuery(); //F�hrt das Kommando aus
            }
            
        }



        // TextBox TextChanged Event (wird ausgel�st wenn der Text in der TextBox ge�ndert wird)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        //Button zum L�schen der Aufgabe)
        private void button2_Click(object sender, EventArgs e)
        {
            {
                if (ListBox.SelectedItem == null) return; //�berpr�ft ob eine Aufgabe ausgew�hlt ist
                var selectedTask = ListBox.SelectedItem.ToString(); //Liest die ausgew�hlte Aufgabe aus der Liste
                connection.Open(); //�ffnet die Verbindung zur Datenbank
                
                using (var cmd = connection.CreateCommand()) //Erstellt ein neues SQL-Kommando
                {
                    cmd.CommandText = @"DELETE FROM tasks WHERE id = (@id)"; // SQL-Befehl um die Aufgabe zu l�schen
                    cmd.Parameters.AddWithValue(@"id", selectedTask); //F�gt den Parameter f�r die Beschreibung hinzu
                    cmd.ExecuteNonQuery(); //F�hrt das Kommando aus
                    
                    ListBox.Items.Remove(selectedTask); //Entfernt die Aufgabe aus der Liste
                    ListBox.Update(); //Aktualisiert die Liste
                }

            }

        }   


        //(Speichern Button) Zum Aufgaben hinzuf�gen 
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
                    cmd.CommandText = @"INSERT INTO tasks (Description, IsCompleted) VALUES (@description, 0);";
                    cmd.Parameters.AddWithValue("@description", task);
                    cmd.ExecuteNonQuery();
                    ListBox.Items.Add(task);
                }
            }
           
            textBox1.Clear();

        }

        // CheckedListBox ItemCheck Event (wird ausgel�st wenn eine Aufgabe abgehakt wird)
        private void CheckedListBox1_ItemCheck(Object sender, ItemCheckEventArgs e)
        {

        }

    }
}
