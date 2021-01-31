using DbTests.Services.Model;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

namespace DbTests.Services.Repositories
{
    public class AdoRepository
    {
        public AdoRepository()
        {

        }

        public IEnumerable<OrderDetails> GetAllFromOrderDetails()
        {
            var list = new List<OrderDetails>();

            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                var command = new SqlCommand("SELECT * FROM dbo.[Order Details]", connection);
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new OrderDetails()
                    {
                        OrderId = (int)reader.GetValue(reader.GetOrdinal(nameof(OrderDetails.OrderId))),
                        ProductId = (int)reader.GetValue(reader.GetOrdinal(nameof(OrderDetails.ProductId))),
                        UnitPrice = (decimal)reader.GetValue(reader.GetOrdinal(nameof(OrderDetails.UnitPrice))),
                        Quantity = (short)reader.GetValue(reader.GetOrdinal(nameof(OrderDetails.Quantity))),
                        Discount = (float)reader.GetValue(reader.GetOrdinal(nameof(OrderDetails.Discount)))
                    });
                }
                reader.Close();
            }

            return list;
        }
    }
}
