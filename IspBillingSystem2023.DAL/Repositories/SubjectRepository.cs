using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IspBillingSystem2023.DAL.Entities;
using System.Xml.Linq;

namespace IspBillingSystem2023.DAL.Repositories
{
    public class SubjectRepository
    {
        private readonly string _connectionString;

        public SubjectRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Add(Subject subject)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Subjects (Name, TaxNumber, Address, IsCompany) VALUES (@Name, @TaxNumber, @Address, @IsCompany) SELECT SCOPE_IDENTITY()";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                    {
                        sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@Name", subject.Name)
                            );
                        sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@TaxNumber", subject.TaxNumber)
                            );
                        sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@Address", subject.Address)
                            );
                        sqlCommand.Parameters.Add(
                            new SqlParameter(
                                "@IsCompany", subject.IsCompany)
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

        public bool Edit(Subject subject)
        {
            if (subject.Id != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string sqlQuery = "UPDATE Subjects SET Name = @Name, TaxNumber = @TaxNumber, Address = @Address, IsCompany = @IsCompany WHERE Id = @Id";

                        using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                        {
                            sqlCommand.Parameters.Add(
                                new SqlParameter(
                                    "@Name", subject.Name
                                )
                            );
                            sqlCommand.Parameters.Add(
                                new SqlParameter(
                                    "@TaxNumber", subject.TaxNumber
                                )
                            );
                            sqlCommand.Parameters.Add(
                                new SqlParameter(
                                    "@Address", subject.Address
                                )
                            );
                            sqlCommand.Parameters.Add(
                                new SqlParameter(
                                    "@IsCompany", subject.IsCompany
                                )
                            );
                            sqlCommand.Parameters.Add(
                                new SqlParameter(
                                    "@Id", subject.Id
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
            else
            {
                //The subject has no Id => do not know which entry we may edit
                return false;
            }
        }

        public Subject GetById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Subjects WHERE Id = @Id";

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
                                reader.Read(); //read information for one line of the table
                                Subject subject = new Subject();
                                subject.Id = (int)reader.GetValue(0);
                                subject.Name = (string)reader.GetValue(1);
                                subject.TaxNumber = (string)reader.GetValue(2);
                                subject.Address = (string)reader.GetValue(3);
                                subject.IsCompany = (bool)reader.GetValue(4);
                                return subject;
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

        public List<Subject> GetAll()
        {
            List<Subject> subjects = new List<Subject>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Subjects";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                { 
                                    Subject subject = new Subject();
                                    subject.Id = (int)reader.GetValue(0);
                                    subject.Name = (string)reader.GetValue(1);
                                    subject.TaxNumber = (string)reader.GetValue(2);
                                    subject.Address = (string)reader.GetValue(3);
                                    subject.IsCompany = (bool)reader.GetValue(4);
                                    subjects.Add(subject);
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
            return subjects;
        }

        public bool Delete(int id)
        {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string sqlQuery = "DELETE FROM Subjects WHERE Id = @Id";

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
        /* Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IspBillingSystemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False */
    

