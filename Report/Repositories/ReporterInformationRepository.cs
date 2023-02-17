using Microsoft.Data.SqlClient;
using Report.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repositories
{
#nullable disable
    public class ReporterInformationRepository
    {
        private readonly string _connectionString;


        public ReporterInformationRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DC"].ConnectionString;
        }


        public void AddReportersInformation(ReportersInformation ri)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlCommand = """
                            INSERT INTO ReportersInformations
                            (Reporter, Name, ReporterType, Occupation, SpecialityArea, Address, Country, State, City, Pin, LandlineNo, MobileNo, Email, FaxNo, ReportDate)
                            VALUES
                            (@Reporter, @Name, @ReporterType, @Occupation, @SpecialityArea, @Address, @Country, @State, @City, @Pin, @LandlineNo, @MobileNo, @Email, @FaxNo, @ReportDate)
                            """;
                using (var command = new SqlCommand(sqlCommand,connection))
                {
                    command.Parameters.AddWithValue("@Reporter", ri.Reporter);
                    command.Parameters.AddWithValue("@Name", ri.Name);
                    command.Parameters.AddWithValue("@ReporterType", ri.ReporterType);
                    command.Parameters.AddWithValue("@Occupation", ri.Occupation);
                    command.Parameters.AddWithValue("@SpecialityArea", ri.SpecialityArea);
                    command.Parameters.AddWithValue("@Address", ri.Address);
                    command.Parameters.AddWithValue("@Country", ri.Country);
                    command.Parameters.AddWithValue("@State", ri.State);
                    command.Parameters.AddWithValue("@City", ri.City);
                    command.Parameters.AddWithValue("@Pin", ri.Pin);
                    command.Parameters.AddWithValue("@LandlineNo", ri.LandlineNo);
                    command.Parameters.AddWithValue("@MobileNo", ri.MobileNo);
                    command.Parameters.AddWithValue("@Email", ri.Email);
                    command.Parameters.AddWithValue("@FaxNo", ri.FaxNo);
                    command.Parameters.AddWithValue("@ReportDate", ri.ReportDate);

                    using (var reader = command.ExecuteReader()) { }
                }
            }
        }
        public List<ReportersInformation> GetAllReportersInformation()
        {
            var reportersInformations = new List<ReportersInformation>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlCommand = "Select * From ReportersInformations";

                using (var command = new SqlCommand(sqlCommand, connection))
                {
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reportersInformations.Add(
                                new ReportersInformation()
                                {
                                    Reporter = reader.GetString(1),
                                    Name = reader.GetString(2),
                                    ReporterType = reader.GetString(3),
                                    Occupation = reader.GetString(4),
                                    SpecialityArea = reader.GetString(5),
                                    Address = reader.GetString(6),
                                    Country = reader.GetString(7),
                                    State = reader.GetString(8),
                                    City = reader.GetString(9),
                                    Pin = reader.GetString(10),
                                    LandlineNo = reader.GetString(11),
                                    MobileNo = reader.GetString(12),
                                    Email = reader.GetString(13),
                                    FaxNo = reader.GetString(14),
                                    ReportDate = reader.GetDateTime(15)
                                }
                            );
                        }
                    }
                }
            }

            return reportersInformations;
        }

    }
}
