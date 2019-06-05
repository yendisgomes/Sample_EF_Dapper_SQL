using EntityFramework.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static EFContext db = new EFContext();

        static void Main(string[] args)
        {
            var list = db.Products.ToList();

            Console.WriteLine("{0} - {1} - {2} - {3}", "Id", "ProductName", "QuantityPerUnit", "UnitPrice");
            foreach (var produto in list)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}",
                    produto.ProductId, produto.ProductName, produto.QuantityPerUnit, produto.UnitPrice);
            }
            Console.ReadLine();
        }
    }
}
