using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_logismikou
{
    public class Writer : User
    {
        public List<Book> books = new List<Book>();//tha to pairnei apo tin basi
       public List<string> lista = new List<string>();
        public List<string> comment_text = new List<string>();
        public List<string> by = new List<string>();
        public List<string> question = new List<string>();
        public List<int> cId = new List<int>();
        

        
        public Writer(String username, String gender, String first_lastname, String email):base(username,gender,first_lastname,email)
        {
            
            //constructor
            List<Book> books = new List<Book>();
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();
                    string query = $"SELECT * FROM Book WHERE writer='{this.First_lastname}' ;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                       
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {                               
                                this.books.Add(new Book(reader.GetInt32(reader.GetOrdinal("book_id")), reader.GetString(reader.GetOrdinal("title")),
                                reader.GetString(reader.GetOrdinal("genre")), reader.GetString(reader.GetOrdinal("publisher")),
                                reader.GetString(reader.GetOrdinal("writer")), reader.GetInt32(reader.GetOrdinal("price")), reader.GetString(reader.GetOrdinal("summary")), reader.GetString(reader.GetOrdinal("image"))));
                                this.lista.Add(reader.GetInt32(reader.GetOrdinal("sales")).ToString());
                            }

                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR {ex}");
                }

            }
        }
        public void publish_book()
        {
            Console.WriteLine("The writer publish a new book!");
        }

        public void see_reviews(int id)
        {
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();
                    string query = $"SELECT writen_by,comment FROM Comments_book WHERE book_id='{id}';";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())

                        {

                            while (reader.Read())
                            {
                               this.by.Add(reader.GetString(reader.GetOrdinal("writen_by")));
                                this.comment_text.Add(reader.GetString(reader.GetOrdinal("comment")));
                            }

                        }
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR {ex}");
                }

            }
        }

        public void answer_questions(string text,int id)
        {
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string sql = "UPDATE Comments_to_writer SET status ='answered',answer=@ans WHERE com_id = @id";

                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ans", text);
                        command.Parameters.AddWithValue("@id",id);

                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"Rows affected: {rowsAffected}");

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Request sent successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Fail");
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: {ex.Message}");
                }
            }
        }

        public void see_questions()
        {
            this.question.Clear();
            this.cId.Clear();
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();
                    string query = $"SELECT question,com_id FROM Comments_to_writer WHERE status='sent' AND writen_to='{this.First_lastname}';";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())

                        {

                            while (reader.Read())
                            {
                                this.question.Add(reader.GetString(reader.GetOrdinal("question")));
                                this.cId.Add(reader.GetInt32(reader.GetOrdinal("com_id")));
                            }

                        }
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR {ex}");
                }

            }
        }
    }
}
