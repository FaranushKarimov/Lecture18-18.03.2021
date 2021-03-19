using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Dapper;
using System.Data.SqlClient;

namespace Lecture18_18._03._2021.Repositories
{
    public abstract class Repository<TModel>
    {
        public string ConnectionString { get; set; }

        public Repository()
        {
            ConnectionString = "Data Source=KARIMOVFARAMUSH;Initial Catalog=testDB;Integrated Security=True;";
        }

        public List<TModel> Select()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    return connection.Query<TModel>($"SELECT * FROM {typeof(TModel).Name.ToUpper()}").ToList();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error found: {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }
    }
}
