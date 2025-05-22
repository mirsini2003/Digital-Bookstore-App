using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ergasia_logismikou
{
    public class Book
    {
        private int id;
        private string title;
        private string genre;
        private string publisher;
        private string writer;
        private double price;
        private string summary;
        private string image;

        public Book(int id,string title, string genre, string publisher, string writer, double price,string summary,string image)
        {
            this.Id = id;
            this.Title = title;
            this.Genre = genre;
            this.Publisher = publisher;
            this.writer = writer;
            this.Price = price;
            this.summary = summary;
            this.image = image;
        }

        public Book()
        {
        }

        public List<Book> get_all_books()
        {
            List<Book> books = new List<Book>();
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    string query = $"SELECT * FROM Book ;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                string s = reader.GetString(reader.GetOrdinal("summary")); 
                                books.Add(new Book(reader.GetInt32(reader.GetOrdinal("book_id")), reader.GetString(reader.GetOrdinal("title")),
                                    reader.GetString(reader.GetOrdinal("genre")), reader.GetString(reader.GetOrdinal("publisher")),
                                    reader.GetString(reader.GetOrdinal("writer")), reader.GetInt32(reader.GetOrdinal("price")), reader.GetString(reader.GetOrdinal("summary")), reader.GetString(reader.GetOrdinal("image"))));
                            }
                           
                        }
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR {ex}");
                }

            }
            return books;
        }


        public string Title { get => title; set => title = value; }
        public double Price { get => price; set => price = value; }
        public string Summary { get => summary; set => summary = value; }
        public string Image { get => image; set => image = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string Writer { get => writer; set => writer = value; }
        public int Id { get => id; set => id = value; }
    }
}
