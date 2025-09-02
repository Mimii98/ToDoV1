using SQLitePCL;
using Microsoft.Data.Sqlite;


namespace To_Do_Liste
{
    public partial class Form1 : Form
    {


        //Konstruktor
        public Form1()
        {
            

            InitializeComponent();
            Batteries.Init();
            using (var connection = new SqliteConnection("Data Source=todo.db"))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS tasks (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Description TEXT NOT NULL,
                                IsCompleted INTEGER NOT NULL
                                );";
                    cmd.ExecuteNonQuery();

                }

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

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

            using (var connection = new SqliteConnection("Data Source=todo.db"))
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

       
    }
}
