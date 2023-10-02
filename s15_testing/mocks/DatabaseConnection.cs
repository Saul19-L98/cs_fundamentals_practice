using System;
using System.Data.SqlClient;

namespace mocks;

public class DatabaseConnection : IDatabaseConnection
{
    private const string ConnectionString = "Data Source=MainServer; Initial Catalog=People; User ID=Admin; Password=123456";

    public Person GetById(int id)
    {
        Person? person = null;

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "SELECT * FROM Persons WHERE ID=@ID";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int personID = (int)reader["Id"];
                string? firstName = reader["Name"].ToString();
                string? lastName = reader["LastName"].ToString();
                person = new Person(personID, firstName, lastName);
            }
            reader.Close();
        }
        return person!;
    }
    public void Write(int id, Person person)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "INSERT INTO Persons (ID, Name, LastName) VALUES (@ID, @Name, @LastName)";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@Name", person.FirstName);
            command.Parameters.AddWithValue("@LastName", person.LastName);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

}
