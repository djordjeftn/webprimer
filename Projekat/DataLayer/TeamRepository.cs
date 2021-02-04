using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TeamRepository
    {
        public List<Team> GetAllTeams()
        {
            List<Team> teams = new List<Team>();
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = Constants.connectionString;

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Teams";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Team t = new Team();
                    t.Id = sqlDataReader.GetInt32(0);
                    t.Name = sqlDataReader.GetString(1);
                    t.Couch = sqlDataReader.GetString(2);
                    t.Points = sqlDataReader.GetInt32(3);

                    teams.Add(t);
                }
            }
            return teams;
        }
        public int InsertAllTeams(Team t)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = string.Format(
                    "INSERT INTO Teams VALUES ('{0}','{1}','{2}')",
                    t.Name, t.Couch, t.Points);

                int result = sqlCommand.ExecuteNonQuery();

                return result;
            }
        }
    }
}
