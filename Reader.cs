using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia_logismikou
{
    public class Reader:User
    {
        public Reader() { }
        public List<string> question = new List<string>();
        public List<string> to = new List<string>();
        public List<string> answer = new List<string>();
        public Reader(String username, String gender, String first_lastname, String email):base(username, gender, first_lastname, email)
        {
            //constructor
        }
       
        public void buy_books(List<Book> cart, List<Label> pos)
        {
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";

            for (int i = 0; i < cart.Count; i++)
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Assuming textBox1.Text contains the value you want to insert
                        string sql = "UPDATE Book SET sales = sales+ @Increment WHERE book_id = @BookId";

                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            // Use parameters to avoid SQL injection
                            command.Parameters.AddWithValue("@Increment",int.Parse(pos[i].Text));
                            command.Parameters.AddWithValue("@BookId", cart[i].Id);

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();

                            // Output the number of rows affected
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

        }

        public void get_answered_Questions()
        {
            this.answer.Clear();
            this.question.Clear();
            this.to.Clear();
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string query = $"SELECT question,answer,writen_to FROM Comments_to_writer WHERE status='answered' AND writen_by='{this.First_lastname}';";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())

                        {

                            while (reader.Read())
                            {
                                this.question.Add(reader.GetString(reader.GetOrdinal("question")));
                                this.answer.Add(reader.GetString(reader.GetOrdinal("answer")));
                                this.to.Add(reader.GetString(reader.GetOrdinal("writen_to")));
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

        public void search()
        {
            Console.WriteLine("The reader can search books!");
        }
        public void review(Book b,string name,string text)
        {

            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Assuming textBox1.Text contains the value you want to insert
                    string query = $"INSERT INTO Comments_book(writen_by,book_id,comment) VALUES (@writer,@b_id,@c)";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Use parameters to avoid SQL injection
                        command.Parameters.AddWithValue("@writer", name);
                        command.Parameters.AddWithValue("@b_id", b.Id);
                        command.Parameters.AddWithValue("@c", text);

                        // Execute the query without using ExecuteReader for INSERT
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Request sent successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Fail");
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }

        }
    }
}




















