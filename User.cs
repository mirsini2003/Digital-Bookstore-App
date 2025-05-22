using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ergasia_logismikou
{
    public class User
    {
        private String username;
        private String gender;
        private String first_lastname;
        private String email;

        public string Username { get => username; set => username = value; }
        public string Gender { get => gender; set => gender = value; }
        public string First_lastname { get => first_lastname; set => first_lastname = value; }
        public string Email { get => email; set => email = value; }

        public string login_status(string temp_usr, string temp_pw)
        {
            string connectionString = "Data Source= db\\book_store_db.db;Version=3;";
            string status = "temp";
            string usr = null;
            string role = null;
            string pw = null;


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                try
                {
                    // Open the connection
                    connection.Open();

                    string query = $"SELECT username,  pw, role FROM Users WHERE username = '{temp_usr}';";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                usr = reader.GetString(reader.GetOrdinal("username"));
                                pw = reader.GetString(reader.GetOrdinal("pw"));
                                role = reader.GetString(reader.GetOrdinal("role"));

                            }
                            if (usr == null)
                            {

                                status = "noexist";
                            }
                            else if (usr.Equals(temp_usr) && !(temp_pw.Equals(pw)))
                            {
                                status = "wrongpw";
                            }
                            else if (usr.Equals(temp_usr) && (temp_pw.Equals(pw)))
                            {
                                status = role;
                            }
                            else
                            {
                                status = "error";
                            }
                        }
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    status = "dberror";
                }

            }

            return status;


        }
        public User() { }
        public User(string username, string gender, string first_lastname, string email)
        {
            this.Username = username;
            this.Gender = gender;
            this.First_lastname = first_lastname;
            this.Email = email;
        }
    }
}
