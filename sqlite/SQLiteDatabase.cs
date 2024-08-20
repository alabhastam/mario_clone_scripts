using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;

public class SQLiteDatabase : MonoBehaviour
{
    private string dbPath;

    void Start()
    {
        // Define the path to the database
        dbPath = Path.Combine(Application.persistentDataPath, "gameDatabase.db");

        // Create a new database or open an existing one
        CreateDatabase();
    }

    void CreateDatabase()
    {
        // Create connection string
        string connectionString = "URI=file:" + dbPath;

        // Open a connection to the database
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            // Create a command to create a table
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"CREATE TABLE IF NOT EXISTS PlayerData (
                                        id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                        playerName TEXT, 
                                        score INTEGER);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        Debug.Log("Database created and table initialized");
    }

    public void InsertData(string playerName, int score)
    {
        string connectionString = "URI=file:" + dbPath;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO PlayerData (playerName, score) VALUES (@playerName, @score)";
                command.Parameters.AddWithValue("@playerName", playerName);
                command.Parameters.AddWithValue("@score", score);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }

        Debug.Log("Data inserted successfully");
    }

    public void RetrieveData()
    {
        string connectionString = "URI=file:" + dbPath;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM PlayerData";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("ID: " + reader["id"] + " Name: " + reader["playerName"] + " Score: " + reader["score"]);
                    }
                }
            }

            connection.Close();
        }
    }
}
