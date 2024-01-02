using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqNorthWind
{
   internal class Program
   {
      static void Main(string[] args)
      {
         List<Customer> clients = new List<Customer>();
         List<Category> categories = new List<Category>();
         List<Employee> commerciaux = new List<Employee>();
         List<Order> commandes = new List<Order>();
         List<Product> produits = new List<Product>();
         IEnumerable<ICollection<Order>> produitsClient;
         IEnumerable<Order> produitsClient2;
         using (var db = new NorthwindContext())
         {
            //  db.Configuration.LazyLoadingEnabled = false;
            clients = db.Customers.ToList();

            categories = db.Categories.ToList();
            commerciaux = db.Employees.ToList();
            commandes = db.Orders.ToList();
            produits = db.Products.ToList();
            produitsClient = clients.Select(c => c.Orders).ToList();
            produitsClient2 = clients.SelectMany(c => c.Orders).ToList();

         }
         //foreach (var client in clients)
         //{
         //   Console.WriteLine(client.Address + "  " + client.Country);
         //}



         foreach (var produit in produitsClient)
         {
            Console.WriteLine(produit.FirstOrDefault()?.Customer.ContactName + " : " + produit?.FirstOrDefault());

         }
         Console.ReadLine();
         Console.WriteLine("***************************************************************");
         foreach (var produit in produitsClient2)
         {
            Console.WriteLine(produit.Customer.ContactName + " : " + produit.OrderID);

         }
         Console.ReadLine();
         foreach (var categorie in categories)
         {
            Console.WriteLine(categorie.CategoryName + " : " + categorie.Description);
         }
         Console.ReadLine();
         var listString = produitsClient2.Select(c => c.ShipAddress);


      }
   }
}
