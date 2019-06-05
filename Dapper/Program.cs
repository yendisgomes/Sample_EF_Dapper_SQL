using Dapper;
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

        static string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        static void Main(string[] args)
        {
            DTO();
        }


        private static void DTO()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                IEnumerable pessoas = connection.Query<Pessoa>("Select * from Pessoa");
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", "Id", "Nome", "Telefone", "Endereço","Cidade","Estado");
                foreach (Pessoa pessoa in pessoas)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4}", pessoa.Id, pessoa.Nome, pessoa.Telefone, pessoa.Endereco, pessoa.Cidade, pessoa.Estado);
                }
                connection.Close();

                Console.ReadKey();
            }
        }
    }
}
