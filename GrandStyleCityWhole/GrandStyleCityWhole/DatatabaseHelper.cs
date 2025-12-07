using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace GrandStyleCityWhole
{
    public static class DatabaseHelper
    {
        private const string DbFile = "GrandStyleCityDBSecondEdition.db";

        public static SqliteConnection GetConnection() => new SqliteConnection($"Data Source={DbFile}");

        public static void InitializeDatabase()
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Players(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PlayerName TEXT,
                    SaveDate TEXT DEFAULT CURRENT_TIMESTAMP
                );
                CREATE TABLE IF NOT EXISTS Options(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Category TEXT,
                    Name TEXT
                );
                CREATE TABLE IF NOT EXISTS PlayerOptions(
                    PlayerId INTEGER,
                    OptionId INTEGER,
                    FOREIGN KEY(PlayerId) REFERENCES Players(Id),
                    FOREIGN KEY(OptionId) REFERENCES Options(Id)
                );";
            cmd.ExecuteNonQuery();
        }

        public static void InitializeOptions(Dictionary<string, string[]> options)
        {
            using var conn = GetConnection();
            conn.Open();
            foreach (var cat in options)
            {
                foreach (var opt in cat.Value)
                {
                    using var cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Options(Category, Name) VALUES(@cat, @name)";
                    cmd.Parameters.AddWithValue("@cat", cat.Key);
                    cmd.Parameters.AddWithValue("@name", opt);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<(int Id, string Name)> GetOptionsByCategory(string category)
        {
            var list = new List<(int, string)>();
            using var conn = GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Name FROM Options WHERE Category=@cat";
            cmd.Parameters.AddWithValue("@cat", category);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add((reader.GetInt32(0), reader.GetString(1)));
            return list;
        }

        public static string GetOptionNameById(int? id)
        {
            if (!id.HasValue) return "None";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Name FROM Options WHERE Id=@id";
            cmd.Parameters.AddWithValue("@id", id.Value);
            return cmd.ExecuteScalar()?.ToString() ?? "Unknown";
        }

        public static long InsertPlayer(PlayerStruct player)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Players(PlayerName) VALUES(@name)";
            cmd.Parameters.AddWithValue("@name", player.PlayerName);
            cmd.ExecuteNonQuery();

            long id;
            using (var cmd2 = conn.CreateCommand())
            {
                cmd2.CommandText = "SELECT last_insert_rowid()";
                id = (long)cmd2.ExecuteScalar();
            }

            foreach (var kvp in player.SingleOptions)
            {
                if (kvp.Value.HasValue)
                {
                    using var cmd2 = conn.CreateCommand();
                    cmd2.CommandText = "INSERT INTO PlayerOptions(PlayerId, OptionId) VALUES(@pid, @oid)";
                    cmd2.Parameters.AddWithValue("@pid", id);
                    cmd2.Parameters.AddWithValue("@oid", kvp.Value.Value);
                    cmd2.ExecuteNonQuery();
                }
            }

            foreach (var (usage, optId) in player.MultipleOptions)
            {
                using var cmd2 = conn.CreateCommand();
                cmd2.CommandText = "INSERT INTO PlayerOptions(PlayerId, OptionId) VALUES(@pid, @oid)";
                cmd2.Parameters.AddWithValue("@pid", id);
                cmd2.Parameters.AddWithValue("@oid", optId);
                cmd2.ExecuteNonQuery();
            }

            return id;
        }

        public static List<(int Id, string Name, string SaveDate)> GetSavedGames()
        {
            var list = new List<(int, string, string)>();
            using var conn = GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, PlayerName, SaveDate FROM Players ORDER BY Id";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            return list;
        }

        public static (Dictionary<string, int?> singleOptions, List<(string usage, int optionId)> multipleOptions, string playerName, string saveDate) GetPlayerWithOptions(int playerId)
        {
            var singleOptions = new Dictionary<string, int?>();
            var multipleOptions = new List<(string usage, int optionId)>();
            using var conn = GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT PlayerName, SaveDate FROM Players WHERE Id=@id";
            cmd.Parameters.AddWithValue("@id", playerId);
            using var reader = cmd.ExecuteReader();
            reader.Read();
            string name = reader.GetString(0);
            string date = reader.GetString(1);
            reader.Close();

            // get all options
            using var cmd2 = conn.CreateCommand();
            cmd2.CommandText = @"SELECT o.Category, o.Id FROM Options o
                                 JOIN PlayerOptions po ON o.Id = po.OptionId
                                 WHERE po.PlayerId=@pid";
            cmd2.Parameters.AddWithValue("@pid", playerId);
            using var r2 = cmd2.ExecuteReader();
            while (r2.Read())
            {
                string cat = r2.GetString(0);
                int oid = r2.GetInt32(1);
                // categorize into single/multiple
                if (singleOptions.ContainsKey(cat))
                {
                    multipleOptions.Add((cat, oid));
                }
                else
                {
                    singleOptions[cat] = oid;
                }
            }

            return (singleOptions, multipleOptions, name, date);
        }

        public static void DeletePlayer(int playerId)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM PlayerOptions WHERE PlayerId=@pid";
            cmd.Parameters.AddWithValue("@pid", playerId);
            cmd.ExecuteNonQuery();

            using var cmd2 = conn.CreateCommand();
            cmd2.CommandText = "DELETE FROM Players WHERE Id=@pid";
            cmd2.Parameters.AddWithValue("@pid", playerId);
            cmd2.ExecuteNonQuery();
        }
    }
}
