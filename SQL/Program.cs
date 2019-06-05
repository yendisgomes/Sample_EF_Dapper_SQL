using Sample_SQL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_SQL
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["conexaoNorthwind"].ConnectionString;

        static void Main(string[] args)
        {
            var produtos = GetList();

            Console.WriteLine("{0} - {1} - {2} - {3}", "Id", "ProductName", "QuantityPerUnit", "UnitPrice");
            foreach (var produto in produtos)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", 
                    produto.ProductId, produto.ProductName, produto.QuantityPerUnit, produto.UnitPrice);    
            }
            Console.ReadLine();
        }

        static List<Produto> GetList()
        {
            List<Produto> Produtos = new List<Produto>();
            Produto produto = null;
            
            string sqlQuery = "SELECT * FROM Products";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {    //Every new row will create a new dictionary that holds the columns
                    produto = new Produto();

                    produto.ProductId = Convert.ToInt32(reader["ProductId"]);
                    produto.ProductName = reader["ProductName"].ToString();
                    produto.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    produto.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    produto.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                    produto.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);

                    Produtos.Add(produto);
                }
                
                reader.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return Produtos;
        }
    }
}
