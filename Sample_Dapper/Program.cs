using Dapper;
using Sample_Dapper.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Dapper
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["conexaoNorthwind"].ConnectionString;

        static void Main(string[] args)
        {
            //SemDTO();
            ComDTO();
        }

        private static void SemDTO()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var resultado = connection.Query("Select * from Customers");
            Console.WriteLine("{0} - {1} - {2} ", "Código", "Nome do Contato", "Endereco do Cliente");
            foreach (dynamic cliente in resultado)
            {
                Console.WriteLine("{0} - {1} - {2} ", cliente.CustomerID, cliente.ContactName, cliente.Address);
            }
            connection.Close();

            Console.ReadKey();
        }

        private static void ComDTO()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                IEnumerable produtos = connection.Query<Produto>("Select * from Products");
                Console.WriteLine("{0} - {1} - {2} ", "Código", "Nome do Produto", "Preço do Produto");
                foreach (Produto produto in produtos)
                {
                    Console.WriteLine("{0} - {1} - {2}", produto.ProductId, produto.ProductName, produto.UnitPrice);
                }
                connection.Close();

                Console.ReadKey();
            }
        }
    }
}
