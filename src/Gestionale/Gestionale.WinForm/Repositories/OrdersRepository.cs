using System;
using System.Collections.Generic;
using Gestionale.WinForm.Models;
using Microsoft.Data.SqlClient;

namespace Gestionale.WinForm.Repositories
{
    public class OrderRepository
    {
        public List<Order> GetAll()
        {
            var list = new List<Order>();

            using (var connection = DbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT Id, OrderDate, TotalAmount, CustomerId FROM Orders", connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Order
                                {
                                    Id = reader.GetGuid(0),
                                    OrderDate = reader.GetDateTime(1),
                                    TotalAmount = reader.GetDecimal(2),
                                    CustomerId = reader.GetGuid(3)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception("Error retrieving orders: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return list;
        }

        public Order GetById(Guid id)
        {
            Order order = new Order();

            using (var connection = DbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT Id, OrderDate, TotalAmount, CustomerId FROM Orders WHERE Id=@Id", connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                order = new Order
                                {
                                    Id = reader.GetGuid(0),
                                    OrderDate = reader.GetDateTime(1),
                                    TotalAmount = reader.GetDecimal(2),
                                    CustomerId = reader.GetGuid(3)
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception("Error retrieving order by Id: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return order;
        }


        public List<Order> GetByCustomerId(Guid customerId)
        {
            var list = new List<Order>();

            using (var connection = DbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT Id, OrderDate, TotalAmount, CustomerId FROM Orders WHERE CustomerId=@CustomerId", connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Order
                                {
                                    Id = reader.GetGuid(0),
                                    OrderDate = reader.GetDateTime(1),
                                    TotalAmount = reader.GetDecimal(2),
                                    CustomerId = reader.GetGuid(3)
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception("Error retrieving orders by customer: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return list;
        }

        public void Create(Order order)
        {
            using (var connection = DbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Orders (Id, OrderDate, TotalAmount, CustomerId) VALUES (@Id, @OrderDate, @TotalAmount, @CustomerId)",connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", order.Id);
                        cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                        cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception("Error creating order: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Update(Order order)
        {
            using (var connection = DbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(
                        "UPDATE Orders SET OrderDate=@OrderDate, TotalAmount=@TotalAmount, CustomerId=@CustomerId WHERE Id=@Id",
                        connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", order.Id);
                        cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                        cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception("Error updating order: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = DbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("DELETE FROM Orders WHERE Id=@Id", connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception("Error deleting order: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }

}
