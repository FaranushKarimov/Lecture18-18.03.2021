using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Lecture18_18._03._2021.Models;
using Lecture18_18._03._2021.Repositories;
using Dapper;

namespace Lecture18_18._03._2021.Repositories
{
    public class UserRepositories : Repository<Users>
    {
        public UserRepositories() : base()
        {

        }


        public int? Create(Users user)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string command = $"INSERT INTO USERS(Name, Age) VALUES('{user.Name}', {user.Age})";
                    return db.Query<int>(command).FirstOrDefault();
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
        public int? Update(Users user, int Id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string tempName = user.Name;
                    int tempAge = user.Age;
                    string command = $"UPDATE USERS set Name = '{tempName}', Age = {tempAge} where Id = {Id}";
                    return db.Query<int>(command).FirstOrDefault();
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
        public int? Delete(int Id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string command = $"DELETE FROM USERS WHERE Id = {Id}";
                    return db.Query<int>(command).FirstOrDefault();
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
