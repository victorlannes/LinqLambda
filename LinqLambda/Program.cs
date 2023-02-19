using System;
using LinqLambda.Entities;
using System.Collections.Generic;
using System.Linq;

namespace curso {
    class Program {

        static void Print<T>(string message, IEnumerable<T> collection) {
            Console.WriteLine(message);
            foreach (T obj in collection) {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        static void Main(string[] args) {

            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2};
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>() {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 },
            };
            // Linq - uso do Where;
            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("TIER 1 AND PRICE < 900: ", r1);

            //Uso do Select;
            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS", r2);

            // Uso do [] para a localização do produto com o nome iniciando com 'C';
            //  Uso do CategoryName para apelidar o "Category.Name", visto que o vs studio não aceitaria 2 nomes iguais. 
            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new {p.Name, p.Price, CategoryName = p.Category.Name});
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);

            //Ordenar por preço e por nome;
            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

            //Usados em paginação, "Skip" - pula os 2 primeiros, "Take - pega os 4 seguintes"
            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

            // Expressao Lambda, usado quando tiver certeza que ele deve retornar ou um ou nenhum elemento
            var r6 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or default test1: " + r6);

            var r7 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("Single or default test2: " + r7);
        }
    }
}