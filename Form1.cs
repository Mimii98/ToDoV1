using SQLitePCL;
using Microsoft.Data.Sqlite;

namespace To_Do_Liste
{
    public partial class Form1 : Form
    {
        private SqliteConnection connection;

        //Konstruktor
        public Form1()
        {
            MessageBox.Show("Halooooo");
            InitializeComponent();
            connection = new SqliteConnection("Data Source = todo.db");
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS tasks (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Description TEXT NOT NULL,
                                IsCompleted INTEGER NOT NULL
                                );";
            cmd.ExecuteNonQuery();


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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
}
