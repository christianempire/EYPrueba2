using Prueba2.Models;
using System.Linq;

namespace Prueba2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SupermarketContext context)
        {
            context.Database.EnsureCreated();

            if (context.Items.Any())
            {
                return;
            }

            var items = new Item[]
            {
                new Item
                {
                    Code = "ART0001",
                    Name = "Detergente",
                    Description = "Descripción",
                    Quantity = 3
                },
                new Item
                {
                    Code = "ART0002",
                    Name = "Comida enlatada",
                    Description = "Descripción",
                    Quantity = 4
                },
                new Item
                {
                    Code = "ART0003",
                    Name = "Jabón",
                    Description = "Descripción",
                    Quantity = 5
                },
                new Item
                {
                    Code = "ART0004",
                    Name = "Shampoo",
                    Description = "Descripción",
                    Quantity = 1
                },
                new Item
                {
                    Code = "ART0005",
                    Name = "Gaseosa",
                    Description = "Descripción",
                    Quantity = 6
                },
                new Item
                {
                    Code = "ART0006",
                    Name = "Cereal",
                    Description = "Descripción",
                    Quantity = 7
                },
                new Item
                {
                    Code = "ART0007",
                    Name = "Arroz",
                    Description = "Descripción",
                    Quantity = 8
                },
                new Item
                {
                    Code = "ART0008",
                    Name = "Avena",
                    Description = "Descripción",
                    Quantity = 4
                },
                new Item
                {
                    Code = "ART0009",
                    Name = "Pan",
                    Description = "Descripción",
                    Quantity = 3
                },
                new Item
                {
                    Code = "ART0010",
                    Name = "Mantequilla",
                    Description = "Descripción",
                    Quantity = 1
                }
            };

            foreach (var item in items)
            {
                context.Items.Add(item);
            }

            context.SaveChanges();
        }
    }
}