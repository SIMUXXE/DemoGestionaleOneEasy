using Gestionale.WinForm.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Gestionale.WinForm.Repositories
{
    public class CustomerRepository
    {
        public List<Customer> GetAll()
        {
            var list = new List<Customer>();

            using (var connection = DbHelper.GetConnection())
            {
                try
                {
                    connection.Open();

                    using (var command = new SqlCommand("SELECT Id, FirstName, LastName, Email, CreationDate FROM Customers", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var customer = new Customer
                                {
                                    Id = reader.GetGuid(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    CreationDate = reader.GetDateTime(4)
                                };
                                list.Add(customer);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while retrieving customers.", ex);
                }
                finally
                {
                    connection.Close();
                }

            }

            return list;
        }

        public Customer GetById(Guid orderId)
        {
            var customer = new Customer();

            using (var connection = DbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT Id, FirstName, LastName, Email, CreationDate FROM Customers WHERE Id=@CustomerId", connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", orderId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer = new Customer
                                {
                                    Id = reader.GetGuid(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    CreationDate = reader.GetDateTime(4)
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while retrieving customers.", ex);
                }
                finally
                {
                    connection.Close();
                }

            }

            return customer;
        }

        public void Create(Customer customer)
        {
            using (var connection = DbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand("INSERT INTO Customers (Id, FirstName, LastName, Email, CreationDate) VALUES (@Id, @FirstName, @LastName, @Email, @CreationDate)", connection))
                    {
                        command.Parameters.AddWithValue("@Id", Guid.NewGuid());
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        command.Parameters.AddWithValue("@CreationDate", DateTime.UtcNow);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while creating the customer.", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Update(Customer customer)
        {
            using (var connection = DbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand("UPDATE Customers SET FirstName=@FirstName, LastName=@LastName, Email=@Email WHERE Id=@Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", customer.Id);
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while updating the customer.", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Delete(Guid customerId)
        {
            using (var connection = DbHelper.GetConnection())
            { 
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand("DELETE FROM Customers WHERE Id=@Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", customerId);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception("An error occurred while deleting the customer.", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
