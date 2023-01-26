using IspBillingSystem2023.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace IspBillingSystem2023.DAL.Repositories
{
    public class EstateRepository
    {
        private readonly string _connectionString;

        public EstateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(Estate estate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Estates (Address, ServiceNumber, Total, SubjectId) VALUES (@Address, @ServiceNumber, @Total, @SubjectId) SELECT SCOPE_IDENTITY()";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                    {
                        sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@Address", estate.Address)
                            );
                        sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@ServiceNumber", estate.ServiceNumber)
                            );
                        sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@Total", estate.Total)
                            );
                        sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@SubjectId", estate.SubjectId)
                            );
                        object result = sqlCommand.ExecuteScalar();

                        return result != null;
                    }

                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool Edit(Estate estate)
        {
            if (estate.Id != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string sqlQuery = "UPDATE Estates SET Address = @Address, ServiceNumber = @ServiceNumber, Total = @Total, SubjectId = @SubjectId WHERE Id = @Id";

                        using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                        {
                            sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@Address", estate.Address)
                            );
                            sqlCommand.Parameters.Add(
                                new SqlParameter(
                                    "@ServiceNumber", estate.ServiceNumber)
                                );
                            sqlCommand.Parameters.Add(
                                new SqlParameter(
                                    "@Total", estate.Total)
                                );
                            sqlCommand.Parameters.Add(
                                new SqlParameter(
                                    "@SubjectId", estate.SubjectId)
                                );
                            sqlCommand.Parameters.Add(
                                new SqlParameter(
                                    "@Id", estate.Id)
                                );
                            int rows = sqlCommand.ExecuteNonQuery();

                            return rows != 0;
                        }

                        return false;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                //The subject has no Id => do not know which entry we may edit
                return false;
            }
        }

        public Estate GetById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Estates WHERE Id = @Id";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                    {
                        sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@Id", id
                            )
                        );
                        using (SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                Estate estate = new Estate();
                                estate.Id = (int)reader.GetValue(0);
                                estate.Address = (string)reader.GetValue(1);
                                estate.ServiceNumber = (int)reader.GetValue(2);
                                estate.Total = (decimal)reader.GetValue(3);
                                estate.SubjectId = (int)reader.GetValue(4);
                                return estate;
                            }
                            else
                            {
                                return null;
                            }
                        }

                    }

                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Estate> GetAll()
        {
            List<Estate> estates = new List<Estate>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Estates";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Estate estate = new Estate();
                                    estate.Id = (int)reader.GetValue(0);
                                    estate.Address = (string)reader.GetValue(1);
                                    estate.ServiceNumber = (int)reader.GetValue(2);
                                    estate.Total = (decimal)reader.GetValue(3);
                                    estate.SubjectId = (int)reader.GetValue(4);
                                    estates.Add(estate);
                                }
                            }
                        }

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return estates;
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "DELETE FROM Estates WHERE Id = @Id";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                    {
                        sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@Id", id
                            )
                        );
                        int rows = sqlCommand.ExecuteNonQuery();

                        return rows != 0;
                    }

                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
